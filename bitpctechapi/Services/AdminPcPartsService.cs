using System;
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

        public async Task<Images> GetImageById(Guid imageId)
        {
            return await _dataContext.Images.SingleOrDefaultAsync(x => x.Id == imageId);
        }

        public async Task<Brand> GetBrandById(Guid brandId)
        {
            return await _dataContext.Brands.SingleOrDefaultAsync(x => x.Id == brandId);
        }

        public async Task<Category> GetCategoryById(Guid categoryId)
        {
            return await _dataContext.Categories.SingleOrDefaultAsync(x => x.Id == categoryId);
        }

        public async Task<PcPart> GetPcPartById(Guid pcPartId)
        {
            return await _dataContext.PcParts.SingleOrDefaultAsync(x => x.Id == pcPartId);
        }

        public async Task<Specification> GetSpecificationById(Guid specificationId)
        {
            return await _dataContext.Specifications.SingleOrDefaultAsync(x => x.Id == specificationId);
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

        public async Task<bool> DeletePcPartById(Guid pcPartId)
        {
            var pcPart = await GetPcPartById(pcPartId);

            if (pcPart != null)
            {
                var images = await GetImageById(pcPart.ImagesId);
                _dataContext.PcParts.Remove(pcPart);
                _dataContext.Images.Remove(images);

                var deleted = await _dataContext.SaveChangesAsync();
                return deleted > 0;
            }
            return false;
        }

        public async Task<bool> DeleteImageById(Guid imageId)
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

        public async Task<bool> DeleteCategoryById(Guid categoryId)
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

        public async Task<bool> DeleteBrandById(Guid brandId)
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

        public async Task<bool> DeleteSpecificationById(Guid specificationId)
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
