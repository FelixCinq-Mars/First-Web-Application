using Microsoft.AspNetCore.Mvc;
using WebApplicationFelix.Data;

namespace WebApplicationFelix.ViewComponents
{
    public class ShoeCountViewComponent : ViewComponent
    {
        private readonly IShoeData shoeData;

        public ShoeCountViewComponent(IShoeData shoeData)
        {
            this.shoeData = shoeData; 
        }
        public IViewComponentResult Invoke()
        {
            var count = shoeData.GetCountOfShoes();
            return View(count);
        }

    }

}
