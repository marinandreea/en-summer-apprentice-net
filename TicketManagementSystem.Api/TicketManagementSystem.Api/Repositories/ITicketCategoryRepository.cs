using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagementSystem.Api.Models;

namespace TicketManagementSystem.Api.Repositories
{
    public interface ITicketCategoryRepository
    {
        Task<TicketCategory> GetById(int id);
    }
}
