using BookStore2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BookStore2.Pages
{
    public class BooksModel : PageModel
    {
        public List<Book> books = new List<Book>();
        public void OnGet()
        {
        }
    }
}
