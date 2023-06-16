using Lembretes.Domain.Dto;
using Lembretes.Domain.Entities;

namespace Lembretes.Domain.Interfaces
{
    public interface ILembretesService
    {
        public Guid Create(Lembrete lembrete);
        public List<LembreteResponse> List();
        public void Delete(Guid id);
        public LembreteResponse? GetById(Guid id);
        public Lembrete? PutById(Guid Id, Lembrete lembrete);
    }
}
