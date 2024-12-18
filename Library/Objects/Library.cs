using System.Collections.Generic;

namespace Library
{
    public class Library
    {
        public readonly string Name;
        private readonly List<Client> _clients = new List<Client>();
        private readonly Dictionary<int, Book> _books = new Dictionary<int, Book>();

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
            _books.Add(_books.Count, book);
        }

        public void RemoveBook(int id)
        {
            _books.Remove(id);
        }

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            foreach (Book book in _books.Values) books.Add(book);
            return books;
        }
    }
}
