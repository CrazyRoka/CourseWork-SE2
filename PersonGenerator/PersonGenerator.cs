using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;
using FizzWare.NBuilder;
using CsvHelper;
using SE2.CourseWork.Models;

namespace SE2.CourseWork.Generators
{
    class PersonGenerator
    {
        private static Random random = new Random();
        public static void GenerateData() => GenerateData("person.dat");
        public static void GenerateData(string fileName) => GenerateData(random.Next(5, 100), fileName);
        public static void GenerateData(int numberOfItems) => GenerateData(numberOfItems, "person.dat");
        public static void GenerateData(int numberOfItems, string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                IList<Person> data = GenerateList(numberOfItems);
                using (CsvWriter writer = new CsvWriter(file))
                {
                    writer.WriteRecords(data);
                }
            }
        }
        protected static IList<Person> GenerateList(int numberOfItems)
        {
            return Builder<Person>.CreateListOfSize(numberOfItems).All()
                .With(person => person.FirstName = Faker.Name.First())
                .With(person => person.MiddleName = Faker.Name.First())
                .With(person => person.LastName = Faker.Name.Last())
                .With(person => person.PhoneNumber = Faker.Phone.Number())
                .With(person => person.BirthdayDate = RandomDay())
                .Build();
        }
        protected static DateTime RandomDay()
        {
            DateTime start = new DateTime(1990, 1, 1);
            DateTime end = new DateTime(2002, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
