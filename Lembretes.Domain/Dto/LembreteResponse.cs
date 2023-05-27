namespace Lembretes.Domain.Dto
{
    public class LembreteResponse
    { 
        public DateTime Date { get; set; }
        public List<Evento> Eventos { get; set; }
    }
}
