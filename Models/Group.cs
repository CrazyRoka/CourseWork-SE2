using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public class Group
    {
        private List<Student> _students;
        private Professor _curator;
        public int NumberOfStudents { get => _students.Count; }
        public string Speciality { get; set; }
        public string SpecialityFullName { get; set; }
        public int Course { get; set; }
        public int Number { get; set; }
        public Professor Curator { get => _curator; set { if (_curator != null) _curator.Group = null; _curator = value; } }
        public string GroupName { get => Speciality + Course + Number; }
        public string CuratorsName { get => Curator?.FullName(); }
        public List<Student> Students { get => _students.ToList(); }
        public Group()
        {

        }
        public Group(string speciality, string specialityFullName, int course, int number, Professor curator, params Student[] students)
        {
            Speciality = speciality;
            SpecialityFullName = specialityFullName;
            Course = course;
            Number = number;
            Curator = curator;
            _students = new List<Student>(students);
        }
        public Group(string groupName, string specialityName)
        {
            Regex regex = new Regex(@"\A(\p{Lu}+)([1-6])([0-9]+)\z");
            if (regex.IsMatch(groupName)){
                Match match = regex.Match(groupName);
                Speciality = match.Groups[1].Value;
                Course = int.Parse(match.Groups[2].Value);
                Number = int.Parse(match.Groups[3].Value);
                SpecialityFullName = specialityName;
                _students = new List<Student>();
            }
            else
            {
                throw new FormatException("Invalid group name!");
            }
        }
        public void AddStudent(Student student) => _students.Add(student);
        public bool DeleteStudent(Student student) => _students.Remove(student);
        public bool ContainsStudent(Student student) => _students.Contains(student);
    }
}
