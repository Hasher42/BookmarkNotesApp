using BookmarkNotesApp.Models;
using BookmarkNotesApp.Services;
using BookmarkNotesApp.ViewModels;

namespace BookmarkNotesApp.Views;

public partial class EditBookmarkPage : ContentPage
{
    public EditBookmarkPage(IBookmarkService service, Bookmark bookmark, Action<Bookmark> onBookmarkUpdated)
    {
        InitializeComponent();
        BindingContext = new EditBookmarkViewModel(service, Navigation, bookmark, onBookmarkUpdated);
    }
}