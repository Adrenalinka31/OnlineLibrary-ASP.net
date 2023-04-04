using OnlineLibrary.Domain.Entity;

namespace OnlineLibrary.DAL.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book> GetByName(string name);

    }
}
