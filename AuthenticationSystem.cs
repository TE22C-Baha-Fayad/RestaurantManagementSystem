using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Timers;

public abstract class AuthenticationSystem
{
    protected static string HandledAskForUserName()
    {
        while (true)
        {
            Console.Write("Please Enter Username: ");
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
    protected static string HandledReadPasswordToHash()
    {
        while (true)
        {
            Console.Write("Please Enter password: ");
            string password = Console.ReadLine();
            if (password.Length < 8)
            {
                Console.WriteLine("\nPlease enter a valid password with more than 8 characters.");
            }
            else
            {
                SHA256 hashAlgorithm = SHA256.Create();
                string hashedPassword = GetHash(hashAlgorithm, password);
                return hashedPassword;
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

public class Register : AuthenticationSystem
{
    public static void RegisterAccount(bool isAdmin)
    {
        // If registering an admin account, verify the secret

        if (isAdmin)
        {
            //Admin secret and hash in code for debug purpose only
            // @AdminSecret1423                                                   
            // 428d66aaea017668a44a8fcfe0bb685d7b4b2321a19d82e4e05b6eabdd0d13b6
            const string adminSecrectHash = "428d66aaea017668a44a8fcfe0bb685d7b4b2321a19d82e4e05b6eabdd0d13b6";
            Console.Write("This Gate is for Admins Only, please Enter the secret to register an AdminAccount: ");
            string inputStringSecret = Console.ReadLine();
            if (!VerifyHash(SHA256.Create(), inputStringSecret, adminSecrectHash))
            {
                Console.WriteLine("Wrong Secret! You are not allowed to register an admin account.");
                Console.WriteLine("Press Any key to continue...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Correct Secret! Please Continue Registering.");
        }

        while (true)
        {

            string username = HandledAskForUserName();
            string passwordHash = HandledReadPasswordToHash();

            // Confirm the password
            Console.Write("Please re-enter the password: ");
            string reEnteredPassword = Console.ReadLine();

            if (VerifyHash(SHA256.Create(), reEnteredPassword, passwordHash))
            {
                if (isAdmin)
                {
                    AdminAccount adminAccount = new AdminAccount(username, passwordHash);
                    Data.adminAccounts.Add(adminAccount);
                    Console.WriteLine("Admin account registered successfully!");
                }
                else
                {
                    UserAccount userAccount = new UserAccount(username, passwordHash);
                    Data.userAccounts.Add(userAccount);
                    Console.WriteLine("User account registered successfully!");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("The password you re-entered does not match. Try again!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
public class Login : AuthenticationSystem
{
    public static Account TryFindAccount(List<Account> accountList)
    {
        string inputUsername = HandledAskForUserName();
        string inputPassword = HandledReadPasswordToHash();

        if (accountList.Count < 1)
        {
            Console.WriteLine("Account not found, username not valid.");
            return null;
        }
        for (int i = 0; i < accountList.Count; i++)
        {
            if (accountList[i].username == inputUsername)
            {
                //username found
                int triesCount = 3;
                for (int j = 0; j < triesCount; j++)
                {
                    if (j > 0)
                        inputPassword = HandledReadPasswordToHash();

                    if (accountList[i].passwordHash == inputPassword)
                    {
                        Console.WriteLine("Login successful!");
                        return accountList[i];
                    }
                    else
                    {
                        Console.WriteLine($"Password is wrong! please try typing the password again. You have {triesCount - j} tries left.");
                    }

                }

            }
            if (i == accountList.Count - 1)
            {
                Console.WriteLine("Account not found, username not valid.");
            }

        }
        return null;
    }
}

