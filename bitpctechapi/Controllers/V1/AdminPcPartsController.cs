using bitpctechapi.Contracts;
using bitpctechapi.Contracts.V1.Requests;
using bitpctechapi.Contracts.V1.Responses;
using bitpctechapi.Data;
using bitpctechapi.Domain;
using bitpctechapi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;

namespace bitpctechapi.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AdminPcPartsController : Controller
    {
        private readonly IAdminPcPartsService _adminPcPartsService;

        public AdminPcPartsController(IAdminPcPartsService iAdminPcPartsService, DataContext dataContext)
        {
            _adminPcPartsService = iAdminPcPartsService;
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddPart)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPart([FromBody] AdminAddPartRequest request)
        {
            PcPart pcPart = new PcPart()
            {
                Name = request.Name,
                BrandId = request.BrandId,
                Model = request.Model,
                Description = request.Description,
                SpecificationId = request.SpecificationId,
                Price = request.Price,
                Discount = request.Discount,
                ImagesId = request.ImagesId,
                DisplayOrder = request.DisplayOrder,
                CategoryId = request.CategoryId,
                StockQuantity = request.StockQuantity
            };

            try
            {
                var status = await _adminPcPartsService.AddPcPart(pcPart);

                if (status)
                    return Ok(new AdminAddOrDeleteResponse{ Message = "Successfully added new Pc part" });

                return BadRequest("Failed");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.AdminPcParts.GetPartAll)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPartAll()
        {
            try
            {
                var pcParts = await _adminPcPartsService.GetPcPartAll();

                if (pcParts != null)
                    return Ok( new AdminGetAllPcPartResponse() { PcParts = pcParts });

                return NotFound("Can not find any PcPart at this moment");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.AdminPcParts.GetPartById)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPartById([FromRoute]Guid pcPartId)
        {
            try
            {
                var pcParts = await _adminPcPartsService.GetPcPartById(pcPartId);

                if (pcParts != null)
                    return Ok(new AdminGetAPcPartResponse() { PcParts = pcParts });

                return NotFound("Can not find this PcPart at this moment");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpDelete(ApiRoutes.AdminPcParts.DeletePartById)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePartById([FromRoute]Guid pcPartId)
        {
            var delete = await _adminPcPartsService.DeletePcPartById(pcPartId);

            if (delete)
                return Ok(new AdminAddOrDeleteResponse { Message = "Successfully delete a pc part" });

            return NotFound("Can not find any");
        }

        private string ImageToBase64(IFormFile image)
        {
            string Image;
            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                var fileBytes = ms.ToArray();
                Image = Convert.ToBase64String(fileBytes);
                // act on the Base64 data
            }
            return Image;
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddImages)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddImages([FromBody] AdminAddImagesRequest request)
        {
            var image = new Images()
            {
                Image1 = request.Image1,
                Image2 = request.Image2,
                Image3 = request.Image3,
                Image4 = request.Image4,
                Image5 = request.Image5,
                Image6 = request.Image6,
                Image7 = request.Image7,
                Image8 = request.Image8,
                Image9 = request.Image9,
                Image10 = request.Image10
            };

            try
            {
                var status = await _adminPcPartsService.AddImages(image);

                if (status)
                    return Ok(new AdminAddOrDeleteResponse { Message = "Successfully added new images", ImageId = image.Id });

                return BadRequest("Failed");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.AdminPcParts.GetImagesAll)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetImagesAll()
        {
            try
            {
                var images = await _adminPcPartsService.GetImagesAll();

                if (images != null)
                    return Ok(new AdminGetAllImagesResponse() { Images = images });

                return NotFound("Can not find any Image at this moment");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.AdminPcParts.GetImageById)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetImageById([FromRoute]Guid imageId)
        {
            try
            {
                var images = await _adminPcPartsService.GetImageById(imageId);

                if (images != null)
                    return Ok(new AdminGetAImagesResponse() { Images = images });

                return NotFound("Can not find a Image at this moment");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpDelete(ApiRoutes.AdminPcParts.DeleteImageById)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteImageById([FromRoute]Guid imageId)
        {
            var delete = await _adminPcPartsService.DeleteImageById(imageId);

            if (delete)
                return Ok(new AdminAddOrDeleteResponse { Message = "Successfully delete images" });

            return NotFound("Can not find any");
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddBrand)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBrand([FromBody] AdminAddBrandRequest request)
        {
            var brand = new Brand(){ Name = request.Name };

            try
            {
                var status = await _adminPcPartsService.AddBrand(brand);

                if (status)
                    return Ok(new AdminAddOrDeleteResponse { Message = "Successfully added new brand" });

                return BadRequest("Failed");
            }
            catch(Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.AdminPcParts.GetBrandAll)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBrandAll()
        {
            try
            {
                var brands = await _adminPcPartsService.GetBrandAll();

                if (brands != null)
                    return Ok(new AdminGetAllBrandResponse() { Brands = brands });

                return NotFound("Can not find any Brand at this moment");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.AdminPcParts.GetBrandById)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBrandById([FromRoute] Guid brandId)
        {
            try
            {
                var brands = await _adminPcPartsService.GetBrandById(brandId);

                if (brands != null)
                    return Ok(new AdminGetABrandResponse() { Brands = brands });

                return NotFound("Can not find any Brand at this moment");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpDelete(ApiRoutes.AdminPcParts.DeleteBrandById)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBrandById([FromRoute]Guid brandId)
        {
            var delete = await _adminPcPartsService.DeleteBrandById(brandId);

            if (delete)
                return Ok(new AdminAddOrDeleteResponse { Message = "Successfully delete a brand" });

            return NotFound("Can not find any");
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddCategory)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory([FromBody] AdminAddCategoryRequest request)
        {
            var category = new Category() { Name = request.Name, DisplayOrder = request.DisplayOrder };

            try
            {
                var status = await _adminPcPartsService.AddCategory(category);

                if (status)
                    return Ok(new AdminAddOrDeleteResponse { Message = "Successfully added new category" });

                return BadRequest("Failed");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.AdminPcParts.GetCategoryAll)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCategoryAll()
        {
            try
            {
                var categories = await _adminPcPartsService.GetCategoryAll();

                if (categories != null)
                    return Ok(new AdminGetAllCategoryResponse() { Categories = categories });

                return NotFound("Can not find any Category at this moment");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.AdminPcParts.GetCategoryById)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCategoryById([FromRoute]Guid categoryId)
        {
            try
            {
                var categories = await _adminPcPartsService.GetCategoryById(categoryId);

                if (categories != null)
                    return Ok(new AdminGetACategoryResponse() { Categories = categories });

                return NotFound("Can not find any Category at this moment");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpDelete(ApiRoutes.AdminPcParts.DeleteCategoryById)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategoryById([FromRoute]Guid categoryId)
        {
            var delete = await _adminPcPartsService.DeleteCategoryById(categoryId);

            if (delete)
                return Ok(new AdminAddOrDeleteResponse { Message = "Successfully delete a category" });

            return NotFound("Can not find any");
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddSpecification)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSpecification([FromBody] AdminAddSpecificationRequest request)
        {
            var specification = new Specification() { Description = request.Description };

            try
            {
                var status = await _adminPcPartsService.AddSpecification(specification);

                if (status)
                    return Ok(new AdminAddOrDeleteResponse { Message = "Successfully added new specification" });

                return BadRequest("Failed");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.AdminPcParts.GetSpecificationAll)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSpecificationAll()
        {
            try
            {
                var specifications = await _adminPcPartsService.GetSpecificationAll();

                if (specifications != null)
                    return Ok(new AdminGetAllSpecificationResponse() { Specifications = specifications });

                return NotFound("Can not find any Specification at this moment");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpGet(ApiRoutes.AdminPcParts.GetSpecificationById)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSpecificationById([FromRoute]Guid specificationId)
        {
            try
            {
                var specifications = await _adminPcPartsService.GetSpecificationById(specificationId);

                if (specifications != null)
                    return Ok(new AdminGetASpecificationResponse() { Specifications = specifications });

                return NotFound("Can not find any Specification at this moment");
            }
            catch (Exception e)
            {
                return StatusCode(422, e);
            }
        }

        [HttpDelete(ApiRoutes.AdminPcParts.DeleteSpecificationById)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSpecificationById([FromRoute]Guid specificationId)
        {
            var delete = await _adminPcPartsService.DeleteSpecificationById(specificationId);

            if (delete)
                return Ok(new AdminAddOrDeleteResponse { Message = "Successfully delete a specification" });

            return NotFound("Can not find any");
        }

    }
}