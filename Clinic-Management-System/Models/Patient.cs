using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Models
{
    public class Patient : Person
    {
        //MedicalRecordNumber, InsuranceInfo, BloodType, Allergies…

        public  int MedicalRecordNumber {get; set; }

        public string InsuranceInfo { get; set; }

        public string BloodType { get; set; }

        public List<string> Allergies { get; set; } = new List<string>();

        public override string GetContactDetails()
        {
            return $"{base.GetContactDetails()}, MRN: {MedicalRecordNumber}, Blood Type: {BloodType}";
        }

        public string GetAllergyInfo()
        {
            return Allergies.Count > 0 ? string.Join(", ", Allergies) : "NO Allergies"; 
        }
    }
}
