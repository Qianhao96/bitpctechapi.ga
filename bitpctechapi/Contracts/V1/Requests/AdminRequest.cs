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
        public IFormFile Image { get; set; }
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
}
