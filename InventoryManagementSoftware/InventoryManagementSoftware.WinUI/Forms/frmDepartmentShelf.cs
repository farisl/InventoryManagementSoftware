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
    public partial class frmDepartmentShelf : Form
    {
        APIService departmentService = new APIService("Department");
        APIService inventoryService = new APIService("Inventory");
        APIService shelfService = new APIService("Shelf");

        public frmDepartmentShelf()
        {
            InitializeComponent();
            dgvDepartments.AutoGenerateColumns = false;
        }

        private async void frmDepartmentShelf_Load(object sender, EventArgs e)
        {
            LoadTheme();
            await LoadData();
        }

        private async Task LoadData()
        {
            await LoadInventories();
            await LoadDepartments();
            await LoadShelves();
        }

        private async Task LoadDepartments()
        {
            int inventoryId = (cmbInventories.SelectedItem as Inventory).Id;

            DepartmentSearchObject search = new DepartmentSearchObject { InventoryId = inventoryId };
            var list = await departmentService.Get<List<Department>>(search);
            dgvDepartments.DataSource = list;
            dgvDepartments.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDepartments.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDepartments.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var departments = await departmentService.Get<List<Department>>();
            cmbDepartments.DataSource = departments;
            cmbDepartments.DisplayMember = "DepartmentName";
            cmbDepartments.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async Task LoadShelves()
        {           
            int departmentId = (cmbDepartments.SelectedItem as Department).Id;
            ShelfSearchObject search = new ShelfSearchObject { DepartmentId = departmentId };
            var list = await shelfService.Get<List<Shelf>>(search);
            dgvShelves.DataSource = list;
            dgvShelves.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvShelves.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvShelves.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvShelves.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async Task LoadInventories()
        {
            var list = await inventoryService.Get<List<Inventory>>();
            cmbInventories.DataSource = list;
            cmbInventories.DisplayMember = "Name";
            cmbInventories.DropDownStyle = ComboBoxStyle.DropDownList;
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
            //label3.ForeColor = ThemeColor.SecondaryColor;
            label1.ForeColor = ThemeColor.SecondaryColor;
        }

        private async void cmbInventories_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDepartments();
        }

        private async void dgvDepartments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvDepartments.SelectedRows[0].DataBoundItem;

            frmDepartment frm = new frmDepartment(item as Department);
            frm.ShowDialog();
            await LoadData();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var item = cmbInventories.SelectedItem as Inventory;
            frmDepartment frm = new frmDepartment(null, item.Id);
            frm.ShowDialog();
            await LoadData();
        }

        private async void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadShelves();
        }

        private async void addShelf_Click(object sender, EventArgs e)
        {
            if (cmbDepartments.Items.Count > 0)
            {
                var item = cmbDepartments.SelectedItem as Department;
                frmShelf frm = new frmShelf(item);
                frm.ShowDialog();
                await LoadShelves();
            }
        }

        private async void dgvShelves_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvShelves.SelectedRows[0].DataBoundItem as Shelf;

            frmShelfProduct frm = new frmShelfProduct(item.Id);
            frm.ShowDialog();
            await LoadShelves();
        }
    }
}
