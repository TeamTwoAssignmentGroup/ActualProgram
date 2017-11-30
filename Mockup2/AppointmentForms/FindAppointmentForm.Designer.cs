namespace Mockup2.AppointmentForms
{
    partial class FindAppointmentForm
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
            this.radioButtonGroupBox = new System.Windows.Forms.GroupBox();
            this.dateRadioButton = new System.Windows.Forms.RadioButton();
            this.nameRadioButton = new System.Windows.Forms.RadioButton();
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.dateGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.searchButton = new System.Windows.Forms.Button();
            this.radioButtonGroupBox.SuspendLayout();
            this.nameGroupBox.SuspendLayout();
            this.dateGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonGroupBox
            // 
            this.radioButtonGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.radioButtonGroupBox.Controls.Add(this.dateRadioButton);
            this.radioButtonGroupBox.Controls.Add(this.nameRadioButton);
            this.radioButtonGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGroupBox.Location = new System.Drawing.Point(12, 12);
            this.radioButtonGroupBox.Name = "radioButtonGroupBox";
            this.radioButtonGroupBox.Size = new System.Drawing.Size(437, 131);
            this.radioButtonGroupBox.TabIndex = 0;
            this.radioButtonGroupBox.TabStop = false;
            this.radioButtonGroupBox.Text = "Search Options";
            // 
            // dateRadioButton
            // 
            this.dateRadioButton.AutoSize = true;
            this.dateRadioButton.Location = new System.Drawing.Point(6, 82);
            this.dateRadioButton.Name = "dateRadioButton";
            this.dateRadioButton.Size = new System.Drawing.Size(228, 37);
            this.dateRadioButton.TabIndex = 100;
            this.dateRadioButton.Text = "Search by date";
            this.dateRadioButton.UseVisualStyleBackColor = true;
            this.dateRadioButton.CheckedChanged += new System.EventHandler(this.dateRadioButton_CheckedChanged);
            // 
            // nameRadioButton
            // 
            this.nameRadioButton.AutoSize = true;
            this.nameRadioButton.Location = new System.Drawing.Point(6, 39);
            this.nameRadioButton.Name = "nameRadioButton";
            this.nameRadioButton.Size = new System.Drawing.Size(245, 37);
            this.nameRadioButton.TabIndex = 100;
            this.nameRadioButton.Text = "Search by name";
            this.nameRadioButton.UseVisualStyleBackColor = true;
            this.nameRadioButton.CheckedChanged += new System.EventHandler(this.nameRadioButton_CheckedChanged);
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Controls.Add(this.label2);
            this.nameGroupBox.Controls.Add(this.label1);
            this.nameGroupBox.Controls.Add(this.lastNameTextBox);
            this.nameGroupBox.Controls.Add(this.firstNameTextBox);
            this.nameGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameGroupBox.Location = new System.Drawing.Point(12, 149);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(437, 141);
            this.nameGroupBox.TabIndex = 1;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(171, 85);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(253, 40);
            this.lastNameTextBox.TabIndex = 2;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(171, 39);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(253, 40);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // dateGroupBox
            // 
            this.dateGroupBox.Controls.Add(this.label4);
            this.dateGroupBox.Controls.Add(this.label3);
            this.dateGroupBox.Controls.Add(this.dateTimePicker2);
            this.dateGroupBox.Controls.Add(this.dateTimePicker1);
            this.dateGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateGroupBox.Location = new System.Drawing.Point(12, 296);
            this.dateGroupBox.Name = "dateGroupBox";
            this.dateGroupBox.Size = new System.Drawing.Size(437, 141);
            this.dateGroupBox.TabIndex = 2;
            this.dateGroupBox.TabStop = false;
            this.dateGroupBox.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Maximum Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Minimum Date";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(224, 84);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 40);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(224, 38);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 40);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(12, 445);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(253, 40);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // FindAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 497);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.dateGroupBox);
            this.Controls.Add(this.nameGroupBox);
            this.Controls.Add(this.radioButtonGroupBox);
            this.Name = "FindAppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find Appointments";
            this.radioButtonGroupBox.ResumeLayout(false);
            this.radioButtonGroupBox.PerformLayout();
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.dateGroupBox.ResumeLayout(false);
            this.dateGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox radioButtonGroupBox;
        private System.Windows.Forms.RadioButton dateRadioButton;
        private System.Windows.Forms.RadioButton nameRadioButton;
        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.GroupBox dateGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button searchButton;
    }
}