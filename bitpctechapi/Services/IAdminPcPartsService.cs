using bitpctechapi.Domain;
using System.Threading.Tasks;

namespace bitpctechapi.Services
{
    public interface IAdminPcPartsService
    {
        Task<bool> AddPcPart(PcPart pcPart);
        Task<PcPart> GetPcPartById(int pcPartId);
        Task<PcPart[]> GetPcPartAll();
        Task<bool> AddCategory(Category category);
        Task<Category> GetCategoryById(int categoryId);
        Task<Category[]> GetCategoryAll();
        Task<bool> AddBrand(Brand brand);
        Task<Brand> GetBrandById(int brandId);
        Task<Brand[]> GetBrandAll();
        Task<bool> AddSpecification(Specification specification);
        Task<Specification> GetSpecificationById(int specificationId);
        Task<Specification[]> GetSpecificationAll();
    }
}
