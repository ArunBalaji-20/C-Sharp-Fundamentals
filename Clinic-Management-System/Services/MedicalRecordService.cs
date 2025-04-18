using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Management_System.Models;


namespace Clinic_Management_System.Services
{
    public class MedicalRecordService
    {
        private static List<MedicalRecord> _medicalRecords = new List<MedicalRecord>();

        public static void LoadRecords(List<MedicalRecord> records)
        {
            _medicalRecords = records;
        }
        public static void AddRecord(MedicalRecord record)
        {
            _medicalRecords.Add(record);
        }

        public static List<MedicalRecord> GetAllRecords()
        {

            return _medicalRecords;
        }

        public static MedicalRecord GetOneRecord(int id)
        {
            var record= _medicalRecords.Find(p=>p.PatientId==id);
            return record;
        }
    }
}
