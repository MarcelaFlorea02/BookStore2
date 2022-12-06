using BookStore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BookStore2.Pages
{
    public class EditBookModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public Book book = new Book();

        public EditBookModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            int bookId = int.Parse(Request.Query["bookId"]);
            var connectionString = _configuration.GetConnectionString("ConnectionString");
            Book book1 = new Book();
            book = book1.GetBookData(connectionString, bookId);
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

            var connectionString = _configuration.GetConnectionString("ConnectionString");
            book1.UpdateBook(connectionString, book1);

            Response.Redirect("./Books");
        }
    }
}
