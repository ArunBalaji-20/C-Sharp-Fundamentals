using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Management_System.Models;

namespace Clinic_Management_System.Services
{
    public class AppointmentManager
    {
        private static List<Appointment> _appoinments = new List<Appointment>();

        public static void LoadAppointments(List<Appointment> appointmentFromFile)
        {
            _appoinments = appointmentFromFile;
        }
        public static void AddAppoinment(Appointment appoinment)
        {
            _appoinments.Add(appoinment);
        }

        public static List<Appointment> GetAll()
        {
            return _appoinments;
        }
        public static int GetCount()
        {
            return _appoinments.Count;
        }
        public static List<Appointment> GetAppointmentsForTheDay(DateTime GivenDateAndTime)
        {
            var results = _appoinments.FindAll(p => p.DateAndTime.Date == GivenDateAndTime.Date);
            return results;
        }
        
        public static List<Appointment> GetOnePatientRecords(int patientId)
        {
            var patientRecords = _appoinments.FindAll(p=>p.PatientId==patientId);
            return patientRecords;
        }

        public static bool RescheduleAppointment(string appointmentId,DateTime newDateTime)
        {
            var existingAppointment=_appoinments.Find(ap=>ap.AppoinmentId == appointmentId);
            bool IsSlotAvail = _appoinments.Any(ap=>ap.DateAndTime==newDateTime);
            if (existingAppointment!=null && IsSlotAvail==false)
            {
                existingAppointment.DateAndTime = newDateTime;
                return true;
                
            }
            else
            {
                return false;
            }
        }
        public static bool CancelAppointment(string appointmentId)
        {
            var res=_appoinments.Find(ap=>ap.AppoinmentId == appointmentId);

            if (res != null)
            {
                res.IsCancelled = true;
                return true;
            }
            else
            {
                return false;
            }
                
        }


        public static bool isAppointmentValid(string appointmentId)
        {
            var res = _appoinments.Find(ap => ap.AppoinmentId == appointmentId);
            if (res != null && res.IsCancelled==false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
