using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationFelix.Core;
using WebApplicationFelix.Data;

namespace WebApplicationFelix.Pages.Shoes
{
    public class DeleteModel : PageModel
    {
        private readonly IShoeData shoeData;

        public Shoe Shoe { get; set; }

        public DeleteModel(IShoeData shoeData)
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
        
        public IActionResult OnPost(int shoeId)
        {
            var shoe = shoeData.Delete(shoeId);
            shoeData.Commit();
            if(shoe==null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{shoe.name} deleted";
            return RedirectToPage("./Shoe");
        }
    }
}
