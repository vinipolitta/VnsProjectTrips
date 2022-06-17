using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VnsProjectTrips.Data;
using VnsProjectTrips.Models;

namespace VnsProjectTrips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly DataContext _context;

        public MarketController(DataContext context)
        {



            _context = context;
        }
        [HttpGet]
        public IEnumerable<Market> Get()
        {
            return _context.Markets;
        }

        [HttpGet("{id}")]
        public Market GetById(int id)
        {
            return _context.Markets.FirstOrDefault(market => market.Id == id); ;
        }
    }
}
