using BooksAppsMobile.Services;
using BooksAppsMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksAppsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListBookPage : ContentPage
    {
        public ListBookPage()
        {
            InitializeComponent();
            BindingContext = new ListBookViewModel(new BookService());
        }
    }
}