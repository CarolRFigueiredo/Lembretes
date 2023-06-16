using Lembretes.Domain.Dto;
using Lembretes.Domain.Entities;
using Lembretes.Domain.Interfaces;
using Lembretes.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Lembretes.Test
{
    public class LembretesServiceTest
    {
        [Fact]
        public void Criar_Lembrete_ShouldReturnOk()
        {
            var lembrete = new Lembrete
            {
                Date = DateTime.Now.AddDays(1),
                Nome = "Teste Criacao"
            };

            var mockLembreteRepository = new Mock<ILembretesRepository>();
            mockLembreteRepository.Setup(x => x.Create(lembrete)).Returns(Guid.NewGuid);

            var response = new LembretesService(mockLembreteRepository.Object).Create(lembrete);

            Assert.NotEqual(Guid.Empty, response);
        }

        [Fact]
        public void Criar_LembreteDataInvalida_ShouldReturnEmpty()
        {
            var lembrete = new Lembrete
            {
                Date = DateTime.Now.AddDays(-1),
                Nome = "Teste Criacao"
            };

            var mockLembreteRepository = new Mock<ILembretesRepository>();
            mockLembreteRepository.Setup(x => x.Create(lembrete)).Returns(Guid.NewGuid);

            var response = new LembretesService(mockLembreteRepository.Object).Create(lembrete);

            Assert.Equal(Guid.Empty, response);
        }

        [Fact]
        public void Criar_LembreteNomeInvalido_ShouldReturnEmpty()
        {
            var lembrete = new Lembrete
            {
                Date = DateTime.Now.AddDays(1),
                Nome = ""
            };

            var mockLembreteRepository = new Mock<ILembretesRepository>();
            mockLembreteRepository.Setup(x => x.Create(lembrete)).Returns(Guid.NewGuid);

            var response = new LembretesService(mockLembreteRepository.Object).Create(lembrete);

            Assert.Equal(Guid.Empty, response);
        }

        [Fact]
        public void Delete_ValidLembrete_ShouldReturnOk()
        {
            var lembrete = new Lembrete
            {
                Date = DateTime.Now.AddDays(1),
                Nome = "Teste Criacao"
            };

            lembrete.SetId();

            var mockLembreteRepository = new Mock<ILembretesRepository>();
            mockLembreteRepository.Setup(x => x.SearchById(lembrete.Id)).Returns(lembrete);
            mockLembreteRepository.Setup(x => x.Delete(lembrete));

            new LembretesService(mockLembreteRepository.Object).Delete(lembrete.Id);

            mockLembreteRepository.Verify(x => x.SearchById(lembrete.Id), Times.Once);
            mockLembreteRepository.Verify(x => x.Delete(lembrete), Times.Once);
        }

        [Fact]
        public void Delete_InvalidLembrete_ShouldReturnOk()
        {
            Guid id = Guid.NewGuid();

            var mockLembreteRepository = new Mock<ILembretesRepository>();
            mockLembreteRepository.Setup(x => x.SearchById(id));

            new LembretesService(mockLembreteRepository.Object).Delete(id);

            mockLembreteRepository.Verify(x => x.SearchById(id), Times.Once);
        }

        [Fact]
        public void List_Lembretes_ShouldReturnOk()
        {
            List<Lembrete> lembretes = new List<Lembrete>();

            lembretes.Add(new Lembrete
            {
                Date = DateTime.Now.AddDays(1).Date,
                Nome = "Teste cria��o"
            });

            lembretes.Add(new Lembrete
            {
                Date = DateTime.Now.AddDays(1).Date,
                Nome = "Teste cria��o"
            });

            lembretes.Add(new Lembrete
            {
                Date = DateTime.Now.AddDays(3).Date,
                Nome = "Teste cria��o"
            });

            lembretes.Add(new Lembrete
            {
                Date = DateTime.Now.AddDays(5).Date,
                Nome = "Teste cria��o"
            });

            lembretes.ForEach(x =>
            {
                x.SetId();
            });

            var mockLembreteRepository = new Mock<ILembretesRepository>();
            mockLembreteRepository.Setup(x => x.List()).Returns(lembretes);

            var response = new LembretesService(mockLembreteRepository.Object).List();

            Assert.NotNull(response);
            Assert.Equal(3, response.Count);
        }

        [Fact]
        public void Get_ValidLembrete_ShouldReturnOk()
        {
            var lembrete = new Lembrete
            {
                Date = DateTime.Now.AddDays(1),
                Nome = "Teste Criacao"
            };

            lembrete.SetId();

            var mockLembreteRepository = new Mock<ILembretesRepository>();
            mockLembreteRepository.Setup(x => x.SearchById(lembrete.Id)).Returns(lembrete);
          
            var lembreteResponse = new LembretesService(mockLembreteRepository.Object).GetById(lembrete.Id);

            Assert.NotNull(lembreteResponse);
            Assert.Equal(lembrete.Date, lembreteResponse.Date);
            Assert.Equal(lembrete.Nome, lembreteResponse.Eventos.ToList().First().Nome);
            Assert.Equal(lembrete.Id, lembreteResponse.Eventos.ToList().First().Id);
        }


        [Fact]
        public void Get_InvalidLembrete_ShouldReturnNull()
        {
            Guid id = Guid.NewGuid();

            var mockLembreteRepository = new Mock<ILembretesRepository>();
            mockLembreteRepository.Setup(x => x.SearchById(id));

            var lembreteResponse = new LembretesService(mockLembreteRepository.Object).GetById(id);

            Assert.Null(lembreteResponse);
        }

        [Fact]
        public void Put_ValidLembrete_ShouldReturnOk()
        {
            var id = Guid.NewGuid();

            var lembrete = new Lembrete
            {
                Date = DateTime.Now.AddDays(5),
                Nome = "Teste Criacao"
            };

            var lembreteAntigo = new Lembrete
            {
                Date = DateTime.Now.AddDays(2),
                Nome = "lmbrete antigo"
            };

            lembreteAntigo.SetId(id);

            var mockLembreteRepository = new Mock<ILembretesRepository>();
            mockLembreteRepository.Setup(x => x.SearchById(id)).Returns(lembreteAntigo);

            var lembreteResponse = new LembretesService(mockLembreteRepository.Object).PutById(id, lembrete);

            Assert.NotNull(lembreteResponse);
            Assert.Equal(lembreteResponse.Date, lembrete.Date);
            Assert.Equal(lembreteResponse.Nome, lembrete.Nome);
            Assert.Equal(lembreteResponse.Id, lembrete.Id);
        }

        [Fact]
        public void Put_InvalidLembrete_ShouldReturnNull()
        {
            Guid id = Guid.NewGuid();

            var lembrete = new Lembrete
            {
                Date = DateTime.Now.AddDays(1),
                Nome = "TESTE"
            };

            var mockLembreteRepository = new Mock<ILembretesRepository>();
            mockLembreteRepository.Setup(x => x.SearchById(id));

            var lembreteResponse = new LembretesService(mockLembreteRepository.Object).PutById(id, lembrete);

            Assert.Null(lembreteResponse);
        }
    }
}