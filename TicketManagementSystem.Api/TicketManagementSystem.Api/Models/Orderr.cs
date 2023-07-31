using System;
using System.Collections.Generic;

#nullable disable

namespace TicketManagementSystem.Api.Models
{
    public partial class Orderr
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public int TicketCategoryId { get; set; }
        public DateTime? OrderedAt { get; set; }
        public int? NumberOfTickets { get; set; }
        public double? TotalPrice { get; set; }

        public virtual TicketCategory TicketCategory { get; set; }
        public virtual Userr User { get; set; }
    }
}
