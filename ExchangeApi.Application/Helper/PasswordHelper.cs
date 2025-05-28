using System.Text;
using Konscious.Security.Cryptography;

namespace ExchangeApi.Application.Helper;

public static class PasswordHelper
{
    public static string HashPasswordWithArgon2(string password, byte[] salt)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be empty", nameof(password));

        if (salt == null || salt.Length == 0)
            throw new ArgumentException("Salt cannot be null or empty", nameof(salt));

        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = 8,
            MemorySize = 65536,
            Iterations = 4
        };

        byte[] hash = argon2.GetBytes(32);
        return Convert.ToBase64String(hash);
    }
}