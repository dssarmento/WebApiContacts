using AutoMapper;
using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;
using Microsoft.Extensions.Logging;

namespace Contacts.Service.Services
{
    public class DDDService : IDDDService
    {
        private readonly IDDDRepository _dDDRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DDDService> _logger;

        public DDDService(IDDDRepository dDDRepository, IMapper mapper, ILogger<DDDService> logger)
        {
            _dDDRepository = dDDRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<DDD>> BuscaTodosDDDs()
        {
            try
            {
                return await _dDDRepository.BuscaTodosDDDs();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public async Task<DDDViewModel> BuscaDDDPorId(int id)
        {
            try
            {
                return _mapper.Map<DDDViewModel>(await _dDDRepository.BuscaDDDPorId(id));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public async Task<DDD> CriaDDD(DDDViewModel DDD)
        {
            try
            {
                var DddMapping = _dDDRepository.CriaDDD(_mapper.Map<DDD>(DDD));
                return await DddMapping;
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public async Task<DDD> AtualizaDDD(DDDViewUpdateModel dDD)
        {
            try
            {
                DDD vdDD = new DDD();
                vdDD.DDDId = dDD.DDDId;
                vdDD.Ddd = dDD.Ddd;
                vdDD.Nome = dDD.Nome;
                var DddMapping = _dDDRepository.AtualizaDDD(vdDD);
                return await DddMapping;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public async Task<bool> DeletaDDD(int id)
        {
            try
            {
                return await _dDDRepository.DeletaDDD(id);
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }
    }
}
