using System;
namespace Lembretes.Domain.Entities
{
	public class Pessoas
	{
		public Guid Id { get; private set; }
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public List<Guid> Lembretes { get; set; }

		public void SetId()
		{
			Id = Guid.NewGuid();
		}
	}
}

