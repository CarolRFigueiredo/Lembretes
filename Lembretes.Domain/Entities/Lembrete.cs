namespace Lembretes.Domain.Entities
{
    public class Lembrete
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; set; }
        public string Nome { get; set; }

        public void SetId() 
        {
            Id = Guid.NewGuid();        
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
