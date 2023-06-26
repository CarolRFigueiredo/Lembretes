using System;
using Lembretes.Domain.Entities;

namespace Lembretes.Domain.Interfaces
{
	public interface IVendasService
	{
        public Guid Create(Vendas vendas);
    }
}

