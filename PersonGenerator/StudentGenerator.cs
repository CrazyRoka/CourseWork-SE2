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
    public class StudentGenerator
    {
        private static Random random = new Random();
        private static readonly string[] Specialities = { "SE", "CS", "DB", "IOT" };
        public static void GenerateData() => GenerateData("student.dat");
        public static void GenerateData(string fileName) => GenerateData(random.Next(5, 100), fileName);
        public static void GenerateData(int numberOfItems) => GenerateData(numberOfItems, "student.dat");
        public static void GenerateData(int numberOfItems, string fileName)
        {
            Console.WriteLine("Generating students");
            using (StreamWriter file = new StreamWriter(fileName))
            {
                IList<Student> data = GenerateList(numberOfItems);
                foreach(Student student in data)
                {
                    file += student;
                }
            }
        }
        protected static IList<Student> GenerateList(int numberOfItems)
        {
            return Builder<Student>.CreateListOfSize(numberOfItems).All()
                .With(student => student.FirstName = Faker.Name.First())
                .With(student => student.MiddleName = Faker.Name.First())
                .With(student => student.LastName = Faker.Name.Last())
                .With(student => student.PhoneNumber = RandomNumber())
                .With(student => student.BirthdayDate = RandomDay().ToString())
                .With(student => student.AverageScore = (decimal) random.NextDouble() * 100)
                .With(student => student.Group = RandomGroup())
                .Build();
        }
        protected static DateTime RandomDay()
        {
            DateTime start = new DateTime(1990, 1, 1);
            DateTime end = new DateTime(2002, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(random.Next(range));
        }
        protected static Group RandomGroup()
        {
            return new Group(Specialities[random.Next(Specialities.Length - 1)], random.Next(1, 7), random.Next(1, 6), null, null);
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
