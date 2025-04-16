using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Models
{
    public class Appointment
    {
        //id,datetime,patient,doctor
        public string AppoinmentId { get; set; }= CustomAppoinmentIdGen();

        public string Reason { get; set; }

        public DateTime DateAndTime { get; set; }


        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public bool IsCancelled { get; set; } = false;

        private static int _nextId = 1;

        public Appointment()
        {
            _nextId++;
        }
        public override string ToString()
        {
            return $"Appointment [{DateAndTime}] - Patient: {PatientId}, Doctor: {DoctorId}, Reason: {Reason}, Cancelled: {IsCancelled}";
        }

        public static string CustomAppoinmentIdGen()
        {
            return $"ap{_nextId}";
        }
    }
}
