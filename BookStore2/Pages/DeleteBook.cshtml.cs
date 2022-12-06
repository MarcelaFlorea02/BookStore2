using BookStore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BookStore2.Pages
{
    public class DeleteBookModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public DeleteBookModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void OnGet()
        {
            //get bookId from query string parameter 
            int bookId = int.Parse(Request.Query["bookId"]);
            string connectionString = _configuration.GetConnectionString("ConnectionString");
            Book book = new Book();
            book.DeleteBook(connectionString, bookId);

            Response.Redirect("./Books");

        }
    }
}
