using System;
using Clinic_Management_System.Models;
using Clinic_Management_System.Services;
using Clinic_Management_System.UIComponents;
//using ClinicManagementSystem.Services;
namespace ClincManagementSystem
{
    class MainClass
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("gg");
            try
            {
                bool running = true;
                int choice = 0;
                // On startup

                var patientsFromFile = await JsonFileHandler.LoadAsync<Patient>("patients.json");
                PatientService.LoadPatients(patientsFromFile);

                var doctorsFromFile = await JsonFileHandler.LoadAsync<Doctor>("doctors.json");
                DoctorServices.LoadDoctors(doctorsFromFile);

                var appointmentFromFile = await JsonFileHandler.LoadAsync<Appointment>("appointments.json");
                AppointmentManager.LoadAppointments(appointmentFromFile);
                

                while (running)
                {
                    Console.Clear();

                    Console.WriteLine("""

                                                ---------------------------------------- 

                                                Clinic Management System 

                                                ---------------------------------------- 

                                                1. Patient Management  
                                                2. Doctor Management  
                                                3. Appointment Scheduling  
                                                4. Medical Records  
                                                5. Reports & Statistics  
                                                6. System Maintenance 
                                                7. Exit 
                                    
                                                
                        """);

                    choice = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine(choice);

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            PatientUI patientUI = new PatientUI();
                            await patientUI.PatientManagement();
                            break;
                        case 2:
                            Console.Clear();
                            DoctorUI doctorUI = new DoctorUI();
                            await doctorUI.DoctorManagement();
                            break;

                        case 3:
                            Console.Clear();
                            AppointmentUI appointmentUI = new AppointmentUI();
                            await appointmentUI.AppoinmentManagement();
                            break;

                        case 4:
                            Console.WriteLine("4");
                            break;
                        case 5:
                            Console.WriteLine("5");
                            break;

                        case 6:
                            Console.WriteLine("6");
                            break;

                        case 7:
                            Console.WriteLine("Closing.....");
                            running = false;
                            break;
                    }
                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }
    }
    

}