using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public class Professor : Person
    {
        public string[] Subjects { get; set; }
        public Group Group { get; set; }
        public Professor() : base()
        {

        }
        public Professor(string firstName, string middleName, string lastName, DateTime birthdayDate, string phoneNumber, Group group, params string[] subjects) : base(firstName, middleName, lastName, birthdayDate, phoneNumber)
        {
            Subjects = subjects;
            Group = group;
        }
        public Professor(Professor clone) : base(clone)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
