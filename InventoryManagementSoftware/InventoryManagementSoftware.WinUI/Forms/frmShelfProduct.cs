using InventoryManagementSoftware.Model;
using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSoftware.WinUI.Forms
{
    public partial class frmShelfProduct : Form
    {
        APIService productShelfService = new APIService("ProductShelf");
        APIService productService = new APIService("Product");
        private int _shelfId;
        private ProductShelf _productShelf = null;

        public frmShelfProduct(int shelfId)
        {
            InitializeComponent();
            dgvProducts.AutoGenerateColumns = false;
            _shelfId = shelfId;
        }

        private async void frmShelfProduct_Load(object sender, EventArgs e)
        {
            await LoadProductShelves();
            await LoadProducts();
        }

        private async Task LoadProductShelves()
        {
            var products = await productShelfService.Get<List<ProductShelf>>(new ProductShelfSearchObject
            {
                ShelfId = _shelfId
            });

            dgvProducts.DataSource = products;
            dgvProducts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvProducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProducts.Columns[1].Visible = false;
            //dgvProducts.Columns[3].Visible = false;
            //dgvProducts.Columns[4].Visible = false;

            nudQuantity.Value = 1;
        }

        private async Task LoadProducts()
        {
            var list = await productService.Get<List<Product>>();

            cmbProducts.DataSource = list;
            cmbProducts.DisplayMember = "Name";
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductShelfUpsertRequest request = new ProductShelfUpsertRequest
            {
                ShelfId = _shelfId,
                ProductId = (cmbProducts.SelectedItem as Product).Id,
                Quantity = (double)nudQuantity.Value
            };

            var list = await productShelfService.Get<List<ProductShelf>>(new ProductShelfSearchObject
            {
                ShelfId = _shelfId,
                ProductId = (cmbProducts.SelectedItem as Product).Id
            });
            if (list == null || list.Count == 0)
                await productShelfService.Insert<ProductShelf>(request);
            else
                await productShelfService.Update<ProductShelf>(list[0].Id, request);

            await LoadProductShelves();
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _productShelf = dgvProducts.SelectedRows[0].DataBoundItem as ProductShelf;
            foreach(var item in cmbProducts.Items)
            {
                if((item as Product).Id == _productShelf.ProductId)
                {
                    cmbProducts.SelectedItem = item;
                    break;
                }
            }
            nudQuantity.Value = _productShelf.Quantity;
        }

        private void cmbProducts_SelectedValueChanged(object sender, EventArgs e)
        {
            nudQuantity.Value = 1;
            _productShelf = null;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var item = dgvProducts.SelectedRows[0].DataBoundItem as ProductShelf;

            await productShelfService.Delete<List<ProductShelf>>(item.Id);
            await LoadProductShelves();
        }
    }
}
