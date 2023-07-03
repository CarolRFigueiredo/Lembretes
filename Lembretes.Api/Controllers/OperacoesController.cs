using System;
using Lembretes.Domain.Dto;
using Lembretes.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lembretes.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OperacoesController : Controller
    {
        public readonly IOperacoesService _operacoesService;

        public OperacoesController(IOperacoesService operacoesService)
        {
            _operacoesService = operacoesService;
        }

        [HttpPost]
        public IActionResult Post(OperacoesRequest operacoes)
        {
             var resposta = _operacoesService.Create(operacoes);
            return Ok(resposta);
            
        }
    }
}

