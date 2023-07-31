using System;
using System.Collections.Generic;

#nullable disable

namespace TicketManagementSystem.Api.Models
{
    public partial class Venue
    {
        public Venue()
        {
            Events = new HashSet<Event>();
        }

        public int VenueId { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
