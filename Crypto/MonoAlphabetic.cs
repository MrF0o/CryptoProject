using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProject.Crypto
{
    class MonoAlphabetic : Crypto
    {
        private Dictionary<char, char> encryptionKey;
        private Dictionary<char, char> decryptionKey;

        public MonoAlphabetic(string key)
        {
            encryptionKey = GenerateEncryptionKey(key);
            decryptionKey = encryptionKey.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        }

        public override string encrypt(string plainText)
        {
            char[] encryptedChars = new char[plainText.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                char plainChar = plainText[i];

                if (encryptionKey.ContainsKey(plainChar))
                {
                    encryptedChars[i] = encryptionKey[plainChar];
                }
                else
                {
                    encryptedChars[i] = plainChar;
                }
            }

            return new string(encryptedChars);
        }

        public override string decrypt(string cipherText)
        {
            char[] decryptedChars = new char[cipherText.Length];

            for (int i = 0; i < cipherText.Length; i++)
            {
                char cipherChar = cipherText[i];

                if (decryptionKey.ContainsKey(cipherChar))
                {
                    decryptedChars[i] = decryptionKey[cipherChar];
                }
                else
                {
                    decryptedChars[i] = cipherChar;
                }
            }

            return new string(decryptedChars);
        }

        private Dictionary<char, char> GenerateEncryptionKey(string key)
        {
            Dictionary<char, char> encryptionKey = new Dictionary<char, char>();

            for (int i = 0; i < key.Length; i++)
            {
                char plainChar = (char)(i + 'a');
                char cipherChar = key[i];

                encryptionKey[plainChar] = cipherChar;

                char upperPlainChar = (char)(i + 'A');
                char upperCipherChar = Char.ToUpper(key[i]);

                encryptionKey[upperPlainChar] = upperCipherChar;
            }

            for (char plainChar = 'a'; plainChar <= 'z'; plainChar++)
            {
                if (!encryptionKey.ContainsKey(plainChar))
                {
                    char cipherChar = (char)('a' + encryptionKey.Count);
                    encryptionKey[plainChar] = cipherChar;

                    char upperPlainChar = Char.ToUpper(plainChar);
                    char upperCipherChar = Char.ToUpper(cipherChar);

                    encryptionKey[upperPlainChar] = upperCipherChar;
                }
            }

            return encryptionKey;
        }
    }
}
