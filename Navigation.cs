class Navigation
{
    



    static void DisplayNavigation(string header,List<string> Options,List<Action> actions)
    {
        const int innitialCursorY = 1;
        int lastcursorYPosition = innitialCursorY;
        while (true)
        {
            Console.Clear();
            Console.WriteLine(header);
            foreach(string option in Options)
            {
                Console.WriteLine($"  {option}");
            }
            Console.WriteLine($"  {Options.Count}.Return - Returns back.");

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
                for(int i = 0; i<Options.Count; i++)
                {
                    if(currnetCursorY == i+innitialCursorY)
                    {
                        actions[i].Invoke();
                        return;
                    }
                }
                if(currnetCursorY == Options.Count)
                {
                    return;
                }

            }
        }
    }
}