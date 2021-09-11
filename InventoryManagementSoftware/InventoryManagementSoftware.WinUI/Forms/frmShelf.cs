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
    public partial class frmShelf : Form
    {
        APIService shelfService = new APIService("Shelf");

        Department _department;

        public frmShelf(Department department)
        {
            InitializeComponent();
            _department = department;
        }

        private void frmShelf_Load(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            List<Department> list = new List<Department> { _department };
            cmbDepartments.DataSource = list;
            cmbDepartments.DisplayMember = "DepartmentName";
            cmbDepartments.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartments.Enabled = false;
        }

        private async void btnAddDepartment_Click(object sender, EventArgs e)
        {
            if (ValidateText(txtName))
            {
                var shelves = await shelfService.Get<List<Shelf>>(new ShelfSearchObject
                {
                    DepartmentId = _department.Id
                });
                if (shelves.Select(x => x.RowNumber).ToList().Contains((int)nudRow.Value))
                    MessageBox.Show($"Shelf with row '{nudRow.Value}' already exists!");
                else
                {
                    ShelfInsertRequest request = new ShelfInsertRequest
                    {
                        Name = txtName.Text,
                        DepartmentId = _department.Id,
                        RowNumber = (int)nudRow.Value
                    };
                    await shelfService.Insert<Shelf>(request);
                    MessageBox.Show("Item added!");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid data!");
            }
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
