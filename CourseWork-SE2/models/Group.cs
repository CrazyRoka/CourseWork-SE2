using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_SE2.models
{
    class Group
    {
        private List<Student> _students;
        public int NumberOfStudents { get => _students.Count; }
        public string Name { get; }
        public Professor Curator { get; }
        public Group(string name, Professor curator, params Student[] students)
        {
            Curator = curator;
            Name = name;
            _students = new List<Student>(students);
        }
        public void AddStudent(Student student) => _students.Add(student);
        public bool DeleteStudent(Student student) => _students.Remove(student);
        public bool ContainsStudent(Student student) => _students.Contains(student);
    }
}
