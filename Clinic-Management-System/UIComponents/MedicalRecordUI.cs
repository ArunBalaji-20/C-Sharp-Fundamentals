using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Management_System.Models;
using Clinic_Management_System.Services;

namespace Clinic_Management_System.UIComponents
{
    public class MedicalRecordUI
    {
        private bool running = true;
        public async Task MedicalRecords()
        {

            while (running)
            {
                Console.WriteLine("1. Get medical records for one patient");
                Console.WriteLine("2. List All Medical Records");
                Console.WriteLine("3. Add a Medical Record");
                Console.WriteLine("4. Save & Exit to Main menu");


                int i;
                i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        Console.WriteLine("Get medical records for one patient");
                        GetOneRecord();
                        break;
                    case 2:
                        Console.WriteLine("List all records");
                        GetAll();
                        break;

                    case 3:
                        Console.WriteLine("Add a record");
                        AddMedicalRecord();
                        break;
                   
                    case 4:
                        Console.WriteLine("exiting");
                        await SaveData();
                        running = false;
                        break;
                }



            }
        }

        public void GetOneRecord()
        {
            int PatientId = ValidatorClass.PatientIdValidator();
            string PatientName=PatientService.GetPatientName(PatientId);
            var result=MedicalRecordService.GetOneRecord(PatientId);
            if (result != null)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("No records found");
            }
               
            
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();


        }

        public void GetAll()
        {
            Console.Clear();
            var records=MedicalRecordService.GetAllRecords();
            foreach (var record in records)
            {
                Console.WriteLine(record + $" | AppointmentId:{record.AppointmentId}"); // Calls your overridden ToString()
            }
            Console.WriteLine("-------------------");
            Console.WriteLine("Press Enter to go back");
            Console.ReadLine();
        }

        public void AddMedicalRecord()
        {
            Console.Clear();
            Console.WriteLine("-----Adding Medical Records------");

            var MedicalRecordObj = new MedicalRecord();

            MedicalRecordObj.PatientId = ValidatorClass.PatientIdValidator();

            MedicalRecordObj.DoctorId = ValidatorClass.DoctorIdValidator();

            MedicalRecordObj.VistedDate = ValidatorClass.DateValidator();

            MedicalRecordObj.AppointmentId = ValidatorClass.AppointmentIdValidator();

            Console.WriteLine("Enter Diagnosis Details:");
            MedicalRecordObj.Diagnosis = Console.ReadLine();

            Console.WriteLine("Enter Treatment Details:");
            MedicalRecordObj.Treatment = Console.ReadLine();

            MedicalRecordService.AddRecord(MedicalRecordObj);

            Console.WriteLine("Record added to the Database.Press Enter to return");
            Console.ReadLine();

        }

        public async Task SaveData()
        {
            await JsonFileHandler.SaveAsync("MedicalRecords.json",MedicalRecordService.GetAllRecords());
        }

    }
}
