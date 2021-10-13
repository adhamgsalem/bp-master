using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BPCalculator.Pages
{
    
    public class HeartRateModel : PageModel
    {
        [BindProperty]
        public HeartRateCalculator HR { get; set; }
        public void OnGet()
        {
            HR = new HeartRateCalculator() { HeartRate = 50 };
        }

    }
}