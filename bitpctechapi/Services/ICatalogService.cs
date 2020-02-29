using bitpctechapi.Contracts.V1.Responses;
using bitpctechapi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bitpctechapi.Services
{
    public interface ICatalogService
    {
        Task<Category[]> GetAllCategoryAsync();
        Task<Brand[]> GetAllBrandAsync();
        Task<Images> GetImagesByPcpartIdAsync(Guid pcPartId);
        Task<ProductResponse[]> GetAllProductByCategoryAndBrandAsync(Guid categoryId, Guid brandId);

    }
}
