using System;
using System.Collections.Generic;

#nullable disable

namespace TicketManagementSystem.Api.Models
{
    public partial class Userr
    {
        public Userr()
        {
            Orderrs = new HashSet<Orderr>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Orderr> Orderrs { get; set; }
    }
}
