using System;
using System.Collections.Generic;

#nullable disable

namespace TicketManagementSystem.Api.Models
{
    public partial class TotalNumberOfTicketsPerCategory
    {
        public int? TicketCategoryId { get; set; }
        public int? TotalTicketsSold { get; set; }
        public decimal? TotalPriceForTickets { get; set; }
    }
}
