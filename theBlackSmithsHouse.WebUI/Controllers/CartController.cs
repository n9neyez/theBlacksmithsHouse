using System.Linq;
using System.Web;
using System.Web.Mvc;
using theBlackSmithsHouse.Domain.Abstract;
using theBlackSmithsHouse.Domain.Entities;
using theBlackSmithsHouse.WebUI.Models; 

namespace theBlackSmithsHouse.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        public CartController (IProductRepository repo)
        {
            repository = repo;
        }
        // ASP.NET session state feature to store and retrieve Cart objects
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"]; // retrieve object

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart; // add object to session state
            }
            return cart;
        }
        // performs redirection by using the specified route values dictionary
        public RedirectToRouteResult AddToCart(int productID, string returnUrl) // parameters match the input elements in the HTML forms in ProductSummary.cshtml view
        {
            Product product = repository.Products.FirstOrDefault
                                                (p => p.ProductID == productID);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl }); // redirects to specified action using action nameand route values
        }
        
        public RedirectToRouteResult RemoveFromCart(int productID, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault
                                                    (p => p.ProductID == productID);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        // View Result
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
    }
}