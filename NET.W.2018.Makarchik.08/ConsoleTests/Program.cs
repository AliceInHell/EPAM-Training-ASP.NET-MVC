using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookService;
using BookService.Searchers;
using BankAccount;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // BookListService demonstration
            BooksListService newService = new BooksListService();

            newService.AddBook(new Book("someISBN", "someTitle", "someAuthor", 
                "someOffice", 2018, 150, 50));
            newService.AddBook(new Book("anotherISBN", "anotherTitle", "anotherAuthor",
                "anotherOffice", 2015, 100, 56));
            newService.AddBook(new Book("andAnotherISBN", "andAnotherTitle", "andAnotherAuthor",
                "andAnotherOffice", 2011, 170, 52));

            newService.SortBooks(new TitleComparator());

            foreach (Book b in newService.books)
                Console.WriteLine(b);

            newService.SaveBooks("./Books.bin");

            newService.books.Clear();
            newService.LoadBooks("./Books.bin");

            List<Book> tmp = newService.FindBookByTag(new TitleSearcher(), "anotherTitle");
            foreach (Book b in tmp)
                Console.WriteLine(b);

            // BankAccount demonstration

            Account myAccount = new Account(12345, "Vadim", "Makarchik");
            myAccount.AddCash(Currency.USD, new GoldCash());
            myAccount.Replenish(Currency.USD, 10000.0);
            myAccount.Debit(Currency.USD, 50.0);

            Console.WriteLine(myAccount.getAmount(Currency.USD));
            Console.WriteLine(myAccount.getBonuce());

            Console.ReadLine();
        }
    }
}
