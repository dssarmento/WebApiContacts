using AutoMapper;
using Contacts.Data.Repositorys;
using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;
using Microsoft.Extensions.Logging;
using NPOI.SS.Formula.Functions;

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

        public List<Contato> BuscaTodosContatos()
        {
            try
            {
                return _contatoRepository.BuscaTodosContatos();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public Contato BuscaContatoPorId(int id)
        {
            try
            {
                return _contatoRepository.BuscaContatoPorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public List<Contato> BuscaContatoPorDDDId(int id)
        {
            try
            {
                return _contatoRepository.BuscaContatosPorDDDId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public List<Contato> BuscaContatoPorDDDNome(string Nome)
        {
            try
            {
                return _contatoRepository.BuscaContatosPorDDDNome(Nome);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public Contato CriaNovoContato(ContatoViewModel Contato)
        {
            try
            {
                var ContatoMapping = _contatoRepository.CriaContato(_mapper.Map<Contato>(Contato));
                return ContatoMapping;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public Contato AtualizaContato(ContatoViewUpdateModel contato)
        {
            try
            {
                Contato vContato = new Contato();
                vContato.ContatoId = contato.ContatoId;
                vContato.Nome = contato.Nome;
                vContato.Telefone = contato.Telefone;
                vContato.Email = contato.Email;
                vContato.DDDId = contato.DDDId;
                var ContatoMapping = _contatoRepository.AtualizaContato(vContato);
                return ContatoMapping;
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
