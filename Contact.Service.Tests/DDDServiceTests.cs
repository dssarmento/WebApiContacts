using AutoMapper;
using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;
using Contacts.Service.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Contact.Service.Tests
{
    public sealed class DDDServiceTests
    {
        private readonly Mock<IDDDRepository> _repository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<ContatoService>> _logger;
        private readonly IDDDService _service;

        public DDDServiceTests()
        {
            _repository = new Mock<IDDDRepository>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<ContatoService>>();
            _service = new DDDService(_repository.Object, _mapper.Object, _logger.Object);
        }

        [Fact]
        public void DDDServiceDeveRetornarLista()
        {
            // Arrange
            IList<DDD> listaDeDDD = new List<DDD>()
            {
                new DDD
                {
                    DDDId = 1,
                    Nome = "Rio Grande do Sul"
                }
            }; 
            
            IList<DDDViewModel> listaDeDDDViewModel = new List<DDDViewModel>()
            {
                new DDDViewModel
                {
                    DDDId = 1,
                    Nome = "Rio Grande do Sul"
                }
            };
            _repository.Setup(repository => repository.BuscaTodosDDDs()).Returns(listaDeDDD);
            _mapper.Setup(map => map.Map<IList<DDDViewModel>>(listaDeDDD)).Returns(listaDeDDDViewModel);

            // Act
            var buscaDDD = _service.BuscaTodosDDDs();

            // Assert
            Assert.Equal(listaDeDDDViewModel, buscaDDD);
        }
        
        [Fact]
        public void DDDServiceDeveRetornarUmObjeto()
        {
            // Arrange
            var ddd = new DDD
            {
               DDDId = 1,
               Nome = "Rio Grande do Sul"
            }; 
            
            var dddViewModel = new DDDViewModel
            {
                DDDId = 1,
                Nome = "Rio Grande do Sul"
            };

            _repository.Setup(repository => repository.BuscaDDDPorId(It.IsAny<int>())).Returns(ddd);
            _mapper.Setup(map => map.Map<DDDViewModel>(ddd)).Returns(dddViewModel);

            // Act
            var buscaDddPorId = _service.BuscaDDDPorId(1);

            // Assert
            Assert.Equal(dddViewModel, buscaDddPorId);
        }

        [Fact]
        public void DDDServiceDeveCriarUmObjeto()
        {
            // Arrange
            var ddd = new DDD
            {
                DDDId = 1,
                Nome = "Rio Grande do Sul"
            };

            var dddViewModel = new DDDViewModel
            {
                DDDId = 1,
                Nome = "Rio Grande do Sul"
            };

            _repository.Setup(repository => repository.CriaDDD(It.IsAny<DDD>())).Returns(ddd);
            _mapper.Setup(map => map.Map<DDDViewModel>(ddd)).Returns(dddViewModel);

            // Act
            var criarDDD = _service.CriaDDD(dddViewModel);

            // Assert
            Assert.Equal(dddViewModel, criarDDD);
        }
        
        [Fact]
        public void DDDServiceDeveAtualizarUmObjeto()
        {
            // Arrange
            var ddd = new DDD
            {
                DDDId = 1,
                Nome = "Rio Grande do Sul"
            };

            var dddViewModel = new DDDViewModel
            {
                DDDId = 1,
                Nome = "Rio Grande do Sul"
            };

            _repository.Setup(repository => repository.AtualizaDDD(It.IsAny<DDD>())).Returns(ddd);
            _mapper.Setup(map => map.Map<DDDViewModel>(ddd)).Returns(dddViewModel);

            // Act
            var atualizaDDD = _service.AtualizaDDD(dddViewModel);

            // Assert
            Assert.Equal(dddViewModel, atualizaDDD);
        }

        [Fact]
        public void DDDServiceDeveExecutarComSucesso()
        {
            // Arrange
            _repository.Setup(repository => repository.DeletaDDD(It.IsAny<int>())).Returns(true);

            // Act
            var deletaDDD = _service.DeletaDDD(1);

            // Assert
            Assert.True(deletaDDD);
        }
    }
}
