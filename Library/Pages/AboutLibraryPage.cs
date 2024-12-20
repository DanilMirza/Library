﻿using System;

namespace Library.Pages
{
    public abstract class AboutLibraryPage
    {
        private static int _selected = 0;

        public static void Print()
        {
            Program.Width = 70;
            Program.Height = 30;
            PrintAboutLibraryPage();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (_selected == 0)
                    {
                        MainPage.Print();
                    }
                    else if (_selected == 1)
                    {
                        MainPage.Print();
                        //страница для изменения "о библтотеке"
                    }
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (_selected <= 0) _selected = 1;
                    else _selected--;

                    PrintAboutLibraryPage();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (_selected >= 1) _selected = 0;
                    else _selected++;

                    PrintAboutLibraryPage();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    _selected = 1;

                    PrintAboutLibraryPage();
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    _selected = 0;

                    PrintAboutLibraryPage();
                }
            }
        }

        private static void PrintAboutLibraryPage()
        {
            Console.Clear();
            Page.PrintTitle("О библиотеке");
            PrintAboutLibraryPageActions();
        }

        static void PrintAboutLibraryPageActions()
        {
            string[] actions = {
                "< Назад",
                "Изменить"
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
