using BooksAppsMobile.Models;
using BooksAppsMobile.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BooksAppsMobile.ViewModels
{
    public class DetailBookViewModel : BaseViewModel
    {
        private Book book;

        public Book Book { get => book; set => SetProperty(ref book, value); }

        public ICommand CheckCommand => new Command<string>(async (weblink) => { await ReadBook(weblink); }, CanReadBook);

        private bool CanReadBook(string weblink)
        {
            return !string.IsNullOrWhiteSpace(weblink);
        }

        private async Task ReadBook(string weblink)
        {
            await App.Current.MainPage.Navigation.PushAsync(new BookWebPage(weblink));
        }

        public DetailBookViewModel(Book book)
        {
            Book = book;
        }
    }
}
