using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.viewmodel;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorSevice _authorSevice;
        public AuthorsController(AuthorSevice authorSevice)
        {
            _authorSevice = authorSevice;
        }
        [HttpPost("Add-Author")]
        public IActionResult AddBook([FromBody] AuthorVm author)
        {
            _authorSevice.AddAuthor(author);
            return Ok();
        }
        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult GetAuthorWhisBooks(int id)
        {
         var x=   _authorSevice.GetAuthorWithBookvm(id);
            return Ok(x);
        }
    }
}
