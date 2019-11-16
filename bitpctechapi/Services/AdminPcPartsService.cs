using System.Threading.Tasks;
using bitpctechapi.Data;
using bitpctechapi.Domain;
using Microsoft.EntityFrameworkCore;

namespace bitpctechapi.Services
{
    public class AdminPcPartsService : IAdminPcPartsService
    {
        private readonly DataContext _dataContext;

        public AdminPcPartsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddBrand(Brand brand)
        {
            await _dataContext.Brands.AddAsync(brand);
            var status = await _dataContext.SaveChangesAsync();
            return status > 0;
        }

        public async Task<bool> AddCategory(Category category)
        {
            await _dataContext.Categories.AddAsync(category);
            var status = await _dataContext.SaveChangesAsync();
            return status > 0;
        }

        public async Task<bool> AddPcPart(PcPart pcPart)
        {
            await _dataContext.PcParts.AddAsync(pcPart);
            var status = await _dataContext.SaveChangesAsync();
            return status > 0;
        }

        public async Task<bool> AddImages(Images images)
        {
            await _dataContext.Images.AddAsync(images);
            var status = await _dataContext.SaveChangesAsync();
            return status > 0;
        }

        public async Task<bool> AddSpecification(Specification specification)
        {
            await _dataContext.Specifications.AddAsync(specification);
            var status = await _dataContext.SaveChangesAsync();
            return status > 0;
        }

        public async Task<Images> GetImageById(int imageId)
        {
            return await _dataContext.Images.SingleOrDefaultAsync(x => x.ImagesId == imageId);
        }

        public async Task<Brand> GetBrandById(int brandId)
        {
            return await _dataContext.Brands.SingleOrDefaultAsync(x => x.BrandId == brandId);
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _dataContext.Categories.SingleOrDefaultAsync(x => x.CategoryId == categoryId);
        }

        public async Task<PcPart> GetPcPartById(int pcPartId)
        {
            return await _dataContext.PcParts.SingleOrDefaultAsync(x => x.PcPartId == pcPartId);
        }

        public async Task<Specification> GetSpecificationById(int specificationId)
        {
            return await _dataContext.Specifications.SingleOrDefaultAsync(x => x.SpecificationId == specificationId);
        }

        public async Task<PcPart[]> GetPcPartAll()
        {
            return await _dataContext.PcParts.ToArrayAsync();
        }

        public async Task<Images[]> GetImagesAll()
        {
            return await _dataContext.Images.ToArrayAsync();
        }

        public async Task<Category[]> GetCategoryAll()
        {
            return await _dataContext.Categories.ToArrayAsync();
        }

        public async Task<Brand[]> GetBrandAll()
        {
            return await _dataContext.Brands.ToArrayAsync();
        }

        public async Task<Specification[]> GetSpecificationAll()
        {
            return await _dataContext.Specifications.ToArrayAsync();
        }

        public async Task<bool> DeletePcPartById(int pcPartId)
        {
            var pcPart = await GetPcPartById(pcPartId);
            if (pcPart != null)
            {
                _dataContext.PcParts.Remove(pcPart);

                var deleted = await _dataContext.SaveChangesAsync();
                return deleted > 0;
            }
            return false;
        }

        public async Task<bool> DeleteImageById(int imageId)
        {
            var images = await GetImageById(imageId);
            if (images != null)
            {
                _dataContext.Images.Remove(images);

                var deleted = await _dataContext.SaveChangesAsync();
                return deleted > 0;
            }
            return false;
        }

        public async Task<bool> DeleteCategoryById(int categoryId)
        {
            var category = await GetCategoryById(categoryId);
            if (category != null)
            {
                _dataContext.Categories.Remove(category);

                var deleted = await _dataContext.SaveChangesAsync();
                return deleted > 0;
            }
            return false;
        }

        public async Task<bool> DeleteBrandById(int brandId)
        {
            var brand = await GetBrandById(brandId);
            if (brand != null)
            {
                _dataContext.Brands.Remove(brand);

                var deleted = await _dataContext.SaveChangesAsync();
                return deleted > 0;
            }
            return false;
        }

        public async Task<bool> DeleteSpecificationById(int specificationId)
        {
            var specification = await GetSpecificationById(specificationId);
            if (specification != null)
            {
                _dataContext.Specifications.Remove(specification);

                var deleted = await _dataContext.SaveChangesAsync();
                return deleted > 0;
            }
            return false;
        }
    }
}
