using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookService.Searchers;
using System.IO;

namespace BookService
{
    public class BooksListService
    {
        #region Fields

        public List<Book> books { set; get; }

        #endregion

        #region Methods

        /// <summary>
        /// load books from some file
        /// </summary>
        /// <param name="filePath">path to the existing file</param>
        public void LoadBooks(string filePath)
        {
            if (File.Exists(filePath))
            {
                BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open));

                try
                {
                    while (reader.BaseStream.Length != reader.BaseStream.Position)
                    {
                        books.Add(new Book(reader.ReadString(), reader.ReadString(), reader.ReadString(),
                            reader.ReadString(), reader.ReadInt16(), reader.ReadInt32(),
                                reader.ReadInt32()));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Some troubles with file\n" + e.Message);
                }
                finally
                {
                    reader.Close();
                }
            }
            else
                Console.WriteLine("File does not exists");
        }

        /// <summary>
        /// save books to file
        /// </summary>
        /// <param name="filePath">path or a new file name</param>
        public void SaveBooks(string filePath)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate));

            foreach(Book b in books)
            {
                writer.Write(b.ISBN);
                writer.Write(b.Title);
                writer.Write(b.Author);
                writer.Write(b.PublishingOffice);
                writer.Write(b.PublishingYear);
                writer.Write(b.PagesCount);
                writer.Write(b.Price);
            }

            writer.Close();
        }

        /// <summary>
        /// book list constructor
        /// </summary>
        public BooksListService()
        {
            books = new List<Book>();
        }

        /// <summary>
        /// add book to list
        /// </summary>
        /// <param name="book">nnew book</param>
        public void AddBook(Book book)
        {
            if (books.IndexOf(book) >= 0)
                throw new Exception("Book list contains this book");
            else
                books.Add(book);
        }

        /// <summary>
        /// remove book if list contains it
        /// </summary>
        /// <param name="book">removable book</param>
        public void RemoveBook(Book book)
        {
            if (books.IndexOf(book) >= 0)
                throw new Exception("Book list does not contains this book");
            else
                books.Remove(book);
        }

        /// <summary>
        /// sort books 
        /// </summary>
        /// <param name="comparator">comparator</param>
        public void SortBooks(IComparer<Book> comparator)
        {
            books.Sort(comparator);
        }

        /// <summary>
        /// find books by some field
        /// </summary>
        /// <param name="searcher">searcher</param>
        /// <param name="tag">book field</param>
        /// <returns></returns>
        public List<Book> FindBookByTag(ISearcher searcher, string tag)
        {
            List<Book> tmp = new List<Book>();

            foreach(Book b in books)
            {
                if (searcher.IsMatch(b, tag))
                    tmp.Add(b);
            }

            return tmp;
        }

        #endregion
    }
}
