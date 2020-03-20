using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfoRazor30.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookInfoRazor30.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> Onpost()
        {
            if (ModelState.IsValid)
            {
                await _context.Book.AddAsync(Book);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");               
            }
            else
            {
                return Page();
            }
            
        }
    }
}
