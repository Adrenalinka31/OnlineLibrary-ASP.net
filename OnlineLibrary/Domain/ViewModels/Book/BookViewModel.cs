namespace OnlineLibrary.Domain.ViewModels.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImageURL { get; set; }
        public string BookYear { get; set; }
    }
}
