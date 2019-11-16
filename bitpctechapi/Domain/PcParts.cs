using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bitpctechapi.Domain
{
    public class PcPart
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Guid SpecificationId { get; set; }
        [ForeignKey("SpecificationId")]
        public Specification Specification { get; set; }

        [Required]
        public double Price { get; set; }

        public double? Discount { get; set; }

        [Required]
        public Guid ImagesId { get; set; }
        [ForeignKey("ImagesId")]
        public Images Images { get; set; }

        public int? DisplayOrder { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }

    public class Images
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Image1 { get; set; }

        [Required]
        public string Image2 { get; set; }

        [Required]
        public string Image3 { get; set; }

        [Required]
        public string Image4 { get; set; }

        [Required]
        public string Image5 { get; set; }

        public string Image6 { get; set; }

        public string Image7 { get; set; }

        public string Image8 { get; set; }

        public string Image9 { get; set; }

        public string Image10 { get; set; }

    }

    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DisplayOrder { get; set; }
    }

    public class Brand
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    } 

    public class Specification
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
