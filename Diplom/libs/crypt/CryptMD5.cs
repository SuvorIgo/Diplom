using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.crypt
{
    static class CryptMD5
    {
        static public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        static public bool EqualsHashes(string pass, string passHash)
        {
            var md5 = MD5.Create();

            return pass.Equals(passHash);
        }
    }
}
