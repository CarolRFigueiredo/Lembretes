using System;
using Lembretes.Domain.Entities;

namespace Lembretes.Domain.Interfaces
{
	public interface IPessoasRepository
	{
        public Guid Create(Pessoas pessoas);
        public Pessoas SearchById(Guid id);
        public Pessoas Put(Pessoas pessoas);
    }
}

