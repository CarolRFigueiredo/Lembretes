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

        public Pessoas SearchById(Guid id)
        {
            return _pessoas.Find(x => x.Id == id);
        }
    }
}

