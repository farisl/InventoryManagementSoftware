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
    public partial class frmInventory : Form
    {
        APIService inventoryService = new APIService("Inventory");
        APIService cityService = new APIService("City");

        public frmInventory()
        {
            InitializeComponent();
            dgvInventories.AutoGenerateColumns = false;
        }

        private async void frmInventory_Load(object sender, EventArgs e)
        {
            await LoadData();
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
            //label4.ForeColor = ThemeColor.SecondaryColor;
        }

        private async Task LoadData(InventorySearchObject search = null)
        {
            var list = await inventoryService.Get<List<Inventory>>(search);

            dgvInventories.DataSource = list;
            dgvInventories.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvInventories.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvInventories.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvInventories.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            await LoadCities();
        }

        private async Task LoadCities()
        {
            var cities = await cityService.Get<List<City>>();
            cities.Insert(0, new City
            {
                Id = 0,
                Name = "----Select----",
                CountryId = 0
            });
            cmbCities.DataSource = cities;
            cmbCities.DisplayMember = "Name";
            cmbCities.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            InventorySearchObject search = new InventorySearchObject { Name = txtName.Text };

            if (cmbCities.SelectedIndex > 0)
                search.CityId = (cmbCities.SelectedItem as City).Id;

            if(nudTo.Value > 0)
            {
                search.SizeFrom = (float?)nudFrom.Value;
                search.SizeTo = (float?)nudTo.Value;
            }

            await LoadData(search);
        }

        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmInventoryDetails frm = new frmInventoryDetails();
            frm.ShowDialog();
            await LoadData();
        }

        private async void dgvInventories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvInventories.SelectedRows[0].DataBoundItem;

            frmInventoryDetails frm = new frmInventoryDetails(item as Inventory);
            frm.ShowDialog();
            await LoadData();
        }
    }
}
