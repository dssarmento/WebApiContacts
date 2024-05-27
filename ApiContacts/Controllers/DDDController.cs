using Contacts.Domain.Interfaces;
using Contacts.Domain.ModelsView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DDDController : Controller
    {
        private readonly IDDDService _dDDService;
        private readonly ILogger<DDDController> _logger;

        public DDDController(IDDDService dDDService, ILogger<DDDController> logger)
        {
            _dDDService = dDDService;
            _logger = logger;
        }

        [HttpGet("BuscaTodosDDD")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(_dDDService.BuscaTodosDDDs().Result);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        [HttpGet("BuscaDDDPorID/{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_dDDService.BuscaDDDPorId(id).Result);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] DDDViewModel dDD)
        {
            try
            {
                return Ok(_dDDService.CriaDDD(dDD).Result);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] DDDViewUpdateModel dDD)
        {
            try
            {
                return Ok(_dDDService.AtualizaDDD(dDD).Result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_dDDService.DeletaDDD(id).Result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }
    }
}
