using InventoryManagementSoftware.Model;
using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSoftware.WinUI.Forms
{
    public partial class frmCity : Form
    {
        APIService countryService = new APIService("Country");
        APIService cityService = new APIService("City");

        public frmCity()
        {
            InitializeComponent();
        }

        private async void frmCity_Load(object sender, EventArgs e)
        {
            var countries = await countryService.Get<List<Country>>();
            cmbCountries.DataSource = countries;
            cmbCountries.DisplayMember = "Name";
            cmbCountries.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateName())
            {
                CityUpsertRequest request = new CityUpsertRequest
                {
                    Name = txtName.Text,
                    CountryId = (cmbCountries.SelectedItem as Country).Id
                };
                await cityService.Insert<City>(request);
                MessageBox.Show("City added!");
            }
            else
                MessageBox.Show("Please enter valid data!");
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

    }
}
