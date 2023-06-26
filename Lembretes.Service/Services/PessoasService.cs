using System;
using Lembretes.Domain.Dto;
using Lembretes.Domain.Entities;
using Lembretes.Domain.Interfaces;
using Lembretes.Infra.Data.Repositories;

namespace Lembretes.Service.Services
{
	public class PessoasService : IPessoasService
	{
        public readonly IPessoasRepository _pessoasRepository;
        public readonly ILembretesRepository _lembretesRepository;

        public PessoasService(IPessoasRepository pessoasRepository, ILembretesRepository lembretesRepository)
        {
            _pessoasRepository = pessoasRepository;
            _lembretesRepository = lembretesRepository;
		}

        public Guid Create(Pessoas pessoas)
        {
            if (ValidarPessoas(pessoas))
            {
                return _pessoasRepository.Create(pessoas);
            }

            return Guid.Empty;
        }

        public PessoaResponse GetById(Guid id)
        {
            var pessoas = _pessoasRepository.SearchById(id);

            if (pessoas == null)
            {
                return null;
            }

            PessoaResponse pessoaResponse = ConverterPessoasToPessoaResponse(pessoas);

            return pessoaResponse;
        }

        public Pessoas? PutById(Guid id, Pessoas pessoas)
        {
            var pessoaAntiga = _pessoasRepository.SearchById(id);

            if (pessoaAntiga != null && ValidarPessoas(pessoas))
            {
                pessoas.SetId(id);

                pessoas = _pessoasRepository.Put(pessoas);

                return pessoas;
            }

            return null;
        }

        private bool ValidarPessoas(Pessoas pessoas)
        {
            var resposta = pessoas != null && pessoas.DataNascimento < DateTime.Now && !string.IsNullOrEmpty(pessoas.Nome);

            if (resposta == true && pessoas != null && pessoas.Lembretes != null)
            {
                pessoas.Lembretes.ForEach(x =>
                {
                    var lembrete = _lembretesRepository.SearchById(x);

                    if(lembrete == null)
                    {
                        resposta = false;
                    }
                });
            }

            return resposta;
        }

        private PessoaResponse ConverterPessoasToPessoaResponse(Pessoas pessoas)
        {
            PessoaResponse pessoaResponse = new PessoaResponse();

            pessoaResponse.Id = pessoas.Id;
            pessoaResponse.Nome = pessoas.Nome;
            pessoaResponse.DataNascimento = pessoas.DataNascimento;
            pessoaResponse.Lembretes = new List<Lembrete>();

            pessoas.Lembretes.ForEach(x =>
            {
                var lembrete = _lembretesRepository.SearchById(x);

                if(lembrete != null)
                {
                    pessoaResponse.Lembretes.Add(lembrete);
                }
            });

            return pessoaResponse;
        }
    }
}

