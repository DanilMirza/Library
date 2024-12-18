using System;

namespace Library.Pages
{
    public abstract class MainPage
    {
        private static int _selected = 0;
        
        public static void Print()
        {
            Program.Width = 70;
            Program.Height = 13;
            PrintMainPage();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (_selected)
                    {
                        case 0: 
                            { 
                                AboutLibraryPage.Print(); 
                                break;
                            }
                        case 1:
                            {
                                RegisterBookPage.Print();
                                break;
                            }
                        case 2:
                            {
                                BookViewingPage.Print();
                                break;
                            }
                        case 3:
                            {
                                AddClientPage.Print();
                                break;
                            }
                        case 4:
                            {
                                ClientViewingPage.Print();
                                break;
                            }
                    }
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (_selected <= 0) _selected = 4;
                    else _selected--;

                    PrintMainPage();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (_selected >= 4) _selected = 0;
                    else _selected++;

                    PrintMainPage();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    _selected = 4;

                    PrintMainPage();
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    _selected = 0;

                    PrintMainPage();
                }
            }
        }

        static void PrintMainPage()
        {
            Console.Clear();
            Page.PrintTitle("Главное меню");
            PrintMainPageActions();
        }

        static void PrintMainPageActions()
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

                if (j == _selected)
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
