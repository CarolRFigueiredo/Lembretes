using System;
using Lembretes.Domain.Entities;

namespace Lembretes.Domain.Dto
{
	public class OperacoesRequest
	{
		public Operacoes operacoes { get; set; }
		public decimal ValorA { get; set; }
		public decimal ValorB { get; set; }
		public bool CondicaoIf { get; set; }
	}
}

