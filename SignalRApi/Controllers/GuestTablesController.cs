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
    }
}
