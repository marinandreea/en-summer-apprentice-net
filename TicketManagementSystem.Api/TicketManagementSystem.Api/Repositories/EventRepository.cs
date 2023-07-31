using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Api.Exceptions;
using TicketManagementSystem.Api.Models;

namespace TicketManagementSystem.Api.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly practicaContext _dbContext;
        public EventRepository()
        {
            _dbContext = new practicaContext();
        }
        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Event @event)
        {
            _dbContext.Remove(@event);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var events = await _dbContext.Events.Include(e=>e.Venue).Include(e=>e.EventType).ToListAsync();

            if(events == null)
            {
                throw new EntityNotFoundException("No events found!");
            }
            return events;
        }

        public async Task<Event> GetById(int id)
        {
            var @event = await _dbContext.Events.Where(e => e.EventId == id).Include(e=>e.Venue).Include(e=>e.EventType).FirstOrDefaultAsync();
            
            if(@event == null)
            {
                throw new EntityNotFoundException(id,nameof(Event));
            }
            return @event;

        }

        public async Task Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
