using System.Security.Cryptography;
using System.Text;

namespace WebTextForum.Helpers
{
    public static class Security
    {
        public static string HashedPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
