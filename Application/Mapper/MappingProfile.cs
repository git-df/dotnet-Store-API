using Application.Functions.Offer.Commands.AddOffer;
using Application.Functions.Offer.Queries.GetAllOffers;
using Application.Functions.Offer.Queries.GetOffers;
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
            CreateMap<AddOfferCommand, Offer>();
            CreateMap<Offer, GetAllOffersDto>();
            CreateMap<Offer, GetOffersDto>();
        }
    }
}
