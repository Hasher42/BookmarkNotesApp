using BookmarkNotesApp.Data;
using BookmarkNotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkNotesApp.Repositories
{
    public class BookmarkRepository : GenericRepository<Bookmark>, IBookmarkRepository
    {
        private readonly AppDbContext _context;

        public BookmarkRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Bookmark>> GetByCategoryAsync(string category)
        {
            return await _context.Connection.Table<Bookmark>()
                .Where(x => x.Category == category)
                .ToListAsync();
        }

        public async Task<List<Bookmark>> SearchAsync(string keyword)
        {
            return await _context.Connection.Table<Bookmark>()
                .Where(x => x.Title.Contains(keyword) || x.Url.Contains(keyword))
                .ToListAsync();
        }
    }
}
