using System;
using Lembretes.Domain.Entities;
using Lembretes.Domain.Interfaces;
using Lembretes.Infra.Data.Repositories;

namespace Lembretes.Service.Services
{
    public class VendasService : IVendasService
    {

        public readonly IVendasRepository _vendasRepository;

        public VendasService(IVendasRepository vendasRepository)
        {
            _vendasRepository = vendasRepository;
        }

        public Guid Create(Vendas vendas)
        {
            if (ValidarVendas(vendas) && ValidarVendedor(vendas.Vendedor))
            {
                var vendedorNovo = new Vendedor();
                vendedorNovo.Cpf = vendas.Vendedor.Cpf;
                vendedorNovo.Email = vendas.Vendedor.Email;
                vendedorNovo.Nome = vendas.Vendedor.Nome;
                vendedorNovo.Telefone = vendas.Vendedor.Telefone;
               
                var vendasNovas = new Vendas();
                vendasNovas.Vendedor = vendedorNovo;
                vendasNovas.Itens = vendas.Itens;
              
                return _vendasRepository.Create(vendas);
            }

            return Guid.Empty;
        }

        private bool ValidarVendas(Vendas vendas)
        {
            if (vendas.Date <= DateTime.Now && vendas.Itens != null && vendas.Itens.Count >= 1)
            {
                return true;
            }

            return false;
        }

        private bool ValidarVendedor(Vendedor vendedor)
        {
            if (!string.IsNullOrEmpty(vendedor.Cpf) && !string.IsNullOrEmpty(vendedor.Email) && !string.IsNullOrEmpty(vendedor.Nome) && !string.IsNullOrEmpty(vendedor.Telefone))
            {
                return true;
            }


            return false;
        }

    } 
}
