using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Clinic_Management_System.Models
{
    public class Doctor : Person
    {
        //Specialization, LicenseNumber(Unique ID provided to physicians), AvailableHours

        public string Specialization { get; set; }

        public Guid LicenseNumber { get; set; }

        public int AvailableHours { get; set; }

        public Doctor()
        {
            LicenseNumber = SetGuid(); // Automatically assign a new GUID
        }
        public override string GetContactDetails()
        {
            var number= base.GetContactDetails();
            return $"Number: {number} | Specialization: {Specialization} | AvailableHours:{AvailableHours}";
        }

        public static Guid SetGuid()
        {
            Guid newId = Guid.NewGuid();
            //Console.WriteLine(newId);
            return newId;
        }
    }
}
