using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onatrix_assignment.Models
{
    [Table("WeHelp")]
    public class WeHelpModel
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public DateTime SubmittedDate { get; set; } = DateTime.Now;
    }
}
