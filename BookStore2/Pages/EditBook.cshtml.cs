using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BookStore2.Pages
{
    public class EditBookModel : PageModel
    {
        public Book book = new Book();
        private readonly IBookRepository _bookRepository;
        private readonly string _connectionString;

        public EditBookModel(IConfiguration configuration, IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        public void OnGet()
        {
            int bookId = int.Parse(Request.Query["bookId"]);
            book = _bookRepository.GetBookData(_connectionString, bookId);
        }

        public void OnPost()
        {
            Book book1 = new Book();
            book1.Title = Request.Form["bookTitle"];
            book1.ISBN = Request.Form["bookISBN"];
            book1.PublisherName = Request.Form["bookPublisher"];
            book1.AuthorName = Request.Form["bookAuthor"];
            book1.CategoryName = Request.Form["bookCategory"];
            book1.BookId = int.Parse(Request.Query["bookId"]);

            _bookRepository.UpdateBook(_connectionString, book1);

            Response.Redirect("./Books");
        }
    }
}
