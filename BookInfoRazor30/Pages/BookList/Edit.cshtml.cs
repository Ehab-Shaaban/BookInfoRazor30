using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfoRazor30.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookInfoRazor30.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _context.Book.FindAsync(id);
        }
        public async Task<IActionResult> Onpost()
        {
            if (ModelState.IsValid)
            {
                var DbBook = await _context.Book.FindAsync(Book.Id);
                DbBook.Name = Book.Name;
                DbBook.Auther = Book.Auther;
                DbBook.ISBN = Book.ISBN;
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
