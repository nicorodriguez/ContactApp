using ContactApp.DTO;
using ContactApp.Model;
using ContactApp.Model.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Domain.ContactDomain
{
    public interface IContactDomain
    {
        Task<CommandResponse<IEnumerable<ContactDTO>>> GetAll();
        Task<CommandResponse<ContactDTO>> GetById(int id);
        Task<CommandResponse<IEnumerable<ContactDTO>>> GetByEmailOrPhoneNumber(string search);
        Task<CommandResponse<IEnumerable<ContactDTO>>> GetByCity(string search);
        Task<CommandResponse<IEnumerable<ContactDTO>>> GetByState(string search);
        Task<CommandResponse> Create(ContactDTO contactDTO);
        Task<CommandResponse> Update(ContactDTO contactDTO);
        Task<CommandResponse> Delete(int id);
    }
}
