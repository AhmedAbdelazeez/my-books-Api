using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Paging
{
    public class paginatedlist<T> :List<T>
    {
        public int pageindex { get; set; }
        public int Totalpages { get; set; }

        public paginatedlist(List<T> items,int count,int pageindex,int pagesize)
        {
            pageindex = pageindex;
            Totalpages = (int)Math.Ceiling(count / (double)pagesize);

            this.AddRange(items);
        }

        public bool haspriviouspage
        {
            get
            {
                return pageindex > 1;
            }
        }
        public bool HasNextPage
        {
            get
            {
                return pageindex < Totalpages;
            }
        }

        public static paginatedlist<T> Create(IQueryable<T> source,int pageindex,int pagesize)
        {
            var count = source.Count(); 
            var items = source.Skip((pageindex-1)* pagesize).Take(pagesize).ToList(); 

            return new paginatedlist<T>(items,count,pageindex,pagesize);
        } 
    }
}
