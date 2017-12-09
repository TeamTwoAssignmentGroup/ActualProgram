namespace Mockup2
{
    partial class ReceptionistForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceptionistForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Exit = new System.Windows.Forms.Button();
            this.findAppointmentButton = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.appointmentDataGridView = new System.Windows.Forms.DataGridView();
            this.StaffFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentCause = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.lastNameTextbox = new System.Windows.Forms.TextBox();
            this.firstNameTextbox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NHSNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextOfKin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.religion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.seeRotaLastName = new System.Windows.Forms.TextBox();
            this.seeRotaFirstName = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.seerotadateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1357, 729);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Exit);
            this.tabPage1.Controls.Add(this.findAppointmentButton);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.appointmentDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 42);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1349, 683);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Appointments";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.Location = new System.Drawing.Point(977, 623);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(364, 52);
            this.Exit.TabIndex = 100;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // findAppointmentButton
            // 
            this.findAppointmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.findAppointmentButton.AutoSize = true;
            this.findAppointmentButton.Location = new System.Drawing.Point(9, 623);
            this.findAppointmentButton.Name = "findAppointmentButton";
            this.findAppointmentButton.Size = new System.Drawing.Size(314, 52);
            this.findAppointmentButton.TabIndex = 3;
            this.findAppointmentButton.Text = "Find Appointment";
            this.findAppointmentButton.UseVisualStyleBackColor = true;
            this.findAppointmentButton.Click += new System.EventHandler(this.findAppointmentButton_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.AutoSize = true;
            this.button7.Location = new System.Drawing.Point(330, 623);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(364, 52);
            this.button7.TabIndex = 4;
            this.button7.Text = "Cancel Appointment";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.AutoSize = true;
            this.button6.Location = new System.Drawing.Point(330, 565);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(364, 52);
            this.button6.TabIndex = 2;
            this.button6.Text = "Amend Appointment";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.AutoSize = true;
            this.button5.Location = new System.Drawing.Point(9, 565);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(314, 52);
            this.button5.TabIndex = 1;
            this.button5.Text = "Add Appointment";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // appointmentDataGridView
            // 
            this.appointmentDataGridView.AllowUserToAddRows = false;
            this.appointmentDataGridView.AllowUserToDeleteRows = false;
            this.appointmentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appointmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.appointmentDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.appointmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StaffFirstName,
            this.StaffLastName,
            this.PatientFirstName,
            this.PatientLastName,
            this.Date,
            this.Time,
            this.AppointmentStatus,
            this.appointmentCause});
            this.appointmentDataGridView.Location = new System.Drawing.Point(3, 3);
            this.appointmentDataGridView.MultiSelect = false;
            this.appointmentDataGridView.Name = "appointmentDataGridView";
            this.appointmentDataGridView.ReadOnly = true;
            this.appointmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentDataGridView.Size = new System.Drawing.Size(1338, 556);
            this.appointmentDataGridView.TabIndex = 99;
            // 
            // StaffFirstName
            // 
            this.StaffFirstName.HeaderText = "Staff First Name";
            this.StaffFirstName.Name = "StaffFirstName";
            this.StaffFirstName.ReadOnly = true;
            this.StaffFirstName.Width = 228;
            // 
            // StaffLastName
            // 
            this.StaffLastName.HeaderText = "Staff Last Name";
            this.StaffLastName.Name = "StaffLastName";
            this.StaffLastName.ReadOnly = true;
            this.StaffLastName.Width = 225;
            // 
            // PatientFirstName
            // 
            this.PatientFirstName.HeaderText = "Patient First Name";
            this.PatientFirstName.Name = "PatientFirstName";
            this.PatientFirstName.ReadOnly = true;
            this.PatientFirstName.Width = 186;
            // 
            // PatientLastName
            // 
            this.PatientLastName.HeaderText = "Patient Last Name";
            this.PatientLastName.Name = "PatientLastName";
            this.PatientLastName.ReadOnly = true;
            this.PatientLastName.Width = 183;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 101;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 106;
            // 
            // AppointmentStatus
            // 
            this.AppointmentStatus.HeaderText = "Status";
            this.AppointmentStatus.Name = "AppointmentStatus";
            this.AppointmentStatus.ReadOnly = true;
            this.AppointmentStatus.Width = 122;
            // 
            // appointmentCause
            // 
            this.appointmentCause.HeaderText = "Cause";
            this.appointmentCause.Name = "appointmentCause";
            this.appointmentCause.ReadOnly = true;
            this.appointmentCause.Width = 124;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.lastNameTextbox);
            this.tabPage2.Controls.Add(this.firstNameTextbox);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 42);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1349, 683);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Patients";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Location = new System.Drawing.Point(977, 623);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(364, 52);
            this.button9.TabIndex = 101;
            this.button9.Text = "Exit";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 580);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 33);
            this.label2.TabIndex = 8;
            this.label2.Text = "Last name";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "First name";
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button8.AutoSize = true;
            this.button8.Location = new System.Drawing.Point(607, 623);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(284, 52);
            this.button8.TabIndex = 3;
            this.button8.Text = "Find";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // lastNameTextbox
            // 
            this.lastNameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastNameTextbox.Location = new System.Drawing.Point(607, 577);
            this.lastNameTextbox.Name = "lastNameTextbox";
            this.lastNameTextbox.Size = new System.Drawing.Size(284, 40);
            this.lastNameTextbox.TabIndex = 2;
            // 
            // firstNameTextbox
            // 
            this.firstNameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstNameTextbox.Location = new System.Drawing.Point(607, 531);
            this.firstNameTextbox.Name = "firstNameTextbox";
            this.firstNameTextbox.Size = new System.Drawing.Size(284, 40);
            this.firstNameTextbox.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.AutoSize = true;
            this.button4.Location = new System.Drawing.Point(8, 623);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(414, 52);
            this.button4.TabIndex = 6;
            this.button4.Text = "Remove Patient";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(8, 565);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(414, 52);
            this.button3.TabIndex = 5;
            this.button3.Text = "Edit Existing Patient";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(8, 507);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(414, 52);
            this.button2.TabIndex = 4;
            this.button2.Text = "Register New Patient";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.NHSNumber,
            this.firstName,
            this.lastName,
            this.address,
            this.postcode,
            this.nextOfKin,
            this.DOB,
            this.gender,
            this.religion,
            this.email,
            this.phone});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1338, 498);
            this.dataGridView1.TabIndex = 100;
            // 
            // id
            // 
            this.id.HeaderText = "Patient ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 167;
            // 
            // NHSNumber
            // 
            this.NHSNumber.HeaderText = "NHS Number";
            this.NHSNumber.Name = "NHSNumber";
            this.NHSNumber.ReadOnly = true;
            this.NHSNumber.Width = 213;
            // 
            // firstName
            // 
            this.firstName.HeaderText = "First Name";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            this.firstName.Width = 184;
            // 
            // lastName
            // 
            this.lastName.HeaderText = "Last Name";
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            this.lastName.Width = 181;
            // 
            // address
            // 
            this.address.HeaderText = "Address";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 147;
            // 
            // postcode
            // 
            this.postcode.HeaderText = "Postcode";
            this.postcode.Name = "postcode";
            this.postcode.ReadOnly = true;
            this.postcode.Width = 161;
            // 
            // nextOfKin
            // 
            this.nextOfKin.HeaderText = "Next Of Kin";
            this.nextOfKin.Name = "nextOfKin";
            this.nextOfKin.ReadOnly = true;
            this.nextOfKin.Width = 189;
            // 
            // DOB
            // 
            this.DOB.HeaderText = "DOB";
            this.DOB.Name = "DOB";
            this.DOB.ReadOnly = true;
            this.DOB.Width = 103;
            // 
            // gender
            // 
            this.gender.HeaderText = "Gender";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            this.gender.Width = 137;
            // 
            // religion
            // 
            this.religion.HeaderText = "Religion";
            this.religion.Name = "religion";
            this.religion.ReadOnly = true;
            this.religion.Width = 146;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 114;
            // 
            // phone
            // 
            this.phone.HeaderText = "Phone";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.Width = 123;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.button11);
            this.tabPage3.Controls.Add(this.seeRotaLastName);
            this.tabPage3.Controls.Add(this.seeRotaFirstName);
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.seerotadateTimePicker1);
            this.tabPage3.Location = new System.Drawing.Point(4, 42);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1349, 683);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Rota";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 33);
            this.label4.TabIndex = 106;
            this.label4.Text = "Staff Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 33);
            this.label3.TabIndex = 105;
            this.label3.Text = "Staff First Name";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(607, 98);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(249, 52);
            this.button11.TabIndex = 104;
            this.button11.Text = "See Rota";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // seeRotaLastName
            // 
            this.seeRotaLastName.Location = new System.Drawing.Point(607, 52);
            this.seeRotaLastName.Name = "seeRotaLastName";
            this.seeRotaLastName.Size = new System.Drawing.Size(249, 40);
            this.seeRotaLastName.TabIndex = 103;
            // 
            // seeRotaFirstName
            // 
            this.seeRotaFirstName.Location = new System.Drawing.Point(607, 6);
            this.seeRotaFirstName.Name = "seeRotaFirstName";
            this.seeRotaFirstName.Size = new System.Drawing.Size(249, 40);
            this.seeRotaFirstName.TabIndex = 102;
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.Location = new System.Drawing.Point(977, 623);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(364, 52);
            this.button10.TabIndex = 101;
            this.button10.Text = "Exit";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(8, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "See Staff List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // seerotadateTimePicker1
            // 
            this.seerotadateTimePicker1.Location = new System.Drawing.Point(8, 6);
            this.seerotadateTimePicker1.Name = "seerotadateTimePicker1";
            this.seerotadateTimePicker1.Size = new System.Drawing.Size(300, 40);
            this.seerotadateTimePicker1.TabIndex = 0;
            // 
            // ReceptionistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 729);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReceptionistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Over Surgery - Receptionist";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker seerotadateTimePicker1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView appointmentDataGridView;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NHSNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn postcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextOfKin;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn religion;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.Button findAppointmentButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentCause;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox seeRotaLastName;
        private System.Windows.Forms.TextBox seeRotaFirstName;
        public System.Windows.Forms.TextBox lastNameTextbox;
        public System.Windows.Forms.TextBox firstNameTextbox;
    }
}