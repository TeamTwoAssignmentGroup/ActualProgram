﻿namespace Mockup2.PatientForms
{
    partial class ViewTestHistoryForm
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
            this.PatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Results = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateResults = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientID,
            this.FirstName,
            this.LastName,
            this.TestTaken,
            this.DateTaken,
            this.Results,
            this.DateResults});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 261);
            this.dataGridView1.TabIndex = 0;
            // 
            // PatientID
            // 
            this.PatientID.HeaderText = "Patient ID";
            this.PatientID.Name = "PatientID";
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            // 
            // TestTaken
            // 
            this.TestTaken.HeaderText = "Test Taken";
            this.TestTaken.Name = "TestTaken";
            // 
            // DateTaken
            // 
            this.DateTaken.HeaderText = "Date Taken";
            this.DateTaken.Name = "DateTaken";
            // 
            // Results
            // 
            this.Results.HeaderText = "Results";
            this.Results.Name = "Results";
            // 
            // DateResults
            // 
            this.DateResults.HeaderText = "Results Received Date";
            this.DateResults.Name = "DateResults";
            // 
            // ViewTestHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 261);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ViewTestHistoryForm";
            this.Text = "ViewTestHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn Results;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateResults;
    }
}