using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationFelix.Core;
using WebApplicationFelix.Data;

namespace WebApplicationFelix.Pages.Shoes
{
    public class DetailModel : PageModel
    {

        private readonly IShoeData shoeData;
        [TempData]
        public string Message { get; set; }
        public Shoe Shoe { get; set; }

        public DetailModel(IShoeData shoeData)
        {
            this.shoeData = shoeData;
        }
        public IActionResult OnGet(int shoeId)
        {
            Shoe = shoeData.GetById(shoeId);
            if(Shoe == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
