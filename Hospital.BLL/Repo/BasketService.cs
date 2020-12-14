using System;
using System.Text.Json;
using System.Threading.Tasks;
using Hospital.DAL.Entities;
using StackExchange.Redis;

namespace Hospital.DAL
{
    public class BasketService:IBasketService
    {
        private readonly IDatabase _redis;

        public BasketService(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase();
        }
        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var data = await _redis.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket)
        {
            var created = await _redis.StringSetAsync(customerBasket.Id,
                JsonSerializer.Serialize(customerBasket), TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetBasketAsync(customerBasket.Id);
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _redis.KeyDeleteAsync(basketId);
        }
    }
    
}