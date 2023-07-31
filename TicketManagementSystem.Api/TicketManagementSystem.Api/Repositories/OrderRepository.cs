using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagementSystem.Api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Api.Exceptions;

namespace TicketManagementSystem.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly practicaContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new practicaContext();
        }
        public int Add(Orderr order)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Orderr @order)
        {
            _dbContext.Remove(@order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Orderr>> GetAll()
        {
            var orders = await _dbContext.Orderrs.Include(o => o.TicketCategory).ToListAsync();
            if(orders == null)
            {
                throw new EntityNotFoundException("No orders found!");
            }
            return orders;
        }

        public async Task<Orderr> GetById(int id)
        {
            var @order = await _dbContext.Orderrs.Where(o => o.OrderId == id).Include(o => o.TicketCategory).FirstOrDefaultAsync();
            if(order == null)
            {
                throw new EntityNotFoundException(id, nameof(Orderr));
            }
            return @order;
        }

        public async Task Update(Orderr @order)
        {
            _dbContext.Entry(@order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
