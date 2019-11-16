using bitpctechapi.Domain;
using System.Threading.Tasks;

namespace bitpctechapi.Services
{
    public interface IAdminPcPartsService
    {
        Task<bool> AddPcPart(PcPart pcPart);
        Task<PcPart> GetPcPartById(int pcPartId);
        Task<bool> DeletePcPartById(int pcPartId);
        Task<PcPart[]> GetPcPartAll();
        Task<bool> AddImages(Images images);
        Task<Images> GetImageById(int imageId);
        Task<bool> DeleteImageById(int imageId);
        Task<Images[]> GetImagesAll();
        Task<bool> AddCategory(Category category);
        Task<Category> GetCategoryById(int categoryId);
        Task<bool> DeleteCategoryById(int categoryId);
        Task<Category[]> GetCategoryAll();
        Task<bool> AddBrand(Brand brand);
        Task<Brand> GetBrandById(int brandId);
        Task<bool> DeleteBrandById(int brandId);
        Task<Brand[]> GetBrandAll();
        Task<bool> AddSpecification(Specification specification);
        Task<Specification> GetSpecificationById(int specificationId);
        Task<bool> DeleteSpecificationById(int specificationId);
        Task<Specification[]> GetSpecificationAll();
    }
}
