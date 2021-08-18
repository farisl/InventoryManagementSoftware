using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSoftware.WinUI.Forms
{
    public partial class frmLogin : Form
    {
        APIService authService = new APIService("AuthManagement/Login");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateEmail() && ValidatePassword())
            {
                try
                {
                    var authResult = await Authenticate();
                    var parentForm = ParentForm as frmMainMenu;
                    parentForm.EnableButtons();

                    this.Close();
                }
                catch
                {
                    var parentForm = ParentForm as frmMainMenu;
                    parentForm.DisableButtons();
                    MessageBox.Show("Incorrect username or password!");
                }
            }
            else
                MessageBox.Show("Please enter valid inputs!");
        }

        private async Task<AuthResult> Authenticate()
        {
            UserLoginRequest request = new UserLoginRequest
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            var authResult = await authService.Insert<AuthResult>(request);
            APIService.Token = $"Bearer {authResult.Token}";
            return authResult;
        }

        private bool ValidatePassword()
        {
            bool status;
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Focus();
                errorProvider.SetError(txtPassword, "This is a required field!");
                status = false;
            }
            else
            {
                errorProvider.SetError(txtPassword, "");
                status = true;
            }
            return status;
        }

        private bool ValidateEmail()
        {
            bool status;
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Focus();
                errorProvider.SetError(txtEmail, "This is a required field!");
                status = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                txtEmail.Focus();
                errorProvider.SetError(txtEmail, "Enter a valid email format!");
                status = false;
            }
            else
            {
                errorProvider.SetError(txtEmail, "");
                status = true;
            }
            return status;
        }

    }
}
