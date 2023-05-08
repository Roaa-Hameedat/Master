using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_Commerce.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private ShopDb db;
        public ProductsController(ShopDb _db)
        {
            db = _db;
        }
        [AllowAnonymous]
        public IActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var productDetails = db.Products.Find(id);
            if (productDetails == null)
            {
                return RedirectToAction("Index", "Home");
            }


            return View(productDetails);
        }

        public IActionResult CartItems()
        {
            var data = db.Carts.Include(x => x.product).OrderByDescending(x=>x.CartId);

          
              decimal  Total=db.Carts.Sum(x=>x.product!.Productprice);
            ViewBag.tot = Total;
            HttpContext.Session.SetString("total", Total.ToString());
            return View(data);
        
        }
        
    
        public async Task<IActionResult> AddtoCart(int id)
        {
            Cart cart = new Cart
            {
                ProductId = id,
            };
            db.Carts.Add(cart);
           await db.SaveChangesAsync();
            return RedirectToAction(nameof(CartItems));
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var ProductDeleted = db.Carts.Find(id);

            if (ProductDeleted == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(ProductDeleted);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var ProductDeleted = db.Carts.Find(id); 
            db.Carts.Remove(ProductDeleted!);
            db.SaveChanges();
            return RedirectToAction(nameof(CartItems));
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            ViewBag.tot = HttpContext.Session.GetString("total");

            return View();
        }
        public async Task<IActionResult> Checkout(Customer customer)
        {

            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(CheckoutSuccec));
            }
            return View(customer);
        }
        public IActionResult CheckoutSuccec()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult PrductinCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home"); 
            }
            var data= db.Products.Where(c=>c.CategoryId==id);
            return View(data);
        }


    }
}
