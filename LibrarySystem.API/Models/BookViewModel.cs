using LibrarySystem.API.Entities;
using LibrarySystem.API.Enums;

namespace LibrarySystem.API.Models
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, string isbn, int publication, BookStatusEnum status)
        {
            Id = id;
            Title = title;
            Author = author;
            Isbn = isbn;
            Publication = publication;
            Status = status;
        }
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public string Isbn { get; private set; }

        public int Publication { get; private set; }

        public BookStatusEnum Status { get; private set; }

        public static BookViewModel FromEntity(Book entity)
            => new BookViewModel(entity.Id, entity.Title, entity.Author, entity.Isbn, entity.Publication, entity.Status);
    }
}
