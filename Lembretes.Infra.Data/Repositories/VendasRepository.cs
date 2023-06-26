using System;
using Lembretes.Domain.Entities;
using System.Collections.Generic;
using Lembretes.Domain.Interfaces;

namespace Lembretes.Infra.Data.Repositories
{
    public class VendasRepository : IVendasRepository
    {
        public List<Vendas> _vendas;

        public VendasRepository()
        {
            _vendas = new List<Vendas>();
        }

        public Guid Create(Vendas vendas)
        {
            _vendas.Add(vendas);

            return vendas.Id;
        }
    }
}

