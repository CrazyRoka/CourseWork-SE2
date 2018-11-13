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
        public static void GenerateData() => GenerateData("student.dat");
        public static void GenerateData(string fileName) => GenerateData(random.Next(5, 100), fileName);
        public static void GenerateData(int numberOfItems) => GenerateData(numberOfItems, "student.dat");
        public static void GenerateData(int numberOfItems, string fileName)
        {
            Console.WriteLine("Generating students");
            StreamWriter file = new StreamWriter(fileName);
            IList<Student> data = GenerateList(numberOfItems);
            foreach (Student student in data)
            {
                file += student;
            }
            file.Close();
        }
        protected static IList<Student> GenerateList(int numberOfItems)
        {
            IList<Student> list = new List<Student>(numberOfItems);
            for (int i = 0; i < numberOfItems; i++)
                list.Add(Randomizer.generateStudent());
            return list;
        }
    }
}
