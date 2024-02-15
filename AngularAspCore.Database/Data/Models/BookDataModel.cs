using System.ComponentModel.DataAnnotations;

namespace AngularAspCore.Database.Data.Models
{
    /// <summary>
    /// Book Database Model/ Entity
    /// </summary>
    public class BookDataModel
    {
        /// <summary>
        /// Uniqe Id Database Auto Incroments
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Book Title
        /// </summary>
        [Required]
        public required string Title { get; set; }

        /// <summary>
        /// Book Description
        /// </summary>
        [Required]
        public required string Description { get; set; }

        /// <summary>
        /// Book Author
        /// </summary>
        [Required]
        public required string Author { get; set; }
    }
}
