using BookStroeManagement.Data;
using BookStroeManagement.Models;
using BookStroeManagement.Repositories.Interfacees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStroeManagement.Controllers
{
    public class BookController : Controller
    {

       
        private readonly IBook _IBook;

        public BookController(IBook Ibook)
        {
            _IBook = Ibook;
        }
        public async Task<ActionResult<IEnumerable<Book>>> Index()
        {
            return View(await _IBook.GetAllBooks());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Book book = new Book();
            return View(book);
        }

        [HttpPost]
        public async Task <IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            var newBook =await _IBook.CreateBook(book);
            return Content("Successfully Added!");

        }

        [HttpGet("Book/Edit/{BookID}")]
        public async Task<IActionResult> Edit(int BookID)
        {
            var updateBook = await _IBook.GetBookByID(BookID);
            // return Ok(updateBook);
            if (updateBook == null)
            {
                return NotFound("The book you're looking for is not available.");
            }
            return View(updateBook);
        }


        [HttpPost("Book/Edit/{BookID}")]
        public async Task<IActionResult> Edit(int BookID, Book Book)
        {
            var updateBook = await _IBook.UpdateBookInfo(BookID, Book);
            // return Ok(updateBook);
            if (updateBook == null)
            {
                return NotFound("The book you're looking for is not available.");
            }
            return Content("Updated done successfully");
        }

        [HttpGet("Book/Delete/{BookName}")]
        public async Task<IActionResult> Delete(string BookName)
        {
            var BookToDelete =await _IBook.ViewBookDetails(BookName);

            if (BookToDelete == null)
            {
                return NotFound("The book you're looking for is not available.");
            }
            return View(BookToDelete);

        }


        [HttpPost("Book/Delete/{BookName}")]
        public async Task<IActionResult> Delete(string BookName,Book book)
        {
            var BookToDelete =await _IBook.DeleteBook(BookName);
            if (BookToDelete == null)
            {
                return NotFound("The book you're looking for is not available.");
                //TempData["ErrorMessage"] = "Book not found.";
                //return RedirectToAction("Delete"); 
            }
            

            return Content("Deleted done successfully");
        }

        [HttpGet("Book/Details/{BookName}")]
        public async Task<IActionResult> Details(string BookName)
        {
            var Book = await _IBook.ViewBookDetails(BookName);
          
            if (Book == null)
            {
                return NotFound("The book you're looking for is not available.");
            }
            return View(Book);

        }

    }
}
