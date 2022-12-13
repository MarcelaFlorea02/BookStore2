using Domain.Models;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetBooks(string connectionString);
        Book GetBookData(string connectionString, int bookId);
        void CreateBook(string connectionString, Book book);
        void UpdateBook(string connectionString, Book book);
        void DeleteBook(string connectionString, int bookId);
    }
}
