using System;
using System.Collections.Generic;

#nullable disable

namespace TicketManagementSystem.Api.Models
{
    public partial class TicketCategory
    {
        public TicketCategory()
        {
            Orderrs = new HashSet<Orderr>();
        }

        public int TicketCategoryId { get; set; }
        public int EventId { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<Orderr> Orderrs { get; set; }
    }
}
