using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public class Student : Person
    {
        public Group Group { get; set; }
        public string GroupName { get => Speciality + Group.Number; }
        public string Speciality { get => Group.Speciality; }
        public int Course { get => Group.Course; }
        public decimal AverageScore { get; set; }
        public Student() : base()
        {

        }
        public Student(string firstName, string middleName, string lastName, DateTime birthdayDate, string phoneNumber, Group group, decimal averageScore) : base(firstName, middleName, lastName, birthdayDate, phoneNumber)
        {
            Group = group;
            AverageScore = averageScore;
        }
        public Student(Student clone) : this(clone.FirstName, clone.MiddleName, clone.LastName, clone._birthdayDate, clone.PhoneNumber, clone.Group, clone.AverageScore)
        {

        }
    }
}
