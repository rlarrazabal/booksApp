using BooksAppsMobile.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BooksAppsMobile.ViewModels
{
    public class SearchBookViewModel:BaseViewModel
    {
        private string searchTerm = string.Empty;
        public string SearchTerm
        {
            get => searchTerm;
            set => SetProperty(ref searchTerm, value);
        }

        public ICommand Search => new Command<string>(async (term) => { await SearchBook(term); }, CanSearch);

        private async Task SearchBook(string term)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListBookPage());
            MessagingCenter.Send(this, "Search", term);
        }

        private bool CanSearch(string term)
        {
            return !string.IsNullOrWhiteSpace(term);
        }
    }
}
