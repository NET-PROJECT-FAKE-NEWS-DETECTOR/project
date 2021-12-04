using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI.Pages
{
    public class ResultModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string URL { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(URL))
            {
                URL = "Nu ai setat link!!";
            }
        }
    }
}
