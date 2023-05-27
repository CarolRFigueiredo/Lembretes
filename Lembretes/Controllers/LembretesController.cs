using Lembretes.Domain.Entities;
using Lembretes.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lembretes.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LembretesController : Controller
    {
        public readonly ILembretesService _lembreteService;

        public LembretesController(ILembretesService lembreteService)
        {
            _lembreteService = lembreteService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_lembreteService.List());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }

            _lembreteService.Delete(id);

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Lembrete lembrete) 
        {
            Guid id = _lembreteService.Create(lembrete);

            if(id == Guid.Empty)
            {
                return BadRequest();
            }

            return Ok(id);
        }
    }
}
