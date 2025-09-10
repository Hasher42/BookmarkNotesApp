using AndroidX.Lifecycle;
using BookmarkNotesApp.Services.ViewModel;

namespace BookmarkNotesApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage(BookmarkViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel; // ✅ Inject ViewModel via DI
        }

    }

}
