using System.Collections.Generic;
using theBlackSmithsHouse.Domain.Entities;

namespace theBlackSmithsHouse.WebUI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; } 

        // Add current rarity property
        public string CurrentRarity { get; set; }
    }
}