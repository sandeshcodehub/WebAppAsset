using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppAsset.Pages
{
    [Authorize]
    public class RIndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
