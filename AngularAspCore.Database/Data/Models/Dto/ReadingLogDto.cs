namespace AngularAspCore.Database.Data.Models.Dto
{
    /// <summary>
    /// Reading Log Data Transfer Object
    /// Used to Transfer data from front end to Database Model
    /// </summary>
    public class ReadingLogDto
    {
        /// <summary>
        /// Reader Data Model
        /// </summary>
        public ReaderDataModel ReaderId { get; set; }

        /// <summary>
        /// Book Data Model
        /// </summary>
        public BookDataModel BookId { get; set; }

        /// <summary>
        /// Started Reading Date
        /// </summary>
        public string ReadingStart { get; set; }

        /// <summary>
        /// Ended Reading Date
        /// </summary>
        public string? ReadingEnd { get; set; }
    }
}
