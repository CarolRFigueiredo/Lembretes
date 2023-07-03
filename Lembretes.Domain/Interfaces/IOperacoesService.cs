using System;
using Lembretes.Domain.Dto;
using Lembretes.Domain.Entities;

namespace Lembretes.Domain.Interfaces
{
	public interface IOperacoesService
	{
		public decimal Create(OperacoesRequest operacoesRequest);
	}
}

