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
    public partial class frmProduct : Form
    {
        APIService productService = new APIService("Product");
        APIService categoryService = new APIService("Category");
        APIService brandService = new APIService("Brand");

        public frmProduct()
        {
            InitializeComponent();
            dgvProducts.AutoGenerateColumns = false;          
        }

        private async void frmProduct_Load(object sender, EventArgs e)
        {
            LoadTheme();
            await LoadData();
        }

        public async Task LoadData(ProductSearchObject request = null)
        {
            var list = await productService.Get<List<Product>>(request);

            dgvProducts.DataSource = list;
            dgvProducts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvProducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvProducts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            await LoadCategories();
            cmbBrands.Enabled = false;
            cmbBrands.DropDownStyle = ComboBoxStyle.DropDownList;

            nudFrom.Minimum = 0;
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label3.ForeColor = ThemeColor.SecondaryColor;
            label4.ForeColor = ThemeColor.SecondaryColor;
        }

        private async Task LoadCategories()
        {
            var categories = await categoryService.Get<List<Category>>();
            categories.Insert(0, new Category { Id = 0, Name = "----Select----" });
            cmbCategories.DataSource = categories;
            cmbCategories.DisplayMember = "Name";
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCategories.SelectedIndex != 0)
            {
                var selected = cmbCategories.SelectedItem as Category;
                BrandSearchObject search = new BrandSearchObject
                {
                    CategoryIds = new List<int> { selected.Id }
                };
                var brands = await brandService.Get<List<Brand>>(search);
                brands.Insert(0, new Brand
                {
                    Id = 0,
                    Name = "----Select----"
                });
                cmbBrands.Enabled = true;
                cmbBrands.DataSource = brands;
                cmbBrands.DisplayMember = "Name";
            }
            else
            {
                cmbBrands.Enabled = false;
                cmbBrands.DataSource = null;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            ProductSearchObject search = new ProductSearchObject { Name = txtName.Text };

            if (cmbCategories.SelectedIndex != 0)
                search.CategoryId = (cmbCategories.SelectedItem as Category).Id;
            else
                search.CategoryId = null;

            if (cmbBrands.SelectedIndex > 0)
                search.BrandId = (cmbBrands.SelectedItem as Brand).Id;
            else
                search.BrandId = null;

            if(nudTo.Value > 0)
            {
                search.PriceFrom = (double?)nudFrom.Value;
                search.PriceTo = (double?)nudTo.Value;
            }

            await LoadData(search);
        }

        private async void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvProducts.SelectedRows[0].DataBoundItem;

            frmProductDetails frm = new frmProductDetails(item as Product);
            frm.ShowDialog();
            await LoadData();
        }

        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmProductDetails frm = new frmProductDetails();
            frm.ShowDialog();
            await LoadData();
        }
    }
}
