using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Management_System.Services;

namespace Clinic_Management_System.UIComponents
{
    public class MaintainanceUI
    {
        private bool running = true;

        public async Task Maintainance()
        {
            while (running)
            {
                Console.WriteLine(@"
                1. Reset Patients records 
                2. Reset Doctor records 
                3. Reset Medical records 
                4. Reset Appointment records 
                5. Save & Exit to Main menu
                ");

                int i;
                i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 1:
                        Console.WriteLine("Reset Patients records");
                        ResetRecords("patients.json");
                        break;

                    case 2:
                        Console.WriteLine("Reset Doctor records ");
                        ResetRecords("doctors.json");
                        break;
                    case 3:
                        Console.WriteLine(" Reset Medical records ");
                        ResetRecords("MedicalRecords.json");
                        break;
                    case 4:
                        Console.WriteLine(" Reset Appointment records ");
                        ResetRecords("appointments.json");
                        break;
                    case 5:
                        Console.WriteLine("exiting");
                        //await SaveData();
                        running = false;
                        break;
                }



            }

        }
        public async Task ResetRecords(string RecordName)
        {
            await JsonFileHandler.SaveAsync(RecordName, new List<object>());
        }
    }
}
