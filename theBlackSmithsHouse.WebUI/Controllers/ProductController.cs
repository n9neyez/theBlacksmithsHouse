using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theBlackSmithsHouse.Domain.Abstract;
using theBlackSmithsHouse.WebUI.Models;

namespace theBlackSmithsHouse.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository myrepository;

        public ProductController (IProductRepository productRepository)
        {
            this.myrepository = productRepository;
        }

        // display 6 Products on the page
        public int PageSize = 6;
        // GET: Product
        public ViewResult List(string rarity, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = myrepository.Products
                                        .Where(p => rarity == null || p.Rarity == rarity) // filter objects/products by Rarity, from Products class
                                        .OrderBy(p => p.ProductID)
                                        .Skip((page - 1) * PageSize)
                                        .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = rarity == null ?
                                    myrepository.Products.Count() :
                                    myrepository.Products.Where
                                        (e => e.Rarity == rarity).Count()
                },
                CurrentRarity = rarity // indicate current category
            };
            return View(model);
        }
    }
}