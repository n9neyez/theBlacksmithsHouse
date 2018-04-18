using System.Web.Mvc;
using System.Collections.Generic;
using theBlackSmithsHouse.Domain.Abstract;
using System.Linq;

// This controller is for the Rarity list which user can select to filter the products
namespace theBlackSmithsHouse.WebUI.Controllers
{
    public class RarityController : Controller
    {
        private IProductRepository repository;
        // add constructor that accepts IProductRepository as argument
        public RarityController (IProductRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult RarityMenu()
        {               // use Linq query to obtain list of rarities from repository to pass to the view
            IEnumerable<string> rarities = repository.Products.Select(x => x.Rarity)
                                                              .Distinct()
                                                              .OrderBy(x => x);
            return PartialView(rarities);
        }
    }
}