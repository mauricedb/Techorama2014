using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Techorama2014.Models;

namespace Techorama2014.Api
{
    public class BooksController : ApiController
    {
        private readonly IBooksRepository _repo = new BooksRepository();

        // GET api/books
        public IQueryable<Book> Get()
        {
            return _repo.GetBooks().AsQueryable();
        }

        // GET api/books/5
        public HttpResponseMessage Get(int id)
        {
            Book book = _repo.GetBook(id);
            if (book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, book);
        }

        // POST api/books
        public HttpResponseMessage Post(Book book)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                Book addedBook = _repo.AddBook(book);
                HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.Created, addedBook);
                result.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = addedBook.Id}));
                return result;
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT api/books/5
        public HttpResponseMessage Put(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                if (book.Id != id)
                {
                    throw new ValidationException("Invalid book ID.");
                }
                Book updatedBook = _repo.UpdateBook(book);
                return Request.CreateResponse(HttpStatusCode.OK, updatedBook);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE api/books/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _repo.DeleteBook(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}