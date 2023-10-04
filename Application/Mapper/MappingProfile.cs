using Application.Functions.Auth.Commands.SignUp;
using Application.Functions.Offer.Commands.AddOffer;
using Application.Functions.Offer.Commands.UpdateOffer;
using Application.Functions.Offer.Queries.GetAllOffers;
using Application.Functions.Offer.Queries.GetOfferDetails;
using Application.Functions.Offer.Queries.GetOffers;
using Application.Functions.Order.Queries.GetAllOrders;
using Application.Functions.Order.Queries.GetAllPayments;
using Application.Functions.Order.Queries.GetOrders;
using Application.Functions.Order.Queries.GetPaymentsHistory;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //Auth commands
            CreateMap<SignUpCommand, AppUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLower()))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.ToLower()))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.ToLower()))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email.ToLower()));

            //Offer commands
            CreateMap<AddOfferCommand, Offer>();

            //Offer queries
            CreateMap<Offer, GetAllOffersDto>();
            CreateMap<Offer, GetOffersDto>();
            CreateMap<Offer, GetOfferDetailsDto>();

            //Order queries
            CreateMap<Order, GetOrdersDto>()
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.Payment.Status.ToString()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Payment.Price))
                .ForMember(dest => dest.PaymentId, opt => opt.MapFrom(src => src.Payment.Id));
            CreateMap<Order, GetAllOrdersDto>()
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.Payment.Status.ToString()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Payment.Price));
            CreateMap<Payment, GetPaymentsHistoryDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<Payment, GetAllPaymentsDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AppUser.Email));
        }
    }
}
