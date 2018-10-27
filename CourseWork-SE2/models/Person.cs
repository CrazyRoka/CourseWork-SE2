using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_SE2.models
{
    class Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string PhoneNumber { get; set; }
        public Person(string firstName, string secondName, string thirdName, DateTime birthdayDate, string phoneNumber)
        {
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
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
