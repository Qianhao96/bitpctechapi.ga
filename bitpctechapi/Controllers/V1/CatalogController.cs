using System;
using System.Threading.Tasks;
using bitpctechapi.Contracts;
using bitpctechapi.Data;
using bitpctechapi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bitpctechapi.Controllers.V1
{
    public class CatalogController : ControllerBase
    {
        public readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService iCatalogService, DataContext dataContext)
        {
            _catalogService = iCatalogService;
        }

        [HttpGet(ApiRoutes.Catalog.GetProductsByCategoryAndBrand)]
        public async Task<IActionResult> CatalogGetProductByCategoryAndBrand([FromRoute]Guid categoryId, Guid brandId)
        {
            try
            {
                var pcParts = await _catalogService.GetAllProductByCategoryAndBrandAsync(categoryId, brandId);

                if (pcParts != null)
                    return Ok(pcParts);

                return NotFound("Can not find any!");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.Catalog.GetImagesByPcpartId)]
        public async Task<IActionResult> CatalogGetImagesByPcpartId([FromRoute]Guid pcpartId)
        {
            try
            {
                var images = await _catalogService.GetImagesByPcpartIdAsync(pcpartId);

                if (images != null)
                    return Ok(images);

                return NotFound("Can not find any!");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.Catalog.GetAllCategory)]
        public async Task<IActionResult> CatalogGetAllCategory()
        {
            try
            {
                var categories = await _catalogService.GetAllCategoryAsync();

                if (categories != null)
                    return Ok(categories);

                return NotFound("Can not find any!");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.Catalog.GetAllBrand)]
        public async Task<IActionResult> CatalogGetAllBrand()
        {
            try
            {
                var brands = await _catalogService.GetAllBrandAsync();

                if (brands != null)
                    return Ok(brands);

                return NotFound("Can not find any!");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }
    }
}