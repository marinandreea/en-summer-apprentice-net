using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagementSystem.Api.Models;

namespace TicketManagementSystem.Api.Repositories
{
   public interface IOrderRepository
    {
        Task<IEnumerable<Orderr>> GetAll();
        Task<Orderr> GetById(int id);
        int Add(Orderr @order);
        Task Update(Orderr @order);
        Task Delete(Orderr @order);
    }
}
