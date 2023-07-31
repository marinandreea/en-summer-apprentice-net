using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagementSystem.Api.Models.Dto
{
    public class OrderDto
    {
        public string TicketCategory { get; set; } = string.Empty;
        public DateTime? OrderedAt { get; set; }
        public int? NumberOfTickets { get; set; }
        public double? TotalPrice { get; set; }
    }
}
