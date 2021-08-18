
namespace InventoryManagementSoftware.WinUI.Forms
{
    partial class frmDepartmentShelf
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbInventories = new System.Windows.Forms.ComboBox();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddDepartment = new System.Windows.Forms.Button();
            this.addShelf = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDepartments = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvShelves = new System.Windows.Forms.DataGridView();
            this.clmShelfId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShelfName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductShelves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShelves)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(52, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 35);
            this.label1.TabIndex = 11;
            this.label1.Text = "Departments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Inventory";
            // 
            // cmbInventories
            // 
            this.cmbInventories.FormattingEnabled = true;
            this.cmbInventories.Location = new System.Drawing.Point(145, 121);
            this.cmbInventories.Name = "cmbInventories";
            this.cmbInventories.Size = new System.Drawing.Size(169, 28);
            this.cmbInventories.TabIndex = 25;
            this.cmbInventories.SelectedIndexChanged += new System.EventHandler(this.cmbInventories_SelectedIndexChanged);
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmName,
            this.cmbSize});
            this.dgvDepartments.Location = new System.Drawing.Point(60, 176);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.RowHeadersWidth = 51;
            this.dgvDepartments.RowTemplate.Height = 29;
            this.dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartments.Size = new System.Drawing.Size(305, 273);
            this.dgvDepartments.TabIndex = 27;
            this.dgvDepartments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartments_CellDoubleClick);
            // 
            // clmId
            // 
            this.clmId.DataPropertyName = "Id";
            this.clmId.HeaderText = "Id";
            this.clmId.MinimumWidth = 6;
            this.clmId.Name = "clmId";
            this.clmId.Visible = false;
            this.clmId.Width = 125;
            // 
            // clmName
            // 
            this.clmName.DataPropertyName = "Name";
            this.clmName.HeaderText = "Name";
            this.clmName.MinimumWidth = 6;
            this.clmName.Name = "clmName";
            this.clmName.Width = 125;
            // 
            // cmbSize
            // 
            this.cmbSize.DataPropertyName = "DepartmentSize";
            this.cmbSize.HeaderText = "Size";
            this.cmbSize.MinimumWidth = 6;
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Width = 125;
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDepartment.Location = new System.Drawing.Point(261, 474);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(104, 33);
            this.btnAddDepartment.TabIndex = 31;
            this.btnAddDepartment.Text = "Add";
            this.btnAddDepartment.UseVisualStyleBackColor = true;
            this.btnAddDepartment.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // addShelf
            // 
            this.addShelf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addShelf.Location = new System.Drawing.Point(785, 474);
            this.addShelf.Name = "addShelf";
            this.addShelf.Size = new System.Drawing.Size(104, 33);
            this.addShelf.TabIndex = 36;
            this.addShelf.Text = "Add";
            this.addShelf.UseVisualStyleBackColor = true;
            this.addShelf.Click += new System.EventHandler(this.addShelf_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Department";
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Location = new System.Drawing.Point(625, 121);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(169, 28);
            this.cmbDepartments.TabIndex = 33;
            this.cmbDepartments.SelectedIndexChanged += new System.EventHandler(this.cmbDepartments_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(509, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 35);
            this.label4.TabIndex = 32;
            this.label4.Text = "Shelves";
            // 
            // dgvShelves
            // 
            this.dgvShelves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShelves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmShelfId,
            this.clmShelfName,
            this.clmRowNumber,
            this.clmProductsCount,
            this.clmDepartmentId,
            this.clmProductShelves});
            this.dgvShelves.Location = new System.Drawing.Point(517, 176);
            this.dgvShelves.Name = "dgvShelves";
            this.dgvShelves.RowHeadersWidth = 51;
            this.dgvShelves.RowTemplate.Height = 29;
            this.dgvShelves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShelves.Size = new System.Drawing.Size(372, 279);
            this.dgvShelves.TabIndex = 37;
            this.dgvShelves.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShelves_CellDoubleClick);
            // 
            // clmShelfId
            // 
            this.clmShelfId.DataPropertyName = "Id";
            this.clmShelfId.HeaderText = "Id";
            this.clmShelfId.MinimumWidth = 6;
            this.clmShelfId.Name = "clmShelfId";
            this.clmShelfId.Visible = false;
            this.clmShelfId.Width = 125;
            // 
            // clmShelfName
            // 
            this.clmShelfName.DataPropertyName = "Name";
            this.clmShelfName.HeaderText = "Name";
            this.clmShelfName.MinimumWidth = 6;
            this.clmShelfName.Name = "clmShelfName";
            this.clmShelfName.Width = 125;
            // 
            // clmRowNumber
            // 
            this.clmRowNumber.DataPropertyName = "RowNumber";
            this.clmRowNumber.HeaderText = "Row";
            this.clmRowNumber.MinimumWidth = 6;
            this.clmRowNumber.Name = "clmRowNumber";
            this.clmRowNumber.Width = 125;
            // 
            // clmProductsCount
            // 
            this.clmProductsCount.DataPropertyName = "ProductsCount";
            this.clmProductsCount.HeaderText = "Products";
            this.clmProductsCount.MinimumWidth = 6;
            this.clmProductsCount.Name = "clmProductsCount";
            this.clmProductsCount.Width = 125;
            // 
            // clmDepartmentId
            // 
            this.clmDepartmentId.DataPropertyName = "DepartmentId";
            this.clmDepartmentId.HeaderText = "DepartmentId";
            this.clmDepartmentId.MinimumWidth = 6;
            this.clmDepartmentId.Name = "clmDepartmentId";
            this.clmDepartmentId.Visible = false;
            this.clmDepartmentId.Width = 125;
            // 
            // clmProductShelves
            // 
            this.clmProductShelves.DataPropertyName = "ProductShelves";
            this.clmProductShelves.HeaderText = "ProductShelves";
            this.clmProductShelves.MinimumWidth = 6;
            this.clmProductShelves.Name = "clmProductShelves";
            this.clmProductShelves.Visible = false;
            this.clmProductShelves.Width = 125;
            // 
            // frmDepartmentShelf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 536);
            this.Controls.Add(this.dgvShelves);
            this.Controls.Add(this.addShelf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDepartments);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddDepartment);
            this.Controls.Add(this.dgvDepartments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbInventories);
            this.Controls.Add(this.label1);
            this.Name = "frmDepartmentShelf";
            this.Text = "frmDepartmentShelf";
            this.Load += new System.EventHandler(this.frmDepartmentShelf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShelves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbInventories;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmbSize;
        private System.Windows.Forms.Button btnAddDepartment;
        private System.Windows.Forms.Button addShelf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvShelves;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShelfId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShelfName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductShelves;
    }
}