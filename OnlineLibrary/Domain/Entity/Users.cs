using OnlineLibrary.Domain.Enum;

namespace OnlineLibrary.Domain.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
