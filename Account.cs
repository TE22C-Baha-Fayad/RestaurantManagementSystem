public abstract class Account
{
   public string username{get;set;}
   public string passwordHash{get;set;}
}

public class AdminAccount : Account
{
    public AdminAccount(string username, string passwordHash)
    {
        this.username = username;
        this.passwordHash = passwordHash;
    }
}
public class UserAccount : Account
{
    public UserAccount(string username, string passwordHash)
    {
        this.username = username;
        this.passwordHash = passwordHash;
    }
}