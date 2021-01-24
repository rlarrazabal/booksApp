using BooksAppsMobile.Models;
using BooksAppsMobile.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BooksAppsMobile.ViewModels
{
    public class ListBookViewModel : BaseViewModel
    {
        private const int PAGESIZE = 20;

        private readonly BookService BookRepository;

        private string term = string.Empty;

        public string Term
        {
            get => term;
            set => SetProperty(ref term,value);
        }

        private ObservableCollection<Book> books;

        public ObservableCollection<Book> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }

        public ListBookViewModel()
        {
            Books = new ObservableCollection<Book>();
            BookRepository = new BookService();
            MessagingCenter.Subscribe<SearchBookViewModel, string>(this, "Search", async (vm, t) => { Term = t; await LoadBooks(); });
        }

        public async Task LoadBooks()
        {
            try
            {
                IsBusy = true;
                var newBooks = await BookRepository.GetList(term, Books.Count, PAGESIZE);
                foreach (var newBook in newBooks?.ToList()?? new List<Book>())
                {
                    Books.Add(newBook);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
