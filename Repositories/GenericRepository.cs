using BookmarkNotesApp.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkNotesApp.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly SQLiteAsyncConnection _db;

        public GenericRepository(AppDbContext context)
        {
            _db = context.Connection;
        }

        public Task<List<T>> GetAllAsync() => _db.Table<T>().ToListAsync();

        public Task<T> GetByIdAsync(int id) => _db.FindAsync<T>(id);

        public Task<List<T>> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
            => _db.Table<T>().Where(predicate).ToListAsync();

        public Task<int> AddAsync(T entity) => _db.InsertAsync(entity);

        public Task<int> UpdateAsync(T entity) => _db.UpdateAsync(entity);

        public Task<int> DeleteAsync(T entity) => _db.DeleteAsync(entity);
    }
}
