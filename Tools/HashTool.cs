using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public static class Hash
{
    public static string CreateSHA256(this string str)
    {
        SHA256 hash = SHA256.Create();
        UTF8Encoding encoder = new();
        byte[] combined = encoder.GetBytes(str);
        hash.ComputeHash(combined);
        string delimitedHexHash = BitConverter.ToString(hash.Hash);
        string completedSha1Hash = delimitedHexHash.Replace("-", "");
        return completedSha1Hash;
    }

    public async Task<string> CreateSHA256Async(this string str)
    {
        return await Task.Run(() =>
        {
            SHA256 hash = SHA256.Create();
            UTF8Encoding encoder = new();
            byte[] combined = encoder.GetBytes(str);
            hash.ComputeHash(combined);
            string delimitedHexHash = BitConverter.ToString(hash.Hash);
            string completedSha1Hash = delimitedHexHash.Replace("-", "");
            return completedSha1Hash;

        });
    }
}