using BookStore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BookStore2.Pages
{
    public class NewBookModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public NewBookModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
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
            book.CreateBook(connectionString, book);

            Response.Redirect("./Books"); 

        }
    }
}
