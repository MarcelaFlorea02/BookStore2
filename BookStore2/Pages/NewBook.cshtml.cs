using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BookStore2.Pages
{
    public class NewBookModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IBookRepository _bookRepository;

        public NewBookModel(IConfiguration configuration, IBookRepository bookRepository)
        {
            _configuration = configuration;
            _bookRepository = bookRepository;
        }

        public void OnPost()
        {
            Book book = new Book();
            book.Title = Request.Form["bookTitle"];
            book.ISBN = Request.Form["bookISBN"];
            book.PublisherName = Request.Form["bookPublisher"];
            book.AuthorName = Request.Form["bookAuthor"];
            book.CategoryName = Request.Form["bookCategory"];

            var connectionString = _configuration.GetConnectionString("ConnectionString");
            _bookRepository.CreateBook(connectionString, book);

            Response.Redirect("./Books");
        }
    }
}
