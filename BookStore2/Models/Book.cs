using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BookStore2.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string PublisherName { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }

        //Get all books 
        public List<Book> GetBooks(string connectionString)
        {
            List<Book> books = new List<Book>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select BookId, Title, ISBN, PublisherName, AuthorName, CategoryName from GetBookData";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        Book book = new Book();
                        book.BookId = int.Parse(sqlDataReader["BookId"].ToString());
                        book.Title = sqlDataReader["Title"].ToString();
                        book.ISBN = sqlDataReader["ISBN"].ToString();
                        book.PublisherName = sqlDataReader["PublisherName"].ToString();
                        book.AuthorName = sqlDataReader["AuthorName"].ToString();
                        book.CategoryName = sqlDataReader["CategoryName"].ToString();

                        books.Add(book);
                    }
                }
                return books;
            }
        }

        //Get one book 
        public Book GetBookData(string connectionString, int bookId)
        {
            Book book = new Book();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select BookId, Title, ISBN, PublisherName, AuthorName, CateogoryName from GetBookData where BookId = " + bookId;
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        book.BookId = int.Parse(sqlDataReader["BookId"].ToString());
                        book.Title = sqlDataReader["Title"].ToString();
                        book.ISBN = sqlDataReader["ISBN"].ToString();
                        book.PublisherName = sqlDataReader["PublisherName"].ToString();
                        book.AuthorName = sqlDataReader["AuthorName"].ToString();
                        book.CategoryName = sqlDataReader["Category"].ToString();
                    }
                }
            }
            return book;
        }

        //Create book 
        public void CreateBook(string connectionString, Book book)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("CreateBook", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Title", book.Title));
                    command.Parameters.Add(new SqlParameter("@ISBN", book.ISBN));
                    command.Parameters.Add(new SqlParameter("@PublisherName", book.PublisherName));
                    command.Parameters.Add(new SqlParameter("@AuthorName", book.AuthorName));
                    command.Parameters.Add(new SqlParameter("@CategoryName", book.CategoryName));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // log exception 
            }
        }

        //Update Book 
        public void UpdateBook(string connectionString, Book book)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("UpdateBook", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@BookId", book.BookId));
                sqlCommand.Parameters.Add(new SqlParameter("@Title", book.Title));
                sqlCommand.Parameters.Add(new SqlParameter("@ISBN", book.ISBN));
                sqlCommand.Parameters.Add(new SqlParameter("@PublisherName", book.PublisherName));
                sqlCommand.Parameters.Add(new SqlParameter("@AuthorName", book.AuthorName));
                sqlCommand.Parameters.Add(new SqlParameter("@CategoryName", book.CategoryName));

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //log exception
            }
        }

        //delete book 
        public void DeleteBook(string connectionString, int bookId)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("DeleteBook", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@BookId", bookId));

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //log exception
            }
        }

    }
}
