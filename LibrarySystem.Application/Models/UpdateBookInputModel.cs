namespace LibrarySystem.Application.Models
{
    public class UpdateBookInputModel
    {
        public int IdBook { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Isbn { get; set; }

        public int Publication { get; set; }
    }
}
