using System;

namespace Library
{
    public class Book
    {
        public readonly string Name;
        public readonly string Author;
        public readonly string ReleaseYear;
        public bool IsIssued { get; private set; }

        public Book(string name, string author, string releaseDateTime)
        {
            Name = name;
            Author = author;
            ReleaseYear = releaseDateTime;
            IsIssued = false;
        }

        public void Issue()
        {
            if (IsIssued) throw new Exception("Книга уже выдана.");
            IsIssued = true;
        }

        public void Return()
        {
            IsIssued = false;
        }
    }
}
