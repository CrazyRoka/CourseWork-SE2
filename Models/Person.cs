using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string PhoneNumber { get; set; }
        public Person()
        {

        }
        public Person(string firstName, string middleName, string lastName, DateTime birthdayDate, string phoneNumber)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthdayDate = birthdayDate;
            PhoneNumber = phoneNumber;
        }
        public Person(Person clone)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
