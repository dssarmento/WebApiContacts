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
        private readonly ILogger<ContatoService> _logger;

        public DDDService(IDDDRepository dDDRepository, IMapper mapper, ILogger<ContatoService> logger)
        {
            _dDDRepository = dDDRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public IList<DDDViewModel> BuscaTodosDDDs()
        {
            try
            {
                return _mapper.Map<IList<DDDViewModel>>(_dDDRepository.BuscaTodosDDDs());
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public DDDViewModel BuscaDDDPorId(int id)
        {
            try
            {
                return _mapper.Map<DDDViewModel>(_dDDRepository.BuscaDDDPorId(id));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public DDDViewModel CriaDDD(DDDViewModel DDD)
        {
            try
            {
                var DddMapping = _dDDRepository.CriaDDD(_mapper.Map<DDD>(DDD));
                return _mapper.Map<DDDViewModel>(DddMapping);
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public DDDViewModel AtualizaDDD(DDDViewModel DDD)
        {
            try
            {
                var DddMapping = _dDDRepository.AtualizaDDD(_mapper.Map<DDD>(DDD));
                return _mapper.Map<DDDViewModel>(DddMapping);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public bool DeletaDDD(int id)
        {
            try
            {
                return _dDDRepository.DeletaDDD(id);
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }
    }
}
