namespace Mockup2.RotaForms
{
    partial class SeeStaffRotaForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StaffFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffJobRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StaffFirstName,
            this.StaffLastName,
            this.StaffJobRole,
            this.Mon,
            this.Tue,
            this.Wed,
            this.Thu,
            this.Fri,
            this.Sat,
            this.Sun});
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(785, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // StaffFirstName
            // 
            this.StaffFirstName.HeaderText = "First Name";
            this.StaffFirstName.Name = "StaffFirstName";
            this.StaffFirstName.Width = 82;
            // 
            // StaffLastName
            // 
            this.StaffLastName.HeaderText = "Last Name";
            this.StaffLastName.Name = "StaffLastName";
            this.StaffLastName.Width = 83;
            // 
            // StaffJobRole
            // 
            this.StaffJobRole.HeaderText = "Job Role";
            this.StaffJobRole.Name = "StaffJobRole";
            this.StaffJobRole.Width = 74;
            // 
            // Mon
            // 
            this.Mon.HeaderText = "Monday";
            this.Mon.Name = "Mon";
            this.Mon.Width = 70;
            // 
            // Tue
            // 
            this.Tue.HeaderText = "Tuesday";
            this.Tue.Name = "Tue";
            this.Tue.Width = 73;
            // 
            // Wed
            // 
            this.Wed.HeaderText = "Wednesday";
            this.Wed.Name = "Wed";
            this.Wed.Width = 89;
            // 
            // Thu
            // 
            this.Thu.HeaderText = "Thursday";
            this.Thu.Name = "Thu";
            this.Thu.Width = 76;
            // 
            // Fri
            // 
            this.Fri.HeaderText = "Friday";
            this.Fri.Name = "Fri";
            this.Fri.Width = 60;
            // 
            // Sat
            // 
            this.Sat.HeaderText = "Saturday";
            this.Sat.Name = "Sat";
            this.Sat.Width = 74;
            // 
            // Sun
            // 
            this.Sun.HeaderText = "Sunday";
            this.Sun.Name = "Sun";
            this.Sun.Width = 68;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SeeStaffRotaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SeeStaffRotaForm";
            this.Text = "SeeStaffRotaForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffJobRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fri;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sun;
        private System.Windows.Forms.Button button1;
    }
}