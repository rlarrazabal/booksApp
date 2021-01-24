using BooksAppsMobile.Models;
using BooksAppsMobile.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAppMobile.Test.Mocks
{
    public class MockBookService : IBookService
    {
        public async Task<IEnumerable<Book>> GetList(string term, int start, int lenght)
        {
            var books = new List<Book>();
            for(var i=0; i < lenght; i++)
            {
                books.Add(new Book() { Id = (i+start).ToString(), Title = $"{term} {i+start}" }) ;
            }
            return await Task.FromResult(books);
        }
    }
}
