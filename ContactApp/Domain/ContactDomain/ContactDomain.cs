using ContactApp.DTO;
using ContactApp.Model;
using ContactApp.Model.Mappers;
using ContactApp.Model.Responses;
using ContactApp.Repository.ContactRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Domain.ContactDomain
{
    public class ContactDomain : IContactDomain
    {
        private readonly IContactRepository _contactRepository;

        public ContactDomain(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<CommandResponse<IEnumerable<ContactDTO>>> GetAll()
        {
            var result = new CommandResponse<IEnumerable<ContactDTO>>() { Result = null };

            try
            {
                result.Result = (await _contactRepository.GetAll()).Select(x => x.MapToDTO()).ToList();
                result.IsSuccessful = true;
            }
            catch (Exception e)
            {
                result.IsSuccessful = false;
                result.ErrorMessages = result.ErrorMessages.Concat(new[] { "Error: " + e.ToString() });
            }

            return result;
        }
    }
}
