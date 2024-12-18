using System;

namespace Library.Pages
{
    public abstract class RegisterBookPage
    {
        private static Book book;

        public static void Print()
        {
            Program.Width = 70;
            Program.Height = 8;
            PrintRegisterBookPage(0);
            int selected = 0;

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selected == 0)
                    {
                        book = null;
                        MainPage.Print();
                    }
                    else if (selected == 1)
                    {
                        Program.Library.AddBook(book);
                        MainPage.Print();
                    }
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (selected <= 0) selected = 1;
                    else selected--;

                    PrintRegisterBookPage(selected);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (selected >= 1) selected = 0;
                    else selected++;

                    PrintRegisterBookPage(selected);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    selected = 1;

                    PrintRegisterBookPage(selected);
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    selected = 0;

                    PrintRegisterBookPage(selected);
                }
            }
        }

        private static void PrintRegisterBookPage(int i)
        {
            Console.Clear();
            Page.PrintTitle("Регистрация новой книги");
            PrintRegisterBookPageActions(i);
        }

        private static void PrintRegisterBookPageActions(int i)
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

                if (j == i)
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
