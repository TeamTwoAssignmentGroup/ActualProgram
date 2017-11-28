namespace Mockup2
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.adminTabs = new System.Windows.Forms.TabControl();
            this.rotaTab = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Rota_StaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rota_FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rota_LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Staff_JobRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffTab = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.removeStaffButton = new System.Windows.Forms.Button();
            this.editStaffButton = new System.Windows.Forms.Button();
            this.addStaffButton = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.StaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.systemTab = new System.Windows.Forms.TabPage();
            this.reportBug = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.adminTabs.SuspendLayout();
            this.rotaTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.staffTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.systemTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // adminTabs
            // 
            this.adminTabs.Controls.Add(this.rotaTab);
            this.adminTabs.Controls.Add(this.staffTab);
            this.adminTabs.Controls.Add(this.systemTab);
            this.adminTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminTabs.HotTrack = true;
            this.adminTabs.Location = new System.Drawing.Point(0, 0);
            this.adminTabs.Margin = new System.Windows.Forms.Padding(4);
            this.adminTabs.Name = "adminTabs";
            this.adminTabs.SelectedIndex = 0;
            this.adminTabs.Size = new System.Drawing.Size(1344, 897);
            this.adminTabs.TabIndex = 0;
            // 
            // rotaTab
            // 
            this.rotaTab.Controls.Add(this.button4);
            this.rotaTab.Controls.Add(this.button3);
            this.rotaTab.Controls.Add(this.dataGridView1);
            this.rotaTab.Location = new System.Drawing.Point(4, 49);
            this.rotaTab.Margin = new System.Windows.Forms.Padding(4);
            this.rotaTab.Name = "rotaTab";
            this.rotaTab.Padding = new System.Windows.Forms.Padding(4);
            this.rotaTab.Size = new System.Drawing.Size(1336, 844);
            this.rotaTab.TabIndex = 0;
            this.rotaTab.Text = "Rota";
            this.rotaTab.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(1119, 767);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(204, 64);
            this.button4.TabIndex = 2;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(11, 767);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(199, 64);
            this.button3.TabIndex = 1;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rota_StaffID,
            this.Rota_FirstName,
            this.Rota_LastName,
            this.Staff_JobRole,
            this.Monday,
            this.Tuesday,
            this.Wednesday,
            this.Thursday,
            this.Friday,
            this.Saturday,
            this.Sunday});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1328, 750);
            this.dataGridView1.TabIndex = 0;
            // 
            // Rota_StaffID
            // 
            this.Rota_StaffID.HeaderText = "Staff ID";
            this.Rota_StaffID.Name = "Rota_StaffID";
            this.Rota_StaffID.ReadOnly = true;
            this.Rota_StaffID.Visible = false;
            this.Rota_StaffID.Width = 136;
            // 
            // Rota_FirstName
            // 
            this.Rota_FirstName.HeaderText = "First Name";
            this.Rota_FirstName.Name = "Rota_FirstName";
            this.Rota_FirstName.ReadOnly = true;
            this.Rota_FirstName.Width = 228;
            // 
            // Rota_LastName
            // 
            this.Rota_LastName.HeaderText = "Last Name";
            this.Rota_LastName.Name = "Rota_LastName";
            this.Rota_LastName.ReadOnly = true;
            this.Rota_LastName.Width = 227;
            // 
            // Staff_JobRole
            // 
            this.Staff_JobRole.HeaderText = "Job ";
            this.Staff_JobRole.Name = "Staff_JobRole";
            this.Staff_JobRole.ReadOnly = true;
            this.Staff_JobRole.Width = 109;
            // 
            // Monday
            // 
            this.Monday.HeaderText = "Monday";
            this.Monday.Name = "Monday";
            this.Monday.ReadOnly = true;
            this.Monday.Width = 181;
            // 
            // Tuesday
            // 
            this.Tuesday.HeaderText = "Tuesday";
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.ReadOnly = true;
            this.Tuesday.Width = 192;
            // 
            // Wednesday
            // 
            this.Wednesday.HeaderText = "Wednesday";
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.ReadOnly = true;
            this.Wednesday.Width = 246;
            // 
            // Thursday
            // 
            this.Thursday.HeaderText = "Thursday";
            this.Thursday.Name = "Thursday";
            this.Thursday.ReadOnly = true;
            this.Thursday.Width = 204;
            // 
            // Friday
            // 
            this.Friday.HeaderText = "Friday";
            this.Friday.Name = "Friday";
            this.Friday.ReadOnly = true;
            this.Friday.Width = 151;
            // 
            // Saturday
            // 
            this.Saturday.HeaderText = "Saturday";
            this.Saturday.Name = "Saturday";
            this.Saturday.ReadOnly = true;
            this.Saturday.Width = 197;
            // 
            // Sunday
            // 
            this.Sunday.HeaderText = "Sunday";
            this.Sunday.Name = "Sunday";
            this.Sunday.ReadOnly = true;
            this.Sunday.Width = 175;
            // 
            // staffTab
            // 
            this.staffTab.Controls.Add(this.button5);
            this.staffTab.Controls.Add(this.removeStaffButton);
            this.staffTab.Controls.Add(this.editStaffButton);
            this.staffTab.Controls.Add(this.addStaffButton);
            this.staffTab.Controls.Add(this.dataGridView2);
            this.staffTab.Location = new System.Drawing.Point(4, 49);
            this.staffTab.Margin = new System.Windows.Forms.Padding(4);
            this.staffTab.Name = "staffTab";
            this.staffTab.Padding = new System.Windows.Forms.Padding(4);
            this.staffTab.Size = new System.Drawing.Size(1336, 844);
            this.staffTab.TabIndex = 1;
            this.staffTab.Text = "Staff";
            this.staffTab.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(1119, 761);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(204, 64);
            this.button5.TabIndex = 4;
            this.button5.Text = "Exit";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // removeStaffButton
            // 
            this.removeStaffButton.AutoSize = true;
            this.removeStaffButton.Location = new System.Drawing.Point(557, 761);
            this.removeStaffButton.Margin = new System.Windows.Forms.Padding(4);
            this.removeStaffButton.Name = "removeStaffButton";
            this.removeStaffButton.Size = new System.Drawing.Size(337, 64);
            this.removeStaffButton.TabIndex = 3;
            this.removeStaffButton.Text = "Remove Staff";
            this.removeStaffButton.UseVisualStyleBackColor = true;
            // 
            // editStaffButton
            // 
            this.editStaffButton.AutoSize = true;
            this.editStaffButton.Location = new System.Drawing.Point(284, 761);
            this.editStaffButton.Margin = new System.Windows.Forms.Padding(4);
            this.editStaffButton.Name = "editStaffButton";
            this.editStaffButton.Size = new System.Drawing.Size(237, 64);
            this.editStaffButton.TabIndex = 2;
            this.editStaffButton.Text = "Edit Staff";
            this.editStaffButton.UseVisualStyleBackColor = true;
            this.editStaffButton.Click += new System.EventHandler(this.editStaffButton_Click);
            // 
            // addStaffButton
            // 
            this.addStaffButton.AutoSize = true;
            this.addStaffButton.Location = new System.Drawing.Point(8, 761);
            this.addStaffButton.Margin = new System.Windows.Forms.Padding(4);
            this.addStaffButton.Name = "addStaffButton";
            this.addStaffButton.Size = new System.Drawing.Size(241, 64);
            this.addStaffButton.TabIndex = 1;
            this.addStaffButton.Text = "Add Staff";
            this.addStaffButton.UseVisualStyleBackColor = true;
            this.addStaffButton.Click += new System.EventHandler(this.addStaffButton_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StaffID,
            this.FirstName,
            this.LastName,
            this.JobTitle,
            this.Email,
            this.Address,
            this.PostCode});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView2.Location = new System.Drawing.Point(4, 4);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1328, 715);
            this.dataGridView2.TabIndex = 0;
            // 
            // StaffID
            // 
            this.StaffID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.StaffID.HeaderText = "Staff ID";
            this.StaffID.Name = "StaffID";
            this.StaffID.ReadOnly = true;
            this.StaffID.Width = 169;
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 228;
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.Width = 227;
            // 
            // JobTitle
            // 
            this.JobTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.JobTitle.HeaderText = "Job Title";
            this.JobTitle.Name = "JobTitle";
            this.JobTitle.ReadOnly = true;
            this.JobTitle.Width = 188;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 139;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 185;
            // 
            // PostCode
            // 
            this.PostCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PostCode.HeaderText = "Post Code";
            this.PostCode.Name = "PostCode";
            this.PostCode.ReadOnly = true;
            this.PostCode.Width = 222;
            // 
            // systemTab
            // 
            this.systemTab.Controls.Add(this.reportBug);
            this.systemTab.Controls.Add(this.button6);
            this.systemTab.Controls.Add(this.button2);
            this.systemTab.Controls.Add(this.button1);
            this.systemTab.Location = new System.Drawing.Point(4, 49);
            this.systemTab.Margin = new System.Windows.Forms.Padding(4);
            this.systemTab.Name = "systemTab";
            this.systemTab.Size = new System.Drawing.Size(1336, 844);
            this.systemTab.TabIndex = 3;
            this.systemTab.Text = "System";
            this.systemTab.UseVisualStyleBackColor = true;
            // 
            // reportBug
            // 
            this.reportBug.Location = new System.Drawing.Point(5, 76);
            this.reportBug.Margin = new System.Windows.Forms.Padding(4);
            this.reportBug.Name = "reportBug";
            this.reportBug.Size = new System.Drawing.Size(427, 64);
            this.reportBug.TabIndex = 4;
            this.reportBug.Text = "Report Bug";
            this.reportBug.UseVisualStyleBackColor = true;
            this.reportBug.Click += new System.EventHandler(this.reportBug_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(1099, 743);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(204, 64);
            this.button6.TabIndex = 3;
            this.button6.Text = "Exit";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(440, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(427, 64);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset Passwords";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(5, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(427, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "Message Patient";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 897);
            this.Controls.Add(this.adminTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.adminTabs.ResumeLayout(false);
            this.rotaTab.ResumeLayout(false);
            this.rotaTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.staffTab.ResumeLayout(false);
            this.staffTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.systemTab.ResumeLayout(false);
            this.systemTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl adminTabs;
        private System.Windows.Forms.TabPage rotaTab;
        private System.Windows.Forms.TabPage staffTab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage systemTab;
        private System.Windows.Forms.Button removeStaffButton;
        private System.Windows.Forms.Button editStaffButton;
        private System.Windows.Forms.Button addStaffButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostCode;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button reportBug;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rota_StaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rota_FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rota_LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Staff_JobRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sunday;
    }
}