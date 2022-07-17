using System.Text;

namespace Store.Domain.Utility
{
    public static class HashPassword
    {
        public static string EncodePasswordBase64(string password)
        {
            try
            {
                byte[] encData = new byte[password.Length];
                encData = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(encData);
            }
            catch (Exception error)
            {
                throw new Exception($"Falha ao encodar password: {error.Message}");
            }
        }

        public static string DecodePassword(string password)
        {
            var encoder = new UTF8Encoding();
            var utf8Decoder = encoder.GetDecoder();
            byte[] totalBytes = Convert.FromBase64String(password);
            int charCount = utf8Decoder.GetCharCount(totalBytes, 0, totalBytes.Length);
            char[] decodedChar = new char[charCount];
            utf8Decoder.GetChars(totalBytes, 0, totalBytes.Length, decodedChar, 0);
            return new string(decodedChar);
        }
    }
}
