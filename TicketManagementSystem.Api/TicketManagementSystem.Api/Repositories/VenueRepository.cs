using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Api.Models;

namespace TicketManagementSystem.Api.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        private readonly practicaContext _dbContext;
        //private readonly ITicketCategoryRepository _ticketCategoryRepository;
        //private readonly IEventRepository _eventRepository;


        public VenueRepository()
        {
            _dbContext = new practicaContext();
           // _ticketCategoryRepository = ticketCategoryRepository;
           // _eventRepository = eventRepository;
        }

        public async Task<Venue> getVenueByOrder(Orderr @order)
        {
            var ticketCategory = await _dbContext.TicketCategories.Where(t => t.TicketCategoryId == order.TicketCategoryId).FirstOrDefaultAsync();
            var @event = await _dbContext.Events.Where(e => e.EventId == ticketCategory.EventId).FirstOrDefaultAsync();
            var venue = await _dbContext.Venues.Where(v => v.VenueId == @event.VenueId).FirstOrDefaultAsync();
            return venue;
        }

        public async Task Update(Venue venue)
        {
            _dbContext.Entry(venue).State = EntityState.Modified;
           await _dbContext.SaveChangesAsync();
        }
    }
}
