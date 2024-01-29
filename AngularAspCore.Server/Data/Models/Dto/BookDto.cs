namespace AngularAspCore.Server.Data.Models.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public double Rate { get; set; }
        public string? DateStart { get; set; }
        public string? DateFinish { get; set; }
    }
}
