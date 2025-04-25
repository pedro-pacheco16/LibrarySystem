using LibrarySystem.API.Entities;

namespace LibrarySystem.API.Models
{
    public class CreateBookInputModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Isbn { get; set; }

        public int Publication { get; set; }

        public Book ToEntity()
            => new(Title, Author, Isbn, Publication);
    }
}
