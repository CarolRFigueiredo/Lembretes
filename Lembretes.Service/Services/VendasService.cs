﻿using System;
using Lembretes.Domain.Dto;
using Lembretes.Domain.Entities;
using Lembretes.Domain.Interfaces;
using Lembretes.Infra.Data.Repositories;

namespace Lembretes.Service.Services
{
    public class VendasService : IVendasService
    {

        public readonly IVendasRepository _vendasRepository;
        private object _statusVendasRepository;

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

        public Vendas? GetById(Guid id)
        {
            var vendas = _vendasRepository.SearchById(id);

            if (vendas == null)
            {
                return null;
            }

            return vendas;
        }

        public Vendas? PutById(Guid id, Vendas vendas)
        {
            var vendasAntiga = _vendasRepository.SearchById(id);

            if (vendasAntiga != null && ValidarVendas(vendas) && ValidarVendedor(vendas.Vendedor))
            {
                vendas.SetId(id);

                vendas = _vendasRepository.Put(vendas);

                return vendas;
            }

            return null;
        }

        public Vendas? PatchById(Guid id, StatusVendas statusVendas)
        {
            var vendaAntiga = _vendasRepository.SearchById(id);

            if (vendaAntiga != null)
            {
                if(ValidarStatus(statusVendas, vendaAntiga))
                {
                    vendaAntiga.SetStatus(statusVendas);

                    var vendas = _vendasRepository.Put(vendaAntiga);

                    return vendas;
                }
            }

            return null;
        }

        public void Delete(Guid id)
        {
            Vendas? vendas = _vendasRepository.SearchById(id);

            if (vendas != null && vendas.Status == StatusVendas.Cancelado)
            {
                _vendasRepository.Delete(vendas);
            }
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

        private bool ValidarStatus(StatusVendas statusVendas, Vendas vendas)
        {
            if (vendas.Status == StatusVendas.AguardandoPagamento && (statusVendas == StatusVendas.Cancelado || statusVendas == StatusVendas.PagamentoAprovado))
            {
                return true;
            }
            else if(vendas.Status == StatusVendas.PagamentoAprovado && (statusVendas == StatusVendas.EnviadoParaTransportadora || statusVendas == StatusVendas.Cancelado))
            {
                return true;
            }
            else if(vendas.Status == StatusVendas.EnviadoParaTransportadora && statusVendas == StatusVendas.Entregue)
            {
                return true;
            }
            else
            {
                return false;
            }   
        }

    } 
}
