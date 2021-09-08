using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Game
{
    class KeyGenerator
    {
        public string Key { get; set; }
        public string GiveKey()
        {
            byte[] KeyByte = new byte[16];
            RandomNumberGenerator RandomKey  = RandomNumberGenerator.Create();
            RandomKey.GetBytes(KeyByte);
            Key = BitConverter.ToString(KeyByte, 0).Replace("-", string.Empty);
            return Key;    
        }
    }
}
