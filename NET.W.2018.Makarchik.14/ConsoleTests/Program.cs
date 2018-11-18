using BinarySearchTree;
using BookService;
using BookService.Comparators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatrixGenerator;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // Queue tests
            Queue.Queue<int> queue = new Queue.Queue<int>(5);

            queue.Push(1);
            queue.Push(2);
            queue.Push(3);
            queue.Push(4);
            queue.Push(5);
            queue.Push(6);

            Console.WriteLine(queue.Count);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(queue.Pop());
            }

            Console.WriteLine();

            foreach(int item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Pop());

            Console.WriteLine();

            // Tree tests
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(
                new AuthorComparer(),
                new Book[] {
                    new Book("ISBN", "Title", "C", "PublishingHous", 2005, 200, 50),
                    new Book("ISBN", "Title", "B", "PublishingHous", 2005, 200, 50),
                    new Book("ISBN", "Title", "A", "PublishingHous", 2005, 200, 50),
                    new Book("ISBN", "Title", "E", "PublishingHous", 2005, 200, 50),
                    new Book("ISBN", "Title", "D", "PublishingHous", 2005, 200, 50)
                });

            foreach (Book s in tree.DirectBypass().ToList())
            {
                Console.WriteLine(s);
            }

            // Matrix generator tests        
            Generator<int> g = new Generator<int>();
            Matrix<int> intMatrix = g.GenearteDiagonalMatrix(5, new int[5] { 1, 2, 3, 4, 5 });

            intMatrix.MatrixElementChangeEvent += MyConsoleEvent;

            intMatrix[2, 4] = 15;

            // Summ test
            Matrix<int> first = new Matrix<int>(2);
            first[0, 0] = 1;
            first[0, 1] = 2;
            first[1, 0] = 3;
            first[1, 1] = 4;

            Matrix<int> second = new Matrix<int>(2);
            second[0, 0] = 4;
            second[0, 1] = 3;
            second[1, 0] = 2;
            second[1, 1] = 1;

            Matrix<int> result = first + second;
            
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    Console.Write(result[i, j] + "   ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public static void MyConsoleEvent(object sender, MatrixElementChangeEventArgs<int> e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
