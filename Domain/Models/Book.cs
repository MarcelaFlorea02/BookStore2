namespace Domain.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string PublisherName { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
    }
}
