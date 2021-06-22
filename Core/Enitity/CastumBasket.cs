using System.Collections.Generic;
using Core.Entities;

namespace Core.Enitity
{
    public class CastumBasket
    {
        public CastumBasket()
        {
        }

        public CastumBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        
    }
}