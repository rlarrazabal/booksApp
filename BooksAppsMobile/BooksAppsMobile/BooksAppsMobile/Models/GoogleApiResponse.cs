using System.Collections.Generic;

namespace BooksAppsMobile.Models
{
    public class GoogleApiResponse
    {
        public int totalItems { get; set; }
        public List<Item> items { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public VolumeInfo volumeInfo { get; set; }
        public AccessInfo accessInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string title { get; set; }
        public string publishedDate { get; set; }
        public string[] authors { get; set; }
        public ImageLink imageLinks { get; set; }
    }

    public class ImageLink
    {
        public string thumbnail { get; set; }
        public string smallThumbnail { get; set; }
    }

    public class AccessInfo
    {
        public string webReaderLink { get; set; }
    }
}
