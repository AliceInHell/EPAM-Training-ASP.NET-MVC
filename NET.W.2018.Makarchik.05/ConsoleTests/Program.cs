using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JaggedArraySort;

namespace Polynomial
{
    class Program
    {
        private static int[][] intArray = new int[][]
        {
            new int[] {1, 6, 9 },
            new int[] { -1, -5, 2, 7, 9},
            new int[] { },
            new int[] {0, 11, 12},
            new int[] {-10, 6, 4, 50},
            new int[] {0}
        };

        static void Main(string[] args)
        {
            JuggedArray array = new JuggedArray(intArray);
            array.DescendingSortByMinElement();
            Console.WriteLine(array);
        }
    }
}
