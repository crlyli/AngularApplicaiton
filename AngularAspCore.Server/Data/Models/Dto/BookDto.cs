using System.ComponentModel.DataAnnotations;

namespace AngularAspCore.Server.Data.Models.Dto
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book title is required")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public double Rate { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public string? DateStart { get; set; }
        public string? DateFinish { get; set; }
    }
}
