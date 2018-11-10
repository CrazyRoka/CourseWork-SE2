using CsvHelper;
using FizzWare.NBuilder;
using SE2.CourseWork.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Generators
{
    public class ProfessorGenerator
    {
        private static Random random = new Random();
        private static readonly string[] Specialities = { "ПЗ", "КН", "БД", "ІР", "КІ", "СА" };
        private static readonly Dictionary<string, string> fullName = new Dictionary<string, string> { { "ПЗ", "Програмне забезпечення" }, { "КН", "Комп'ютерні науки" }, { "БД", "Бази даних" }, { "ІР", "Інтернет речі" }, { "КІ", "Комп'ютерна інженерія" }, { "СА", "Системний аналіз" } };
        private static readonly string[] Subjects = { "Математичний аналіз", "Основи програмування", "Об'єктно орієнтоване програмування", "Дискретна математика", "Чисельні методи", "Основи баз даних", "ВІПЗ", "Алгоритми і структури даних" };
        public static void GenerateData() => GenerateData("vykladach.dat");
        public static void GenerateData(string fileName) => GenerateData(random.Next(5, 100), fileName);
        public static void GenerateData(int numberOfItems) => GenerateData(numberOfItems, "vykladach.dat");
        public static void GenerateData(int numberOfItems, string fileName)
        {
            Console.WriteLine("Generating professors");
            StreamWriter file = new StreamWriter(fileName);
            try
            {
                IList<Professor> data = GenerateList(numberOfItems);
                foreach (Professor professor in data)
                {
                    file += professor;
                }
            }
            finally
            {
                file.Close();
            }
        }
        protected static IList<Professor> GenerateList(int numberOfItems)
        {
            IList<Professor> list = new List<Professor>(numberOfItems);
            for (int i = 0; i < numberOfItems; i++)
            {
                list.Add(new Professor(Faker.Name.First(), Faker.Name.First(), Faker.Name.Last(), RandomDay(), 
                    RandomNumber(), RandomGroup(), Subjects.OrderBy(x => random.Next()).Take(random.Next(1, Subjects.Length)).ToArray()));
            }
            return list;
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
            return new Group(speciality,  fullName[speciality], random.Next(1, 7), random.Next(1, 6), null);
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
