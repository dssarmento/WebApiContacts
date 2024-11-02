using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApiContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService contatoervice;

        public ContatoController(IContatoService contatoervice)
        {
            this.contatoervice = contatoervice;
        }

        [HttpGet("dddsById/{id}")]
        public ActionResult<List<Contato>> GetContatosDDDId(int id)
        {
            return Ok(contatoervice.GetContatosDDDId(id));
        }

        [HttpGet("dddsByNome/{nome}")]
        public ActionResult<List<Contato>> GetContatosDDDNome(string nome)
        {
            return Ok(contatoervice.GetContatosDDDNome(nome));
        }


        [HttpGet("todos")]
        public ActionResult<List<Contato>> Get()
        {
            return Ok(contatoervice.GetAll());
        }


        [HttpGet("{id}", Name = "GetContato")]
        public ActionResult<ContatoViewModel> Get(int id)
        {
            return Ok(contatoervice.GetByID(id));
        }

        [HttpPost]
        public ActionResult<ContatoViewModel> Post([FromBody] ContatoViewModel contato)
        {
            return Ok(contatoervice.Post(contato));
        }

        [HttpPut]
        public ActionResult<ContatoViewModel> Put(ContatoViewModel contato)
        {
            return Ok(contatoervice.Put(contato));
        }

        [HttpDelete("{id}")]
        public ActionResult<ContatoViewModel> Delete(int id)
        {
            return Ok(contatoervice.Delete(id));
        }
    }
}
