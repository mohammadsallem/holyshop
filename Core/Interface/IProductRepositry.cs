using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Enitity;

namespace Core.Interface
{
    public interface IProductRepositry
    {

        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

        
    }
}