using OnlineLibrary.Domain.Enum;

namespace OnlineLibrary.Domain.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public TypeBook Category { get; set; }
        public string ImageURL { get; set; }
        public string BookYear { get; set; }

    }
}
