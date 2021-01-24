using BooksAppsMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BooksAppsMobile.Services
{
    public class BookService:IDataService<Book>
    {
        readonly string url = "https://www.googleapis.com/books/v1/volumes?q={0}&startIndex={1}&maxResults={2}";

        public async Task<IEnumerable<Book>> GetList(string term, int start, int lenght)
        {
            var books = new List<Book>();
            var client = new HttpClient();
            var response = await client.GetAsync(string.Format(url, term, start, lenght));
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var typedResult = JsonConvert.DeserializeObject<GoogleApiResponse>(result);
                foreach (var item in typedResult.items)
                {
                    books.Add(new Book(item));
                }
            }
            return books;

        }
    }
}
