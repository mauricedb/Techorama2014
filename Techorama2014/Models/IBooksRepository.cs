using System;
using System.Collections.Generic;

namespace Techorama2014.Models
{
    public interface IBooksRepository : IDisposable
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(Book newBook);
        Book UpdateBook(Book newBook);
        void DeleteBook(int id);
    }
}