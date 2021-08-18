
namespace InventoryManagementSoftware.WinUI.Forms
{
    partial class frmProductDetails
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
            this.components = new System.ComponentModel.Container();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBrands = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvAttributes = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAttributes = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtAttributeName = new System.Windows.Forms.TextBox();
            this.lblAttributeName = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(191, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(169, 27);
            this.txtName.TabIndex = 8;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(92, 83);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 20);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(191, 126);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(169, 27);
            this.txtDescription.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Description";
            // 
            // cmbBrands
            // 
            this.cmbBrands.FormattingEnabled = true;
            this.cmbBrands.Location = new System.Drawing.Point(191, 220);
            this.cmbBrands.Name = "cmbBrands";
            this.cmbBrands.Size = new System.Drawing.Size(169, 28);
            this.cmbBrands.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Brand";
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(191, 174);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(169, 28);
            this.cmbCategories.TabIndex = 18;
            this.cmbCategories.SelectedIndexChanged += new System.EventHandler(this.cmbCategories_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Price";
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(191, 267);
            this.nudPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(169, 27);
            this.nudPrice.TabIndex = 23;
            this.nudPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(256, 323);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 33);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvAttributes
            // 
            this.dgvAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmName,
            this.clmValue});
            this.dgvAttributes.Location = new System.Drawing.Point(408, 80);
            this.dgvAttributes.Name = "dgvAttributes";
            this.dgvAttributes.RowHeadersWidth = 51;
            this.dgvAttributes.RowTemplate.Height = 29;
            this.dgvAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttributes.Size = new System.Drawing.Size(319, 287);
            this.dgvAttributes.TabIndex = 26;
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
            this.clmName.DataPropertyName = "AttributeName";
            this.clmName.HeaderText = "Name";
            this.clmName.MinimumWidth = 6;
            this.clmName.Name = "clmName";
            this.clmName.Width = 125;
            // 
            // clmValue
            // 
            this.clmValue.DataPropertyName = "Value";
            this.clmValue.HeaderText = "Value";
            this.clmValue.MinimumWidth = 6;
            this.clmValue.Name = "clmValue";
            this.clmValue.Width = 125;
            // 
            // lblAttributes
            // 
            this.lblAttributes.AutoSize = true;
            this.lblAttributes.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAttributes.Location = new System.Drawing.Point(408, 38);
            this.lblAttributes.Name = "lblAttributes";
            this.lblAttributes.Size = new System.Drawing.Size(123, 35);
            this.lblAttributes.TabIndex = 25;
            this.lblAttributes.Text = "Attributes";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(901, 174);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 28);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(623, 386);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 33);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(856, 129);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(138, 27);
            this.txtValue.TabIndex = 32;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(757, 132);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(45, 20);
            this.lblValue.TabIndex = 31;
            this.lblValue.Text = "Value";
            // 
            // txtAttributeName
            // 
            this.txtAttributeName.Location = new System.Drawing.Point(856, 83);
            this.txtAttributeName.Name = "txtAttributeName";
            this.txtAttributeName.Size = new System.Drawing.Size(138, 27);
            this.txtAttributeName.TabIndex = 30;
            // 
            // lblAttributeName
            // 
            this.lblAttributeName.AutoSize = true;
            this.lblAttributeName.Location = new System.Drawing.Point(757, 86);
            this.lblAttributeName.Name = "lblAttributeName";
            this.lblAttributeName.Size = new System.Drawing.Size(68, 20);
            this.lblAttributeName.TabIndex = 29;
            this.lblAttributeName.Text = "Attribute";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 453);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtAttributeName);
            this.Controls.Add(this.lblAttributeName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvAttributes);
            this.Controls.Add(this.lblAttributes);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbBrands);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.MinimumSize = new System.Drawing.Size(430, 453);
            this.Name = "frmProductDetails";
            this.Text = "frmProductDetails";
            this.Load += new System.EventHandler(this.frmProductDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBrands;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvAttributes;
        private System.Windows.Forms.Label lblAttributes;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtAttributeName;
        private System.Windows.Forms.Label lblAttributeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmValue;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}