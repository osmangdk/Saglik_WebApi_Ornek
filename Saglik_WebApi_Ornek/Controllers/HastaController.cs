using Business.Concrete.SaglikManager;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System.Text.Json;

namespace Saglik_WebApi_Ornek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HastaController : ControllerBase
    {

        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _cache;
        private readonly HastaneContext _db;
        private readonly SaglikManager _saglikManager;

        public HastaController(IConnectionMultiplexer redis, HastaneContext db, SaglikManager saglikManager)
        {
            _redis = redis;
            _cache = _redis.GetDatabase();
            _db = db;
            _saglikManager = saglikManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHasta(int id)
        {
            string cacheKey = $"hasta:{id}";

            // 1. Redis'ten oku
            var cachedHasta = await _cache.StringGetAsync(cacheKey);
            if (cachedHasta.HasValue)
            {
                var hasta = JsonSerializer.Deserialize<Hastum>(cachedHasta);
                return Ok(hasta);
            }

            // 2. Yoksa veritabanından getir
            var hastaFromDb = await _saglikManager.GetByIdAsync(id);
            if (hastaFromDb == null)
                return NotFound();

            // 3. Redis'e cachele (10 dakika süreyle)
            await _cache.StringSetAsync(
                cacheKey,
                JsonSerializer.Serialize(hastaFromDb),
                TimeSpan.FromMinutes(10));

            return Ok(hastaFromDb);
        }
    }
}
