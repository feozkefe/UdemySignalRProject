﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {

            Category category = new Category()
            {
               CategoryName = createCategoryDto.CategoryName,
               Status = true
            };

            _categoryService.TAdd(category);
            return Ok("Kategori eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Kategori Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            Category category = new Category()
            {
                CategoryName = updateCategoryDto.CategoryName,
                CategoryId = updateCategoryDto.CategoryId,
                Status = updateCategoryDto.Status
            };

            _categoryService.TUpdate(category);
            return Ok("Kategori Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }
    }
}
