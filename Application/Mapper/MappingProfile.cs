using Application.Functions.Offer.Commands.AddOffer;
using Application.Functions.Offer.Commands.UpdateOffer;
using Application.Functions.Offer.Queries.GetAllOffers;
using Application.Functions.Offer.Queries.GetOfferDetails;
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
            //Offer comands
            CreateMap<AddOfferCommand, Offer>();

            //Offer queries
            CreateMap<Offer, GetAllOffersDto>();
            CreateMap<Offer, GetOffersDto>();
            CreateMap<Offer, GetOfferDetailsDto>();
        }
    }
}
