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
    public partial class frmInventoryDetails : Form
    {
        APIService inventoryService = new APIService("Inventory");
        APIService cityService = new APIService("City");

        private Inventory _inventory;

        public frmInventoryDetails(Inventory inventory = null)
        {
            InitializeComponent();
            _inventory = inventory;

            if (_inventory == null)
                this.Text = "Add inventory";
            else
                this.Text = _inventory.Name;
        }

        private async void frmInventoryDetails_Load(object sender, EventArgs e)
        {
            await LoadCities();
        }

        private async Task LoadCities()
        {
            var cities = await cityService.Get<List<City>>();
            cmbCities.DataSource = cities;
            cmbCities.DisplayMember = "Name";
            cmbCities.DropDownStyle = ComboBoxStyle.DropDownList;
            if(_inventory != null)
            {
                foreach(var item in cmbCities.Items)
                {
                    if (_inventory.Address.CityId == (item as City).Id)
                        cmbCities.SelectedItem = item;
                }

                txtName.Text = _inventory.Name;
                txtAddress.Text = _inventory.Address.Name;
                txtPhone.Text = _inventory.PhoneNumber;
                nudSize.Value = (decimal)_inventory.Size;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateText(txtName) && ValidateText(txtPhone) && ValidateText(txtAddress))
            {
                InventoryUpsertRequest request = new InventoryUpsertRequest
                {
                    Name = txtName.Text,
                    AddressName = txtAddress.Text,
                    CityId = (cmbCities.SelectedItem as City).Id,
                    PhoneNumber = txtPhone.Text,
                    Size = (float)nudSize.Value
                };

                if (_inventory == null)
                {
                    await inventoryService.Insert<Inventory>(request);
                    MessageBox.Show("Item added!");
                }
                else
                {
                    await inventoryService.Update<Inventory>(_inventory.Id, request);
                    MessageBox.Show("Saved!");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid data!");
            }
        }

        private async void addCity_Click(object sender, EventArgs e)
        {
            frmCity frm = new frmCity();
            frm.ShowDialog();
            await LoadCities();
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
