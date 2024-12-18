using System;
using System.Collections.Generic;

namespace Library.Pages
{
    public abstract class BookViewingPage
    {
        private static int _selected = 0;
        private static List<Book> _books = Program.Library.GetBooks();
        
        public static void Print()
        {
            Program.Width = 70;
            Program.Height = 40;
            PrintBookViewingPage();

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
                        Program.Library.RemoveBook(_selected - 1);
                        PrintBookViewingPage();
                    }
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (_selected <= 0) _selected = _books.Count;
                    else _selected--;

                    PrintBookViewingPage();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (_selected >= _books.Count) _selected = 0;
                    else _selected++;

                    PrintBookViewingPage();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    _selected = _books.Count;

                    PrintBookViewingPage();
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    _selected = 0;

                    PrintBookViewingPage();
                }
            }
        }

        static void PrintBookViewingPage()
        {
            _books = Program.Library.GetBooks();
            Console.Clear();
            Page.PrintTitle("Просмотр книг");
            PrintBookViewingPageActions();
        }

        static void PrintBookViewingPageActions()
        {
            string[] actions = new string[_books.Count + 1];
            actions[0] = "< Назад";
            for (int j = 1;  j < actions.Length; j++)
            {
                actions[j] = "Списать";
            }

            for (int j = 0; j < actions.Length; j++)
            {
                if (j > 0) 
                {
                    Console.Write("Книга");
                    Console.CursorLeft = Program.Width - actions[j].Length; 
                }

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

                if (j > 0)
                {
                    Console.WriteLine($"Название   :{_books[j - 1].Name}");
                    Console.WriteLine($"Автор      :{_books[j - 1].Author}");
                    Console.WriteLine($"Год выпуска:{_books[j - 1].ReleaseYear}");
                    Console.WriteLine($"Выдана     :{(_books[j - 1].IsIssued ? "да" : "нет")}");
                    Console.WriteLine();
                }
            }
        }
    }
}
