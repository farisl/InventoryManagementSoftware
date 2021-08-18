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
    public partial class frmDepartment : Form
    {
        APIService inventoryService = new APIService("Inventory");
        APIService departmentService = new APIService("Department");
        private Department _department;

        public frmDepartment(Department department = null)
        {
            InitializeComponent();
            _department = department;
        }

        private async void frmDepartment_Load(object sender, EventArgs e)
        {
            await LoadInventories();
        }

        private async Task LoadInventories()
        {
            var list = await inventoryService.Get<List<Inventory>>();
            cmbInventories.DataSource = list;
            cmbInventories.DisplayMember = "Name";
            cmbInventories.DropDownStyle = ComboBoxStyle.DropDownList;

            if(_department != null)
            {
                txtName.Text = _department.Name;
                nudSize.Value = (decimal)_department.Size;

                foreach (var item in cmbInventories.Items)
                {
                    if (_department.InventoryId == (item as Inventory).Id)
                    {
                        cmbInventories.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateName())
            {

                DepartmentUpsertRequest request = new DepartmentUpsertRequest
                {
                    Name = txtName.Text,
                    InventoryId = (cmbInventories.SelectedItem as Inventory).Id,
                    Size = (float)nudSize.Value
                };

                if (_department != null)
                {
                    await departmentService.Update<Department>(_department.Id, request);
                    MessageBox.Show("Saved!");
                }
                else
                {
                    await departmentService.Insert<Department>(request);
                    MessageBox.Show("Item added!");
                }
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
