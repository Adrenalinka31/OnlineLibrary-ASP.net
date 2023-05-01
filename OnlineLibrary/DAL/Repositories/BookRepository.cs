using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DAL.Interfaces;
using OnlineLibrary.Domain.Entity;

namespace OnlineLibrary.DAL.Repositories
{
    public class BookRepository : IBaseRepository<Book>
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Create(Book entity)
        {
             await _db.Book.AddAsync(entity);
            await _db.SaveChangesAsync();

           
        }
        public async Task Delete(Book entity)
        {
            _db.Book.Remove(entity);
            _db.SaveChanges();
            
        }
        public IQueryable<Book> GetAll()
        {
            return _db.Book;
        }
        public async Task<Book> Update(Book entity)
        {
            _db.Book.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
