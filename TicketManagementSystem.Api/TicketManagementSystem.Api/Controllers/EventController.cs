using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.Api.Models.Dto;
using TicketManagementSystem.Api.Models;
using TicketManagementSystem.Api.Repositories;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace TicketManagementSystem.Api.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        

        public EventController(IEventRepository eventRepository, IMapper mapper, ILogger<EventController> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
           
        }

        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> GetAll()
        {
            var events = await _eventRepository.GetAll();
            var dtoEvents = events.Select(e => _mapper.Map<EventDto>(e));
            return Ok(dtoEvents);
        }

        [HttpGet]
        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            
                var @event = await _eventRepository.GetById(id);

                var eventDto = _mapper.Map<EventDto>(@event);

                return Ok(eventDto);        
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);
          
            _mapper.Map(eventPatch, eventEntity);
            await _eventRepository.Update(eventEntity);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);
          
            await _eventRepository.Delete(eventEntity);
            return NoContent();
        }
    }

   
}
