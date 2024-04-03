using Contacts.Data.Context;
using WebApiContacts.Server.Utils;
using Contacts.Domain.Models;
using WebApiContacts.Domain.Recursos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Domain.ModelsView;
using Contacts.Domain.Interfaces;

namespace WebApiContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService contatoervice;
        private readonly AppDbContext context;
        public ContatoController(AppDbContext context, IContatoService contatoervice)
        {
            this.context = context;
            this.contatoervice = contatoervice;
        }

        [HttpGet("dddsById/{id:int}")]
        public async Task<ActionResult<List<Contato>>> GetContatosDDDId(int id)
        {
            return Ok(contatoervice.GetContatosDDDId(id));
        }

        [HttpGet("dddsByNome/{nome:string}")]
        public async Task<ActionResult<List<Contato>>> GetContatosDDDNome(string nome)
        {
            return Ok(contatoervice.GetContatosDDDNome(nome));
        }


        [HttpGet("todos")]
        public async Task<ActionResult<List<Contato>>> Get()
        {
            return Ok(contatoervice.GetAll());
        }
                

        [HttpGet("{id}", Name = "GetContato")]
        public async Task<ActionResult<Contato>> Get(int id)
        {
            return Ok(contatoervice.GetByID(id));
        }

        [HttpPost]
        public async Task<ActionResult<Contato>> Post(ContatoView contato)
        {
            return Ok(contatoervice.Post(contato));
        }

        [HttpPut]
        public async Task<ActionResult<Contato>> Put(ContatoRetornoView contato)
        {
            return Ok(contatoervice.Put(contato));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contato>> Delete(int id)
        {
            return Ok(contatoervice.Delete(id));
        }
    }
}
