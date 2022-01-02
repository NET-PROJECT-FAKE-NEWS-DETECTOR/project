using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI.Pages.Admin
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public AdminAuth Credential { get; set; }
       
        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            // verify the credentials

            if (Credential.Username == "admin1" && Credential.Password == "admin1")
            {
                // creating the security context
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "admin1"),
                    new Claim(ClaimTypes.Email, "admin1@mywebsite.com")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = Credential.RememberMe
                };

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal, authProperties);

                return RedirectToPage("/Account/Admin");

            }

            return Page();
        }
    }
}
