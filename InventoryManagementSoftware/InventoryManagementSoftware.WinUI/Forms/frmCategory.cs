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
    public partial class frmCategory : Form
    {
        APIService categoryService = new APIService("Category");

        public frmCategory()
        {
            InitializeComponent();
        }

        private async void addCategory_Click(object sender, EventArgs e)
        {
            if (ValidateName())
            {
                BaseUpsertRequest request = new BaseUpsertRequest { Name = txtName.Text };

                await categoryService.Insert<Category>(request);
                MessageBox.Show("Category added!");
            }
            else
            {
                MessageBox.Show("Please enter valid data!");
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

    }
}
