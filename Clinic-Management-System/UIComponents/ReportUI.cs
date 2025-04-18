using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Management_System.Models;
using Clinic_Management_System.Services;
namespace Clinic_Management_System.UIComponents
{
    public class ReportUI
    {
        private bool running=true;
        public async Task ReportAndStats()
        {
            while (running)
            {
                Console.Clear();
                Console.WriteLine(@"
                    1. Export Patients to CSV
                    2. Export Appointments to CSV
                    3. Export Medical Records to CSV
                    4. View Appointments for the day
                    5. Clinic Statistics
                    6. Back
                ");

                int i;
                i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        Console.WriteLine("Export Patients to CSV");
                        ReportGeneration.ConvertToCsv("patients.json");
                        break;

                    case 2:
                        Console.WriteLine("Export Appointments to CSV");
                        ReportGeneration.ConvertToCsv("appointments.json");
                        //ListAll();
                        break;
                    case 3:
                        Console.WriteLine("Export Medical Records to CSV");
                        ReportGeneration.ConvertToCsv("MedicalRecords.json");
                        break;
                    case 4:
                        Console.WriteLine(" View Appointments for the day");
                        ViewAppointment();
                        break;

                    case 5:
                        Console.WriteLine("Clinic Statistics");
                        ClinicStats();
                        break;

                    case 6:
                        Console.WriteLine("exiting");
                        running = false;
                        break;
                }



            }
        }

        public void ViewAppointment()
        {
            Console.Clear();
            Console.WriteLine("----View Upcoming Appointments----");
            Console.WriteLine("Enter the date to see upcoming appointments:");
            DateTime dateTime = ValidatorClass.DateValidator();

            var results = AppointmentManager.GetAppointmentsForTheDay(dateTime);
            //Console.WriteLine(results);
            if (results != null && results.Any())
            {
                foreach (var result in results)
                {
                    Console.WriteLine(result.ToString());
                }
            }
            else
            {
                Console.WriteLine("No upcoming appointments for the day");
            }
            Console.WriteLine("Press enter to Go back!!!");
            Console.ReadLine();

        }

        public void ClinicStats()
        {
            Console.Clear();
            Console.WriteLine("-----Clinic Statistics------");
            //patients,doctors,appointments
            int NumberOfPatients = PatientService.GetCount();
            Console.WriteLine($"Number of Patients:{NumberOfPatients}");

            int NumberOfDoctors = DoctorServices.GetCount();
            Console.WriteLine($"Number of Doctors:{NumberOfDoctors}");

            int NumberOfAppointments = AppointmentManager.GetCount();
            Console.WriteLine($"Number of Appointments:{NumberOfAppointments}");


            Console.WriteLine("Press enter to go back!!");
            Console.ReadLine() ;
        }

    }

    
      
}
