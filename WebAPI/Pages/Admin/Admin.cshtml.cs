
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI.Pages
{
    public class AdminModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }

        //TODO: check if is neccessary 'SupportGet' for password
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }

        public void OnGet()
        {
        }
    }
}
