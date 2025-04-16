using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Management_System.Models;
using Clinic_Management_System.UIComponents;

namespace Clinic_Management_System.Services
{
    public class ValidatorClass
    {
        public static DateTime DateValidator()
        {
            while (true)
            {
                Console.WriteLine("enter date and time (e.g. 2025-04-16 14:30)");
                string? input = Console.ReadLine();
                DateTime AppointmentDateTime;
                if (DateTime.TryParse(input, out AppointmentDateTime))
                {
                    return AppointmentDateTime;
                    //break;
                }
                else
                {
                    Console.WriteLine("invalid date time format");
                }
            }
        }

        public static int PatientIdValidator()
        {
            while (true)
            {
                Console.WriteLine("Enter PatientId (eg. 10):");
                int InpPatientId = Convert.ToInt32(Console.ReadLine());
                bool validId = PatientService.IsPatientId(InpPatientId);
                if (validId)
                {
                    return InpPatientId;
                }
                else
                {
                    Console.WriteLine("enter a valid patient id:");
                }

            }
        }

        public static int DoctorIdValidator()
        {
            while (true)
            {
                Console.WriteLine("Enter DoctorId (eg. 10):");
                int InpDoctorId = Convert.ToInt32(Console.ReadLine());
                bool validDocId = DoctorServices.IsDoctorId(InpDoctorId);
                if (validDocId)
                {
                    return InpDoctorId;
                }
                else
                {
                    Console.WriteLine("enter a valid Doctor id:");
                }
            }

        }
    }
}
