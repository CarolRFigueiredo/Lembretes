using Lembretes.Domain.Entities;
using Lembretes.Domain.Interfaces;

namespace Lembretes.Service.Services
{
    public class LembretesService : ILembretesService
    {
        public readonly ILembretesRepository _lembretesRepository;

        public LembretesService(ILembretesRepository lembretesRepository) 
        {
            _lembretesRepository = lembretesRepository;
        }

        public Guid Create(Lembrete lembrete)
        {
            if (ValidarLembrete(lembrete))
            {
                lembrete.Date = lembrete.Date.Date;
                return _lembretesRepository.Create(lembrete);
            }

            return Guid.Empty;
        }

        public void Delete(Guid id)
        {
            Lembrete? lembrete = _lembretesRepository.SearchById(id);

            if (lembrete != null)
            {
                _lembretesRepository.Delete(lembrete);
            }
        }

        public List<Lembrete> List()
        {
            return _lembretesRepository.List();
        }

        private static bool ValidarLembrete(Lembrete lembrete)
        {
            return lembrete != null && lembrete.Date >= DateTime.Now && !string.IsNullOrEmpty(lembrete.Nome);
        }
    }
}
