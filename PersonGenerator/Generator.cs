using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE2.CourseWork.Generators
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonGenerator.GenerateData(1000);
            StudentGenerator.GenerateData(1000);
            ProfessorGenerator.GenerateData(1000);
            GroupGenerator.GenerateData(10);
        }
    }
}
