using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Models
{
    public class MedicalRecord
    {
        public string MedicalRecordId { get; set; } = CustomMedicalRecordIdGen();

        public string Diagnosis { get; set; }
        public string Treatment { get; set; }

        public DateTime VistedDate { get; set; }


        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string AppointmentId { get; set; }


        private static int _nextId = 1;

        public MedicalRecord()
        {
            _nextId++;
        }
        public override string ToString()
        {
            return $"MedicalRecordId: {MedicalRecordId} | PatientId: {PatientId} | DoctorId: {DoctorId} | VistedDate: {VistedDate} | Diagnosis: {Diagnosis} | treatment: {Treatment} ";
        }

        public static string CustomMedicalRecordIdGen()
        {
            return $"MR{_nextId}";
        }
    }
}
