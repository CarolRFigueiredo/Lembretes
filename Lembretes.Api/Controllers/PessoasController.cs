using System;
using Lembretes.Domain.Entities;
using Lembretes.Domain.Interfaces;
using Lembretes.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lembretes.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PessoasController : Controller
	{
        public readonly IPessoasService _pessoasService;

        public PessoasController(IPessoasService pessoasService)
        {
            _pessoasService = pessoasService;
        }

        [HttpPost]
        public IActionResult Post(Pessoas pessoas)
        {
            Guid id = _pessoasService.Create(pessoas);

            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            return Ok(id);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var lembrete = _pessoasService.GetById(id);

            if (lembrete == null)
            {
                return NotFound();
            }

            return Ok(lembrete);

        }
    }        
}

