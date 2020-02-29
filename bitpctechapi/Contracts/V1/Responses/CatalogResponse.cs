using bitpctechapi.Domain;
using System;

namespace bitpctechapi.Contracts.V1.Responses
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public Specification Specification { get; set; }
        public double Price { get; set; }
        public double PriceAfterDiscount { get; set; }
        public double Discount { get; set; }
        //public Images Images { get; set; }
        public int DisplayOrder { get; set; }
        public Category Category { get; set; }
        public int StockQuantity { get; set; }
    }
}
