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
                .With(group => group.Name = group.Speciality + random.Next(1, 7) + random.Next(1, 6))
                .Build();
        }

    }

    public sealed class GroupClassMap : ClassMap<Group> 
    {
        public GroupClassMap()
        {
            Map(m => m.Name).Index(0).Name("Name");
            Map(m => m.Speciality).Index(1).Name("Speciality");
        }
    }
}
