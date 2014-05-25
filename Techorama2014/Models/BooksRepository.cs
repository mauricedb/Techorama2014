using System;
using System.Collections.Generic;
using System.Linq;

namespace Techorama2014.Models
{
    public class BooksRepository : IBooksRepository
    {
        private static readonly List<Book> _books;

        static BooksRepository()
        {
            _books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    BookTitle = "The Ultimate Hitchhiker's Guide to the Galaxy",
                    Author = "Douglas Adams",
                    ImageName = "TheUltimateHitchhikersGuide.jpg",
                },
                new Book
                {
                    Id = 2,
                    BookTitle = "2001: A Space Odyssey",
                    Author = "Arthur C. Clarke",
                    ImageName = "2001ASpaceOdyssey.jpg",
                },
                new Book
                {
                    Id = 3,
                    BookTitle = "The War of the Worlds",
                    Author = "H G Wells",
                    ImageName = "TheWaroftheWorlds.jpg",
                },
                new Book
                {
                    Id = 4,
                    BookTitle = "Jurassic Park",
                    Author = "Michael Crichton",
                    ImageName = "JurassicPark.jpg",
                },
                new Book
                {
                    Id = 5,
                    BookTitle = "I, Robot",
                    Author = "Isaac Asimov",
                    ImageName = "IRobot.jpg",
                },
            };
        }

        public List<Book> GetBooks()
        {
            return _books.OrderBy(b => b.Id).ToList();
        }

        public Book GetBook(int id)
        {
            return _books.SingleOrDefault(b => b.Id == id);
        }

        public void Dispose()
        {
        }

        public Book AddBook(Book newBook)
        {
            newBook.Id = Environment.TickCount;
            _books.Add(newBook);

            return newBook;
        }

        public Book UpdateBook(Book newBook)
        {
            Book oldBook = _books.Single(b => b.Id == newBook.Id);
            _books.Remove(oldBook);
            _books.Add(newBook);
            return newBook;
        }


        public void DeleteBook(int id)
        {
            Book oldBook = _books.SingleOrDefault(b => b.Id == id);
            if (oldBook != null)
            {
                _books.Remove(oldBook);
            }
        }
    }
}