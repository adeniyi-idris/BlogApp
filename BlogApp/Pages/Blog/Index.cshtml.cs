using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;

namespace BlogApp.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public IndexModel(DAL.DataContext context)
        {
            _context = context;
        }

        public List<DAL.Models.Blog> blogs { get; set; }

        public IActionResult Onget(string searchQuery)
        {
            //search operation
            if (!string.IsNullOrEmpty(searchQuery))
            {
                blogs = _context.Blogs.Where(b => b.Title.Contains(searchQuery)).ToList();
            }
            else
            {
                blogs = _context.Blogs.ToList();
            }
            return Page();
        }

    }
}
