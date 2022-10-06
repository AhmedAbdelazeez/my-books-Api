using my_books.Data.Models;
using my_books.Data.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class BookServices
    {
        private AppdbContext _context;
        public BookServices(AppdbContext context)
        {
            _context = context;
        }
        public void AddbookWithAutgor(Bookvm book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                DataRead = book.IsRead ? book.DataRead.Value : null,
                Description = book.Description,
                IsRead = book.IsRead,
                Rate = book.Rate,

                Genra = book.Genra,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PuplisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorId)
            {
                var _book_authoe = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Books_Authors.Add(_book_authoe);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public BookwhithAuthorvm GetAllBooksById(int bookid)  
            {
            var _bookWhithAuthorvm = _context.Books.Where(n=>n.Id==bookid).Select(book => new BookwhithAuthorvm()
            {
                Title = book.Title,
                DataRead = book.IsRead ? book.DataRead.Value : null,
                Description = book.Description,
                IsRead = book.IsRead,
                Rate = book.Rate,

                Genra = book.Genra,
                CoverUrl = book.CoverUrl,
                
                PupliserName = book.Publisher.Name,
                AuthorName=book.Book_Authors.Select(n=>n.Author.FullName).ToList() 
            }).FirstOrDefault();
            return _bookWhithAuthorvm;  
            }
        
        public Book Updatebyid(int bookid,Bookvm book)
        {
            var _book=_context.Books.FirstOrDefault(n=>n.Id==bookid);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.DataRead = book.IsRead ? book.DataRead.Value : null;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.Rate = book.Rate;
                
                _book.Genra = book.Genra;
                _book.CoverUrl = book.CoverUrl;
                _context.SaveChanges();
            }
            return _book;


        }
        public void Deletedbyid(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookid);

            if( _book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
           
            
           
        }
    }
}
