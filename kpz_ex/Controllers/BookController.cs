using kpz_ex.DTO;
using kpz_ex.Models;
using Microsoft.AspNetCore.Mvc;

namespace kpz_ex.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {

        private readonly BooksContext _context;
        public BookController(BooksContext context)
        {

            _context = context;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return Ok(_context.Books.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(BookDTO dto)
        {

            var book = new Book()
            {
                Book_Name = dto.Book_Name,
                Book_Author = dto.Book_Author,
                Book_Quantity = dto.Book_Quantity,
            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        [HttpPut]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> BorrowBook([FromRoute] int id)
        {

            var book = await _context.Books.FindAsync(id);

            if (book != null && book.Book_Quantity != 0)
            {
            
                book.Book_Quantity -= 1;

                await _context.SaveChangesAsync();

                return Ok(book);
            }
          
            return NotFound();

        }

        [HttpPut]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> ReturnBook([FromRoute] int id)
        {

            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
               
                book.Book_Quantity += 1;

                await _context.SaveChangesAsync();

                return Ok(book);
            }

            return NotFound();

        }

    }
}
