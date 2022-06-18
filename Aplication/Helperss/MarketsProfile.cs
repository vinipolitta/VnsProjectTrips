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
        }
    }
}
