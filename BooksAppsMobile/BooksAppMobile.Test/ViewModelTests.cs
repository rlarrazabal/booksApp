using BooksAppMobile.Test.Mocks;
using BooksAppsMobile.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAppMobile.Test
{
    public class ViewModelTests
    {
        ListBookViewModel viewModel;

        [Test]
        public async Task ListViewModel_DoesLoad_Test()
        {
            viewModel = new ListBookViewModel(new MockBookService()) { Term = "TERM" };
            await viewModel.LoadBooks();
            Assert.True(viewModel.CanLoadMoreBooks(viewModel.Books.Last()));
        }

        [Test]
        public async Task ListViewModel_DoesntLoad_When_NotLastBook_Test()
        {
            viewModel = new ListBookViewModel(new MockBookService()) { Term = "TEST" };
            await viewModel.LoadBooks();
            Assert.False(viewModel.CanLoadMoreBooks(viewModel.Books.First()));
        }

        [Test]
        public async Task ListViewModel_DoesntLoad_When_MissingTerm_Test()
        {
            viewModel = new ListBookViewModel(new MockBookService());
            await viewModel.LoadBooks();
            Assert.False(viewModel.CanLoadMoreBooks(viewModel.Books.Last()));
        }

        [Test]
        public void ListViewModel_DoesntLoad_When_Busy_Test()
        {
            viewModel = new ListBookViewModel(new MockBookService())
            {
                Term="TERM",
                IsBusy = true
            };
            Assert.False(viewModel.CanLoadMoreBooks(new BooksAppsMobile.Models.Book()));
        }
    }
}
