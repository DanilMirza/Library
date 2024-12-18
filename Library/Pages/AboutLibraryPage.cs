using System;

namespace Library.Pages
{
    public abstract class AboutLibraryPage
    {
        public static void Print()
        {
            Program.Width = 70;
            Program.Height = 30;
            PrintAboutLibraryPage(0);
            int selected = 0;

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selected == 0)
                    {
                        MainPage.Print();
                    }
                    else if (selected == 1)
                    {
                        MainPage.Print();
                        //страница для изменения "о библтотеке"
                    }
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (selected <= 0) selected = 1;
                    else selected--;

                    PrintAboutLibraryPage(selected);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (selected >= 1) selected = 0;
                    else selected++;

                    PrintAboutLibraryPage(selected);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    selected = 1;

                    PrintAboutLibraryPage(selected);
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    selected = 0;

                    PrintAboutLibraryPage(selected);
                }
            }
        }

        private static void PrintAboutLibraryPage(int i)
        {
            Console.Clear();
            Page.PrintTitle("О библиотеке");
            PrintAboutLibraryPageActions(i);
        }

        static void PrintAboutLibraryPageActions(int i)
        {
            string[] actions = {
                "< Назад",
                "Изменить"
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

                if (j == 1)
                {
                    Console.WriteLine("\n" +
                        "Расписание\n" +
                        " - Понедельник:  9:00 - 18:00\n" +
                        " - Вторник:      9:00 - 18:00\n" +
                        " - Среда:        9:00 - 18:00\n" +
                        " - Четверг:      9:00 - 18:00\n" +
                        " - Пятница:      9:00 - 18:00\n" +
                        " - Суббота:     11:00 - 16:00\n" +
                        " - Воскресенье: 11:00 - 16:00\n" +
                        "Описание:\n" +
                        "   Очень хорошая библиотека.");
                }
            }
        }
    }
}
