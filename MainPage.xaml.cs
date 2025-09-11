using BookmarkNotesApp.Services;
using BookmarkNotesApp.ViewModels;

namespace BookmarkNotesApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(IBookmarkService bookmarkService)
        {
            InitializeComponent();

            // Set the BindingContext to the ViewModel
            BindingContext = new BookmarkViewModel(bookmarkService);
        }

        private void SearchBarControl_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue) && sender is SearchBar searchBar)
            {
                searchBar.Unfocus(); // Close keyboard when cleared
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            SearchBarControl.Unfocus();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchBarControl.Unfocus();

            // optional: clear selection so it doesn't stay highlighted
            if (sender is CollectionView collectionView)
                collectionView.SelectedItem = null;
        }
    }

}
