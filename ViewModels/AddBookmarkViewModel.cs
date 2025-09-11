using BookmarkNotesApp.Models;
using BookmarkNotesApp.Services;
using System.Windows.Input;

namespace BookmarkNotesApp.ViewModels
{
    public class AddBookmarkViewModel
    {
        private readonly IBookmarkService _service;
        private readonly INavigation _navigation;
        public string Title { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }

        public ICommand SaveCommand { get; }
        // Callback to notify MainPage
        private readonly Action<Bookmark> _onBookmarkAdded;

        public AddBookmarkViewModel(IBookmarkService service, INavigation navigation, Action<Bookmark> onBookmarkAdded = null)
        {
            _service = service;
            _navigation = navigation;
            _onBookmarkAdded = onBookmarkAdded;
            SaveCommand = new Command(async () => await SaveBookmark());
        }

        private async Task SaveBookmark()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Url))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter Title and URL.", "OK");
                return;
            }

            var newBookmark = new Bookmark
            {
                Title = Title,
                Url = Url,
                Category = string.IsNullOrWhiteSpace(Category) ? "General" : Category,
                CreatedDate = DateTime.UtcNow
            };

            await _service.AddAsync(newBookmark);

            // Notify MainPage
            _onBookmarkAdded?.Invoke(newBookmark);

            await _navigation.PopAsync();
        }
    }
}
