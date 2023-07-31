using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagementSystem.Api.Models.Dto
{
    public class VenuePatchDto
    {
        public int VenueId { get; set; }
        public int Capacity { get; set; }
    }
}
