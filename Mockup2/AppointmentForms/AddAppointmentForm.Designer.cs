namespace Mockup2.AppointmentForms
{
    partial class AddAppointmentForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.causeTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.staffcomboBox1 = new System.Windows.Forms.ComboBox();
            this.patientcomboBox2 = new System.Windows.Forms.ComboBox();
            this.timeslotcomboBox1 = new System.Windows.Forms.ComboBox();
            this.firstnametextBox1 = new System.Windows.Forms.TextBox();
            this.lastnametextBox2 = new System.Windows.Forms.TextBox();
            this.findPatientButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(267, 197);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 40);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // causeTextBox
            // 
            this.causeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.causeTextBox.Location = new System.Drawing.Point(267, 384);
            this.causeTextBox.Multiline = true;
            this.causeTextBox.Name = "causeTextBox";
            this.causeTextBox.Size = new System.Drawing.Size(200, 98);
            this.causeTextBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(267, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 41);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Staff ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "Selected Patient";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(185, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(162, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 33);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cause";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(180, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 33);
            this.label5.TabIndex = 10;
            this.label5.Text = "Time";
            // 
            // statusComboBox
            // 
            this.statusComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Booked",
            "Canceled",
            "Late",
            "Complete",
            "NoShow"});
            this.statusComboBox.Location = new System.Drawing.Point(267, 337);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(200, 41);
            this.statusComboBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 33);
            this.label6.TabIndex = 12;
            this.label6.Text = "Status";
            // 
            // staffcomboBox1
            // 
            this.staffcomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.staffcomboBox1.Enabled = false;
            this.staffcomboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffcomboBox1.FormattingEnabled = true;
            this.staffcomboBox1.Location = new System.Drawing.Point(267, 243);
            this.staffcomboBox1.Name = "staffcomboBox1";
            this.staffcomboBox1.Size = new System.Drawing.Size(200, 41);
            this.staffcomboBox1.TabIndex = 4;
            this.staffcomboBox1.SelectedIndexChanged += new System.EventHandler(this.staffcomboBox1_SelectedIndexChanged);
            // 
            // patientcomboBox2
            // 
            this.patientcomboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.patientcomboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientcomboBox2.FormattingEnabled = true;
            this.patientcomboBox2.Location = new System.Drawing.Point(267, 150);
            this.patientcomboBox2.Name = "patientcomboBox2";
            this.patientcomboBox2.Size = new System.Drawing.Size(200, 41);
            this.patientcomboBox2.TabIndex = 16;
            // 
            // timeslotcomboBox1
            // 
            this.timeslotcomboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeslotcomboBox1.FormattingEnabled = true;
            this.timeslotcomboBox1.Location = new System.Drawing.Point(267, 290);
            this.timeslotcomboBox1.Name = "timeslotcomboBox1";
            this.timeslotcomboBox1.Size = new System.Drawing.Size(200, 41);
            this.timeslotcomboBox1.TabIndex = 5;
            // 
            // firstnametextBox1
            // 
            this.firstnametextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnametextBox1.Location = new System.Drawing.Point(267, 12);
            this.firstnametextBox1.Name = "firstnametextBox1";
            this.firstnametextBox1.Size = new System.Drawing.Size(200, 40);
            this.firstnametextBox1.TabIndex = 1;
            // 
            // lastnametextBox2
            // 
            this.lastnametextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnametextBox2.Location = new System.Drawing.Point(267, 58);
            this.lastnametextBox2.Name = "lastnametextBox2";
            this.lastnametextBox2.Size = new System.Drawing.Size(200, 40);
            this.lastnametextBox2.TabIndex = 2;
            // 
            // findPatientButton
            // 
            this.findPatientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findPatientButton.Location = new System.Drawing.Point(267, 104);
            this.findPatientButton.Name = "findPatientButton";
            this.findPatientButton.Size = new System.Drawing.Size(200, 40);
            this.findPatientButton.TabIndex = 20;
            this.findPatientButton.Text = "Find";
            this.findPatientButton.UseVisualStyleBackColor = true;
            this.findPatientButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 33);
            this.label7.TabIndex = 21;
            this.label7.Text = "Patient First Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(254, 33);
            this.label8.TabIndex = 22;
            this.label8.Text = "Patient Last Name";
            // 
            // AddAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 541);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.findPatientButton);
            this.Controls.Add(this.lastnametextBox2);
            this.Controls.Add(this.firstnametextBox1);
            this.Controls.Add(this.timeslotcomboBox1);
            this.Controls.Add(this.patientcomboBox2);
            this.Controls.Add(this.staffcomboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.causeTextBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "AddAppointmentForm";
            this.Text = "Add Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox statusComboBox;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.TextBox causeTextBox;
        private System.Windows.Forms.ComboBox staffcomboBox1;
        private System.Windows.Forms.ComboBox patientcomboBox2;
        public System.Windows.Forms.ComboBox timeslotcomboBox1;
        private System.Windows.Forms.TextBox firstnametextBox1;
        private System.Windows.Forms.TextBox lastnametextBox2;
        private System.Windows.Forms.Button findPatientButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}