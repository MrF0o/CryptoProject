using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProject.Crypto
{
    abstract public class Crypto
    {
        public abstract string encrypt(string plainText);
        public abstract string decrypt(string cipherText);
    }
}
