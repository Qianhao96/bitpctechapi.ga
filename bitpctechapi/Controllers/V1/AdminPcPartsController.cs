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
        public async Task<IActionResult> AddPart([FromForm] AdminAddPartRequest request)
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
                CategoryId = request.CategoryId
            };

            try
            {
                var status = await _adminPcPartsService.AddPcPart(pcPart);

                if (status)
                    return Ok("Successfully added a new PcPart");

                return BadRequest("Failed");
            }
            catch (Exception e)
            {
                return StatusCode(422, e.Message);
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
                return StatusCode(422, e.Message);
            }
        }

        [HttpDelete(ApiRoutes.AdminPcParts.DeletePartById)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePartById([FromRoute]int pcPartId)
        {
            var delete = await _adminPcPartsService.DeletePcPartById(pcPartId);

            if (delete)
                return Ok("Successfully deleted");

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
        public async Task<IActionResult> AddImages([FromForm] AdminAddImagesRequest request)
        {
            var test = (request.Image1 != null)? ImageToBase64(request.Image1) : "";
            var image = new Images()
            {
                Image1 = (request.Image1 != null) ? ImageToBase64(request.Image1) : "",
                Image2 = (request.Image2 != null) ? ImageToBase64(request.Image2) : "",
                Image3 = (request.Image3 != null) ? ImageToBase64(request.Image3) : "",
                Image4 = (request.Image4 != null) ? ImageToBase64(request.Image4) : "",
                Image5 = (request.Image5 != null) ? ImageToBase64(request.Image5) : "",
                Image6 = (request.Image6 != null) ? ImageToBase64(request.Image6) : "",
                Image7 = (request.Image7 != null) ? ImageToBase64(request.Image7) : "",
                Image8 = (request.Image8 != null) ? ImageToBase64(request.Image8) : "",
                Image9 = (request.Image9 != null) ? ImageToBase64(request.Image9) : "",
                Image10 = (request.Image10 != null) ? ImageToBase64(request.Image10) : ""
            };

            try
            {
                var status = await _adminPcPartsService.AddImages(image);

                if (status)
                    return Ok("Successfully added a new Images");

                return BadRequest("Failed");
            }
            catch (Exception e)
            {
                return StatusCode(422, e.Message);
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
                return StatusCode(422, e.Message);
            }
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddBrand)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBrand([FromForm] AdminAddBrandRequest request)
        {
            var brand = new Brand(){ Name = request.Name };

            try
            {
                var status = await _adminPcPartsService.AddBrand(brand);

                if (status)
                    return Ok("Successfully added a new Brand");

                return BadRequest("Failed");
            }
            catch(Exception e)
            {
                return StatusCode(422, e.Message);
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
                return StatusCode(422, e.Message);
            }
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddCategory)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory([FromForm] AdminAddCategoryRequest request)
        {
            var category = new Category() { Name = request.Name, DisplayOrder = request.DisplayOrder };

            try
            {
                var status = await _adminPcPartsService.AddCategory(category);

                if (status)
                    return Ok("Successfully added a new category");

                return BadRequest("Failed");
            }
            catch (Exception e)
            {
                return StatusCode(422, e.Message);
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
                return StatusCode(422, e.Message);
            }
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddSpecification)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSpecification([FromForm] AdminAddSpecificationRequest request)
        {
            var specification = new Specification() { Description = request.Description };

            try
            {
                var status = await _adminPcPartsService.AddSpecification(specification);

                if (status)
                    return Ok("Successfully added a new specification");

                return BadRequest("Failed");
            }
            catch (Exception e)
            {
                return StatusCode(422, e.Message);
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
                return StatusCode(422, e.Message);
            }
        }

    }
}