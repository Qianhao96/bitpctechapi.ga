using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bitpctechapi.Domain
{
    public class PcPart
    {
        [Key]
        [Required]
        public int PcPartId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int SpecificationId { get; set; }
        [ForeignKey("SpecificationId")]

        public Specification Specification { get; set; }

        [Required]
        public double Price { get; set; }

        public double? Discount { get; set; }

        [Required]
        public string Image { get; set; }

        public int? DisplayOrder { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public Category Category { get; set; }
    }

    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DisplayOrder { get; set; }
    }

    public class Brand
    {
        [Key]
        [Required]
        public int BrandId { get; set; }

        [Required]
        public string Name { get; set; }
    } 

    public class Specification
    {
        [Key]
        [Required]
        public int SpecificationId { get; set; }
        public string Description { get; set; }
    }
}
