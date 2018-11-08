using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public class Group
    {
        private SortedSet<Student> _students;
        public int NumberOfStudents { get => _students.Count; }
        public string Speciality { get; set; }
        public int Course { get; set; }
        public int Number { get; set; }
        public Professor Curator { get; set; }
        public string GroupName { get => Speciality + Course + Number; }
        public string CuratorsName() => Curator?.FullName() ?? "";
        public List<Student> Students { get => _students.ToList(); }
        public Group()
        {

        }
        public Group(string speciality, int course, int number, Professor curator, params Student[] students)
        {
            Speciality = speciality;
            Course = course;
            Number = number;
            Curator = curator;
            Speciality = speciality;
            _students = new SortedSet<Student>(students);
        }
        public Group(string groupName)
        {
            // TODO
            throw new NotImplementedException();
        }
        public void AddStudent(Student student) => _students.Add(student);
        public bool DeleteStudent(Student student) => _students.Remove(student);
        public bool ContainsStudent(Student student) => _students.Contains(student);
    }
}
