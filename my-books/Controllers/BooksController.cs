using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.viewmodel;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookServices _bookServices;

     
        public BooksController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }
        [HttpGet("get-all-books")]
        public IActionResult Getallbook()
        {
            var allbok=_bookServices.GetAllBooks();
            return Ok(allbok);
        }
        [HttpGet("get-book-id/{id}")]
        public IActionResult Getallbookbyid(int id)
        {
            var book = _bookServices.GetAllBooksById(id);
            return Ok(book);
        }
        [HttpPost("Add-Book-whith-author")]
        public IActionResult AddBook([FromBody] Bookvm book)
        {
            _bookServices.AddbookWithAutgor(book);
            return Ok();
        }

        [HttpPut("update-book-by=id/{id}")]
        public IActionResult Update( int id,[FromBody] Bookvm book)
        {
            var booh = _bookServices.Updatebyid(id, book);
            return Ok(booh);
        }
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult Deletbyid(int id)
        {
            _bookServices.Deletedbyid(id);
            return Ok();
        } 
        
    }
}
