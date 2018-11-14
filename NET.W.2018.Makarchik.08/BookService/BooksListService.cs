using System;
using System.Collections.Generic;
using System.IO;
using BookService.Searchers;
using NLog;

namespace BookService
{
    public class BooksListService
    {
        /// <summary>
        /// Logger from NLog
        /// </summary>
        private Logger _logger;

        /// <summary>
        /// book list constructor
        /// </summary>
        public BooksListService()
        {
            Books = new List<Book>();
            _logger = LogManager.GetCurrentClassLogger();
        }

        #region Properties

        public List<Book> Books { get; set; }

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

                _logger.Trace(string.Format("Reading books from {0}", filePath));

                try
                {
                    while (reader.BaseStream.Length != reader.BaseStream.Position)
                    {
                        Books.Add(new Book(
                            reader.ReadString(),
                            reader.ReadString(),
                            reader.ReadString(),
                            reader.ReadString(),
                            reader.ReadInt16(),
                            reader.ReadInt32(),
                            reader.ReadInt32()));
                    }

                    _logger.Info("Have read new book");
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message);
                }
                finally
                {
                    reader.Close();
                }
            }
            else
            {
                _logger.Error(string.Format("File {0} does not exists", filePath));
            }
        }

        /// <summary>
        /// save books to file
        /// </summary>
        /// <param name="filePath">path or a new file name</param>
        public void SaveBooks(string filePath)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate));

            _logger.Trace(string.Format("Saving books to {0}", filePath));

            foreach (Book b in Books)
            {
                writer.Write(b.ISBN);
                writer.Write(b.Title);
                writer.Write(b.Author);
                writer.Write(b.PublishingOffice);
                writer.Write(b.PublishingYear);
                writer.Write(b.PagesCount);
                writer.Write(b.Price);

                _logger.Info("Another book was written");
            }

            writer.Close();
        }

        /// <summary>
        /// add book to list
        /// </summary>
        /// <param name="book">new book</param>
        public void AddBook(Book book)
        {
            _logger.Trace(string.Format("Adding new book to service"));

            if (Books.IndexOf(book) >= 0)
            {
                _logger.Error(string.Format("Book list contains additing book"));
                throw new Exception("Book list contains this book");
            }
            else
            {
                Books.Add(book);
                _logger.Info(string.Format("Book was added"));
            }
        }

        /// <summary>
        /// remove book if list contains it
        /// </summary>
        /// <param name="book">removable book</param>
        public void RemoveBook(Book book)
        {
            _logger.Trace(string.Format("Removing book from service"));

            if (Books.IndexOf(book) >= 0)
            {
                _logger.Error(string.Format("Book list does not contains removing book"));
                throw new Exception("Book list does not contains this book");
            }
            else
            {
                Books.Remove(book);
                _logger.Info(string.Format("Book was removed"));
            }
        }

        /// <summary>
        /// sort books 
        /// </summary>
        /// <param name="comparator">comparator</param>
        public void SortBooks(IComparer<Book> comparator)
        {
            _logger.Trace(string.Format("Sorting books"));
            Books.Sort(comparator);
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

            foreach (Book b in Books)
            {
                if (searcher.IsMatch(b, tag))
                {
                    tmp.Add(b);
                    _logger.Trace(string.Format("Found some book by tag"));
                }
            }

            return tmp;
        }

        #endregion
    }
}
