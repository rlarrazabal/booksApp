using BooksAppsMobile.Models;
using BooksAppsMobile.Services;
using BooksAppsMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public ICommand LoadMoreBooksCommand => new Command<Book>(async (b) => await LoadBooks(), CanLoadMoreBooks);

        public ICommand BookSelectedCommand => new Command<Book>(async (b) => await CheckBook(b));

        private async Task CheckBook(Book book)
        {
            await App.Current.MainPage.Navigation.PushAsync(new DetailBookPage(book));
        }

        public ListBookViewModel(IDataService<Book> dataService)
        {
            Books = new ObservableCollection<Book>();
            BookRepository = (BookService)dataService;
            MessagingCenter.Subscribe<SearchBookViewModel, string>(this, "Search", async (vm, t) => { Term = t; await LoadBooks(); });
        }

        /// <summary>
        /// Retrieves a set ammount of books from the service
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if the appearing book is the last to load more books 
        /// </summary>
        /// <param name="book">Newly appearing book</param>
        /// <returns>Can load more books in the list</returns>
        public bool CanLoadMoreBooks(Book book)
        {
            return !IsBusy && Books.Count >= PAGESIZE && book.Id == Books.Last().Id;
        }

    }
}
