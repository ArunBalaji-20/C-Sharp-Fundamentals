using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Models
{
    public class Staff : Person
    {
        //Position, Department, HireDate

        public string Position { get; set; }

        public string Department { get; set; }

        public DateOnly HireDate { get; set; }

        public override string GetContactDetails()
        {
            //var data= base.GetContactDetails();

            return $"{base.GetContactDetails()} , Position: {Position} , Department: {Department}";
        }
    }
}
