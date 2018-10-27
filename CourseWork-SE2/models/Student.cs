using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_SE2.models
{
    class Student : Person
    {
        public int Course { get; set; }
        public Group Group { get; set; }
        public string Speciality { get => Group.Speciality; }
        public decimal AverageScore { get; set; }
        public Student(string firstName, string secondName, string thirdName, DateTime birthdayDate, string phoneNumber, int course, Group group, decimal averageScore) : base(firstName, secondName, thirdName, birthdayDate, phoneNumber)
        {
            Course = course;
            Group = group;
            AverageScore = averageScore;
        }
        public Student(Student clone) : base(clone)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
