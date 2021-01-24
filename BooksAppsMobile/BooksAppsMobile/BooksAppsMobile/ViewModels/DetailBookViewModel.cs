﻿using BooksAppsMobile.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BooksAppsMobile.ViewModels
{
    public class DetailBookViewModel : BaseViewModel
    {
        private Book book;
        public Book Book { get => book; set => SetProperty(ref book, value); }

        public ICommand CheckCommand => new Command<string>(async (x) => { await CheckBook(x); }, CanCheckBook);
        private bool CanCheckBook(string arg)
        {
            return !string.IsNullOrWhiteSpace(arg);
        }

        private async Task CheckBook(string x)
        {
            await Task.CompletedTask;
        }

        public DetailBookViewModel(Book book)
        {
            Book = book;
        }
    }
}