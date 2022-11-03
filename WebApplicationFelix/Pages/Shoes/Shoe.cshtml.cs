using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationFelix.Core;
using WebApplicationFelix.Data;

namespace WebApplicationFelix.Pages
{
    public class ShoeModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IShoeData shoeData;

        public string Message { get; set; }
        public IEnumerable<Shoe> Shoes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ShoeModel(IConfiguration config, IShoeData shoeData)
        {
            this.config = config;
            this.shoeData = shoeData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Shoes = shoeData.GetShoesByName(SearchTerm);
        }
    }
}
