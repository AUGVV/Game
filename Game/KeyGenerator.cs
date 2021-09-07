using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Game
{
    class KeyGenerator
    {
        public byte[] Key = new byte[16];
        public byte[] GiveKey()
        {
            RandomNumberGenerator RandomKey  = RandomNumberGenerator.Create();
            RandomKey.GetBytes(Key);
            return Key;    
        }
    }
}
