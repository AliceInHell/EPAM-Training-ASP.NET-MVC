using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoubleToString;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DoubleToStringConventor.ConvertDoubleToString(double.PositiveInfinity));
            Console.ReadLine();
        }
    }
}
