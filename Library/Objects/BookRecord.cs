using System;

namespace Library
{
    public class BookRecord
    {
        public readonly int BookId;
        public readonly DateTime StartDateTime = DateTime.Now;
        public readonly DateTime EndDateTime;

        public BookRecord(int bookId, DateTime endDateTime)
        {
            BookId = bookId;
            EndDateTime = endDateTime;
        }

        public bool IsОverdue()
        {
            return EndDateTime < DateTime.Now;
        }
    }
}
