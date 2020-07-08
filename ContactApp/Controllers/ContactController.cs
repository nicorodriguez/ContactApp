using ContactApp.Domain.ContactDomain;
using ContactApp.DTO;
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

        // GET: api/Contact/Get
        [EnableCors]
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetAll()
        {
            var result = await _domain.GetAll();

            if (result.IsSuccessful == false)
                return StatusCode(500, result);

            return Ok(result);
        }

        // GET: api/Contact/Get/2
        [EnableCors]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ContactDTO>> GetById(int id)
        {
            var result = await _domain.GetById(id);

            if (result.Result == null)
                return NotFound(result);
            if (result.IsSuccessful == false)
                return StatusCode(500, result);

            return Ok(result);
        }

        // GET: api/Contact/GetByEmailOrPhoneNumber/34
        [EnableCors]
        [HttpGet("GetByEmailOrPhoneNumber/{search}")]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetByEmailOrPhoneNumber(string search)
        {
            var result = await _domain.GetByEmailOrPhoneNumber(search);

            if (result.IsSuccessful == false)
                return StatusCode(500, result);

            return Ok(result);
        }

        // GET: api/Contact/GetByCity/Capital Federal
        [EnableCors]
        [HttpGet("GetByCity/{search}")]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetByCity(string search)
        {
            var result = await _domain.GetByCity(search);

            if (result.IsSuccessful == false)
                return StatusCode(500, result);

            return Ok(result);
        }

        // GET: api/Contact/GetByState/Buenos Aires
        [EnableCors]
        [HttpGet("GetByState/{search}")]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetByState(string search)
        {
            var result = await _domain.GetByState(search);

            if (result.IsSuccessful == false)
                return StatusCode(500, result);

            return Ok(result);
        }

        // POST: api/Contact/Create
        [EnableCors]
        [HttpPost("Create")]
        public async Task<ActionResult> CreateContact([FromBody] ContactDTO contact)
        {
            var result = await _domain.Create(contact);

            if (result.IsSuccessful == false)
                return StatusCode(500, result);

            return Ok(result);
        }

        // POST: api/Contact/Update
        [EnableCors]
        [HttpPost("Update")]
        public async Task<ActionResult> UpdateContact([FromBody] ContactDTO contact)
        {
            var result = await _domain.Update(contact);

            if (result.IsSuccessful == false)
                return StatusCode(500, result);

            return Ok(result);
        }

        // DELETE: api/Contact/5
        [EnableCors]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var result = await _domain.Delete(id);

            if (result.IsSuccessful == false)
                return StatusCode(500, result);

            return Ok(result);
        }
    }
}
