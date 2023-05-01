using OnlineLibrary.DAL.Interfaces;
using OnlineLibrary.Domain.Entity;

namespace OnlineLibrary.DAL.Repositories
{
    public class UserRepository : IBaseRepository<Users>
    {
        private readonly ApplicationDbContext _db;

        public UserRepository (ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Users entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Users entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Users> GetAll()
        {
            return _db.Users;
        }

        public async Task<Users> Update(Users entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
