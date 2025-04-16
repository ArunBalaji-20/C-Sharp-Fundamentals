using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Management_System.Models;
using Clinic_Management_System.Services;

namespace Clinic_Management_System.UIComponents
{
    public class DoctorUI
    {
        private bool running = true;

        public async Task DoctorManagement()
        {
            while (running)
            {
                Console.WriteLine(@"
                1. Add Doctors 
                2. List all Doctors
                3. Delete Doctor by Id
                4. Exit to Main menu
                ");

                int i;
                i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        Console.WriteLine("DoctorAdd");

                        AddDoctors(); //defined below
                        break;

                    case 2:
                        Console.WriteLine("Listing all");
                        ListAll();
                        break;
                    case 3:
                        Console.WriteLine("deleting ..");
                        Delete();
                        break;
                    case 4:
                        Console.WriteLine("exiting");
                        await SaveData();
                        running = false;
                        break;
                }



            }


        }

        public void AddDoctors()
        {
            var doctor = new Doctor();
            Console.WriteLine("-------ADD NEW DOCTOR------");

            Console.WriteLine("enter First Name:");
            doctor.FirstName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("enter Last Name");
            doctor.LastName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter DOB(yyyy-mm-dd):");
            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly dob))
                doctor.DateOfBirth = dob;
            else
            {
                Console.WriteLine("Invalid date format.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Enter Contact number:");
            doctor.ContactInfo=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Specialization:");
            doctor.Specialization = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter Available Hours:");
            doctor.AvailableHours = Convert.ToInt32(Console.ReadLine());

            DoctorServices.AddDoctors(doctor);
            Console.WriteLine("Added Successfully. Press Enter to return.");
            Console.ReadLine();
        }

        public void ListAll()
        {
            Console.Clear();
            Console.WriteLine("------ All Doctors ------");
            var DoctorsData = DoctorServices.GetDoctors();

            if (DoctorsData.Count == 0)
            {
                Console.WriteLine("No data found");

            }
            else
            {
                foreach (var Doctor in DoctorsData)
                {
                    Console.WriteLine($"ID: {Doctor.Id} | Name: {Doctor.FirstName} {Doctor.LastName} | ContactNumber: {Doctor.ContactInfo} | Specialization:{Doctor.Specialization} | LicenseNumber: {Doctor.LicenseNumber}");


                }

            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }

        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("Enter Doctor License Number:");
            string input = Console.ReadLine();
            Guid licenseNum = Guid.Parse(input);

            bool result= DoctorServices.DeleteDoctor(licenseNum);
            if (result)
            {
                Console.WriteLine("Data removed successfully..");
            }
            else
            {
                Console.WriteLine("Data not removed , Invalid id");
            }
        }

        public async Task SaveData()
        {
            await JsonFileHandler.SaveAsync("doctors.json",DoctorServices.GetDoctors());
        }
    }
}
