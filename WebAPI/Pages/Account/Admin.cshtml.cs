
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace WebAPI.Pages
{
    public class AdminModel : PageModel
    {

        public async Task<IActionResult> OnGet()
        {

            if (User.Identity.IsAuthenticated)
            {
                return Page();

            }
            return RedirectToPage("/Account/Login");
        }
    }
}
