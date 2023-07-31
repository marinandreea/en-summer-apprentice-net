using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Api.Models;

namespace TicketManagementSystem.Api.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly practicaContext _dbContext;
        public TicketCategoryRepository()
        {
            _dbContext = new practicaContext();
        }
        public async Task<TicketCategory> GetById(int id)
        {
            var ticketCategory = await _dbContext.TicketCategories.Where(t => t.TicketCategoryId == id).FirstOrDefaultAsync();
            return ticketCategory;
        }
    }
}
