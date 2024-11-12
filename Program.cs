

using System.Net.WebSockets;

class Program
{
    static void Main(string[] args)
    {
        MainMenu();

    }
    static void MainMenu()
    {
        Console.CursorVisible = false;
        const int innitialCursorY = 4;
        int lastcursorYPosition = innitialCursorY;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Royal Restaurant!");
            Console.WriteLine("Please navigate with (Up) arrow and (Down) arrow and confirm with Enter.");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("  1.Login");
            Console.WriteLine("  2.Register new Account");
            Console.WriteLine("  3.Exit");

            Console.SetCursorPosition(0, lastcursorYPosition);
            string navigationCharacter = "=>";
            Console.Write(navigationCharacter);


            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.UpArrow && lastcursorYPosition > innitialCursorY)
            {
                lastcursorYPosition--;

            }
            else if (key == ConsoleKey.DownArrow && lastcursorYPosition < innitialCursorY + 2)
            {
                lastcursorYPosition++;

            }
            else if (key == ConsoleKey.Enter)
            {
                int currnetCursorY = Console.GetCursorPosition().Top;
                if (currnetCursorY == innitialCursorY)
                {
                    LoginPage();
                }
                else if (currnetCursorY == innitialCursorY + 1)
                {
                    RegisterPage();
                }
                else if (currnetCursorY == innitialCursorY + 2)
                {
                    Exit();
                    break;
                }
            }

        }
    }
    static void Exit()
    {
        Console.Clear();
        Console.WriteLine("See you next time!");
        return;
    }
    static void LoginPage()
    {

    }
    static void RegisterPage()
    {


        const int innitialCursorY = 1;
        int lastcursorYPosition = innitialCursorY;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("What type of account would you like to Register?");
            Console.WriteLine("  1.User Account - Recommended for users");
            Console.WriteLine("  2.Admin Account - For Restaurant staff only.");
            Console.WriteLine("  3.Return - Returns back to main menu.");

            Console.SetCursorPosition(0, lastcursorYPosition);
            string navigationCharacter = "=>";
            Console.Write(navigationCharacter);


            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.UpArrow && lastcursorYPosition > innitialCursorY)
            {
                lastcursorYPosition--;

            }
            else if (key == ConsoleKey.DownArrow && lastcursorYPosition < innitialCursorY + 2)
            {
                lastcursorYPosition++;

            }
            else if (key == ConsoleKey.Enter)
            {
                int currnetCursorY = Console.GetCursorPosition().Top;
                Console.Clear();
                if (currnetCursorY == innitialCursorY)
                {
                    Register.RegisterAccount(false);
                }
                else if (currnetCursorY == innitialCursorY + 1)
                {
                    Register.RegisterAccount(true);
                }
                else if (currnetCursorY == innitialCursorY + 2)
                {
                    return;
                }

            }
        }
    }


}