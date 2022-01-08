using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace WebAPI.Pages.Admin
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public AdminAuth Credential { get; set; }
        public bool incorect_credentials = false;
       
        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }


            var connectionString = "server=localhost;database=dotnetproject;user=root;password=acasa213";

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            string qry = "select * from adminauth where Username='" + Credential.Username + "' and Password='" + Credential.Password + "'";

            MySqlCommand cmd = new MySqlCommand(qry, connection);

            MySqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                // creating the security context
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, Credential.Username),
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

            incorect_credentials = true;

            return Page();
        }
    }
}
