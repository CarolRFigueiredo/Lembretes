using System;
using Lembretes.Domain.Dto;
using Lembretes.Domain.Entities;

namespace Lembretes.Domain.Interfaces
{
	public interface IVendasService
	{
        public Guid Create(Vendas vendas);
        public Vendas? GetById(Guid id);
        public Vendas? PutById(Guid Id, Vendas vendas);
        public Vendas? PatchById(Guid Id, StatusVendas statusVendas);
        public void Delete(Guid id);
    }
}

