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

            Console.ReadLine();
        }

        public static void MyConsoleEvent(object sender, MatrixElementChangeEventArgs<int> e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
