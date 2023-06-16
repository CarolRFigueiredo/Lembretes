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

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var lembrete = _lembreteService.GetById(id);

            if (lembrete == null)
            {
                return NotFound();
            }

            return Ok(lembrete);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
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

            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            return Ok(id);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] Lembrete lembrete)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var lembreteNovo = _lembreteService.PutById(id,lembrete);

            if(lembreteNovo == null)
            {
                return NotFound();
            }

            return Ok(lembreteNovo);
        }
    }
}
