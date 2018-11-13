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
        public static void GenerateData() => GenerateData("vykladach.dat");
        public static void GenerateData(string fileName) => GenerateData(random.Next(5, 100), fileName);
        public static void GenerateData(int numberOfItems) => GenerateData(numberOfItems, "vykladach.dat");
        public static void GenerateData(int numberOfItems, string fileName)
        {
            Console.WriteLine("Generating professors");
            StreamWriter file = new StreamWriter(fileName);
            IList<Professor> data = GenerateList(numberOfItems);
            foreach (Professor professor in data)
            {
                file += professor;
            }
        }
        protected static IList<Professor> GenerateList(int numberOfItems)
        {
            IList<Professor> list = new List<Professor>(numberOfItems);
            for (int i = 0; i < numberOfItems; i++)
                list.Add(Randomizer.generateProfessor());
            return list;
        }
    }
}
