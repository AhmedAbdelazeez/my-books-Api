using my_books.Data.Models;
using my_books.Data.Paging;
using my_books.Data.viewmodel;
using my_books.Exceptoon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace my_books.Data.Services
{
    public class PulisherService
    {
        private AppdbContext _context;
        public PulisherService(AppdbContext context)
        {
            _context = context;
        }
        public List<Publisher> GetAllPuplisger(string sortby, string searchString,int? pagenumber) 
        { 
            var allpublisher=  _context.publishers.OrderBy(n=>n.Name).ToList();

            if (!string.IsNullOrEmpty(sortby))
            {
                switch (sortby)
                {
                    case "name_desc":
                        allpublisher = _context.publishers.OrderBy(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                
                    
                        allpublisher = allpublisher.Where(n=>n.Name.Contains(searchString,StringComparison.CurrentCultureIgnoreCase)).ToList();
                    
               
            }

            int pagesize = 5;
            allpublisher = paginatedlist<Publisher>.Create(allpublisher.AsQueryable(), pagenumber ??1, pagesize);



            return allpublisher;
        }

        public Publisher AddPuplisher(PuplisherVm puplisher)
        {
            if (StringStartWithNumber(puplisher.Name)) throw new PublisherExptionName("Name sartts whis number");
            var _publisher = new Publisher()
            {
                Name= puplisher.Name    
            };
            _context.publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }

        public Publisher Getpuplisherbyid(int id) =>
            _context.publishers.FirstOrDefault(n => n.Id == id);
        

        public PuplisherWithBooksAndAuthorVM GetPuplisherData(int publisherId)
        {
            var _publisher = _context.publishers.Where(n => n.Id == publisherId)
                .Select(n => new PuplisherWithBooksAndAuthorVM()
                {
                    Name = n.Name,
                    BookAuthors=n.Books.Select(n=> new BookAuthorvm()
                    {
                        BookName=n.Title,
                        BookAuthors=n.Book_Authors.Select(n=>n.Author.FullName).ToList() 
                    }).ToList()
                }).FirstOrDefault();
            return _publisher;
        }

        public void DeletepuplisherbyId(int id)
        {
            var _publisher=_context.publishers.FirstOrDefault(n => n.Id == id);

            if(_publisher != null)
            {
                _context.publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"the pupliser with id {id} does not exest");
            }
        }
        private bool StringStartWithNumber(string name) =>
            (Regex.IsMatch(name, @"^\d"));

        
    }
}
