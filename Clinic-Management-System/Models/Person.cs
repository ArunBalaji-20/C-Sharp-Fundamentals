using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System.Models
{
    public class Person
    {
        //Id, FirstName, LastName, DateOfBirth, ContactInfo
        private static int _nextId = 1;
        public  int Id { get; private set; }
        public  string FirstName { get; set; }

        public string LastName { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }

        public int ContactInfo { get; set; }

        //GetFullName(), GetAge(), GetContactDetails()

        public Person()
        {
            Id = _nextId++;
        }


        public virtual string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public virtual int GetAge()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - DateOfBirth.Year;

            // If birthday hasn't occurred yet this year, subtract 1
            if (today < DateOnly.FromDateTime(DateTime.Today).AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public virtual string GetContactDetails()
        {
            return $"{ContactInfo}";
        }


    }
}
