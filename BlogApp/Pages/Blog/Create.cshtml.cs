using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlogApp.Pages.Blog
{
    //[Authorize]
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;

        public CreateModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DAL.Models.Blog blogs { get; set; }

        public void OnGet()
        { 

        }

        public IActionResult OnPost() 
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Add(blogs);
                _context.SaveChanges();
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }

        //multiple page handler
        public IActionResult OnPostFinish(int id)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
