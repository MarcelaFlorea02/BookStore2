using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BookStore2.Pages
{
    public class BooksModel : PageModel
    {
        public List<Book> books = new List<Book>();
        private readonly IConfiguration _configuration;
        private readonly IBookRepository _bookRepository;

        private readonly ILogger<BooksModel> _logger;
        //dependency injection 
        public BooksModel(IConfiguration configuration, ILogger<BooksModel> logger,
            IBookRepository bookRepository)
        {
            _configuration = configuration;
            _logger = logger;
            _bookRepository = bookRepository;
        }

        //gets called when the page loads
        public void OnGet()
        {
            books = GetBookList();
        }

        private List<Book> GetBookList()
        {
            var connectionString = _configuration.GetConnectionString("ConnectionString");
            var books = _bookRepository.GetBooks(connectionString);
            _logger.LogInformation("Got all books");
            return books;
        }
    }
}
