public class LoginSystem
{
    public string HandledAskForUserName()
    {
        //kör en while loop här
        Console.Write("Please Enter your Username: ");
        string username = Console.ReadLine();
        if(username.Length < 3)
        {
            Console.WriteLine("\nPlease enter a username with more characters than 3");
        }

        return username;
    }
}

public class Register : LoginSystem
{
    private string username;
   public Register()
   {
     this.username = HandledAskForUserName();
   }
}
public class Login : LoginSystem
{

}