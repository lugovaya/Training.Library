using System.Threading.Tasks;
using Library.Domain.Models;
using Library.Repositories;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Web.Controllers
{
    [Route("library")]
    public class BooksController : Controller
    {
        private readonly IBooksRepository _booksRepository; // injection via constructor

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("books/{id:int}")] // ~/library/books/3
        [Route("{id:int}/{name:maxlength(10)}")] // ~/library/3/Deathly
        public IActionResult Edit(int bookId, string name)
        {
            var book = _booksRepository.Get(bookId);

            if (book == null)
                return NotFound();

            return PartialView(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int bookId, LibraryItem model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var book = _booksRepository.Get(bookId);

            if (book == null)
                return NotFound();

            book.Description = model.Description;

            await _booksRepository.UpdateAsync(book);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> NeedToPay([FromServices] ILibrarian librarian, int bookId) // inject  to controller Action
        {
            var book = _booksRepository.Get(bookId);

            if (book == null)
                return NotFound();

            var userRepository = HttpContext.RequestServices.GetService<IUsersRepository>(); // get directly from HttpContext

            var currentVisitor = (Visitor) userRepository.Get(User.Identity.Name);

            await librarian.ApplyFees(book, currentVisitor);

            return Json(new {result = "success"});
        }
    }
}