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

        public List<DDD> BuscaTodosDDDs()
        {
            try
            {
                return _dDDRepository.BuscaTodosDDDs();
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

        public DDD CriaDDD(DDDViewModel DDD)
        {
            try
            {
                var DddMapping = _dDDRepository.CriaDDD(_mapper.Map<DDD>(DDD));
                return DddMapping;
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        public DDD AtualizaDDD(DDDViewUpdateModel dDD)
        {
            try
            {
                DDD vdDD = new DDD();
                vdDD.DDDId = dDD.DDDId;
                vdDD.Ddd = dDD.Ddd;
                vdDD.Nome = dDD.Nome;
                var DddMapping = _dDDRepository.AtualizaDDD(vdDD);
                return DddMapping;
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
