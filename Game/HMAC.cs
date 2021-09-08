using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Game
{
    class HMAC
    {
        public string GiveHmac(string key, string step)
        {          
            HMACSHA256 Hmac = new HMACSHA256(Encoding.Default.GetBytes(key));
            byte[] Hash = Hmac.ComputeHash(Encoding.Default.GetBytes(step));
            return "HMAC: " + BitConverter.ToString(Hash, 0).Replace("-", string.Empty);
        }
    }
}
