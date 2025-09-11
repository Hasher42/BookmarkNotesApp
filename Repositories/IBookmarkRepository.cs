using BookmarkNotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkNotesApp.Repositories
{
    public interface IBookmarkRepository : IGenericRepository<Bookmark>
    {
        Task<List<Bookmark>> GetByCategoryAsync(string category);
        Task<List<Bookmark>> SearchAsync(string keyword);
    }
}
