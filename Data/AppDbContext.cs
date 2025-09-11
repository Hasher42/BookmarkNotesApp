using BookmarkNotesApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkNotesApp.Data
{
    public class AppDbContext
    {
        private readonly SQLiteAsyncConnection _db;

        public AppDbContext(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Bookmark>().Wait();
        }

        public SQLiteAsyncConnection Connection => _db;
    }
}
