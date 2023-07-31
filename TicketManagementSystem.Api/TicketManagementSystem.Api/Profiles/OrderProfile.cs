using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TicketManagementSystem.Api.Models;
using TicketManagementSystem.Api.Models.Dto;

namespace TicketManagementSystem.Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Orderr, OrderDto>()
                .ForMember(dest => dest.TicketCategory, opt => opt.MapFrom(src => src.TicketCategory != null ? src.TicketCategory.Description : string.Empty))
                .ForMember(dest => dest.OrderedAt, opt => opt.MapFrom(src => src.OrderedAt))
                .ForMember(dest => dest.NumberOfTickets, opt => opt.MapFrom(src => src.NumberOfTickets))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice)).ReverseMap();

            CreateMap<Orderr, OrderPatchDto>()
                .ForMember(dest => dest.NumberOfTickets, opt => opt.MapFrom(src => src.NumberOfTickets))
                .ForMember(dest => dest.TicketCategoryId, opt => opt.MapFrom(src => src.TicketCategoryId)).ReverseMap();
        }
    }
}
