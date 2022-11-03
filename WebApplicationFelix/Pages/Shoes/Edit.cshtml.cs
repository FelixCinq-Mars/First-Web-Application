using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationFelix.Core;
using WebApplicationFelix.Data;

namespace WebApplicationFelix.Pages.Shoes
{
    public class EditModel : PageModel
    {
        private readonly IShoeData shoeData;
        [BindProperty]
        public Shoe Shoe { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        private readonly IHtmlHelper htmlHelper;
        public EditModel(IShoeData shoeData, IHtmlHelper htmlHelper)
        {
            this.shoeData = shoeData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? shoeId)
        {
            Types = htmlHelper.GetEnumSelectList<ShoeType>();
            if (shoeId.HasValue) { 
               Shoe = shoeData.GetById(shoeId.Value);
            }
            else
            {
                Shoe = new Shoe();
            }
            if(Shoe == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Types = htmlHelper.GetEnumSelectList<ShoeType>();
                return Page();
            }   
            if (Shoe.id > 0)
            {
                shoeData.Update(Shoe);
            }
            else
            {
                shoeData.Add(Shoe);
            }
            shoeData.Commit();
            TempData["Message"] = "Shoe saved!";
            return RedirectToPage("./Detail", new {shoeId = Shoe.id });
        }
    
    }

}
