using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TicketManagementSystem.Api.Models;
using TicketManagementSystem.Api.Models.Dto;

namespace TicketManagementSystem.Api.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType != null ? src.EventType.Name : string.Empty))
                .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue != null ? src.Venue.Location : string.Empty)).ReverseMap();

            CreateMap<Event, EventPatchDto>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

        }
    }
}
