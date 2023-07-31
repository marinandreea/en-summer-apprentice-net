using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagementSystem.Api.Models;

namespace TicketManagementSystem.Api.Repositories
{
   public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event> GetById(int id);
        int Add(Event @event);
        Task Update(Event @event);
        Task Delete(Event @event);

    }
}
