using my_books.Data.Models;
using my_books.Data.viewmodel;
using System.Linq;

namespace my_books.Data.Services
{
    public class AuthorSevice
    {
        private AppdbContext _context;
        public AuthorSevice(AppdbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVm book)
        {
            var _Aurhor = new Author()
            {
                FullName= book.FullName,    
            };
            _context.Authors.Add(_Aurhor);
            _context.SaveChanges();
        }

        public AuthorWithBookvm GetAuthorWithBookvm(int authorid)
        {
            var _author = _context.Authors.Where(n => n.Id == authorid).Select(n => new AuthorWithBookvm()
            {
                FullName=n.FullName,
                Booktitles=n.Book_Authors.Select(n=>n.Book.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }

    }
}
