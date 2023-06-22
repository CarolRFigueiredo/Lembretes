using Lembretes.Domain.Entities;

namespace Lembretes.Domain.Dto
{
	public class PessoaResponse
	{
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Lembrete> Lembretes { get; set; }
    }
}

