using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public class Person
    {
        protected DateTime _birthdayDate;
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BirthdayDate { get => _birthdayDate.ToString("yyyy-MM-dd"); set => _birthdayDate = DateTime.Parse(value); }
        public string PhoneNumber { get; set; }
        public string FullName() => $"{LastName} {FirstName} {MiddleName}";
        public Person()
        {

        }
        public Person(string firstName, string middleName, string lastName, DateTime birthdayDate, string phoneNumber)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            _birthdayDate = birthdayDate;
            PhoneNumber = phoneNumber;
        }
        public Person(Person clone) : this(clone.FirstName, clone.MiddleName, clone.LastName, clone._birthdayDate, clone.PhoneNumber)
        {

        }
        public override string ToString()
        {
            return $"{FullName()} {BirthdayDate} {PhoneNumber}";
        }
    }
}
