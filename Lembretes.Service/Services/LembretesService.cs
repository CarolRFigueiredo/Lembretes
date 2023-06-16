using Lembretes.Domain.Dto;
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

        public List<LembreteResponse> List()
        {
            var lembretes = _lembretesRepository.List().OrderBy(x => x.Date).ToList();

            return ConverterLembreteToLembrateResponse(lembretes);
        }

        public LembreteResponse? GetById(Guid id)
        {
            var lembrete = _lembretesRepository.SearchById(id);

            if (lembrete == null)
            {
                return null;
            }

            LembreteResponse lembreteResponse = ConverterLembreteToLembreteResponse(lembrete);

            return lembreteResponse;
        }

        public Lembrete? PutById(Guid id, Lembrete lembrete)
        {
            var lembreteAntigo = _lembretesRepository.SearchById(id);

            if (lembreteAntigo != null)
            {
                lembrete.SetId(id);

                _lembretesRepository.Put(lembrete);

                return lembrete;
                    
            }

            return null;
        }

        private LembreteResponse ConverterLembreteToLembreteResponse(Lembrete lembrete)
        {
            LembreteResponse lembreteResponse = new LembreteResponse();

            lembreteResponse.Date = lembrete.Date;
            lembreteResponse.Eventos = new List<Evento>
            {
                new Evento
                {
                    Id = lembrete.Id,
                    Nome = lembrete.Nome
                }
            };

            return lembreteResponse;
        }

        private List<LembreteResponse> ConverterLembreteToLembrateResponse(List<Lembrete> lembretes)
        {
            List<LembreteResponse> lembretesResponse = new List<LembreteResponse>();

            lembretes.ForEach(x => 
            {
                var lembreteResponse = lembretesResponse.Find(y => y.Date == x.Date);

                if (lembreteResponse == null)
                {
                    lembretesResponse.Add(new LembreteResponse
                    {
                        Date = x.Date,
                        Eventos = new List<Evento>
                        {
                            new Evento
                            {
                                Id = x.Id,
                                Nome = x.Nome
                            }
                        }
                    });
                }
                else 
                {
                    lembreteResponse.Eventos.Add(new Evento
                    {
                        Id = x.Id, 
                        Nome = x.Nome
                    });
                }
            });

            return lembretesResponse;
        }

        private static bool ValidarLembrete(Lembrete lembrete)
        {
            return lembrete != null && lembrete.Date >= DateTime.Now && !string.IsNullOrEmpty(lembrete.Nome);
        }
    }
}
