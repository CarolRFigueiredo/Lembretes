using System;
using Lembretes.Domain.Entities;
using Lembretes.Domain.Interfaces;

namespace Lembretes.Infra.Data.Repositories
{
    public class PessoasRepository : IPessoasRepository
    {
        private List<Pessoas> _pessoas;

        public PessoasRepository()
        {
            _pessoas = new List<Pessoas>();
        }

        public Guid Create(Pessoas pessoas)
        {
            pessoas.SetId();
            _pessoas.Add(pessoas);

            return pessoas.Id;
        }

        public Pessoas Put(Pessoas pessoas)
        {
            var pessoaAntiga = _pessoas.Find(x => x.Id == pessoas.Id);
           
            if(pessoaAntiga != null)
            {
                _pessoas.Remove(pessoaAntiga);
                _pessoas.Add(pessoas);

                return pessoas;
            }

            return null;
        }

        public Pessoas SearchById(Guid id)
        {
            return _pessoas.Find(x => x.Id == id);
        }
    }
}

