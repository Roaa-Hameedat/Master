using E_Commerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        private ShopDb db;
        public ProductViewComponent(ShopDb _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View (db.Products);
        }
    }
}
