using System;
namespace Lembretes.Domain.Entities
{
	public enum StatusVendas
	{
		AguardandoPagamento = 1,
		PagamentoAprovado = 2,
		Cancelado = 3,
		EnviadoParaTransportadora = 4,
		Entregue = 5	 
	}
}

