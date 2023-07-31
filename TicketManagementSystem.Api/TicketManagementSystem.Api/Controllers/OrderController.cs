using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.Api.Exceptions;
using TicketManagementSystem.Api.Models;
using TicketManagementSystem.Api.Models.Dto;
using TicketManagementSystem.Api.Repositories;

namespace TicketManagementSystem.Api.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IVenueRepository _venueRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;
        public OrderController(IOrderRepository orderRepository,IVenueRepository venueRepository, ITicketCategoryRepository ticketCategoryRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _venueRepository = venueRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            var orders = await _orderRepository.GetAll();
            var dtoOrders = orders.Select(o => _mapper.Map<OrderDto>(o));

            return Ok(dtoOrders);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var @order = await _orderRepository.GetById(id);
            var orderDto = _mapper.Map<OrderDto>(@order);
            return Ok(orderDto);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            var @order = await _orderRepository.GetById(orderPatch.OrderId);
          
            if(orderPatch.TicketCategoryId != 0)
            {
                var ticketCategory = await _ticketCategoryRepository.GetById(orderPatch.TicketCategoryId);
                if(ticketCategory == null)
                {
                    throw new EntityNotFoundException(orderPatch.TicketCategoryId, nameof(TicketCategory));
                }
                if(orderPatch.NumberOfTickets > 0)
                {
                    double totalPrice = (double)(ticketCategory.Price * orderPatch.NumberOfTickets);
                    @order.TotalPrice = totalPrice;  
                    if(@order.NumberOfTickets != orderPatch.NumberOfTickets)
                    {
                        var venue = await _venueRepository.getVenueByOrder(@order);
                        int diff = (int)(@order.NumberOfTickets - orderPatch.NumberOfTickets);
                        VenuePatchDto venuePatchDto = new VenuePatchDto()
                        {
                            VenueId = venue.VenueId,
                            Capacity = venue.Capacity + diff
                        };
                        _mapper.Map(venuePatchDto, venue);
                       await _venueRepository.Update(venue);
                    }
                    
                }
                else
                {
                    throw new ArgumentException ("Number of tickets cannot be negative or 0"); 
                }
                
            }
            else
            {
                throw new ArgumentException("Ticket category id is missing or invalid!");
            }  
            _mapper.Map(orderPatch, @order);
            await _orderRepository.Update(@order);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var @order = await _orderRepository.GetById(id);
            await _orderRepository.Delete(@order);
            return NoContent();
        }

    }
}
