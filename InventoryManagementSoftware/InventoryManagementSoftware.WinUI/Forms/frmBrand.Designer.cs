
namespace InventoryManagementSoftware.WinUI.Forms
{
    partial class frmBrand
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
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvBrands = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCategories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clbCategories = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addCategory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrands)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Location = new System.Drawing.Point(849, 468);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(104, 33);
            this.btnDetails.TabIndex = 0;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBrand.Location = new System.Drawing.Point(730, 468);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(104, 33);
            this.btnAddBrand.TabIndex = 1;
            this.btnAddBrand.Text = "Add";
            this.btnAddBrand.UseVisualStyleBackColor = true;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(164, 366);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 33);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(31, 69);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 20);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(99, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(169, 27);
            this.txtName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(413, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 35);
            this.label3.TabIndex = 7;
            this.label3.Text = "Brands";
            // 
            // dgvBrands
            // 
            this.dgvBrands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBrands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmName,
            this.clmCategories});
            this.dgvBrands.Location = new System.Drawing.Point(413, 66);
            this.dgvBrands.Name = "dgvBrands";
            this.dgvBrands.RowHeadersWidth = 51;
            this.dgvBrands.RowTemplate.Height = 29;
            this.dgvBrands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBrands.Size = new System.Drawing.Size(540, 384);
            this.dgvBrands.TabIndex = 8;
            this.dgvBrands.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBrands_CellDoubleClick);
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
            // clmCategories
            // 
            this.clmCategories.DataPropertyName = "Categories";
            this.clmCategories.HeaderText = "Categories";
            this.clmCategories.MinimumWidth = 6;
            this.clmCategories.Name = "clmCategories";
            this.clmCategories.Width = 125;
            // 
            // clbCategories
            // 
            this.clbCategories.FormattingEnabled = true;
            this.clbCategories.Location = new System.Drawing.Point(99, 160);
            this.clbCategories.Name = "clbCategories";
            this.clbCategories.Size = new System.Drawing.Size(169, 180);
            this.clbCategories.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(31, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 35);
            this.label1.TabIndex = 10;
            this.label1.Text = "Categories";
            // 
            // addCategory
            // 
            this.addCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCategory.Location = new System.Drawing.Point(170, 110);
            this.addCategory.Name = "addCategory";
            this.addCategory.Size = new System.Drawing.Size(56, 35);
            this.addCategory.TabIndex = 11;
            this.addCategory.Text = "Add";
            this.addCategory.UseVisualStyleBackColor = true;
            this.addCategory.Click += new System.EventHandler(this.addCategory_Click);
            // 
            // frmBrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 536);
            this.Controls.Add(this.addCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clbCategories);
            this.Controls.Add(this.dgvBrands);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddBrand);
            this.Controls.Add(this.btnDetails);
            this.Name = "frmBrand";
            this.Text = "Brands";
            this.Load += new System.EventHandler(this.frmBrand_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrands)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnAddBrand;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvBrands;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCategories;
        private System.Windows.Forms.CheckedListBox clbCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addCategory;
    }
}