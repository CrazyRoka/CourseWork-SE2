using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public class Professor : Person
    {
        // приватне поле групи
        private Group _group;
        // публічні поля (гетери та сетери)
        public string[] Subjects { get; set; }
        public string SubjectList { get => string.Join(", ", Subjects); set => Subjects = value.Split(',').Select(s => s.Trim()).ToArray(); }
        public string GroupName { get => Group?.GroupName; set => Group = GroupsContainer.FindOrCreateGroup(value, Speciality); }
        public string Speciality { get => Group?.SpecialityFullName ?? ""; set => Group.SpecialityFullName = value; }
        public Group Group
        {
            get => _group;
            set
            {
                if(_group != null) _group.Curator = null;
                _group = value;
                if(_group != null)
                {
                    Professor previousCurator = _group.Curator;
                    if (previousCurator != null) previousCurator._group = null;
                    _group.Curator = this;
                }

            }
        }
        // конструктори класу
        public Professor() : base()
        {

        }
        public Professor(string firstName, string middleName, string lastName, DateTime birthdayDate, string phoneNumber, Group group, params string[] subjects) : base(firstName, middleName, lastName, birthdayDate, phoneNumber)
        {
            Subjects = subjects;
            Group = group;
        }
        public Professor(Professor clone) : this(clone.FirstName, clone.MiddleName, clone.LastName, clone._birthdayDate, clone.PhoneNumber, clone.Group, clone.Subjects)
        {

        }
        // перезавантажені оператори для зчитування / запису з файлів
        public static StreamWriter operator +(StreamWriter writer, Professor professor)
        {
            writer.WriteLine($"{professor.FirstName},{professor.MiddleName}" +
                $",{professor.LastName},{professor.BirthdayDate},{professor.PhoneNumber}," +
                $"{professor.GroupName},{professor.Speciality},{string.Join(";", professor.Subjects)}");
            return writer;
        }
        public static StreamReader operator -(StreamReader reader, Professor professor)
        {
            string line = reader.ReadLine();
            string[] parts = line.Split(',');
            professor.FirstName = parts[0]; professor.MiddleName = parts[1]; professor.LastName = parts[2]; professor.BirthdayDate = parts[3];
            professor.PhoneNumber = parts[4]; professor.Group = GroupsContainer.FindOrCreateGroup(parts[5], parts[6]);
            professor.Subjects = parts[7].Split(';');
            professor.Group.Curator = professor;
            return reader;
        }
    }
}
