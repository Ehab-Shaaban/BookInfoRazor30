using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfoRazor30.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookInfoRazor30.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> Books { get; set; }
        async public Task  OnGet()
        {
            Books = await _context.Book.ToListAsync();
        }
    }
}
