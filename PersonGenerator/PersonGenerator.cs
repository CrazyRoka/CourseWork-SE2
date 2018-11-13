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
            Console.WriteLine("Generating persons");
            StreamWriter file = new StreamWriter(fileName);
            IList<Person> data = GenerateList(numberOfItems);
            foreach (Person person in data)
            {
                file += person;
            }
            file.Close();
        }
        protected static IList<Person> GenerateList(int numberOfItems)
        {
            List<Person> list = new List<Person>();
            for (int i = 0; i < numberOfItems; i++)
                list.Add(Randomizer.generatePerson());
            return list;
        }
    }
}
