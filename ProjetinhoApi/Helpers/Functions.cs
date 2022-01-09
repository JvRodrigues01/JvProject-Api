using System.Text;

namespace ProjetinhoApi.Helpers
{
    public class Functions
    {
        public static string Key = "@s@;-21MMaijdn!()2-3";

        public static string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string Decrypt(string base64encode)
        {
            if (string.IsNullOrEmpty(base64encode))
                return "";
            var base64encodeBytes = Convert.FromBase64String(base64encode);
            var result = Encoding.UTF8.GetString(base64encodeBytes);
            return result.Substring(0, result.Length - Key.Length);
        }
    }
}
