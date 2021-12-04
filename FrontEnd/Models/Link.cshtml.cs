using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI.Models
{
    public class LinkModel
    {
        public string URL { get; set; }

        public void OnGet()
        {
        }
    }
}
