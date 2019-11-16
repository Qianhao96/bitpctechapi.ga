using bitpctechapi.Domain;
using System;
using System.Threading.Tasks;

namespace bitpctechapi.Services
{
    public interface IAdminPcPartsService
    {
        Task<bool> AddPcPart(PcPart pcPart);
        Task<PcPart> GetPcPartById(Guid pcPartId);
        Task<bool> DeletePcPartById(Guid pcPartId);
        Task<PcPart[]> GetPcPartAll();
        Task<bool> AddImages(Images images);
        Task<Images> GetImageById(Guid imageId);
        Task<bool> DeleteImageById(Guid imageId);
        Task<Images[]> GetImagesAll();
        Task<bool> AddCategory(Category category);
        Task<Category> GetCategoryById(Guid categoryId);
        Task<bool> DeleteCategoryById(Guid categoryId);
        Task<Category[]> GetCategoryAll();
        Task<bool> AddBrand(Brand brand);
        Task<Brand> GetBrandById(Guid brandId);
        Task<bool> DeleteBrandById(Guid brandId);
        Task<Brand[]> GetBrandAll();
        Task<bool> AddSpecification(Specification specification);
        Task<Specification> GetSpecificationById(Guid specificationId);
        Task<bool> DeleteSpecificationById(Guid specificationId);
        Task<Specification[]> GetSpecificationAll();
    }
}
