using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfoRazor30.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookInfoRazor30.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        //public IEnumerable<Book> Books { get; set; }
        // GET: /<controller>/
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _context.Book.ToListAsync()});
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var DbBook = await _context.Book.FirstOrDefaultAsync(u => u.Id == id);

            if(DbBook == null)
            {
                return Json(new {success =false, massage= "No data found" });
            }
            _context.Book.Remove(DbBook);
            await _context.SaveChangesAsync();

            return Json(new { success = true, massage = "The book deleted" });
        }
    }
}
