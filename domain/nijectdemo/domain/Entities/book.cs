using System;

namespace Entities.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public byte[] Thumbnail { get; set; }
        public decimal Price { get; set; }
        public DateTime Published { get; set; }
    }
}
