using BooksAppsMobile.ViewModels;
using Xamarin.Forms;

namespace BooksAppsMobile
{
    /// <summary>
    /// Search page
    /// </summary>
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new SearchBookViewModel();
        }
    }
}
