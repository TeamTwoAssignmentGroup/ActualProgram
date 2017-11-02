namespace Mockup2.PrescriptionForms
{
    partial class ViewPrescription
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
            this.scientificName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commercialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instructions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scientificName,
            this.commercialName,
            this.manufacturer,
            this.instructions});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(284, 261);
            this.dataGridView1.TabIndex = 0;
            // 
            // scientificName
            // 
            this.scientificName.HeaderText = "Scientific Name";
            this.scientificName.Name = "scientificName";
            // 
            // commercialName
            // 
            this.commercialName.HeaderText = "Commercial Name";
            this.commercialName.Name = "commercialName";
            // 
            // manufacturer
            // 
            this.manufacturer.HeaderText = "Manufacturer";
            this.manufacturer.Name = "manufacturer";
            // 
            // instructions
            // 
            this.instructions.HeaderText = "Instructions";
            this.instructions.Name = "instructions";
            // 
            // ViewPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ViewPrescription";
            this.Text = "ViewPrescription";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn scientificName;
        private System.Windows.Forms.DataGridViewTextBoxColumn commercialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn instructions;
    }
}