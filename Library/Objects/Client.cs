using System.Collections.Generic;

namespace Library
{
    public class Client
    {
        public readonly string FullName;
        public readonly string PhoneNumber;
        private readonly List<BookRecord> _bookRecords = new List<BookRecord>();

        public Client(string fullName, string phoneNumber)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public BookRecord GetBookRecord(int index)
        {
            return _bookRecords[index];
        }

        public void AddBookRecord(BookRecord bookRecord)
        {
            _bookRecords.Add(bookRecord);
        }

        public void RemoveBookRecord(int index)
        {
            _bookRecords.RemoveAt(index);
        }

        public List<BookRecord> GetBookRecords()
        {
            List<BookRecord> bookRecords = new List<BookRecord>();
            bookRecords.AddRange(_bookRecords);
            return bookRecords;
        }
    }
}
