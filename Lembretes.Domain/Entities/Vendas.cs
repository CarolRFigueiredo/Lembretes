using System;
using System.Collections.Generic;

namespace Lembretes.Domain.Entities
{
	public class Vendas
	{
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public Vendedor Vendedor { get; set; }
        public List<string> Itens { get; set; }
        public StatusVendas Status { get; private set; }

        public Vendas()
        {
            Id = Guid.NewGuid();
            Status = StatusVendas.AguardandoPagamento;
            Date = DateTime.Now;
        }
    }
}

