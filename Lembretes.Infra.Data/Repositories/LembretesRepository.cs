using Lembretes.Domain.Entities;
using Lembretes.Domain.Interfaces;

namespace Lembretes.Infra.Data.Repositories
{
    public class LembretesRepository : ILembretesRepository
    {
        private List<Lembrete> _lembretes;

        public LembretesRepository() 
        {
            _lembretes = new List<Lembrete>();
        }

        public Guid Create(Lembrete lembrete)
        {
            lembrete.SetId();
            _lembretes.Add(lembrete);

            return lembrete.Id;
        }

        public void Delete(Lembrete lembrete)
        {
            _lembretes.Remove(lembrete);
        }

        public List<Lembrete> List()
        {
            return _lembretes;
        }

        public Lembrete? SearchById(Guid id)
        {
            return _lembretes.Find(x => x.Id == id);
        }
    }
}
