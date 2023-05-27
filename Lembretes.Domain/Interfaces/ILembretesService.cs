using Lembretes.Domain.Entities;

namespace Lembretes.Domain.Interfaces
{
    public interface ILembretesService
    {
        public Guid Create(Lembrete lembrete);
        public List<Lembrete> List();
        public void Delete(Guid id);
    }
}
