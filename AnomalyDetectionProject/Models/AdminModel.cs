using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnomalyDetectionProject.Models
{
    public class AdminModel
    {
        [key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Admin ID")]
        public string? Admin_id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [MaxLength(16)]
        public string? Ad_Password { get; set; }

    }
}
