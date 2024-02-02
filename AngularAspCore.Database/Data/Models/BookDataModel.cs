namespace AngularAspCore.Database.Data.Models
{
    public class BookDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public double Rate { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }
    }
}
