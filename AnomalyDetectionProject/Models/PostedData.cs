using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnomalyDetectionProject.Models
{
    [Table("PostedData", Schema = "dbo")]
    public class PostedData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Posted Data Id")]
        public int PostedDataId { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        [Display(Name = "Anomaly Screenshot")]
        public string? CrimeScreenshot { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        [Display(Name = "Anomaly Date and Time")]
        public string? AnomalyDateTime { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        [Display(Name = "Action type")]
        [MaxLength(100)]
        public string? ActionType { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        [Display(Name = "Action Priority")]
        [MaxLength(10)]
        public string? ActionPriority { get; set; }

        [ForeignKey("Camera")]
        [Display(Name = "Zone ID")]
        [NotMapped]
        public int ZoneID { get; set; }

        public virtual Camera camera { get; set; }

    }
}