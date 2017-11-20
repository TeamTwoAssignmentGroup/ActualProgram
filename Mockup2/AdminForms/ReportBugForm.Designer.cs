namespace Mockup2.AdminForms
{
    partial class ReportBugForm
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
            this.reportDate = new System.Windows.Forms.DateTimePicker();
            this.reportTime = new System.Windows.Forms.DateTimePicker();
            this.reportSubject = new System.Windows.Forms.TextBox();
            this.reportMessage = new System.Windows.Forms.TextBox();
            this.sendReportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reportDate
            // 
            this.reportDate.Location = new System.Drawing.Point(72, 14);
            this.reportDate.Name = "reportDate";
            this.reportDate.Size = new System.Drawing.Size(200, 20);
            this.reportDate.TabIndex = 0;
            // 
            // reportTime
            // 
            this.reportTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.reportTime.Location = new System.Drawing.Point(72, 40);
            this.reportTime.Name = "reportTime";
            this.reportTime.ShowUpDown = true;
            this.reportTime.Size = new System.Drawing.Size(200, 20);
            this.reportTime.TabIndex = 1;
            // 
            // reportSubject
            // 
            this.reportSubject.Location = new System.Drawing.Point(72, 66);
            this.reportSubject.Name = "reportSubject";
            this.reportSubject.Size = new System.Drawing.Size(200, 20);
            this.reportSubject.TabIndex = 2;
            // 
            // reportMessage
            // 
            this.reportMessage.Location = new System.Drawing.Point(72, 92);
            this.reportMessage.Multiline = true;
            this.reportMessage.Name = "reportMessage";
            this.reportMessage.Size = new System.Drawing.Size(200, 128);
            this.reportMessage.TabIndex = 3;
            // 
            // sendReportButton
            // 
            this.sendReportButton.Location = new System.Drawing.Point(72, 226);
            this.sendReportButton.Name = "sendReportButton";
            this.sendReportButton.Size = new System.Drawing.Size(75, 23);
            this.sendReportButton.TabIndex = 4;
            this.sendReportButton.Text = "Send Report";
            this.sendReportButton.UseVisualStyleBackColor = true;
            this.sendReportButton.Click += new System.EventHandler(this.sendReportButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Subject";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ReportBugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendReportButton);
            this.Controls.Add(this.reportMessage);
            this.Controls.Add(this.reportSubject);
            this.Controls.Add(this.reportTime);
            this.Controls.Add(this.reportDate);
            this.Name = "ReportBugForm";
            this.Text = "ReportBugForm";
            this.Load += new System.EventHandler(this.ReportBugForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker reportDate;
        private System.Windows.Forms.DateTimePicker reportTime;
        private System.Windows.Forms.TextBox reportSubject;
        private System.Windows.Forms.TextBox reportMessage;
        private System.Windows.Forms.Button sendReportButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}