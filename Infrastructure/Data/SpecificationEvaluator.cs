using System.Linq;
using Core.Enitity;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec){
           
           var query = inputQuery;
           
           if( spec.Critiria != null)
             {
               query = query.Where(spec.Critiria);
             }

             if( spec.OrderBy != null)
             {
               query = query.OrderBy(spec.OrderBy);
             }
             
             if( spec.OrderByDescending != null)
             {
               query = query.OrderByDescending(spec.OrderByDescending);
             }
             if( spec.IsPaginEnable)
             {
               query = query.Skip(spec.Skip).Take(spec.Take);
             }
           
           query = spec.Includes.Aggregate(query ,( current , include ) => current.Include(include));

           return query;
           
        }
        
    }
}