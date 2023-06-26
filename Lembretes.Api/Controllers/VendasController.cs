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
    }
}
