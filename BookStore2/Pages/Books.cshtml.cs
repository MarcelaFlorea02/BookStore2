using BookStore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BookStore2.Pages
{
    public class BooksModel : PageModel
    {
        public List<Book> books = new List<Book>();
        private readonly IConfiguration _configuration;

        //dependency injection 
        public BooksModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //gets called when the page loads
        public void OnGet()
        {
            books = GetBookList();
        }

        private List<Book> GetBookList()
        {
            var connectionString = _configuration.GetConnectionString("ConnectionString");
            var book = new Book();
            var books = book.GetBooks(connectionString);
            return books;

        }
    }
}
