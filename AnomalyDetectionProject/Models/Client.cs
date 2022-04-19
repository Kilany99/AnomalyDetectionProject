using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnomalyDetectionProject.Models
{
    [Table("Client", Schema = "dbo")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Client ID")]
        public int ClientId { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        [Display(Name = "Client Username")]
        [MaxLength(8)]
        public string? ClientName { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Client Password")]
        [MaxLength(16)]
        public string? Password { get; set; }
        [ForeignKey("Camera")]
        [Display(Name = "Zone Name")]
        [NotMapped]
        public int ZoneID { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string? DeviceToken { get; set; }

        public virtual Camera camera { get; set; }

    }
}
