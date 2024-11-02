using AutoMapper;
using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;
using Contacts.Service.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Contact.Service.Tests
{
    public sealed class ContatoServiceTests
    {
        private readonly Mock<IContatoRepository> _repository;
        private readonly Mock<IDDDRepository> _repositoryDDD;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<ContatoService>> _logger;
        private readonly Mock<ILogger<DDDService>> _loggerDDD;
        private readonly IContatoService _service;
        private readonly IDDDService _serviceDDD;

        public ContatoServiceTests()
        {
            _repository = new Mock<IContatoRepository>();
            _repositoryDDD = new Mock<IDDDRepository>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<ContatoService>>();
            _loggerDDD = new Mock<ILogger<DDDService>>();
            _service = new ContatoService(_repository.Object, _mapper.Object, _logger.Object);
            _serviceDDD = new DDDService(_repositoryDDD.Object, _mapper.Object, _loggerDDD.Object);
        }

        [Fact]
        public async void ContatoServiceDeveCriarUmObjeto()
        {
            // Arrange
            var ddd = new DDD
            {
                DDDId = 1,
                Ddd = 51,
                Nome = "Rio Grande do Sul"
            };

            var dddViewModel = new DDDViewModel
            {
                Ddd = 51,
                Nome = "Rio Grande do Sul"
            };

            _repositoryDDD.Setup(repository => repository.CriaDDD(It.IsAny<DDD>())).ReturnsAsync(ddd);
            _mapper.Setup(map => map.Map<DDDViewModel>(ddd)).Returns(dddViewModel);

            // Act
            var criarDDD = _serviceDDD.CriaDDD(dddViewModel);

            var contato = new Contato
            {
                ContatoId = 1,
                Nome = "Contato Teste",
                Email = "AdminTeste@hotmail.com",
                Telefone = "51999999999",
                DDDId = 1
            };

            var contatoViewModel = new ContatoViewModel
            {
                Nome = "Contato Teste",
                Email = "AdminTeste@hotamil.com",
                Telefone = "51999999999",
                DDDId = 1
            };

            _repository.Setup(repository => repository.CriaContato(It.IsAny<Contato>())).ReturnsAsync(contato);
            _mapper.Setup(map => map.Map<ContatoViewModel>(contato)).Returns(contatoViewModel);

            var criarContato = await _service.CriaNovoContato(contatoViewModel);

            // Assert
            Assert.Equal(contato, criarContato);
        }

        [Fact]
        public async void ContatoServiceDeveAtualizarUmObjeto()
        {
            var contato = new Contato
            {
                ContatoId = 1,
                Nome = "Contato Teste",
                Email = "AdminTeste@hotmail.com",
                Telefone = "51999999999",
                DDDId = 1
            };

            var contatoUpdate = new ContatoViewUpdateModel
            { 
                ContatoId = 1,
                Nome = "Contato Teste",
                Email = "AdminTeste@hotamil.com",
                Telefone = "51999999999",
                DDDId = 1
            };

           _repository.Setup(repository => repository.AtualizaContato(It.IsAny<Contato>())).ReturnsAsync(contato);
            _mapper.Setup(map => map.Map<ContatoViewUpdateModel>(contato)).Returns(contatoUpdate);

            // Act
            var atualizaContato = await _service.AtualizaContato(contatoUpdate);

            // Assert
            Assert.Equal(contato, atualizaContato);
        }

        [Fact]
        public async void ContatoServiceDeveRetornarLista()
        {
            // Arrange
            List<Contato> listaDeContato = new List<Contato>()
            {
                new Contato
                {
                    ContatoId = 1,
                    Nome = "Contato Teste",
                    Email = "AdminTeste@hotmail.com",
                    Telefone = "51999999999",
                    DDDId = 1
                }
            };

            List<ContatoViewModel> listaDeContatoViewModel = new List<ContatoViewModel>()
            {
                new ContatoViewModel
                {
                    Nome = "Contato Teste",
                    Email = "AdminTeste@hotmail.com",
                    Telefone = "51999999999",
                    DDDId = 1
                }
            };

            _repository.Setup(repository => repository.BuscaTodosContatos()).ReturnsAsync(listaDeContato);
            _mapper.Setup(map => map.Map<List<ContatoViewModel>>(listaDeContato)).Returns(listaDeContatoViewModel);

            // Act
            var buscaDDD = await _service.BuscaTodosContatos();


            // Assert
            Assert.Equal(listaDeContato, buscaDDD);
        }

        [Fact]
        public async void ContatoServiceDeveRetornarUmObjeto()
        {
            // Arrange
            var contato = new Contato
            {
                ContatoId = 1,
                Nome = "Contato Teste",
                Email = "AdminTeste@hotmail.com",
                Telefone = "51999999999",
                DDDId = 1
            };

            var contatoViewModel = new ContatoViewModel
            {
                Nome = "Contato Teste",
                Email = "AdminTeste@hotamil.com",
                Telefone = "51999999999",
                DDDId = 1
            };

            _repository.Setup(repository => repository.BuscaContatoPorId(It.IsAny<int>())).ReturnsAsync(contato);
            _mapper.Setup(map => map.Map<ContatoViewModel>(contato)).Returns(contatoViewModel);

            // Act
            var buscaDddPorId = await _service.BuscaContatoPorId(1);

            // Assert
            Assert.Equal(contato, buscaDddPorId);
        }

        [Fact]
        public async void ContatoServiceDeveRetornarListaPorDDDId()
        {
            // Arrange
            List<Contato> listaDeContato = new List<Contato>()
            {
                new Contato
                {
                    ContatoId = 1,
                    Nome = "Contato Teste",
                    Email = "AdminTeste@hotmail.com",
                    Telefone = "51999999999",
                    DDDId = 1,
                    DDD = new DDD
                    {
                        DDDId = 1,
                        Ddd = 51,
                        Nome = "Rio Grande do Sul"
                    }
                }
            };

            List<ContatoViewModel> listaDeContatoViewModel = new List<ContatoViewModel>()
            {
                new ContatoViewModel
                {
                    Nome = "Contato Teste",
                    Email = "AdminTeste@hotmail.com",
                    Telefone = "51999999999",
                    DDDId = 1
                }
            };

            _repository.Setup(repository => repository.BuscaContatosPorDDDId(1)).ReturnsAsync(listaDeContato);
            _mapper.Setup(map => map.Map<List<ContatoViewModel>>(listaDeContato)).Returns(listaDeContatoViewModel);

            // Act
            var buscaContato = await _service.BuscaContatoPorDDDId(1);


            // Assert
            Assert.Equal(listaDeContato, buscaContato);
        }

        [Fact]
        public async void ContatoServiceDeveRetornarListaPorDDDNome()
        {
            // Arrange
            List<Contato> listaDeContato = new List<Contato>()
            {
                new Contato
                {
                    ContatoId = 1,
                    Nome = "Contato Teste",
                    Email = "AdminTeste@hotmail.com",
                    Telefone = "51999999999",
                    DDDId = 1,
                    DDD = new DDD
                    {
                        DDDId = 1,
                        Ddd = 51,
                        Nome = "Rio Grande do Sul"
                    }
                }
            };

            List<ContatoViewModel> listaDeContatoViewModel = new List<ContatoViewModel>()
            {
                new ContatoViewModel
                {
                    Nome = "Contato Teste",
                    Email = "AdminTeste@hotmail.com",
                    Telefone = "51999999999",
                    DDDId = 1
                }
            };

            _repository.Setup(repository => repository.BuscaContatosPorDDDNome("Rio Grande do Sul")).ReturnsAsync(listaDeContato);
            _mapper.Setup(map => map.Map<List<ContatoViewModel>>(listaDeContato)).Returns(listaDeContatoViewModel);

            // Act
            var buscaContato = await _service.BuscaContatoPorDDDNome("Rio Grande do Sul");


            // Assert
            Assert.Equal(listaDeContato, buscaContato);
        }

        [Fact]
        public async void ContatoServiceDeveExecutarComSucesso()
        {
            // Arrange
            _repository.Setup(repository => repository.DeletaContato(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var deletaContato = await _service.DeletaContato(1);

            // Assert
            Assert.True(deletaContato);
        }

    }
}