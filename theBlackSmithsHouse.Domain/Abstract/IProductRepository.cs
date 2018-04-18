using System;
using System.Collections.Generic;
using theBlackSmithsHouse.Domain.Entities;

namespace theBlackSmithsHouse.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
