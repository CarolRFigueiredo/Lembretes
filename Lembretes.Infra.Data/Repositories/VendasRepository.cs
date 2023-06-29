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
        public Vendas? SearchById(Guid id)
        {
            return _vendas.Find(x => x.Id == id);
        }

        public Vendas Put(Vendas vendas)
        {
            var vendasAntiga = _vendas.Find(x => x.Id == vendas.Id);

            if (vendasAntiga != null)
            {
                _vendas.Remove(vendasAntiga);
                _vendas.Add(vendas);
            }

            return vendas;
        }

        public void Delete(Vendas vendas)
        {
            _vendas.Remove(vendas);
        }
    }
}

