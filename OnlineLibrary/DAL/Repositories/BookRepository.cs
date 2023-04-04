using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DAL.Interfaces;
using OnlineLibrary.Domain.Entity;

namespace OnlineLibrary.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Book entity)
        {
             await _db.Book.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Book entity)
        {
            _db.Book.Remove(entity);
            _db.SaveChanges();
            return true;
        }

        public async Task<Book> Get(int id)
        {
           return await _db.Book.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book> GetByName(string name)
        {
            return await _db.Book.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task<List<Book>> Select()
        {
            return _db.Book.ToListAsync();
        }
    }
}
