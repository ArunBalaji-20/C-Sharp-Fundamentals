using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Management_System.Models;

namespace Clinic_Management_System.Services
{
    public class DoctorServices
    {
        private static List<Doctor> _doctor = new List<Doctor>();


        public static void LoadDoctors(List<Doctor> doctorsFromFile)
        {
            _doctor = doctorsFromFile;
        }
        public static void AddDoctors(Doctor doctor)
        {
            _doctor.Add(doctor);
        }

        public static List<Doctor> GetDoctors()
        {

            return _doctor;
        }

        public static int GetCount()
        {
            return _doctor.Count;
        }

        public static bool DeleteDoctor(Guid doctorId)
        {
            var Doc = _doctor.Find(p => p.LicenseNumber == doctorId);
            if (Doc != null)
            {
                _doctor.Remove(Doc);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsDoctorId(int id)
        {
            var exist = _doctor.Find(p => p.Id == id);
            if (exist != null)
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
