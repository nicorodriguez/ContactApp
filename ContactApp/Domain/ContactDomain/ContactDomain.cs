using ContactApp.DTO;
using ContactApp.Model;
using ContactApp.Model.Mappers;
using ContactApp.Model.Responses;
using ContactApp.Repository.ContactRepository;
using ContactApp.Repository.ProfileRepository;
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
        private readonly IProfileRepository _profileRepository;

        public ContactDomain(IContactRepository contactRepository, IProfileRepository profileRepository)
        {
            _contactRepository = contactRepository;
            _profileRepository = profileRepository;
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

        public async Task<CommandResponse<ContactDTO>> GetById(int id)
        {
            var result = new CommandResponse<ContactDTO>() { Result = null };

            try
            {
                var contact = await _contactRepository.GetById(id);

                if (contact is null) 
                {
                    result.IsSuccessful = true;
                }
                else
                {
                    result.Result = contact.MapToDTO();
                    result.IsSuccessful = true;
                }
            }
            catch (Exception e)
            {
                result.IsSuccessful = false;
                result.ErrorMessages = result.ErrorMessages.Concat(new[] { "Error: " + e.ToString() });
            }

            return result;
        }

        public async Task<CommandResponse> Create(ContactDTO contactDTO)
        {
            var result = new CommandResponse();

            try
            {
                var contact = contactDTO.MapFromDTO();

                var existsContactName = _contactRepository.Exists(e => e.Name.Equals(contact.Name));

                var existsProfileId = _profileRepository.Exists(e => e.ProfileId.Equals(contact.ProfileId));

                if (!existsContactName && existsProfileId)
                {
                    await _contactRepository.Create(contact);
                    result.IsSuccessful = true;
                }
                else
                {
                    result.IsSuccessful = false;

                    if (existsContactName)
                        result.ErrorMessages = result.ErrorMessages.Concat(new[] { "Error: " + "Contact has already been created" });

                    if (!existsProfileId)
                        result.ErrorMessages = result.ErrorMessages.Concat(new[] { "Error: " + "ProfileId does not exists or was deleted" });
                }
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
