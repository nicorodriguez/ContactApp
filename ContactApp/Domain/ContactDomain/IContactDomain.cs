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
    }
}
