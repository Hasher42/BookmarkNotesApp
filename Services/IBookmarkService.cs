using BookmarkNotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkNotesApp.Services
{
    public interface IBookmarkService
    {
        Task<List<Bookmark>> GetAllAsync();
        Task<Bookmark> GetByIdAsync(int id);
        Task<List<Bookmark>> SearchAsync(string keyword);
        Task<int> AddAsync(Bookmark bookmark);
        Task<int> UpdateAsync(Bookmark bookmark);
        Task<int> DeleteAsync(Bookmark bookmark);
    }
}
