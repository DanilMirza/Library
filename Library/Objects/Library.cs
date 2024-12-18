using System.Collections.Generic;

namespace Library
{
    public class Library
    {
        public readonly string Name;
        private readonly List<Client> _clients = new List<Client>();
        private readonly List<Book> _books = new List<Book>();

        public Library(string name) 
        {
            Name = name;
        }

        public void AddClient(Client client)
        {
            _clients.Add(client);
        }

        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            clients.AddRange(_clients);
            return clients;
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(int id)
        {
            _books.RemoveAt(id);
        }

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            books.AddRange(_books);
            return books;
        }

        public int GetCountIssuedBooks()
        {
            int count = 0;
            foreach (Book book in _books)
            {
                if (book.IsIssued) count++;
            }
            return count;
        }
    }
}
