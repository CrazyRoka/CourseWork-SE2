using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_SE2.models
{
    class Professor : Person
    {
        public string[] Subjects { get; set; }
        public Group Group { get; set; }
        public Professor(string firstName, string secondName, string thirdName, DateTime birthdayDate, string phoneNumber, Group group, params string[] subjects) : base(firstName, secondName, thirdName, birthdayDate, phoneNumber)
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
