using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Timers;

public class LoginSystem
{
    protected Data database;
    protected string username;
    protected string passwordHash;
    public LoginSystem()
    {
        this.username = HandledAskForUserName();
        this.passwordHash = HandledReadAndHashPassword();
    }
    public string HandledAskForUserName()
    {
        while (true)
        {
            Console.Write("Please Enter your Username: ");
            string username = Console.ReadLine();
            if (username.Length < 3)
            {
                Console.WriteLine("\nPlease enter a valid username with more than 3 characters.");
            }
            else
            {
                return username;
            }
        }
    }
    public string HandledReadAndHashPassword()
    {
        while (true)
        {
            Console.Write("Please Enter a password: ");
            string password = Console.ReadLine();
            if (password.Length < 8)
            {
                Console.WriteLine("\nPlease enter a valid password with more than 8 characters.");
            }
            else
            {
                Console.Write("please ReEnter the password: ");
                string reEnteredPassword = Console.ReadLine();
                if (password == reEnteredPassword)
                {
                    SHA256 hashAlgorithm = SHA256.Create();
                    string hashedPassword = GetHash(hashAlgorithm, password);
                    return hashedPassword;
                }
                else
                {
                    Console.WriteLine("The Password you ReEntered does not match the previous one. Try Again Please!");
                    continue;
                }

            }
        }
    }
    
    protected static string GetHash(HashAlgorithm hashAlgorithm, string input)
    {

        // Convert the input string to a byte array and compute the hash.
        byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        var sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }
    // Verify a hash against a string.
    protected static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
    {
        // Hash the input.
        var hashOfInput = GetHash(hashAlgorithm, input);

        // Create a StringComparer an compare the hashes.
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        return comparer.Compare(hashOfInput, hash) == 0;
    }

}

public class Register : LoginSystem
{
    
    public void RegisterAccount()
    {
        
    }
}
public class Login : LoginSystem
{

    public void TryLoginAccount(){
        SHA256 hashAlgorithm = SHA256.Create();
        if(passwordHash == VerifyHash(hashAlgorithm,passwordHash))
        {

        }
    }

}

