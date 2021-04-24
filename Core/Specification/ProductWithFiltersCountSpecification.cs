using Core.Enitity;

namespace Core.Specification
{
    public class ProductWithFiltersCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersCountSpecification(ProductSpecParams productSpec):
        base ( x =>
               (string.IsNullOrEmpty(productSpec.Search) || x.Name.ToLower().Contains(productSpec.Search)) &&
               (!productSpec.BrandId.HasValue || x.ProductBrandId == productSpec.BrandId) &&
               (!productSpec.TypeId.HasValue || x.ProductTypeId == productSpec.TypeId) 
             )
        {
            
        }
    }
}