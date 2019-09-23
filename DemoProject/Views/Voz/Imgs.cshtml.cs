using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoProject.Views
{
    public class ImgsModel : PageModel
    { 
        public List<string> Imgs { get; set; } 
    }
}