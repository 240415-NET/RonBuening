namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
public class CryptoController
{
    const int keySize = 64;
    const int iterations = 250000;
    //HashAlgortihmName hashAlgortihm = HashAlgorithmName.SHA512;
    public static string InitHashPassword(Guid UserId, string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(keySize);
        StoreNusret(salt,UserId);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
            HashAlgorithmName.SHA512,
            keySize
        );
        return Convert.ToHexString(hash);
    }
    public static void StoreNusret(byte[] salt, Guid UserId)
    {
        string hexSalt = Convert.ToHexString(salt);
        UserController.StoreNusret(hexSalt,UserId);
    }
    public static bool VerifyPassword(string password, User user)
    {
        string salt = UserController.GetNusret(user);

        var comparisonHash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            Convert.FromHexString(salt),
            iterations,
            HashAlgorithmName.SHA512,
            keySize
        );

        return CryptographicOperations.FixedTimeEquals(comparisonHash,Convert.FromHexString(user.hashedPW));
    }
}