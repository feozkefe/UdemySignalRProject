﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISliderService _sliderService;

        public SliderController(IMapper mapper, ISliderService sliderService)
        {
            _mapper = mapper;
            _sliderService = sliderService;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            Slider slider = new Slider()
            {
               Description1 = createSliderDto.Description1,
               Description2 = createSliderDto.Description2,
               Description3 = createSliderDto.Description3,
               Title1 = createSliderDto.Title1,
               Title2 = createSliderDto.Title2,
               Title3 = createSliderDto.Title3,
            };

            _sliderService.TAdd(slider);
            return Ok("Öne Çıkan Bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            Slider slider = new Slider()
            {
                SliderId = updateSliderDto.SliderId,
                Description1 = updateSliderDto.Description1,
                Description2 = updateSliderDto.Description2,
                Description3 = updateSliderDto.Description3,
                Title1 = updateSliderDto.Title1,
                Title2 = updateSliderDto.Title2,
                Title3 = updateSliderDto.Title3,
            };
            _sliderService.TUpdate(slider);
            return Ok("Öne Çıkan Bilgisi Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(value);
        }
    }
}
