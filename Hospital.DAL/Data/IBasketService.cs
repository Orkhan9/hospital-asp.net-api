using System.Threading.Tasks;
using Hospital.DAL.Entities;

namespace Hospital.DAL
{
    public interface IBasketService
    {
            Task<CustomerBasket> GetBasketAsync(string basketId);
            Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket);
            Task<bool> DeleteBasketAsync(string basketId);
    }
}