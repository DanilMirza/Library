using System;

namespace Library.Pages
{
    public abstract class AddClientPage
    {
        private static int _selected = 0;
        private static Client client;

        public static void Print()
        {
            Program.Width = 70;
            Program.Height = 7;
            PrintAddClientPage();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (_selected == 0)
                    {
                        client = null;
                        MainPage.Print();
                    }
                    else if (_selected == 1)
                    {
                        Program.Library.AddClient(client);
                        client = null;
                        MainPage.Print();
                    }
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (_selected <= 0) _selected = 1;
                    else _selected--;

                    PrintAddClientPage();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (_selected >= 1) _selected = 0;
                    else _selected++;

                    PrintAddClientPage();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    _selected = 1;

                    PrintAddClientPage();
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    _selected = 0;

                    PrintAddClientPage();
                }
            }
        }

        private static void PrintAddClientPage()
        {
            Console.Clear();
            Page.PrintTitle("Добавление клиента");
            PrintAddClientPageActions();
        }

        private static void PrintAddClientPageActions()
        {
            if (client == null)
            {
                Console.CursorVisible = true;
                Console.Write("ФИО           :");
                string fullName = Console.ReadLine();
                Console.Write("Номер телефона:");
                string phoneNumber = Console.ReadLine();
                Console.CursorVisible = false;

                client = new Client(fullName, phoneNumber);
            }
            else
            {
                Console.WriteLine($"ФИО           :{client.FullName}");
                Console.WriteLine($"Номер телефона:{client.PhoneNumber}");
            }

            string[] actions = {
                "Отмена",
                "Добавить"
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
