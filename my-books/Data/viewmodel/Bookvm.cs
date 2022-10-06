using System;
using System.Collections.Generic;

namespace my_books.Data.viewmodel
{
    public class Bookvm
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DataRead { get; set; }

        public int? Rate { get; set; }

        public string Genra { get; set; }

       

        public string CoverUrl { get; set; }

        public int PuplisherId { get; set; }
        
        public List<int> AuthorId { get; set; }
        

    }
    public class BookwhithAuthorvm
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DataRead { get; set; }

        public int? Rate { get; set; }

        public string Genra { get; set; }



        public string CoverUrl { get; set; }

        public string PupliserName { get; set; }

        public List<string> AuthorName { get; set; }


    }
}
