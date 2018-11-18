using BinarySearchTree;
using BookService;
using BookService.Comparators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTreeUnitTest
{
    [TestClass]
    public class BinarySearchTreeUnitTestClass
    {
        [TestMethod]
        public void BinarySearchTreeAddMethodTest()
        {
            BinarySearchTree<int> binTree = new BinarySearchTree<int>(Comparer<int>.Default, new List<int> { 1, 2, 3 });
            binTree.Add(5);
            CollectionAssert.AreEqual(
                binTree.DirectBypass().ToList(), 
                new BinarySearchTree<int>(Comparer<int>.Default, new List<int> { 1, 2, 3, 5 }).DirectBypass().ToList());
        }

        [TestMethod]
        public void BinarySearchTreeBypassesTests()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(Comparer<string>.Default, new string[] { "5", "4", "1", "7", "6", "9", "8" });
            string[] direct = new string[7] { "5", "4", "1", "7", "6", "9", "8" };
            string[] symmetrical = new string[7] { "1", "4", "5", "6", "7", "8", "9" };
            string[] reverce = new string[7] { "1", "4", "6", "8", "9", "7", "5" };

            CollectionAssert.AreEqual(direct, tree.DirectBypass().ToList());
            CollectionAssert.AreEqual(symmetrical, tree.SymmetricalBypass().ToList());
            CollectionAssert.AreEqual(reverce, tree.ReverseBypass().ToList());
        }

        [TestMethod]
        public void BinarySearchTreeBookBypassesTests()
        {
            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(
                new AuthorComparer(),
                new Book[] {
                    new Book("ISBN", "Title", "C", "PublishingHous", 2005, 200, 50),
                    new Book("ISBN", "Title", "B", "PublishingHous", 2005, 200, 50),
                    new Book("ISBN", "Title", "A", "PublishingHous", 2005, 200, 50),
                    new Book("ISBN", "Title", "E", "PublishingHous", 2005, 200, 50),
                    new Book("ISBN", "Title", "D", "PublishingHous", 2005, 200, 50)
                });

            List<Book> direct = new List<Book>() {
                new Book("ISBN", "Title", "C", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "B", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "A", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "E", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "D", "PublishingHous", 2005, 200, 50)
            };

            List<Book> symmetrical = new List<Book>() {
                new Book("ISBN", "Title", "A", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "B", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "C", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "D", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "E", "PublishingHous", 2005, 200, 50)
            };
            List<Book> reverce = new List<Book>() {
                new Book("ISBN", "Title", "A", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "B", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "D", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "E", "PublishingHous", 2005, 200, 50),
                new Book("ISBN", "Title", "C", "PublishingHous", 2005, 200, 50)
            };

            CollectionAssert.AreEqual(direct, tree.DirectBypass().ToList());
            CollectionAssert.AreEqual(symmetrical, tree.SymmetricalBypass().ToList());
            CollectionAssert.AreEqual(reverce, tree.ReverseBypass().ToList());
        }
    }
}
