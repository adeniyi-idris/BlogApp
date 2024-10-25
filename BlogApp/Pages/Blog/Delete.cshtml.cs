using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlogApp.Pages.Blog
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly DataContext _context;

        public DeleteModel(DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DAL.Models.Blog blogs { get; set; }

        public void OnGet(int id)
        {
            blogs = _context.Blogs.FirstOrDefault(b => b.BlogId == id);
        }

        public IActionResult OnPost()
        {
            _context.Blogs.Remove(blogs);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }

}

        
