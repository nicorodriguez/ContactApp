using ContactApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Model.Mappers
{
    public static class ContactMapper
    {
        public static ContactDTO MapToDTO(this Contact contact)
        {
            var contactDTO = new ContactDTO()
            {
                ContactId = contact.ContactId,
                ProfileId = contact.ProfileId,
                ProfileName = contact.Profile.Name,
                Name =      contact.Name,
                Company =   contact.Company,
                Image =     contact.Image,
                Email =     contact.Email,
                Birthdate = contact.Birthdate,
                WorkNumber = contact.WorkNumber,
                PersonalNumber = contact.PersonalNumber,
                Address =   contact.Address,
                City =      contact.City,
                State =     contact.State,
            };

            return contactDTO;
        }

        public static Contact MapFromDTO(this ContactDTO contactDTO)
        {
            var contact = new Contact()
            {
                ContactId = contactDTO.ContactId,
                ProfileId = contactDTO.ProfileId,
                Name =      contactDTO.Name,
                Company =   contactDTO.Company,
                Image =     contactDTO.Image,
                Email =     contactDTO.Email,
                Birthdate = contactDTO.Birthdate,
                WorkNumber = contactDTO.WorkNumber,
                PersonalNumber = contactDTO.PersonalNumber,
                Address =   contactDTO.Address,
                City =      contactDTO.City,
                State =     contactDTO.State,
                Profile =   null
            };

            return contact;
        }

        public static Contact MapFromDTO(this ContactDTO contactDTO, Profile profile)
        {
            var contact = new Contact()
            {
                ContactId = contactDTO.ContactId,
                ProfileId = contactDTO.ProfileId,
                Name =      contactDTO.Name,
                Company =   contactDTO.Company,
                Image =     contactDTO.Image,
                Email =     contactDTO.Email,
                Birthdate = contactDTO.Birthdate,
                WorkNumber = contactDTO.WorkNumber,
                PersonalNumber = contactDTO.PersonalNumber,
                Address =   contactDTO.Address,
                City =      contactDTO.City,
                State =     contactDTO.State,
                Profile =   profile
            };

            return contact;
        }
    }
}
