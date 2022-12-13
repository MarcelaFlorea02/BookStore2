using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BookStore2.Pages
{
    public class DeleteBookModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IBookRepository _bookRepository;
        public DeleteBookModel(IConfiguration configuration, IBookRepository bookRepository)
        {
            _configuration = configuration;
            _bookRepository = bookRepository;
        }

        public void OnGet()
        {
            //get bookId from query string parameter 
            int bookId = int.Parse(Request.Query["bookId"]);
            string connectionString = _configuration.GetConnectionString("ConnectionString");
            _bookRepository.DeleteBook(connectionString, bookId);
            Response.Redirect("./Books");
        }
    }
}
