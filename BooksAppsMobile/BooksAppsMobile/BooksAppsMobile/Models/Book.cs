using System.Linq;
using Xamarin.Forms;

namespace BooksAppsMobile.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string PublishDate { get; set; }
        public string Thumbnail { get; set; }
        public string WebLink { get; set; }

        public Book() { }

        public Book(Item googleBook)
        {
            Id = googleBook.id;
            Title = googleBook.volumeInfo?.title ?? "Sin nombre";
            PublishDate = googleBook.volumeInfo?.publishedDate ?? "Sin fecha";
            Authors = googleBook.volumeInfo?.authors!=null? string.Join(", ", googleBook.volumeInfo?.authors): "Sin autor";
            WebLink = googleBook.accessInfo?.webReaderLink ?? "";
            Thumbnail = googleBook.volumeInfo?.imageLinks?.thumbnail;
        }
    }
}
