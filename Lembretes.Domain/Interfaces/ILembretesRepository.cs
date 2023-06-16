using Lembretes.Domain.Entities;

namespace Lembretes.Domain.Interfaces
{
    public interface ILembretesRepository
    {
        public Guid Create(Lembrete lembrete);
        public List<Lembrete> List();
        public void Delete(Lembrete lembrete);
        public Lembrete? SearchById(Guid id);
        public Lembrete Put(Lembrete lembrete);
    }
}
