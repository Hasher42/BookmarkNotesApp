using BookmarkNotesApp.Models;
using BookmarkNotesApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkNotesApp.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IBookmarkRepository _repository;

        public BookmarkService(IBookmarkRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Bookmark>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Bookmark> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<List<Bookmark>> SearchAsync(string keyword) => _repository.SearchAsync(keyword);
        public Task<int> AddAsync(Bookmark bookmark) => _repository.AddAsync(bookmark);
        public Task<int> UpdateAsync(Bookmark bookmark) => _repository.UpdateAsync(bookmark);
        public Task<int> DeleteAsync(Bookmark bookmark) => _repository.DeleteAsync(bookmark);
    }
}
