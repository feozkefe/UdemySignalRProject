using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                NameSurname = createMessageDto.NameSurname,
                Subject = createMessageDto.Subject,
                MessageContent = createMessageDto.MessageContent,
                MessageSendDate = DateTime.Now,
                Mail = createMessageDto.Mail,
                Phone = createMessageDto.Phone,
                Status = false
            };

            _messageService.TAdd(message);
            return Ok("Mesaj Başarılı Bir Şekilde Gönderildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Mesaj Silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateMessageDto updateAboutDto)
        {
            Message message = new Message()
            {
                NameSurname = updateAboutDto.NameSurname,
                Subject = updateAboutDto.Subject,
                MessageContent = updateAboutDto.MessageContent,
                MessageSendDate = updateAboutDto.MessageSendDate,
                Mail = updateAboutDto.Mail,
                Phone = updateAboutDto.Phone,
                MessageId = updateAboutDto.MessageId,
                Status = false
            };
            _messageService.TUpdate(message);
            return Ok("Mesaj Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }
    }
}
