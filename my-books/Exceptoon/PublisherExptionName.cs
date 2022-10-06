using System;

namespace my_books.Exceptoon
{
    public class PublisherExptionName:Exception
    {
        public string publisherName { get; set; }

        public PublisherExptionName()
        {

        }
        public PublisherExptionName(string message):base(message)
        {

        }
        public PublisherExptionName(string message,Exception inner ):base(message,inner)    
        {

        }

        public PublisherExptionName(string message,string PublisherName) : this(message)
        {
            publisherName= PublisherName;   
        }
    }
}
