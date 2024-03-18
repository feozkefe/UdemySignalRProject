using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(IMapper mapper, ITestimonialService testimonialService)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                Status= createTestimonialDto.Status,
                Comment= createTestimonialDto.Comment,
                ImageURL= createTestimonialDto.ImageURL,
                Name= createTestimonialDto.Name,
                Title= createTestimonialDto.Title,
            };

            _testimonialService.TAdd(testimonial);
            return Ok("Referans Bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Referans Bilgisi Silindi");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                TestimonialId = updateTestimonialDto.TestimonialId,
                Status = updateTestimonialDto.Status,
                Comment = updateTestimonialDto.Comment,
                ImageURL = updateTestimonialDto.ImageURL,
                Name = updateTestimonialDto.Name,
                Title = updateTestimonialDto.Title,
            };
            _testimonialService.TUpdate(testimonial);
            return Ok("Referans Bilgisi Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
    }
}
