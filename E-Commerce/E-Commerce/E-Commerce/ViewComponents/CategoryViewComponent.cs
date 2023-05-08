using E_Commerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private ShopDb db;
        public CategoryViewComponent(ShopDb _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.Categories);
        }
    }
}
