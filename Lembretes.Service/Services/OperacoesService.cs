using System;
using Lembretes.Domain.Dto;
using Lembretes.Domain.Entities;
using Lembretes.Domain.Interfaces;

namespace Lembretes.Service.Services
{
	public class OperacoesService : IOperacoesService
	{
		public OperacoesService()
		{
		}

        public decimal Create(OperacoesRequest operacoesRequest)
        {
            if (operacoesRequest.CondicaoIf)
            {
                if(operacoesRequest.operacoes == Operacoes.Divisao)
                {
                    return operacoesRequest.ValorA / operacoesRequest.ValorB;
                }
                else if(operacoesRequest.operacoes == Operacoes.Multiplicacao)
                {
                    return operacoesRequest.ValorA * operacoesRequest.ValorB;
                }
                else if(operacoesRequest.operacoes == Operacoes.Soma)
                {
                    return operacoesRequest.ValorA + operacoesRequest.ValorB;
                }
                else if(operacoesRequest.operacoes == Operacoes.subtracao)
                {
                    return operacoesRequest.ValorA - operacoesRequest.ValorB;
                }
                else
                {
                    return operacoesRequest.ValorA % operacoesRequest.ValorB;
                }  
            }
            else
            {
                switch (operacoesRequest.operacoes)
                {
                    case Operacoes.Divisao:
                        return operacoesRequest.ValorA / operacoesRequest.ValorB;
                    case Operacoes.Multiplicacao:
                        return operacoesRequest.ValorA * operacoesRequest.ValorB;
                    case Operacoes.Soma:
                        return operacoesRequest.ValorA + operacoesRequest.ValorB;
                    case Operacoes.subtracao:
                        return operacoesRequest.ValorA - operacoesRequest.ValorB;
                    default:
                        return operacoesRequest.ValorA % operacoesRequest.ValorB;
                }
            }
        }
    }
}

