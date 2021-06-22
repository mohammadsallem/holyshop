using System;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Enitity;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class BasketReposotry : IBasketRepository
    {       
         private readonly IDatabase _database;
        public BasketReposotry(IConnectionMultiplexer redis)
        {
          _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CastumBasket> GetBasketAsync(string basketId)
        {
          var data = await _database.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CastumBasket>(data);
        }

        public async Task<CastumBasket> UpdateBasketAsync(CastumBasket basket)
        {
         var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), 
            TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}