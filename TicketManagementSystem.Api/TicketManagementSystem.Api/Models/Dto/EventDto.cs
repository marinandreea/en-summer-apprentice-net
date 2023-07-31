using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagementSystem.Api.Models.Dto
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string EventType { get; set; } 
        public string Venue { get; set; }

    }
}
