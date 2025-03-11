using System;
using System.Security.Cryptography;
using System.Text;

public class TokenManager
{
    private static readonly string Key = "YOUR_SECURE_KEY_HERE"; // Store securely in env vars

    public static string EncryptToken(string token)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = aes.Key[..16];

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(token), 0, token.Length);
            return Convert.ToBase64String(encrypted);
        }
    }

    public static string DecryptToken(string encryptedToken)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = aes.Key[..16];

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] decrypted = decryptor.TransformFinalBlock(Convert.FromBase64String(encryptedToken), 0, Convert.FromBase64String(encryptedToken).Length);
            return Encoding.UTF8.GetString(decrypted);
        }
    }
}
