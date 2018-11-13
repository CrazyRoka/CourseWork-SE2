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
            return new Professor(Faker.Name.First(), Faker.Name.First(), Faker.Name.Last(), RandomDay(),
                    RandomNumber(), RandomGroup(), Subjects.OrderBy(x => random.Next()).Take(random.Next(1, Subjects.Length)).ToArray());
        }
        public static Student generateStudent()
        {
            return new Student(Faker.Name.First(), Faker.Name.First(), Faker.Name.Last(), RandomDay(),
                RandomNumber(), RandomGroup(), decimal.Round((decimal)random.NextDouble() * 100, 2));
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
            return new Group(speciality, fullName[speciality], random.Next(1, 7), random.Next(1, 6), null);
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
