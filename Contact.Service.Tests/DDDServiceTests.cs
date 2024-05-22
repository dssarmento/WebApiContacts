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
        private readonly Mock<ILogger<DDDService>> _logger;
        private readonly IDDDService _service;

        public DDDServiceTests()
        {
            _repository = new Mock<IDDDRepository>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<DDDService>>();
            _service = new DDDService(_repository.Object, _mapper.Object, _logger.Object);
        }
               

        [Fact]
        public async void DDDServiceDeveCriarUmObjeto()
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

            _repository.Setup(repository => repository.CriaDDD(It.IsAny<DDD>())).ReturnsAsync(ddd);
            _mapper.Setup(map => map.Map<DDDViewModel>(ddd)).Returns(dddViewModel);

            // Act
            var criarDDD = await _service.CriaDDD(dddViewModel);

            

            // Assert
            Assert.Equal(ddd, criarDDD);
        }

        [Fact]
        public async void DDDServiceDeveAtualizarUmObjeto()
        {
            // Arrange
            var ddd = new DDD
            {
                DDDId = 1,
                Ddd = 51,
                Nome = "Rio Grande"
            };

            var dddUpdate = new DDDViewUpdateModel
            {
                DDDId = 1,
                Ddd = 51,
                Nome = "Rio Grande"
            };

            _repository.Setup(repository => repository.AtualizaDDD(It.IsAny<DDD>())).ReturnsAsync(ddd);
            _mapper.Setup(map => map.Map<DDDViewUpdateModel>(ddd)).Returns(dddUpdate);

            // Act
            var atualizaDDD = await _service.AtualizaDDD(dddUpdate);

            // Assert
            Assert.Equal(ddd, atualizaDDD);
        }

        [Fact]
        public async void DDDServiceDeveRetornarLista()
        {
            // Arrange
            List<DDD> listaDeDDD = new List<DDD>()
            {
                new DDD
                {
                    DDDId = 1,
                    Ddd = 51,
                    Nome = "Rio Grande do Sul"
                }
            };
            List<DDDViewModel> listaDeDDDViewModel = new List<DDDViewModel>()
            {
                new DDDViewModel
                {
                    Ddd = 51,
                    Nome = "Rio Grande do Sul"
                }
            };

            _repository.Setup(repository => repository.BuscaTodosDDDs()).ReturnsAsync(listaDeDDD);
            _mapper.Setup(map => map.Map<List<DDDViewModel>>(listaDeDDD)).Returns(listaDeDDDViewModel);

            // Act
            var buscaDDD = await _service.BuscaTodosDDDs();


            // Assert
            Assert.Equal(listaDeDDD, buscaDDD);
        }

        [Fact]
        public async void DDDServiceDeveRetornarUmObjeto()
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

            _repository.Setup(repository => repository.BuscaDDDPorId(It.IsAny<int>())).ReturnsAsync(ddd);
            _mapper.Setup(map => map.Map<DDDViewModel>(ddd)).Returns(dddViewModel);

            // Act
            var buscaDddPorId = await _service.BuscaDDDPorId(1);

            // Assert
            Assert.Equal(dddViewModel, buscaDddPorId);
        }

        [Fact]
        public async void DDDServiceDeveExecutarComSucesso()
        {
            // Arrange
            _repository.Setup(repository => repository.DeletaDDD(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var deletaDDD = await _service.DeletaDDD(1);

            // Assert
            Assert.True(deletaDDD);
        }
    }
}
