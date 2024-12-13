using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace challenge_features.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal PackHeight { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal PackWidth { get; set; }

        [Column(TypeName = "decimal(8,3)")]
        public decimal PackWeight { get; set; }

        [MaxLength(20)]
        public string Colour { get; set; }

        [MaxLength(20)]
        public string Size { get; set; }
    }
}
