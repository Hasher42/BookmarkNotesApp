using BookmarkNotesApp.Models;
using BookmarkNotesApp.Services;
using BookmarkNotesApp.ViewModels;

namespace BookmarkNotesApp.Views;

public partial class AddBookmarkPage : ContentPage
{
    public AddBookmarkPage(IBookmarkService service, Action<Bookmark> onBookmarkAdded)
    {
        InitializeComponent();
        BindingContext = new AddBookmarkViewModel(service, Navigation, onBookmarkAdded);
    }
}