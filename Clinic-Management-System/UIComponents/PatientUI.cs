using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Clinic_Management_System.Models;
using Clinic_Management_System.Services;


namespace Clinic_Management_System.UIComponents
{
    public class PatientUI
    {
        private bool running = true;

        public async Task PatientManagement()
        {
            while (running)
            {
                Console.WriteLine(@"
                1. Add Patient 
                2. List all Patients
                3. Delete Patient by MRNId
                4. Save & Exit to Main menu
                ");

                int i;
                i=Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        Console.WriteLine("patientaddd");

                        AddPatient();
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

        public void AddPatient()
        {
            Console.WriteLine("---ADD NEW PATIENT-----");
            var patient = new Patient();

            Console.WriteLine("Enter First Name:");
            patient.FirstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            patient.LastName = Console.ReadLine();

            Console.WriteLine("Enter DOB(yyyy-mm-dd):");
            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly dob))
                patient.DateOfBirth = dob;
            else
            {
                Console.WriteLine("Invalid date format.");
                Console.ReadLine();
                return;
            }
            Console.Write("Contact Info: ");
            patient.ContactInfo =Convert.ToInt32( Console.ReadLine());

            Console.Write("Medical Record Number: ");
            patient.MedicalRecordNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Insurance Info: ");
            patient.InsuranceInfo = Console.ReadLine();

            Console.Write("Blood Type: ");
            patient.BloodType = Console.ReadLine();

            Console.Write("Enter allergies (comma separated): ");
            var allergies = Console.ReadLine();
            patient.Allergies = new List<string>(allergies.Split(',', StringSplitOptions.RemoveEmptyEntries));



            PatientService.AddPatient(patient);
            Console.WriteLine("Patient added successfully! Press Enter to return.");
            Console.ReadLine();
        }

        public static void ListAll()
        {
            Console.Clear();
            Console.WriteLine("------ All Patients ------");

            var patients = PatientService.GetAllPatients();

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found.");
            }
            else
            {
                foreach (var patient in patients)
                {
                    Console.WriteLine($"ID: {patient.Id} | Name: {patient.GetFullName()} | Age: {patient.GetAge()} | MRN: {patient.MedicalRecordNumber} | Allergies: {patient.GetAllergyInfo()}");
                }
            }

            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();

        }

        public static void Delete()
        {
            Console.Clear();
            Console.Write("Medical Record Number: ");
            int MRN = Convert.ToInt32(Console.ReadLine());

           var result= PatientService.DeleteByMRN(MRN);

            if (result)
            {
                Console.WriteLine("Patient Data removed");
            }
            else
            {
                Console.WriteLine("Data not removed , check Id");
            }

        }

        public async Task SaveData()
        {
            await JsonFileHandler.SaveAsync("patients.json", PatientService.GetAllForSaving());

        }


    }
}
