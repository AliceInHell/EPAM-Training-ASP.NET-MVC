using System;
using BinarySearch;
using FibonacciNumbers;

namespace ConsoleTests
{
    class Program
    {
        private static int[] _intArray;
        private static BinarySearcher<int> _intSearcher;

        static void Main(string[] args)
        {
            int[] result = FibonacciNumbersGenerator.Generate(15);

            foreach (int value in result)
            {
                Console.WriteLine(value);
            }


            _intArray = new int[6] { 1, 4, 7, 9, 11, 13 };
            _intSearcher = new BinarySearcher<int>(_intArray);

            for (int i = 0; i < _intArray.Length; i++)
            {
                Console.WriteLine(_intSearcher.BinarySearch(_intArray[i]));
            }
            Console.WriteLine(_intSearcher.BinarySearch(5));

            Console.ReadLine();
        }
    }
}
