using System;
using Lembretes.Domain.Entities;

namespace Lembretes.Domain.Interfaces
{
	public interface IVendasRepository
	{
        public Guid Create(Vendas vendas);
        public Vendas? SearchById(Guid id);
        public Vendas Put(Vendas vendas);
    }
}

