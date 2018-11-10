using CsvHelper;
using CsvHelper.Configuration;
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
    class GroupGenerator
    {
        private static Random random = new Random();
        private static readonly string[] Specialities = { "SE", "CS", "DB", "IOT" };
        public static void GenerateData() => GenerateData("group.dat");
        public static void GenerateData(string fileName) => GenerateData(random.Next(5, 100), fileName);
        public static void GenerateData(int numberOfItems) => GenerateData(numberOfItems, "group.dat");
        public static void GenerateData(int numberOfItems, string fileName)
        {
            Console.WriteLine("Generating groups");
            using (StreamWriter file = new StreamWriter(fileName))
            {
                IList<Group> data = GenerateList(numberOfItems);
                using (CsvWriter writer = new CsvWriter(file))
                {
                    writer.Configuration.RegisterClassMap<GroupClassMap>();
                    writer.WriteRecords(data);
                }
            }
        }
        protected static IList<Group> GenerateList(int numberOfItems)
        {
            return Builder<Group>.CreateListOfSize(numberOfItems).All()
                .With(group => group.Speciality = Specialities[random.Next(Specialities.Length)])
                .With(group => group.Course = random.Next(1, 7))
                .With(group => group.Number = random.Next(1, 15))
                .Build();
        }

    }

    public sealed class GroupClassMap : ClassMap<Group> 
    {
        public GroupClassMap()
        {
            Map(m => m.Speciality).Index(0).Name("Speciality");
            Map(m => m.Course).Index(1).Name("Course");
            Map(m => m.Number).Index(2).Name("Number");
        }
    }
}
