using AutoMapper;
using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;
using Microsoft.Extensions.Logging;

namespace Contacts.Service.Services
{
    public  class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ContatoService> _logger;

        public ContatoService(IContatoRepository contatoRepository,IMapper mapper, ILogger<ContatoService> logger)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public IList<ContatoViewModel> BuscaTodosContatos()
        {
            try
            {
                return _mapper.Map <IList<ContatoViewModel>> (_contatoRepository.BuscaTodosContatos());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public ContatoViewModel BuscaContatoPorId(int id)
        {
            try
            {
                return _mapper.Map<ContatoViewModel>(_contatoRepository.BuscaContatoPorId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public IList<ContatoViewModel> BuscaContatoPorDDDId(int id)
        {
            try
            {
                return _mapper.Map<IList<ContatoViewModel>>(_contatoRepository.BuscaContatosPorDDDId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public IList<ContatoViewModel> BuscaContatoPorDDDNome(string Nome)
        {
            try
            {
                return _mapper.Map<IList<ContatoViewModel>>(_contatoRepository.BuscaContatosPorDDDNome(Nome));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public ContatoViewModel CriaNovoContato(ContatoViewModel contatoView)
        {
            try
            {
                return _mapper.Map<ContatoViewModel>(_contatoRepository.CriaContato(_mapper.Map<Contato>(contatoView)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public ContatoViewModel AtualizaContato(ContatoViewModel contato)
        {
            try
            {
                return _mapper.Map<ContatoViewModel>(_contatoRepository.AtualizaContato(_mapper.Map<Contato>(contato)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public bool DeletaContato(int id)
        {
            try
            {
                return _contatoRepository.DeletaContato(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }
    }
}
