using Microsoft.Extensions.Logging;

using BookmarkNotesApp.Model.DbContextApp;
using BookmarkNotesApp.Repositories.Contracts;
using BookmarkNotesApp.Repositories;
using BookmarkNotesApp.Services.Contracts;
using BookmarkNotesApp.Services;
using BookmarkNotesApp.Services.ViewModel;
namespace BookmarkNotesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Database path
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "bookmarks.db3");

            // ✅ Register database context
            builder.Services.AddSingleton<AppDbContext>(s => new AppDbContext(dbPath));

            // ✅ Register repositories
            builder.Services.AddSingleton<IBookmarkRepository, BookmarkRepository>();

            // ✅ Register services
            builder.Services.AddSingleton<IBookmarkService, BookmarkService>();

            // ✅ Register ViewModels
            builder.Services.AddSingleton<BookmarkViewModel>();

            // ✅ Register Pages
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
