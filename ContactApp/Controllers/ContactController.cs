using ContactApp.Domain.ContactDomain;
using ContactApp.Model;
using ContactApp.Model.Responses;
using ContactApp.Repository.ContactRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactDomain _domain;
        private readonly IContactRepository _repository;

        public ContactController(IContactDomain domain, IContactRepository repository)
        {
            _domain = domain;
            _repository = repository;
        }

        [EnableCors]
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
        {
            var result = await _domain.GetAll();

            if (result.IsSuccessful ==  false)
                return StatusCode(500, result);

            return Ok(result);
        }

        /*
        [EnableCors]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetById(int id)
        {
            var result = await _domain.GetById(id);

            if (result.IsSuccessful == false)
                return StatusCode(500, result);

            return Ok(result);
        }
        */
    }
}
