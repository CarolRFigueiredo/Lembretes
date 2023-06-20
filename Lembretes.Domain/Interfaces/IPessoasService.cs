using System;
using Lembretes.Domain.Dto;
using Lembretes.Domain.Entities;

namespace Lembretes.Domain.Interfaces
{
	public interface IPessoasService
	{
        public Guid Create(Pessoas pessoas);
        public Pessoas GetById(Guid id);
    }
}

