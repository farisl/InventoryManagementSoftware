using InventoryManagementSoftware.Model;
using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSoftware.WinUI.Forms
{
    public partial class frmBrandDetails : Form
    {
        APIService brandService = new APIService("Brand");
        APIService categoryService = new APIService("Category");
        private Brand _brand;

        public frmBrandDetails(Brand brand = null)
        {
            InitializeComponent();
            _brand = brand;
        }

        private async Task LoadCategories()
        {
            var categories = await categoryService.Get<List<Category>>();
            clbCategories.DataSource = categories;
            clbCategories.DisplayMember = "Name";
        }

        private async void frmBrandDetails_Load(object sender, EventArgs e)
        {
            await LoadCategories();
            if (_brand != null)
            {
                txtName.Text = _brand.Name;
                for(int i = 0; i < clbCategories.Items.Count; i++)
                {
                    if (_brand.CategoriesBrands.Select(x => x.CategoryId).Contains((clbCategories.Items[i] as Category).Id))
                        clbCategories.SetItemChecked(i, true);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateName() || !ValidateCategories())
            {
                MessageBox.Show("Please enter valid data!");
            }
            else
            {
                BrandUpsertRequest request = new BrandUpsertRequest
                {
                    Name = txtName.Text,
                    CategoryIds = clbCategories.CheckedItems.Cast<Category>().Select(x => x.Id).ToList()
                };
                if (_brand == null)
                {
                    await brandService.Insert<Brand>(request);
                    MessageBox.Show("Item successfuly added!");
                }
                else
                {
                    await brandService.Update<Brand>(_brand.Id, request);
                    MessageBox.Show("Saved!");
                }
            }
        }

        private bool ValidateName()
        {
            bool status;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Focus();
                errorProvider.SetError(txtName, "Name is a required field!");
                status = false;
            }
            else
            {
                errorProvider.SetError(txtName, "");
                status = true;
            }
            return status;
        }

        private bool ValidateCategories()
        {
            bool status;
            if (clbCategories.CheckedItems.Count == 0)
            {
                clbCategories.Focus();
                errorProvider.SetError(clbCategories, "At least 1 category should be selected!");
                status = false;
            }
            else
            {
                errorProvider.SetError(clbCategories, "");
                status = true;
            }
            return status;
        }

    }
}
