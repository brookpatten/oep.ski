using Amphibian.Oep.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly int _defaultIterations = 2;
        private readonly int _hashLength = 32;

        public PasswordService(int defaultIterations, int defaultHashLength)
        {
            _defaultIterations = defaultIterations;
            _hashLength = defaultHashLength;
        }
        public void SetPassword(User user, string password)
        {
            var salt = GenerateSalt(_hashLength);
            var hash = GenerateHash(StringToBytes(password), salt, _defaultIterations, _hashLength);
            user.PasswordSalt = salt;
            user.PasswordHash = hash;
            user.PasswordHashIterations = _defaultIterations;
        }
        public bool CheckPassword(User user, string password)
        {
            if (user.PasswordHash != null && user.PasswordSalt != null && user.PasswordHashIterations.HasValue)
            {
                var calculatedHash = GenerateHash(StringToBytes(password), user.PasswordSalt, user.PasswordHashIterations.Value, user.PasswordHash.Length);
                return calculatedHash.SequenceEqual(user.PasswordHash);
            }
            else
            {
                return false;
            }
        }

        private byte[] StringToBytes(string password)
        {
            return System.Text.UTF8Encoding.UTF8.GetBytes(password);
        }

        private byte[] GenerateSalt(int length)
        {
            var bytes = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return bytes;
        }

        public byte[] GenerateHash(byte[] password, byte[] salt, int iterations, int length)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return deriveBytes.GetBytes(length);
            }
        }
    }
}
