using BooksAppsMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksAppsMobile.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetList(string term, int start, int lenght);
    }
}
