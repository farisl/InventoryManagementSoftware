using Flurl.Http;
using InventoryManagementSoftware.Model;
using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Security;
using InventoryManagementSoftware.Services;
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
    public partial class frmBrand : Form
    {
        APIService brandService = new APIService("Brand");
        APIService categoryService = new APIService("Category");

        public frmBrand()
        {
            InitializeComponent();
            dgvBrands.AutoGenerateColumns = false;
        }

        private async Task LoadData(BrandUpsertRequest request = null)
        {
            var list = await brandService.Get<List<Brand>>(request);

            dgvBrands.DataSource = list;
            dgvBrands.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBrands.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBrands.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var categories = await categoryService.Get<List<Category>>();
            clbCategories.DataSource = categories;
            clbCategories.DisplayMember = "Name";
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
            label1.ForeColor = ThemeColor.SecondaryColor;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            BrandUpsertRequest request = new BrandUpsertRequest
            {
                Name = txtName.Text
            };
            foreach(var item in clbCategories.CheckedItems)
            {
                request.CategoryIds.Add((item as Category).Id);
            }

            await LoadData(request);
        }

        private async void btnAddBrand_Click(object sender, EventArgs e)
        {
            frmBrandDetails frm = new frmBrandDetails();
            frm.ShowDialog();
            await LoadData();
        }

        private async void frmBrand_Load(object sender, EventArgs e)
        {
            LoadTheme();
            await LoadData();
        }

        private async void addCategory_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            frm.ShowDialog();
            await LoadData();
        }
    }
}
