using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VnsProjectTrips.Aplication.Dtos;
using VnsProjectTrips.Aplication.Interfaces;
using VnsProjectTrips.Data;
using VnsProjectTrips.Domain.Models;

namespace VnsProjectTrips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly IMarketService _marketService;

        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var markets = await _marketService.GetAllMarketsAsync(true);
                if (markets == null) return NoContent();

                var marketRetorno = new List<MarketDto>();

                foreach (var market in markets)
                {
                    marketRetorno.Add(new MarketDto()
                    {
                        Id = market.Id,
                        Name = market.Name, 
                        Category = market.Category,
                        DeliveryEstimate = market.DeliveryEstimate,
                        Rating = market.Rating,
                        ImagePath = market.ImagePath,
                        About = market.About,
                        Hours = market.Hours,
                    });
                }

                return Ok(marketRetorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar recuperar markets. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var market = await _marketService.GetMarketByIdAsync(id, true);
                if (market == null) return NoContent();
                return Ok(market);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar markets. Erro: {ex.Message}");
            }
        }

        [HttpGet("{category}/category")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            try
            {
                var market = await _marketService.GetAllMarketsByCategoryAsync(category);
                if (market == null) return NoContent();
                return Ok(market);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar markets. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> post(MarketDto model)
        {
            try
            {
                var market = await _marketService.AddMarkets(model);
                if (market == null) return NoContent();
                return Ok(market);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar markets. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MarketDto model)
        {
            try
            {
                var market = await _marketService.UpdateMarket(id, model);
                if (market == null) return NoContent();
                return Ok(market);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar markets. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var market = await _marketService.GetMarketByIdAsync(id, true);
                if (market == null) return NoContent();

                return await _marketService.DeleteMarket(id) ?
                    Ok("Deletado") :
                    throw new Exception("Ocorreeu um problema nao escifico ao tentar delatar o market");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar markets. Erro: {ex.Message}");
            }
        }

    }
}
