using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Game
{
    class HMAC
    {
        public void GiveHmac(byte[] key, byte[] step)
        {
            HMACSHA256 Hmac = new HMACSHA256(key);
            byte[] Hash = Hmac.ComputeHash(step);
            Console.WriteLine("HMAC: " + BitConverter.ToString(Hash, 0).Replace("-", string.Empty));
        }
    }
}
