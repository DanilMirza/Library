using System;

namespace Library.Pages
{
    public abstract class MainPage
    {
        public static void Print()
        {
            Program.Width = 70;
            Program.Height = 13;
            PrintMainPage(0);
            int selected = 0;

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selected == 0)
                    {
                        AboutLibraryPage.Print();
                    }
                    else if (selected == 1)
                    {
                        RegisterBookPage.Print();
                    }
                    else if (selected == 2)
                    {
                        Console.WriteLine(2);
                    }
                    else if (selected == 3)
                    {
                        Console.WriteLine(3);
                    }
                    else if (selected == 4)
                    {
                        Console.WriteLine(4);
                    }
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (selected <= 0) selected = 4;
                    else selected--;

                    PrintMainPage(selected);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (selected >= 4) selected = 0;
                    else selected++;

                    PrintMainPage(selected);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    selected = 4;

                    PrintMainPage(selected);
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    selected = 0;

                    PrintMainPage(selected);
                }
            }
        }

        static void PrintMainPage(int i)
        {
            Console.Clear();
            Page.PrintTitle("Главное меню");
            PrintMainPageActions(i);
        }

        static void PrintMainPageActions(int i)
        {
            string[] actions = {
                "О библиотеке",
                "Зарегистрировать новую книгу",
                "Просмотеть книги",
                "Добавить клиента",
                "Просмотреть клиентов"};

            for (int j = 0; j < actions.Length; j++)
            {
                if (j == 0) Console.WriteLine("О библтотеке:");
                else if (j == 1) Console.WriteLine("Книги:");
                else if (j == 3) Console.WriteLine("Клиенты:");

                if (j == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($" + {actions[j]}");
                    Console.BackgroundColor = Program.DefaultBackgroundColor;
                    Console.ForegroundColor = Program.DefaultForegroundColor;
                }
                else
                {
                    Console.WriteLine($" - {actions[j]}");
                }
            }
        }
    }
}
