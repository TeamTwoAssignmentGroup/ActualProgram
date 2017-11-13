using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2
{
    /// <summary>
    /// A collection of Table instances that represent the current database. Used primarily
    /// in QueryBuilder to ensure all queries are valid.
    /// </summary>
    public class Tables
    {
        public static readonly AppointmentTable APPOINTMENT_TABLE = new AppointmentTable();
        public static readonly MedicalNotesTable MEDICALNOTES_TABLE = new MedicalNotesTable();
        public static readonly MedicationTable MEDICATION_TABLE = new MedicationTable();
        public static readonly MedicationInstanceTable MEDICATIONINSTANCE_TABLE = new MedicationInstanceTable();
        public static readonly PatientTable PATIENT_TABLE = new PatientTable();
        public static readonly PrescriptionTable PRESCRIPTION_TABLE = new PrescriptionTable();
        public static readonly RotaTable ROTA_TABLE = new RotaTable();
        public static readonly StaffTable STAFF_TABLE = new StaffTable();
        public static readonly TestResultTable TESTRESULT_TABLE = new TestResultTable();
        public static readonly Column ALL = new AllColumn("*", null);

        /// <summary>
        /// Represents the all coumns operator in SQL (*)
        /// </summary>
        public class AllColumn : Column
        {
            public AllColumn(string name, Table parent) : base(name, parent)
            {

            }
        }

        /// <summary>
        /// Represents the Appointment table.
        /// </summary>
        public class AppointmentTable : Table
        {
            public readonly Column ID;
            public readonly Column StaffID;
            public readonly Column PatientID;
            public readonly Column AppointmentDate;
            public readonly Column AppointmentTime;
            public readonly Column Cause;
            public readonly Column Status;
            public AppointmentTable():base("Appointment")
            {
                ID = new Column("id",this);
                StaffID = new Column("staffID", this);
                PatientID = new Column("patientID", this);
                AppointmentDate = new Column("appointmentDate", this);
                AppointmentTime = new Column("appointmentTime", this);
                Cause = new Column("cause", this);
                Status = new Column("status", this);
            }
        }

        /// <summary>
        /// Represents the MedicalNotes table.
        /// </summary>
        public class MedicalNotesTable : Table
        {
            public readonly Column ID;
            public readonly Column PatientID;
            public readonly Column WrittenDate;
            public readonly Column Notes;
            public MedicalNotesTable() : base("MedicalNotes")
            {
                ID = new Column("id", this);
                PatientID = new Column("patientID", this);
                WrittenDate = new Column("writtenDate", this);
                Notes = new Column("notes", this);
            }
        }
        /// <summary>
        /// Represents the Medication table.
        /// </summary>
        public class MedicationTable : Table
        {
            public readonly Column ID;
            public readonly Column ScientificName;
            public readonly Column CommercialName;
            public readonly Column Manufacturer;
            public MedicationTable() : base("Medication")
            {
                ID = new Column("id", this);
                ScientificName = new Column("scientificName", this);
                CommercialName = new Column("commercialName", this);
                Manufacturer = new Column("manufacturer", this);
            }
        }
        /// <summary>
        /// Represents the MedicationInstance table.
        /// </summary>
        public class MedicationInstanceTable : Table
        {
            public readonly Column ID;
            public readonly Column PrescriptionID;
            public readonly Column MedicationID;
            public readonly Column Instructions;
            public MedicationInstanceTable() : base("MedicationInstance")
            {
                ID = new Column("id", this);
                PrescriptionID = new Column("prescriptionID", this);
                MedicationID = new Column("medicationID", this);
                Instructions = new Column("instructions", this);
            }
        }
        /// <summary>
        /// Represents the Patient table.
        /// </summary>
        public class PatientTable : Table
        {
            public readonly Column NHSNumber;
            public readonly Column ID;
            public readonly Column FirstName;
            public readonly Column LastName;
            public readonly Column Address;
            public readonly Column NextOfKin;
            public readonly Column PostCode;
            public readonly Column DOB;
            public readonly Column Gender;
            public readonly Column Religion;
            public readonly Column Email;
            public readonly Column Phone;
            public PatientTable() : base("Patient")
            {
                ID = new Column("id", this);
                NHSNumber = new Column("NHSNumber", this);
                FirstName = new Column("firstName", this);
                LastName = new Column("lastName", this);
                Address = new Column("address", this);
                NextOfKin = new Column("nextOfKin", this);
                PostCode = new Column("postcode", this);
                DOB = new Column("DOB", this);
                Gender = new Column("gender", this);
                Religion = new Column("religion", this);
                Email = new Column("email", this);
                Phone = new Column("phone", this);
            }
        }
        /// <summary>
        /// Represents the Prescription table.
        /// </summary>
        public class PrescriptionTable : Table
        {
            public readonly Column ID;
            public readonly Column PatientID;
            public readonly Column IssuingStaffID;
            public readonly Column IsRepeatable;
            public readonly Column IssueDate;
            public readonly Column RepeatRequested;
            public PrescriptionTable() : base("Prescription")
            {
                ID = new Column("id", this);
                PatientID = new Column("patientID", this);
                IssuingStaffID = new Column("issuingStaffID", this);
                IsRepeatable = new Column("isRepeatable", this);
                IssueDate = new Column("issueDate", this);
                RepeatRequested = new Column("repeatRequested", this);
            }
        }
        /// <summary>
        /// Represents the Rota table.
        /// </summary>
        public class RotaTable : Table
        {
            public readonly Column ID;
            public readonly Column StaffID;
            public readonly Column Mon;
            public readonly Column Tue;
            public readonly Column Wed;
            public readonly Column Thur;
            public readonly Column Fri;
            public readonly Column Sat;
            public readonly Column Sun;
            public RotaTable() : base("Rota")
            {
                ID = new Column("id", this);
                StaffID = new Column("staffID", this);
                Mon = new Column("mon", this);
                Tue = new Column("tue", this);
                Wed = new Column("wed", this);
                Thur = new Column("thur", this);
                Fri = new Column("fri", this);
                Sat = new Column("sat", this);
                Sun = new Column("sun", this);
            }
        }
        /// <summary>
        /// Represents the Staff table.
        /// </summary>
        public class StaffTable : Table
        {
            public readonly Column ID;
            public readonly Column FirstName;
            public readonly Column LastName;
            public readonly Column JobRole;
            public readonly Column Password;
            public readonly Column Email;
            public readonly Column Address;
            public readonly Column Postcode;
            public StaffTable () : base("Staff")
            {
                ID = new Column("id", this);
                FirstName = new Column("firstName", this);
                LastName = new Column("lastName", this);
                JobRole = new Column("jobRole", this);
                Password = new Column("password", this);
                Email = new Column("email", this);
                Address = new Column("Address", this);
                Postcode = new Column("PostCode", this);
            }
        }
        /// <summary>
        /// Represents the TestResult table.
        /// </summary>
        public class TestResultTable : Table
        {
            public readonly Column ID;
            public readonly Column PatientID;
            public readonly Column IssuingStaffID;
            public readonly Column TestName;
            public readonly Column TestDate;
            public readonly Column TestTime;
            public readonly Column Results;
            public TestResultTable() : base("TestResult")
            {
                ID = new Column("id", this);
                PatientID = new Column("patientID", this);
                IssuingStaffID = new Column("issuingStaffID", this);
                TestName = new Column("testName", this);
                TestDate = new Column("testDate", this);
                TestTime = new Column("testTime", this);
                Results = new Column("results", this);
            }
        }
        public abstract class Table {

            public readonly string Name;
            public Table(string name)
            {
                this.Name = name;
            }

            public override string ToString()
            {
                return Name;
            }

        }

        public class Column
        {
            public readonly string Name;
            private readonly Table Parent;
            public Column(string name, Table parent)
            {
                this.Name = name;
                this.Parent = parent;
            }

            public string GetFullName()
            {
                if (Parent == null)
                {
                    return Name;
                }
                else
                {
                    return Parent.Name + "." + Name;
                }
            }

            public string GetAs()
            {
                if (Parent == null)
                {
                    return Name;
                }
                else
                {
                    return Parent.Name + "_" + Name;
                }
            }

            public override string ToString()
            {
                return GetFullName();
            }
        }
    }
}
