using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProject
{
    class Crypto
    {
        public static String monoTable = "zyxwvutsrqponmlkjihgfedcbaABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static String monoAlphabeticCipher(String text)
        {
            char[] cipher = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                    cipher[i] = ' ';
                else
                {
                    int correspondence;
                        
                    if (text[i] < 97)
                    {
                        correspondence = text[i] - 65;
                    } else
                    {
                        correspondence = text[i] - 97;
                    }

                    cipher[i] = monoTable[correspondence];
                }
            }

            return new String(cipher);
        }
        
        public static String monoAlphabeticCipher_reverse(String text)
        {

            char[] cipher = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                    cipher[i] = ' ';
                else
                {
                    int correspondence;


                    correspondence = text[i] + 97;
                    

                    cipher[i] = monoTable[correspondence];
                }
            }

            return new String(cipher);
        }
    }
}
