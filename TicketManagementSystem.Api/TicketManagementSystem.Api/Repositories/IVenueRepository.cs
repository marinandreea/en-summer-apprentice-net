using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagementSystem.Api.Models;

namespace TicketManagementSystem.Api.Repositories
{
    public interface IVenueRepository
    {
        Task Update(Venue venue);
        Task<Venue> getVenueByOrder(Orderr @order);
    }
}
