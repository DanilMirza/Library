using System;

namespace Library.Pages
{
    public abstract class RegisterBookPage
    {
        private static int _selected = 0;
        private static Book book;

        public static void Print()
        {
            Program.Width = 70;
            Program.Height = 8;
            PrintRegisterBookPage();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (_selected == 0)
                    {
                        book = null;
                        MainPage.Print();
                    }
                    else if (_selected == 1)
                    {
                        Program.Library.AddBook(book);
                        book = null;
                        MainPage.Print();
                    }
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (_selected <= 0) _selected = 1;
                    else _selected--;

                    PrintRegisterBookPage();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (_selected >= 1) _selected = 0;
                    else _selected++;

                    PrintRegisterBookPage();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    _selected = 1;

                    PrintRegisterBookPage();
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    _selected = 0;

                    PrintRegisterBookPage();
                }
            }
        }

        private static void PrintRegisterBookPage()
        {
            Console.Clear();
            Page.PrintTitle("Регистрация новой книги");
            PrintRegisterBookPageActions();
        }

        private static void PrintRegisterBookPageActions()
        {
            if (book == null)
            {
                Console.CursorVisible = true;
                Console.Write("Название   :");
                string name = Console.ReadLine();
                Console.Write("Автор      :");
                string author = Console.ReadLine();
                Console.Write("Год выпуска:");
                string releaseDateTime = Console.ReadLine();
                Console.CursorVisible = false;

                book = new Book(name, author, releaseDateTime);
            }
            else
            {
                Console.WriteLine($"Название   :{book.Name}");
                Console.WriteLine($"Автор      :{book.Author}");
                Console.WriteLine($"Год выпуска:{book.ReleaseYear}");
            }

            string[] actions = {
                "Отмена",
                "Зарегестрировать"
            };

            for (int j = 0; j < actions.Length; j++)
            {
                if (j == 1) Console.CursorLeft = Program.Width - actions[1].Length;

                if (j == _selected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(actions[j]);
                    Console.BackgroundColor = Program.DefaultBackgroundColor;
                    Console.ForegroundColor = Program.DefaultForegroundColor;
                }
                else
                {
                    Console.Write(actions[j]);
                }
            }
        }
    }
}
