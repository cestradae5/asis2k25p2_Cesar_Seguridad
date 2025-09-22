//Pablo Quiroa 0901-22-2929 
using System.Security.Cryptography;
using System.Text;

namespace CapaControlador
{
    public static class SeguridadHash
    {
        
        public static string HashearSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); 
                }
                return sb.ToString();
            }
        }
    }
}
