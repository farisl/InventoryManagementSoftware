using InventoryManagementSoftware.Model;
using InventoryManagementSoftware.Model.Requests;
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
    public partial class frmEmployeeDetails : Form
    {
        APIService cityService = new APIService("City");
        APIService genderService = new APIService("Gender");
        APIService inventoryService = new APIService("Inventory");
        APIService employeeyService = new APIService("Employee");
        private Employee _employee;

        public frmEmployeeDetails(Employee employee = null)
        {
            InitializeComponent();
            _employee = employee;
        }

        private async void frmEmployeeDetails_Load(object sender, EventArgs e)
        {
            await LoadGenders();
            await LoadCities();
            await LoadInventories();
            cbActive.Checked = true;
            if(_employee != null)
            {
                txtFirstName.Text = _employee.FirstName;
                txtLastName.Text = _employee.LastName;
                txtAddress.Text = _employee.Address.Name;
                txtEmail.Text = _employee.Email;
                txtJmbg.Text = _employee.Jmbg;
                txtPhone.Text = _employee.PhoneNumber;
                dtpBirthDate.Value = _employee.BirthDate;
                dtpHireDate.Value = (DateTime)_employee.HireDate;
                cmbCities.SelectedItem = _employee.Address.City;
                cmbGenders.SelectedItem = _employee.Gender;
                cbActive.Checked = _employee.Active;
                if(_employee.Salary != null)
                    nudSalary.Value = (decimal)_employee.Salary;
                if (_employee.ActiveInventory == null)
                    cmbInventories.SelectedIndex = 0;
                else
                {
                    foreach(var item in cmbInventories.Items)
                    {
                        if ((item as Inventory).Id == _employee.ActiveInventory.Id)
                        {
                            cmbInventories.SelectedItem = item;
                            break;
                        }                        
                    }
                }
                foreach (var item in cmbCities.Items)
                {
                    if ((item as City).Id == _employee.Address.CityId)
                    {
                        cmbCities.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private async Task LoadGenders()
        {
            cmbGenders.DataSource = await genderService.Get<List<Gender>>();
            cmbGenders.DisplayMember = "Name";
            cmbGenders.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async Task LoadCities()
        {
            cmbCities.DataSource = await cityService.Get<List<City>>();
            cmbCities.DisplayMember = "Name";
            cmbCities.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async Task LoadInventories()
        {
            var inventories = await inventoryService.Get<List<Inventory>>();
            inventories.Insert(0, new Inventory
            {
                Id = 0,
                AddressId = 0,
                Name = "----Select----",
                Size = 0
            });
            cmbInventories.DataSource = inventories;
            cmbInventories.DisplayMember = "Name";
            cmbInventories.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateText(txtFirstName) && ValidateText(txtLastName) && ValidateText(txtAddress)
                && ValidateEmail() && ValidateJmbg())
            {
                if (_employee == null)
                {
                    EmployeeInsertRequest request = new EmployeeInsertRequest
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        GenderId = (cmbGenders.SelectedItem as Gender).Id,
                        AddressName = txtAddress.Text,
                        CityId = (cmbCities.SelectedItem as City).Id,
                        Active = cbActive.Checked,
                        BirthDate = dtpBirthDate.Value,
                        PhoneNumber = txtPhone.Text,
                        Jmbg = txtJmbg.Text,
                        Salary = (double?)nudSalary.Value,
                        Email = txtEmail.Text
                    };
                    if ((cmbInventories.SelectedItem as Inventory).Id > 0)
                    {
                        request.InventoryId = (cmbInventories.SelectedItem as Inventory).Id;
                        request.HireDate = dtpHireDate.Value;
                    }

                    await employeeyService.Insert<Employee>(request);
                    MessageBox.Show("Employee added!");
                }
                else
                {
                    EmployeeUpdateRequest request = new EmployeeUpdateRequest
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        GenderId = (cmbGenders.SelectedItem as Gender).Id,
                        AddressName = txtAddress.Text,
                        CityId = (cmbCities.SelectedItem as City).Id,
                        Active = cbActive.Checked,
                        BirthDate = dtpBirthDate.Value,
                        PhoneNumber = txtPhone.Text,
                        Jmbg = txtJmbg.Text,
                        Salary = (double?)nudSalary.Value,
                        Email = txtEmail.Text
                    };
                    if ((cmbInventories.SelectedItem as Inventory).Id > 0)
                    {
                        request.InventoryId = (cmbInventories.SelectedItem as Inventory).Id;
                        request.HireDate = dtpHireDate.Value;
                    }

                    await employeeyService.Update<Employee>(_employee.Id, request);
                    MessageBox.Show("Saved!");
                }
            }
            else
                MessageBox.Show("Please enter valid data!");
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

        private bool ValidateJmbg()
        {
            bool status;
            if (string.IsNullOrWhiteSpace(txtJmbg.Text))
            {
                txtJmbg.Focus();
                errorProvider.SetError(txtJmbg, "This is a required field!");
                status = false;
            }
            else if (txtJmbg.Text.Length != 13 || !Regex.IsMatch(txtJmbg.Text, @"^\d+$"))
            {
                txtJmbg.Focus();
                errorProvider.SetError(txtJmbg, "Enter a valid JMBG format!");
                status = false;
            }
            else
            {
                errorProvider.SetError(txtJmbg, "");
                status = true;
            }
            return status;
        }

    }
}
