using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public class Group
    {
        private SortedSet<Student> _students;
        public int NumberOfStudents { get => _students.Count; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public Professor Curator { get; set; }
        public List<Student> Students { get => _students.ToList(); }
        public Group()
        {

        }
        public Group(string name, string speciality, Professor curator, params Student[] students)
        {
            Curator = curator;
            Name = name;
            Speciality = speciality;
            _students = new SortedSet<Student>(students);
        }
        public void AddStudent(Student student) => _students.Add(student);
        public bool DeleteStudent(Student student) => _students.Remove(student);
        public bool ContainsStudent(Student student) => _students.Contains(student);
    }
}
