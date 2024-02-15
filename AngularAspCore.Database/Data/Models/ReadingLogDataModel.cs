using System.ComponentModel.DataAnnotations;


namespace AngularAspCore.Database.Data.Models
{
    /// <summary>
    /// Reading Log Data Model
    /// </summary>
    public class ReadingLogDataModel
    {
        /// <summary>
        /// Unique Id Auto incromented in Database
        /// </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Reader Id associated with Reader Data Model pk
        /// </summary>
        [Required]
        public int ReaderId { get; set; }

        /// <summary>
        /// Book Id associated with Book Data Model pk
        /// </summary>
        [Required]
        public int BookId { get; set; }

        /// <summary>
        /// Started reading date
        /// </summary>
        [Required]
        public DateTime ReadingStarted { get; set; }

        /// <summary>
        /// Ended Reading date
        /// </summary>
        public DateTime? ReadingEnded { get; set; }
        
        /// <summary>
        /// Lazy Load Reader data model
        /// </summary>
        public virtual ReaderDataModel Reader { get; set; }

        /// <summary>
        /// Lazy Load Book Data Model
        /// </summary>
        public virtual BookDataModel Book { get; set; }
    }
}
