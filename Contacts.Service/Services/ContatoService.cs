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

        public async Task<List<Contato>> BuscaTodosContatos()
        {
            try
            {
                return await _contatoRepository.BuscaTodosContatos();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public async Task<Contato> BuscaContatoPorId(int id)
        {
            try
            {
                return await _contatoRepository.BuscaContatoPorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public async Task<List<Contato>> BuscaContatoPorDDDId(int id)
        {
            try
            {
                return await _contatoRepository.BuscaContatosPorDDDId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public async Task<List<Contato>> BuscaContatoPorDDDNome(string Nome)
        {
            try
            {
                return await _contatoRepository.BuscaContatosPorDDDNome(Nome);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public async Task<Contato> CriaNovoContato(ContatoViewModel Contato)
        {
            try
            {
                var ContatoMapping = await _contatoRepository.CriaContato(_mapper.Map<Contato>(Contato));

                return ContatoMapping;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public async Task<Contato> AtualizaContato(ContatoViewUpdateModel contato)
        {
            try
            {
                Contato vContato = new Contato();
                vContato.ContatoId = contato.ContatoId;
                vContato.Nome = contato.Nome;
                vContato.Telefone = contato.Telefone;
                vContato.Email = contato.Email;
                vContato.DDDId = contato.DDDId;
                var ContatoMapping = await _contatoRepository.AtualizaContato(vContato);
                return ContatoMapping;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public async Task<bool> DeletaContato(int id)
        {
            try
            {
                return await _contatoRepository.DeletaContato(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }
    }
}
