using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TicketManagementSystem.Api.Models;
using TicketManagementSystem.Api.Models.Dto;

namespace TicketManagementSystem.Api.Profiles
{
    public class VenueProfile : Profile
    {
        public VenueProfile()
        {
            CreateMap<Venue, VenuePatchDto>()
               .ForMember(dest => dest.VenueId, opt => opt.MapFrom(src => src.VenueId))
               .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity)).ReverseMap();
        }
    }
}
