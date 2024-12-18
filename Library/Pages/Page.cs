using System;

namespace Library.Pages
{
    public abstract class Page
    {
        public static void PrintTitle(string title)
        {
            string titleText = $"{title}\n";
            Console.CursorLeft = (Program.Width / 2) - (titleText.Length / 2);
            Console.WriteLine(titleText);
        }
    }
}
