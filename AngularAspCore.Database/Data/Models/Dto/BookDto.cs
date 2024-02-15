namespace AngularAspCore.Database.Data.Models.Dto
{
    /// <summary>
    /// Book Data Transfer Object
    /// Used to translate between front end and database models
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// Boo Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Book Description 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Book Author
        /// </summary>
        public string Author { get; set; }
    }
}
