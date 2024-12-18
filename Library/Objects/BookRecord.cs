using System;

namespace Library
{
    public class BookRecord
    {
        public readonly Book Book;
        public readonly DateTime StartDateTime = DateTime.Now;
        public readonly DateTime EndDateTime;

        public BookRecord(Book book, DateTime endDateTime)
        {
            Book = book;
            EndDateTime = endDateTime;
        }

        public bool IsОverdue()
        {
            return EndDateTime < DateTime.Now;
        }
    }
}
