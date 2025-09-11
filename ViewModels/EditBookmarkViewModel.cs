using BookmarkNotesApp.Models;
using BookmarkNotesApp.Services;
using System.Windows.Input;

namespace BookmarkNotesApp.ViewModels
{
    public class EditBookmarkViewModel
    {
        private readonly IBookmarkService _service;
        private readonly INavigation _navigation;

        private readonly Bookmark _bookmark;
        private readonly Action<Bookmark> _onBookmarkUpdated;

        public string Title { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }

        public ICommand SaveCommand { get; }

        public EditBookmarkViewModel(IBookmarkService service, INavigation navigation, Bookmark bookmark, Action<Bookmark> onBookmarkUpdated)
        {
            _service = service;
            _navigation = navigation;
            _bookmark = bookmark;
            _onBookmarkUpdated = onBookmarkUpdated;

            // Pre-fill data
            Title = bookmark.Title;
            Url = bookmark.Url;
            Category = bookmark.Category;

            SaveCommand = new Command(async () => await SaveBookmark());
        }

        private async Task SaveBookmark()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Url))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter Title and URL.", "OK");
                return;
            }

            _bookmark.Title = Title;
            _bookmark.Url = Url;
            _bookmark.Category = string.IsNullOrWhiteSpace(Category) ? "General" : Category;

            await _service.UpdateAsync(_bookmark);

            _onBookmarkUpdated?.Invoke(_bookmark);

            await _navigation.PopAsync();
        }
    }
}
