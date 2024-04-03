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
using Microsoft.AspNetCore.Http.HttpResults;


namespace WebApiContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DDDController : ControllerBase
    {
        private readonly IDDDService _dDDService;
        private readonly AppDbContext context;
        public DDDController(AppDbContext context, IDDDService dDDService)
        {
            this.context = context;
            this._dDDService = dDDService;
        }

        [HttpGet("todas")]
        public async Task<IActionResult> Get()
        {
            //return (IActionResult)context.DDDs.ToList();
            return Ok(_dDDService.GetAll());
        }

        [HttpGet("{id}", Name = "GetDDD")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            //return await context.DDDs.FirstOrDefaultAsync(x => x.DDDId == id);
            return (IActionResult)_dDDService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DDDView dDD)
        {
            //DDD ddados = new DDD();
            //ddados.Nome = dDD.Nome;

            //context.Add(ddados);
            //await context.SaveChangesAsync();

            //DDDRetornoView dretorno = new DDDRetornoView();
            //dretorno.DDDId = ddados.DDDId;
            //dretorno.Nome = ddados.Nome;

            //return Ok(dretorno);
            return (IActionResult)_dDDService.Post(dDD);
        }

        [HttpPut]
        public async Task<IActionResult> Put(DDDRetornoView dDD)
        {
            //DDD ddados = new DDD();
            //ddados.DDDId = dDD.DDDId;
            //ddados.Nome = dDD.Nome;

            //context.Entry(ddados).State = EntityState.Modified;
            //await context.SaveChangesAsync();

            //return Ok(dDD);
            return (IActionResult)_dDDService.Put(dDD);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var dDD = new DDD { DDDId = id };
            //context.Remove(dDD);
            //await context.SaveChangesAsync();
            //return Ok(dDD);
            return (IActionResult)_dDDService.Delete(id);
        }
    }
}
