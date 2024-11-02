using Contacts.Data.Context;
using Contacts.Domain.Interfaces;
using Contacts.Domain.ModelsView;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            return Ok(_dDDService.GetAll());
        }

        [HttpGet("GetDDD/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dDDService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(DDDViewModel dDD)
        {
            return Ok(_dDDService.Post(dDD));
        }

        [HttpPut]
        public IActionResult Put(DDDViewModel dDD)
        {
            return Ok(_dDDService.Put(dDD));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_dDDService.Delete(id));
        }
    }
}
