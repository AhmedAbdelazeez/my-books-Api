using System.Collections.Generic;

namespace my_books.Data.viewmodel
{
    public class PuplisherVm
    {
        public string Name { get; set; }
    }
    public class PuplisherWithBooksAndAuthorVM
    {
        public string Name { get; set; }

        public List<BookAuthorvm> BookAuthors { get; set; }
    }

    public class BookAuthorvm
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }

}
