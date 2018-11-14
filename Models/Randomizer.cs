using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Models
{
    public class Randomizer
    {
        private static Random random = new Random();
        private static readonly string[] Specialities = { "ПЗ", "КН", "БД", "ІР", "КІ", "СА" };
        private static readonly Dictionary<string, string> fullName = new Dictionary<string, string> { { "ПЗ", "Програмне забезпечення" }, { "КН", "Комп'ютерні науки" }, { "БД", "Бази даних" }, { "ІР", "Інтернет речі" }, { "КІ", "Комп'ютерна інженерія" }, { "СА", "Системний аналіз" } };
        private static readonly string[] Subjects = { "Математичний аналіз", "Основи програмування", "Об'єктно орієнтоване програмування", "Дискретна математика", "Чисельні методи", "Основи баз даних", "ВІПЗ", "Алгоритми і структури даних" };
        public static Person generatePerson()
        {
            return new Person(Faker.Name.First(), Faker.Name.First(), Faker.Name.Last(), RandomDay(), RandomNumber());
        }
        public static Professor generateProfessor()
        {
            Professor professor = new Professor();
            professor.FirstName = Faker.Name.First();
            professor.MiddleName = Faker.Name.First();
            professor.LastName = Faker.Name.Last();
            professor.BirthdayDate = RandomDay().ToString("yyyy-MM-dd");
            professor.PhoneNumber = RandomNumber();
            professor.GroupName = RandomGroup().GroupName;
            professor.Subjects = Subjects.OrderBy(x => random.Next()).Take(random.Next(1, Subjects.Length)).ToArray();
            return professor;
        }
        public static Student generateStudent()
        {
            Student student = new Student();
            student.FirstName = Faker.Name.First();
            student.MiddleName = Faker.Name.First();
            student.LastName = Faker.Name.Last();
            student.BirthdayDate = RandomDay().ToString("yyyy-MM-dd");
            student.PhoneNumber = RandomNumber();
            student.GroupName = RandomGroup().GroupName;
            student.AverageScore = decimal.Round((decimal)random.NextDouble() * 100, 2);
            return student;
        }
        protected static DateTime RandomDay()
        {
            DateTime start = new DateTime(1950, 1, 1);
            DateTime end = new DateTime(1990, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(random.Next(range));
        }
        protected static Group RandomGroup()
        {
            string speciality = Specialities[random.Next(Specialities.Length - 1)];
            Group group = new Group(speciality, fullName[speciality], random.Next(1, 7), random.Next(1, 6), null);
            group = GroupsContainer.FindOrCreateGroup(group.GroupName, group.SpecialityFullName);
            return group;
        }
        protected static string RandomNumber()
        {
            string number = "+380";
            for (int i = 0; i < 9; i++)
                number += random.Next(10);
            return number;
        }
    }
}
