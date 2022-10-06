using System.Collections.Generic;

namespace my_books.Data.viewmodel
{
    public class AuthorVm
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBookvm
    {
        public string FullName { get; set; }
        public List<string> Booktitles { get; set; }
    }
}
