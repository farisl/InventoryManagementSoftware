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
    public partial class frmProductDetails : Form
    {
        APIService brandService = new APIService("Brand");
        APIService categoryService = new APIService("Category");
        APIService productService = new APIService("Product");
        APIService productAttribueService = new APIService("ProductAttribute");
        private Product _product;

        public frmProductDetails(Product product = null)
        {
            InitializeComponent();
            _product = product;
            dgvAttributes.AutoGenerateColumns = false;

            if(_product == null)
            {
                lblAttributes.Visible = false;
                dgvAttributes.Visible = false;
                txtAttributeName.Visible = false;
                txtValue.Visible = false;
                lblAttributeName.Visible = false;
                lblValue.Visible = false;
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                this.Width = 430;
                this.Height = 453;
            }
            
        }

        private async void frmProductDetails_Load(object sender, EventArgs e)
        {
            await LoadCategories();
            cmbBrands.Enabled = false;
            cmbBrands.DropDownStyle = ComboBoxStyle.DropDownList;

            if (_product != null)
            {
                await LoadAttributes();

                txtName.Text = _product.Name;
                txtDescription.Text = _product.Description;

                foreach(var item in cmbCategories.Items)
                {
                    if((item as Category).Id == _product.CategoryBrand.CategoryId)
                    {
                        cmbCategories.SelectedItem = item;
                        break;
                    }
                }

                await LoadBrands();
                foreach (var item in cmbBrands.Items)
                {
                    if ((item as Brand).Id == _product.CategoryBrand.BrandId)
                    {
                        cmbBrands.SelectedItem = item;
                        break;
                    }
                }

                nudPrice.Value = (decimal)_product.PriceValue;
            }
        }

        private async Task LoadCategories()
        {
            var categories = await categoryService.Get<List<Category>>();
            //categories.Insert(0, new Category { Id = 0, Name = "----Select----" });
            cmbCategories.DataSource = categories;
            cmbCategories.DisplayMember = "Name";
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategories.SelectedText = "----Select----";
        }

        private async Task LoadBrands()
        {
            BrandSearchObject search = new BrandSearchObject
            {
                CategoryIds = new List<int> { (cmbCategories.SelectedItem as Category).Id }
            };
            var brands = await brandService.Get<List<Brand>>(search);
            cmbBrands.Enabled = true;
            cmbBrands.DataSource = brands;
            cmbBrands.DisplayMember = "Name";
        }

        private async Task LoadAttributes()
        {
            var list = await productAttribueService.Get<List<ProductAttribute>>(new ProductAttributeSearchObject
            {
                ProductId = _product.Id
            });

            dgvAttributes.DataSource = list;
            dgvAttributes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAttributes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAttributes.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadBrands();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateText(txtName) && ValidateText(txtDescription))
            {
                ProductUpsertRequest request = new ProductUpsertRequest
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    CategoryId = (cmbCategories.SelectedItem as Category).Id,
                    BrandId = (cmbBrands.SelectedItem as Brand).Id,
                    Price = (double)nudPrice.Value
                };
                if (_product == null)
                {
                    await productService.Insert<Product>(request);
                    MessageBox.Show("Item successfuly added!");
                }
                else
                {
                    await productService.Update<Product>(_product.Id, request);
                    MessageBox.Show("Saved!");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid data!");
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateText(txtAttributeName) && ValidateText(txtValue))
            {
                ProductAttributeUpsertRequest request = new ProductAttributeUpsertRequest
                {
                    ProductId = _product.Id,
                    AttributeName = txtAttributeName.Text,
                    Value = txtValue.Text
                };
                await productAttribueService.Insert<ProductAttribute>(request);

                await LoadAttributes();
            }
            else
                MessageBox.Show("Please enter valid data!");
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int id = (dgvAttributes.SelectedRows[0].DataBoundItem as ProductAttribute).Id;

            await productAttribueService.Delete<List<ProductAttribute>>(id);

            await LoadAttributes();
        }

        private bool ValidateText(TextBox textBox)
        {
            bool status;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Focus();
                errorProvider.SetError(textBox, "This is a required field!");
                status = false;
            }
            else
            {
                errorProvider.SetError(textBox, "");
                status = true;
            }
            return status;
        }

    }
}
