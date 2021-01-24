using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksAppsMobile.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetList(string term, int start, int lenght);
    }
}
