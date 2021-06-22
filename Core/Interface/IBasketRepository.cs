using System.Threading.Tasks;
using Core.Enitity;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
        Task<CastumBasket> GetBasketAsync(string basketId);
        Task<CastumBasket> UpdateBasketAsync(CastumBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}