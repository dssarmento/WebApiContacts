using Contacts.Domain.Interfaces;
using Contacts.Domain.ModelsView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : Controller
    {
        private readonly IContatoService _contatoService;
        private readonly ILogger<ContatoController> _logger;

        public ContatoController( IContatoService contatoService, ILogger<ContatoController> logger)
        {
            _contatoService = contatoService;
            _logger = logger;
        }

        [HttpGet("BuscaTodosContatos")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(_contatoService.BuscaTodosContatos().Result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        [HttpGet("BuscaContatoPorId/{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_contatoService.BuscaContatoPorId(id).Result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        [HttpGet("BuscaContatoPorDDDId/{id}")]
        [Authorize]
        public IActionResult GetContatosDDDId(int id)
        {
            try
            {
                return Ok(_contatoService.BuscaContatoPorDDDId(id).Result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        [HttpGet("dddsByNome/{nome}")]
        [Authorize]
        public IActionResult GetContatosDDDNome(string nome)
        {
            try
            {
                return Ok(_contatoService.BuscaContatoPorDDDNome(nome).Result);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CriaNovoContato([FromBody] ContatoViewModel contato)
        {
            try
            {
                return Ok(_contatoService.CriaNovoContato(contato).Result);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult AtualizaContato(ContatoViewUpdateModel contato)
        {
            try
            {
                return Ok(_contatoService.AtualizaContato(contato).Result);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeletaContato(int id)
        {
            try
            {
                return Ok(_contatoService.DeletaContato(id).Result);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Erro na aplicação - {ex}");
                throw;
            }
        }
    }
}
