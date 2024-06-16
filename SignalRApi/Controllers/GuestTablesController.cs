using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestTablesController : ControllerBase
    {
        private readonly IGuestTableService _guestTableService;

        public GuestTablesController(IGuestTableService guestTableService)
        {
            _guestTableService = guestTableService;
        }

        [HttpGet("GuestTableCount")]
        public IActionResult GuestTableCount()
        {
            return Ok(_guestTableService.TGuestTableCount());
        }


        [HttpGet]
        public IActionResult GuestTableList()
        {
            var values = _guestTableService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateGuestTable(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl,
            };

            _guestTableService.TAdd(about);
            return Ok("Hakkında Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuestTable(int id)
        {
            var value = _guestTableService.TGetById(id);
            _guestTableService.TDelete(value);
            return Ok("Hakkında Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateGuestTable(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutId = updateAboutDto.AboutId,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl,
            };
            _guestTableService.TUpdate(about);
            return Ok("Hakkında Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetGuestTable(int id)
        {
            var value = _guestTableService.TGetById(id);
            return Ok(value);
        }
    }
}
