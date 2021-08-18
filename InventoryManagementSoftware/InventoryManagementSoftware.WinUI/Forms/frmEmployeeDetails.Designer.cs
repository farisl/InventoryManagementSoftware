
namespace InventoryManagementSoftware.WinUI.Forms
{
    partial class frmEmployeeDetails
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbInventories = new System.Windows.Forms.ComboBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtJmbg = new System.Windows.Forms.TextBox();
            this.lblJmbg = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblCity = new System.Windows.Forms.Label();
            this.cmbCities = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbGenders = new System.Windows.Forms.ComboBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.nudSalary = new System.Windows.Forms.NumericUpDown();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 507);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "Inventory";
            // 
            // cmbInventories
            // 
            this.cmbInventories.FormattingEnabled = true;
            this.cmbInventories.Location = new System.Drawing.Point(157, 504);
            this.cmbInventories.Name = "cmbInventories";
            this.cmbInventories.Size = new System.Drawing.Size(169, 28);
            this.cmbInventories.TabIndex = 41;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(157, 63);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(169, 27);
            this.txtFirstName.TabIndex = 40;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(62, 63);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(77, 20);
            this.lblFirstName.TabIndex = 39;
            this.lblFirstName.Text = "First name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(157, 112);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(169, 27);
            this.txtLastName.TabIndex = 44;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(62, 112);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(76, 20);
            this.lblLastName.TabIndex = 43;
            this.lblLastName.Text = "Last name";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(62, 159);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(57, 20);
            this.lblGender.TabIndex = 45;
            this.lblGender.Text = "Gender";
            // 
            // txtJmbg
            // 
            this.txtJmbg.Location = new System.Drawing.Point(157, 205);
            this.txtJmbg.Name = "txtJmbg";
            this.txtJmbg.Size = new System.Drawing.Size(169, 27);
            this.txtJmbg.TabIndex = 48;
            // 
            // lblJmbg
            // 
            this.lblJmbg.AutoSize = true;
            this.lblJmbg.Location = new System.Drawing.Point(62, 205);
            this.lblJmbg.Name = "lblJmbg";
            this.lblJmbg.Size = new System.Drawing.Size(45, 20);
            this.lblJmbg.TabIndex = 47;
            this.lblJmbg.Text = "Jmbg";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(62, 252);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(74, 20);
            this.lblBirthDate.TabIndex = 49;
            this.lblBirthDate.Text = "Birth date";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Location = new System.Drawing.Point(157, 252);
            this.dtpBirthDate.MinDate = new System.DateTime(1930, 1, 1, 0, 0, 0, 0);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(169, 27);
            this.dtpBirthDate.TabIndex = 50;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(62, 342);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(34, 20);
            this.lblCity.TabIndex = 52;
            this.lblCity.Text = "City";
            // 
            // cmbCities
            // 
            this.cmbCities.FormattingEnabled = true;
            this.cmbCities.Location = new System.Drawing.Point(157, 339);
            this.cmbCities.Name = "cmbCities";
            this.cmbCities.Size = new System.Drawing.Size(169, 28);
            this.cmbCities.TabIndex = 51;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(157, 295);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(169, 27);
            this.txtAddress.TabIndex = 54;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(62, 295);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(62, 20);
            this.lblAddress.TabIndex = 53;
            this.lblAddress.Text = "Address";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(62, 427);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(50, 20);
            this.lblPhone.TabIndex = 55;
            this.lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(157, 427);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(169, 27);
            this.txtPhone.TabIndex = 56;
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(62, 469);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(50, 20);
            this.lblActive.TabIndex = 57;
            this.lblActive.Text = "Active";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(233, 472);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(18, 17);
            this.cbActive.TabIndex = 58;
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(222, 680);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 33);
            this.btnSave.TabIndex = 59;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbGenders
            // 
            this.cmbGenders.FormattingEnabled = true;
            this.cmbGenders.Location = new System.Drawing.Point(157, 156);
            this.cmbGenders.Name = "cmbGenders";
            this.cmbGenders.Size = new System.Drawing.Size(169, 28);
            this.cmbGenders.TabIndex = 60;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(62, 603);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(49, 20);
            this.lblSalary.TabIndex = 61;
            this.lblSalary.Text = "Salary";
            // 
            // nudSalary
            // 
            this.nudSalary.DecimalPlaces = 2;
            this.nudSalary.Location = new System.Drawing.Point(157, 601);
            this.nudSalary.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSalary.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSalary.Name = "nudSalary";
            this.nudSalary.Size = new System.Drawing.Size(169, 27);
            this.nudSalary.TabIndex = 62;
            this.nudSalary.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.Location = new System.Drawing.Point(157, 554);
            this.dtpHireDate.MinDate = new System.DateTime(1930, 1, 1, 0, 0, 0, 0);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(169, 27);
            this.dtpHireDate.TabIndex = 64;
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Location = new System.Drawing.Point(62, 554);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(71, 20);
            this.lblHireDate.TabIndex = 63;
            this.lblHireDate.Text = "Hire date";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(157, 384);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(169, 27);
            this.txtEmail.TabIndex = 66;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(62, 384);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 20);
            this.lblEmail.TabIndex = 65;
            this.lblEmail.Text = "Email";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmEmployeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 764);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.dtpHireDate);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.nudSalary);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.cmbGenders);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.cmbCities);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.txtJmbg);
            this.Controls.Add(this.lblJmbg);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbInventories);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.MinimumSize = new System.Drawing.Size(431, 671);
            this.Name = "frmEmployeeDetails";
            this.Text = "frmEmployeeDetails";
            this.Load += new System.EventHandler(this.frmEmployeeDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbInventories;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtJmbg;
        private System.Windows.Forms.Label lblJmbg;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.ComboBox cmbCities;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbGenders;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.NumericUpDown nudSalary;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}