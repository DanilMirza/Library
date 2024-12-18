using System;
using Library.Pages;

namespace Library
{
    internal class Program
    {
        public static readonly ConsoleColor DefaultBackgroundColor = Console.BackgroundColor;
        public static readonly ConsoleColor DefaultForegroundColor = Console.ForegroundColor;
        private static int _winth = Console.WindowWidth;
        public static int Width 
        { 
            get
            {
                return _winth;
            }

            set
            {
                _winth = value;
                Console.WindowWidth = _winth;
                Console.BufferWidth = _winth;
            }
        }

        private static int _height = Console.WindowHeight;
        public static int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
                Console.WindowHeight = _height;
                Console.BufferHeight = _height;
            }
        }
        public static readonly Library Library = new Library("Белгородская библиотека");
        
        static void Main(string[] args)
        {
            Console.Title = Library.Name;
            Console.CursorVisible = false;

            MainPage.Print();

            Console.ReadLine();
        }
    }
}
