using AutoMapper;
using VnsProjectTrips.Aplication.Dtos;
using VnsProjectTrips.Domain.Models;

namespace VnsProjectTrips.Aplication.Helperss
{
    public class MarketsProfile: Profile
    {
        public MarketsProfile()
        {
            CreateMap<Market, MarketDto>().ReverseMap();
            CreateMap<MarketItem, MarketItemDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
        }
    }
}
