using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFeatureService _featureService;

        public FeatureController(IMapper mapper, IFeatureService featureService)
        {
            _mapper = mapper;
            _featureService = featureService;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateFeatureDto createFeatureDto)
        {
            Feature feature = new Feature()
            {
               Description1 = createFeatureDto.Description1,
               Description2 = createFeatureDto.Description2,
               Description3 = createFeatureDto.Description3,
               Title1 = createFeatureDto.Title1,
               Title2 = createFeatureDto.Title2,
               Title3 = createFeatureDto.Title3,
            };

            _featureService.TAdd(feature);
            return Ok("Öne Çıkan Bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            Feature feature = new Feature()
            {
                FeatureId = updateFeatureDto.FeatureId,
                Description1 = updateFeatureDto.Description1,
                Description2 = updateFeatureDto.Description2,
                Description3 = updateFeatureDto.Description3,
                Title1 = updateFeatureDto.Title1,
                Title2 = updateFeatureDto.Title2,
                Title3 = updateFeatureDto.Title3,
            };
            _featureService.TUpdate(feature);
            return Ok("Öne Çıkan Bilgisi Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }
    }
}
