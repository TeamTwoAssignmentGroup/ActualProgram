using Mockup2.DatabaseClasses;
using Mockup2.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mockup2.DatabaseClasses.Tables;

namespace Mockup2.PrescriptionForms
{
    public partial class ViewPrescription : Form
    {
        private int prescriptionID;
        private DBConnection dbCon;
        public ViewPrescription(int prescriptionID,DBConnection dbCon)
        {
            this.prescriptionID = prescriptionID;
            this.dbCon = dbCon;
            InitializeComponent();
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            //select M.scientificName, M.commercialName, M.manufacturer, MI.instructions FROM Medication M, MedicationInstance MI WHERE M.id = MI.medicationID AND MI.prescriptionID = 159;
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.MEDICATION_TABLE.ScientificName, Tables.MEDICATION_TABLE.CommercialName, Tables.MEDICATION_TABLE.Manufacturer, Tables.MEDICATIONINSTANCE_TABLE.Instructions)
                .From(Tables.MEDICATION_TABLE, Tables.MEDICATIONINSTANCE_TABLE)
                .Where(b.IsEqual(Tables.MEDICATION_TABLE.ID,Tables.MEDICATIONINSTANCE_TABLE.MedicationID),b.And(),b.IsEqual(Tables.MEDICATIONINSTANCE_TABLE.PrescriptionID,prescriptionID));
            CustomTable table = ctf.GetCustomTable(b);

            foreach(Dictionary<Column,object> row in table.GetRows())
            {
                dataGridView1.Rows.Add(row[MEDICATION_TABLE.ScientificName],row[MEDICATION_TABLE.CommercialName],row[MEDICATION_TABLE.Manufacturer],row[MEDICATIONINSTANCE_TABLE.Instructions]);
            }
        }
    }
}
