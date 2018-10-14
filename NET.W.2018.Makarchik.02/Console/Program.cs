using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntMerger;
using FilterDigit;
using NthRootSearcher;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IntMerger.IntMerger.Merge(8, 15, 3, 8));

            long time;
            Console.WriteLine(BiggerNubmerSearcher.BiggerNubmerSearcher.FindNextBiggerNumber
                (1234321, out time));

            RootCalculator.FindNthRoot(0.004241979, 9, 0.00000001);

            Console.ReadLine();
        }
    }
}
