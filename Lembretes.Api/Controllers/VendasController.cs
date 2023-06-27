using System;
using Lembretes.Domain.Entities;
using Lembretes.Domain.Interfaces;
using Lembretes.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lembretes.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VendasController : Controller
    {
        public readonly IVendasService _vendasService;
        private object _vendaService;

        public VendasController(IVendasService vendasService)
        {
            _vendasService = vendasService;
        }

        [HttpPost]
        public IActionResult Post(Vendas vendas)
        {
            Guid id = _vendasService.Create(vendas);

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

            var vendas = _vendasService.GetById(id);

            if (vendas == null)
            {
                return NotFound();
            }

            return Ok(vendas);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Vendas vendas)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var vendaNova = _vendasService.PutById(id, vendas);

            if (vendaNova == null)
            {
                return NotFound();
            }

            return Ok(vendaNova);
        }
    }
}
