

using System.Diagnostics;
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
            Console.WriteLine("Welcome to the krusty krab Restaurant!");
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
        const int innitialCursorY = 1;
        int lastcursorYPosition = innitialCursorY;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("What type of account would you like to Login As?");
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

                if (currnetCursorY == innitialCursorY)
                {
                    LoginAccount(false);
                }
                else if (currnetCursorY == innitialCursorY + 1)
                {
                    LoginAccount(true);
                }
                else if (currnetCursorY == innitialCursorY + 2)
                {
                    return;
                }

            }
        }
        static Account LoginAccount(bool isAdmin)
        {
            while (true)
            {
                Console.Clear();
                List<Account> accounts;
                if (isAdmin)
                {
                    accounts = Data.adminAccounts.ToList<Account>();
                }
                else
                {
                    accounts = Data.userAccounts.ToList<Account>();
                }
                Account account = Login.TryFindAccount(accounts);
                if (account != null)
                {
                    return account;
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("Would you like to try again? answer with y/n");
                        ConsoleKey answer = Console.ReadKey().Key;
                        if (answer == ConsoleKey.Y)
                        {
                            break;
                        }
                        else if (answer == ConsoleKey.N)
                        {
                            return null;
                        }
                        else
                        {
                            Console.WriteLine("Answer not valid!");
                            Console.WriteLine("press any key to continue...");
                            Console.ReadKey();
                        }
                    }

                }
            }
        }
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
                    break;
                }
                else if (currnetCursorY == innitialCursorY + 1)
                {
                    Register.RegisterAccount(true);
                    break;
                }
                else if (currnetCursorY == innitialCursorY + 2)
                {
                    return;
                }

            }
        }
    }


}