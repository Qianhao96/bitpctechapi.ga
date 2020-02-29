using bitpctechapi.Contracts.V1.Responses;
using bitpctechapi.Data;
using bitpctechapi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace bitpctechapi.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly DataContext _dataContext;

        public CatalogService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        async Task<Category[]> ICatalogService.GetAllCategoryAsync()
        {
            return await _dataContext.Categories.ToArrayAsync();
        }

        async Task<Brand[]> ICatalogService.GetAllBrandAsync()
        {
            return await _dataContext.Brands.ToArrayAsync();
        }

        async Task<ProductResponse[]> ICatalogService.GetAllProductByCategoryAndBrandAsync(Guid CategoryId, Guid BrandId)
        {
            var products = await _dataContext.PcParts
                .Where(pro => pro.CategoryId == CategoryId && pro.BrandId == BrandId)
                .Select(pro => new ProductResponse()
                {
                    Id = pro.Id,
                    ProductName = pro.Name,
                    Brand = pro.Brand,
                    Model = pro.Model,
                    Description = pro.Description,
                    Specification = pro.Specification,
                    Price = pro.Price,
                    PriceAfterDiscount = (double)(pro.Price * pro.Discount),
                    Discount = (double)pro.Discount,
                    //Images = pro.Images,
                    DisplayOrder = (int)pro.DisplayOrder,
                    Category = pro.Category,
                    StockQuantity = pro.StockQuantity
                }).ToArrayAsync();

            return products;
        }

        async Task<Images> ICatalogService.GetImagesByPcpartIdAsync(Guid pcPartId)
        {
            var imageId = await _dataContext.PcParts
                .Where(p => p.Id == pcPartId)
                .Select(p => p.ImagesId)
                .SingleAsync();

            return await _dataContext.Images.SingleOrDefaultAsync(x => x.Id == imageId);
        }
    }
}
