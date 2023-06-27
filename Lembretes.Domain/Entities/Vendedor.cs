using System;
namespace Lembretes.Domain.Entities
{
	public class Vendedor
	{
		public Guid Id { get; private set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }

		public Vendedor()
		{
			Id = Guid.NewGuid();
		}
	}
}

