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
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffTab = new System.Windows.Forms.TabPage();
            this.removeStaffButton = new System.Windows.Forms.Button();
            this.editStaffButton = new System.Windows.Forms.Button();
            this.addStaffButton = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.reportsTab = new System.Windows.Forms.TabPage();
            this.systemTab = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.StaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.adminTabs.Controls.Add(this.reportsTab);
            this.adminTabs.Controls.Add(this.systemTab);
            this.adminTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminTabs.HotTrack = true;
            this.adminTabs.Location = new System.Drawing.Point(0, 0);
            this.adminTabs.Name = "adminTabs";
            this.adminTabs.SelectedIndex = 0;
            this.adminTabs.Size = new System.Drawing.Size(1008, 729);
            this.adminTabs.TabIndex = 0;
            // 
            // rotaTab
            // 
            this.rotaTab.Controls.Add(this.button3);
            this.rotaTab.Controls.Add(this.dataGridView1);
            this.rotaTab.Location = new System.Drawing.Point(4, 42);
            this.rotaTab.Name = "rotaTab";
            this.rotaTab.Padding = new System.Windows.Forms.Padding(3);
            this.rotaTab.Size = new System.Drawing.Size(1000, 683);
            this.rotaTab.TabIndex = 0;
            this.rotaTab.Text = "Rota";
            this.rotaTab.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(8, 634);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 43);
            this.button3.TabIndex = 1;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Monday,
            this.Tuesday,
            this.Wednesday,
            this.Thursday,
            this.Friday,
            this.Saturday,
            this.Sunday});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(994, 625);
            this.dataGridView1.TabIndex = 0;
            // 
            // Monday
            // 
            this.Monday.HeaderText = "Monday";
            this.Monday.Name = "Monday";
            this.Monday.Width = 143;
            // 
            // Tuesday
            // 
            this.Tuesday.HeaderText = "Tuesday";
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.Width = 152;
            // 
            // Wednesday
            // 
            this.Wednesday.HeaderText = "Wednesday";
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.Width = 193;
            // 
            // Thursday
            // 
            this.Thursday.HeaderText = "Thursday";
            this.Thursday.Name = "Thursday";
            this.Thursday.Width = 162;
            // 
            // Friday
            // 
            this.Friday.HeaderText = "Friday";
            this.Friday.Name = "Friday";
            this.Friday.Width = 122;
            // 
            // Saturday
            // 
            this.Saturday.HeaderText = "Saturday";
            this.Saturday.Name = "Saturday";
            this.Saturday.Width = 156;
            // 
            // Sunday
            // 
            this.Sunday.HeaderText = "Sunday";
            this.Sunday.Name = "Sunday";
            this.Sunday.Width = 138;
            // 
            // staffTab
            // 
            this.staffTab.Controls.Add(this.removeStaffButton);
            this.staffTab.Controls.Add(this.editStaffButton);
            this.staffTab.Controls.Add(this.addStaffButton);
            this.staffTab.Controls.Add(this.dataGridView2);
            this.staffTab.Location = new System.Drawing.Point(4, 42);
            this.staffTab.Name = "staffTab";
            this.staffTab.Padding = new System.Windows.Forms.Padding(3);
            this.staffTab.Size = new System.Drawing.Size(1000, 683);
            this.staffTab.TabIndex = 1;
            this.staffTab.Text = "Staff";
            this.staffTab.UseVisualStyleBackColor = true;
            // 
            // removeStaffButton
            // 
            this.removeStaffButton.AutoSize = true;
            this.removeStaffButton.Location = new System.Drawing.Point(304, 352);
            this.removeStaffButton.Name = "removeStaffButton";
            this.removeStaffButton.Size = new System.Drawing.Size(201, 43);
            this.removeStaffButton.TabIndex = 3;
            this.removeStaffButton.Text = "Remove Staff";
            this.removeStaffButton.UseVisualStyleBackColor = true;
            // 
            // editStaffButton
            // 
            this.editStaffButton.AutoSize = true;
            this.editStaffButton.Location = new System.Drawing.Point(156, 352);
            this.editStaffButton.Name = "editStaffButton";
            this.editStaffButton.Size = new System.Drawing.Size(142, 43);
            this.editStaffButton.TabIndex = 2;
            this.editStaffButton.Text = "Edit Staff";
            this.editStaffButton.UseVisualStyleBackColor = true;
            this.editStaffButton.Click += new System.EventHandler(this.editStaffButton_Click);
            // 
            // addStaffButton
            // 
            this.addStaffButton.AutoSize = true;
            this.addStaffButton.Location = new System.Drawing.Point(7, 352);
            this.addStaffButton.Name = "addStaffButton";
            this.addStaffButton.Size = new System.Drawing.Size(143, 43);
            this.addStaffButton.TabIndex = 1;
            this.addStaffButton.Text = "Add Staff";
            this.addStaffButton.UseVisualStyleBackColor = true;
            this.addStaffButton.Click += new System.EventHandler(this.addStaffButton_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StaffID,
            this.FirstName,
            this.LastName,
            this.Address,
            this.PostCode,
            this.JobTitle});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(994, 338);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // reportsTab
            // 
            this.reportsTab.Location = new System.Drawing.Point(4, 42);
            this.reportsTab.Name = "reportsTab";
            this.reportsTab.Padding = new System.Windows.Forms.Padding(3);
            this.reportsTab.Size = new System.Drawing.Size(1000, 683);
            this.reportsTab.TabIndex = 2;
            this.reportsTab.Text = "Reports";
            this.reportsTab.UseVisualStyleBackColor = true;
            // 
            // systemTab
            // 
            this.systemTab.Controls.Add(this.button2);
            this.systemTab.Controls.Add(this.button1);
            this.systemTab.Location = new System.Drawing.Point(4, 42);
            this.systemTab.Name = "systemTab";
            this.systemTab.Size = new System.Drawing.Size(1000, 683);
            this.systemTab.TabIndex = 3;
            this.systemTab.Text = "System";
            this.systemTab.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(251, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(252, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset Passwords";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Message Patient";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StaffID
            // 
            this.StaffID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.StaffID.HeaderText = "Staff ID";
            this.StaffID.Name = "StaffID";
            this.StaffID.Width = 136;
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 184;
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.Width = 181;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.Width = 147;
            // 
            // PostCode
            // 
            this.PostCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PostCode.HeaderText = "Post Code";
            this.PostCode.Name = "PostCode";
            this.PostCode.ReadOnly = true;
            this.PostCode.Width = 175;
            // 
            // JobTitle
            // 
            this.JobTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.JobTitle.HeaderText = "Job Title";
            this.JobTitle.Name = "JobTitle";
            this.JobTitle.Width = 151;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.adminTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.TabPage reportsTab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sunday;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobTitle;
    }
}