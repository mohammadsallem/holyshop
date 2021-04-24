using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Enitity;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory){
            
            try{
                if(!context.ProductBrand.Any()){
                    
                     var brandData = File.ReadAllText("../Infrastructure/Data/seedData/brands.json");

                     var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                     foreach( var item in brands){
                         context.ProductBrand.Add(item);
                     }

                     await context.SaveChangesAsync();
                }

                if(!context.ProductType.Any()){
                    
                     var TypesData = File.ReadAllText("../Infrastructure/Data/seedData/types.json");

                     var types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                     foreach( var item in types){
                         context.ProductType.Add(item);
                     }

                     await context.SaveChangesAsync();
                }

                     if(!context.Products.Any()){
                    
                     var ProductsData = File.ReadAllText("../Infrastructure/Data/seedData/products.json");

                     var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                     foreach( var item in products){
                         context.Products.Add(item);
                         }

                     await context.SaveChangesAsync();
                }

            }catch(Exception ex){
                  
                  var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                  logger.LogError(ex.Message);  
            }
        }
    }
}