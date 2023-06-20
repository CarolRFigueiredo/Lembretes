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

        public PessoasService(IPessoasRepository pessoasRepository)
        {
            _pessoasRepository = pessoasRepository;
		}

        public Guid Create(Pessoas pessoas)
        {
            if (ValidarPessoas(pessoas))
            {
                return _pessoasRepository.Create(pessoas);
            }

            return Guid.Empty;
        }

        public Pessoas GetById(Guid id)
        {
            var pessoas = _pessoasRepository.SearchById(id);

            if (pessoas == null)
            {
                return null;
            }

            return pessoas;
        }

        private static bool ValidarPessoas(Pessoas pessoas)
        {
            return pessoas != null && pessoas.DataNascimento < DateTime.Now && !string.IsNullOrEmpty(pessoas.Nome);
        } 
    }
}

