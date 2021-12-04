using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI.Pages.Admin
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public AdminAuth Credential { get; set; }
       
        public void OnGet()
        {
           
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            return RedirectToPage("/Admin/Admin", new { UserName = Credential.Username, Password = Credential.Password });
        }
    }
}
