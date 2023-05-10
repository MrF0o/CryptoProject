using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProject.Crypto
{
    class CesarMonoAlphabetic : Crypto
    {
        private int k;
        public CesarMonoAlphabetic(int k)
        {
            this.k = k;
        }

        public override string encrypt(string plainText)
        {
            string ciphertext = "";
            int encryption = 0;
            for (int i = 0; i < plainText.Length; i++)
            {
                int txtUser = (int)plainText[i];
                encryption = txtUser + k; // shift letter based on k
                ciphertext += Char.ConvertFromUtf32(encryption); // UTF-32 is MUCH stronger!!
            }
            return ciphertext;
        }

        public override string decrypt(string cipherText)
        {
            string plaintext = "";
            int decryption = 0;
            for (int i = 0; i < cipherText.Length; i++)
            {
                int encrypted = (int)cipherText[i];
                decryption = encrypted - k;
                plaintext += Char.ConvertFromUtf32(decryption);
            }
            return plaintext;
        }
    }
}
