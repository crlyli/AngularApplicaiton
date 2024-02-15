using System.ComponentModel.DataAnnotations;

namespace AngularAspCore.Database.Data.Models
{
    /// <summary>
    /// Reader Data Model / Entity
    /// </summary>
    public class ReaderDataModel
    {
        /// <summary>
        /// Unique Id Auto Incromented by database
        /// </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Reader Full Name
        /// </summary>
        [Required]
        public required string FullName { get; set; }
    }
}
