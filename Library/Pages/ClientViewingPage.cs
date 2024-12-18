using System;
using System.Collections.Generic;

namespace Library.Pages
{
    public abstract class ClientViewingPage
    {
        private static int _selected = 0;
        private static List<Client> _clients = Program.Library.GetClients();

        public static void Print()
        {
            Program.Width = 70;
            Program.Height = 40;
            PrintClientViewingPage();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (_selected == 0)
                    {
                        MainPage.Print();
                        break;
                    }
                    else if (_selected > 0)
                    {
                        PrintClientViewingPage();
                    }
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (_selected <= 0) _selected = _clients.Count;
                    else _selected--;

                    PrintClientViewingPage();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (_selected >= _clients.Count) _selected = 0;
                    else _selected++;

                    PrintClientViewingPage();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    _selected = _clients.Count;

                    PrintClientViewingPage();
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    _selected = 0;

                    PrintClientViewingPage();
                }
            }
        }

        static void PrintClientViewingPage()
        {
            _clients = Program.Library.GetClients();
            Console.Clear();
            Page.PrintTitle("Просмотр клиентов");
            PrintClientViewingPageActions();
        }

        static void PrintClientViewingPageActions()
        {
            string[] actions = new string[_clients.Count + Program.Library.GetCountIssuedBooks() + 1];
            actions[0] = "< Назад";

            int j = 1;
            foreach (Client client in _clients)
            {
                actions[j] = "Выдать книгу";
                j++;
                foreach (BookRecord bookRecord in client.GetBookRecords())
                {
                    actions[j] = "Вернуть книгу";
                    j++;
                }
            }

            if (0 == _selected)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(actions[0]);
                Console.BackgroundColor = Program.DefaultBackgroundColor;
                Console.ForegroundColor = Program.DefaultForegroundColor;
            }
            else
            {
                Console.WriteLine(actions[0]);
            }

            j = 1;
            foreach (Client client in _clients)
            {
                Console.Write("Клиент");
                Console.CursorLeft = Program.Width - actions[j].Length;

                if (j == _selected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(actions[j]);
                    Console.BackgroundColor = Program.DefaultBackgroundColor;
                    Console.ForegroundColor = Program.DefaultForegroundColor;
                }
                else
                {
                    Console.WriteLine(actions[j]);
                }

                Console.WriteLine($"ФИО           :{client.FullName}");
                Console.WriteLine($"Номер телефона:{client.PhoneNumber}");
                Console.WriteLine("Книги:");

                j++;
                foreach (BookRecord bookRecord in client.GetBookRecords())
                {
                    Console.Write("Книга");
                    Console.CursorLeft = Program.Width - actions[j].Length;

                    if (j == _selected)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(actions[j]);
                        Console.BackgroundColor = Program.DefaultBackgroundColor;
                        Console.ForegroundColor = Program.DefaultForegroundColor;
                    }
                    else
                    {
                        Console.WriteLine(actions[j]);
                    }

                    Console.WriteLine($"Название     :{bookRecord.Book.Name}");
                    Console.WriteLine($"Автор        :{bookRecord.Book.Author}");
                    Console.WriteLine($"Год выпуска  :{bookRecord.Book.ReleaseYear}");
                    Console.WriteLine($"Дата выдачи  :{bookRecord.StartDateTime}");
                    Console.WriteLine($"Дата возврата:{bookRecord.EndDateTime}");
                    j++;
                }

                Console.WriteLine();
            }
        }
    }
}
