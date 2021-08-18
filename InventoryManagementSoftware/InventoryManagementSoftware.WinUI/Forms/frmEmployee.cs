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
    public partial class frmEmployee : Form
    {
        APIService employeeService = new APIService("Employee");
        APIService inventoryService = new APIService("Inventory");

        public frmEmployee()
        {
            InitializeComponent();
            dgvEmployees.AutoGenerateColumns = false;
        }

        private async void frmEmployee_Load(object sender, EventArgs e)
        {
            await LoadInventories();
            await LoadEmployees();
        }

        private async Task LoadEmployees(EmployeeSearchObject search = null)
        {
            var list = await employeeService.Get<List<Employee>>(search);

            dgvEmployees.DataSource = list;
            dgvEmployees.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEmployees.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEmployees.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEmployees.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async Task LoadInventories()
        {
            var inventories = await inventoryService.Get<List<Inventory>>();

            cmbInventories.DataSource = inventories;
            cmbInventories.DisplayMember = "Name";
            cmbInventories.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            EmployeeSearchObject search = new EmployeeSearchObject
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                InventoryId = (cmbInventories.SelectedItem as Inventory).Id
            };

            await LoadEmployees(search);
        }

        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmEmployeeDetails frm = new frmEmployeeDetails();
            frm.ShowDialog();
            await LoadEmployees();
        }

        private async void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvEmployees.SelectedRows[0].DataBoundItem as Employee;

            frmEmployeeDetails frm = new frmEmployeeDetails(item);
            frm.ShowDialog();
            await LoadEmployees();
        }
    }
}
