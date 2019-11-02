﻿using bitpctechapi.Contracts;
using bitpctechapi.Contracts.V1.Requests;
using bitpctechapi.Contracts.V1.Responses;
using bitpctechapi.Data;
using bitpctechapi.Domain;
using bitpctechapi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace bitpctechapi.Controllers.V1
{
    public class AdminPcPartsController : Controller
    {
        private readonly IAdminPcPartsService _adminPcPartsService;

        private readonly DataContext _dataContext;

        public AdminPcPartsController(IAdminPcPartsService iAdminPcPartsService, DataContext dataContext)
        {
            _adminPcPartsService = iAdminPcPartsService;
            _dataContext = dataContext;
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddPart)]
        public async Task<IActionResult> AddPart([FromForm] AdminAddPartRequest request)
        {
            string Image;
            using (var ms = new MemoryStream())
            {
                request.Image.CopyTo(ms);
                var fileBytes = ms.ToArray();
                Image = Convert.ToBase64String(fileBytes);
                // act on the Base64 data
            }

            PcPart pcPart = new PcPart()
            {
                Name = request.Name,
                BrandId = request.BrandId,
                Model = request.Model,
                Description = request.Description,
                SpecificationId = request.SpecificationId,
                Price = request.Price,
                Discount = request.Discount,
                Image = Image,
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
                throw e;
            }
        }

        [HttpGet(ApiRoutes.AdminPcParts.GetPartAll)]
        public async Task<IActionResult> GetPartAll()
        {
            try
            {
                var pcParts = await _adminPcPartsService.GetPcPartAll();

                if (pcParts != null)
                    return Ok( new AdminGetAllPcPartResponse() { PcParts = pcParts });

                return NotFound("Can not find ant PcPart at this moment");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddBrand)]
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
                throw e;
            }
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddCategory)]
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
                throw e;
            }
        }

        [HttpPost(ApiRoutes.AdminPcParts.AddSpecification)]
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
                throw e;
            }
        }
    }
}