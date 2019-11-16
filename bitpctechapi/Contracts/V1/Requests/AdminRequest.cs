using Microsoft.AspNetCore.Http;

namespace bitpctechapi.Contracts.V1.Requests
{
    public class AdminAddPartRequest
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int SpecificationId { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int ImagesId { get; set; }
        public int DisplayOrder { get; set; }
        public int CategoryId { get; set; }

    }

    public class AdminAddBrandRequest
    {
        public string Name { get; set; }
    }

    public class AdminAddCategoryRequest
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class AdminAddSpecificationRequest
    {
        public string Description { get; set; }
    }

    public class AdminAddImagesRequest
    {
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile Image3 { get; set; }
        public IFormFile Image4 { get; set; }
        public IFormFile Image5 { get; set; }
        public IFormFile Image6 { get; set; }
        public IFormFile Image7 { get; set; }
        public IFormFile Image8 { get; set; }
        public IFormFile Image9 { get; set; }
        public IFormFile Image10 { get; set; }
    }
}
