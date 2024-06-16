using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.GuestTableDto;
using SignalR.EntityLayer.Entities;

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
        public IActionResult CreateGuestTable(CreateGuestTableDto createGuestTableDto)
        {
            GuestTable guestTable = new GuestTable()
            {
                Name= createGuestTableDto.Name,
                Status = false
            };

            _guestTableService.TAdd(guestTable);
            return Ok("Misafir Masa Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuestTable(int id)
        {
            var value = _guestTableService.TGetById(id);
            _guestTableService.TDelete(value);
            return Ok("Misafir Masa Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateGuestTable(UpdateGuestTableDto updateGuestTableDto)
        {
            GuestTable guestTable = new GuestTable()
            {
                GuestTableId = updateGuestTableDto.GuestTableId,
                Name = updateGuestTableDto.Name,
                Status = false
            };
            _guestTableService.TUpdate(guestTable);
            return Ok("Misafir Masa Alanı Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetGuestTable(int id)
        {
            var value = _guestTableService.TGetById(id);
            return Ok(value);
        }
    }
}
