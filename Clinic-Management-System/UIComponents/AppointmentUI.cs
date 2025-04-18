using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Management_System.Models;
using Clinic_Management_System.Services;

namespace Clinic_Management_System.UIComponents
{
    public class AppointmentUI
    {
        private bool running = true;
        public async Task AppoinmentManagement()
        {
            while (running)
            {
                Console.WriteLine(@"
                1. place an appoinment
                2. List All Appoinments
                3. reschedule appoinment
                4. cancel appoinment
                5. Save & Exit to Main menu
                ");

                int i;
                i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        Console.WriteLine("place an appoinment");
                        PlaceAppointment();
                        break;
                    case 2:
                        Console.WriteLine("List all");
                        ListAll();
                        break;

                    case 3:
                        Console.WriteLine("reschedule appoinment");
                        Reschedule();
                        
                        break;
                    case 4:
                        Console.WriteLine("cancel appoinment ..");
                        CancelAppointment();
                        break;
                    case 5:
                        Console.WriteLine("exiting");
                        await SaveData();
                        running = false;
                        break;
                }



            }

        }

        public void PlaceAppointment()
        {
            Console.Clear();
            Console.WriteLine("------Place Appointment-----");

            var appointment = new Appointment();


            Console.WriteLine("enter reason (max 40 words):");
            appointment.Reason =Console.ReadLine();

            //date validation
            appointment.DateAndTime = ValidatorClass.DateValidator();
            //patientid validation
            appointment.PatientId = ValidatorClass.PatientIdValidator();
            //doctor validation
            appointment.DoctorId = ValidatorClass.DoctorIdValidator();
           
           

            AppointmentManager.AddAppoinment(appointment);
            Console.WriteLine("Appoinment successfully booked!! Press Enter to main menu");
            Console.ReadLine();


        }

        public static void ListAll()
        {
            Console.Clear();
            var AppointmentData = AppointmentManager.GetAll();

            foreach (var appointment in AppointmentData)
            {
                Console.WriteLine($"appointmentID: {appointment.AppoinmentId} | IsCancelled : {appointment.IsCancelled} | Reason: {appointment.Reason} | Date And Time : {appointment.DateAndTime} | PatientID : {appointment.PatientId} | DoctorId : {appointment.DoctorId} ");
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine() ;
        }
        public void CancelAppointment()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----Cancel Appointments-----");

                Console.WriteLine("Enter appointment Id:");
                string? AppointmentId = Console.ReadLine();

                bool result=AppointmentManager.CancelAppointment(AppointmentId);

                if (result)
                {
                    Console.WriteLine("Appointment cancelled");
                    break;

                }
                else
                {
                    Console.WriteLine("Invalid apointment id!!!,Press Enter to Provide id again ");
                    Console.ReadLine();
                }


            }

        }

        public  void Reschedule()
        {
            while (true)
            {
                //Console.Clear();
                Console.WriteLine("----Rescheduling Appointment----");

                Console.WriteLine("Enter your appointmentId (eg. ap1) :");
                string? AppointmentId=Console.ReadLine();

                bool ValidId = AppointmentManager.isAppointmentValid(AppointmentId);
                if (ValidId)
                {
                    DateTime NewDateAndTime = ValidatorClass.DateValidator();
                    bool FinalResult=AppointmentManager.RescheduleAppointment(AppointmentId, NewDateAndTime);
                    if (FinalResult)
                    {
                        Console.WriteLine("Appointment rescheduled successfully..");
                        break ;
                    }
                    else
                    {
                        Console.WriteLine("Error in rescheduling , try again with different slot");
                    }

                }
                else
                {
                    Console.WriteLine("Enter valid appointment id!!, Press enter to try again");
                    Console.ReadLine();
                }
            }

        }

        public async Task SaveData()
        {
            await JsonFileHandler.SaveAsync("appointments.json", AppointmentManager.GetAll());
        }
    }
}
