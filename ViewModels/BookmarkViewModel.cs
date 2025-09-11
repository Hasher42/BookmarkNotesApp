using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BookmarkNotesApp.Models;
using BookmarkNotesApp.Services;
using BookmarkNotesApp.Views;

namespace BookmarkNotesApp.ViewModels
{
    public partial class BookmarkViewModel : ObservableObject
    {
        private readonly IBookmarkService _service;

        public ObservableCollection<Bookmark> Bookmarks { get; } = new();

        [ObservableProperty]
        private string searchText;

        public IEnumerable<Bookmark> FilteredBookmarks =>
            string.IsNullOrWhiteSpace(SearchText)
                ? Bookmarks.OrderByDescending(b => b.CreatedDate)
                : Bookmarks
                    .Where(b => (b.Title ?? string.Empty).Contains(SearchText ?? string.Empty, StringComparison.OrdinalIgnoreCase)
                             || (b.Category ?? string.Empty).Contains(SearchText ?? string.Empty, StringComparison.OrdinalIgnoreCase))
                    .OrderByDescending(b => b.CreatedDate);

        partial void OnSearchTextChanged(string value)
        {
            OnPropertyChanged(nameof(FilteredBookmarks));
        }

        public BookmarkViewModel(IBookmarkService service)
        {
            _service = service;
            LoadBookmarks();
        }

        private async void LoadBookmarks()
        {
            var list = await _service.GetAllAsync();
            Bookmarks.Clear();
            foreach (var b in list.OrderByDescending(x => x.CreatedDate))
                Bookmarks.Add(b);

            OnPropertyChanged(nameof(FilteredBookmarks));
        }

        [RelayCommand]
        private async Task GoToAddPage()
        {
            var page = new AddBookmarkPage(_service, bookmark =>
            {
                Bookmarks.Insert(0, bookmark);
                OnPropertyChanged(nameof(FilteredBookmarks));
            });
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        [RelayCommand]
        private async Task DeleteBookmark(Bookmark bookmark)
        {
            await _service.DeleteAsync(bookmark);
            Bookmarks.Remove(bookmark);
            OnPropertyChanged(nameof(FilteredBookmarks));
        }

        [RelayCommand]
        private async Task GoToEditPage(Bookmark bookmark)
        {
            var page = new EditBookmarkPage(_service, bookmark, updatedBookmark =>
            {
                var index = Bookmarks.IndexOf(bookmark);
                if (index >= 0)
                    Bookmarks[index] = updatedBookmark;

                OnPropertyChanged(nameof(FilteredBookmarks));
            });
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }

}
