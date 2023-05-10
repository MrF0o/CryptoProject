using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProject.Crypto
{
    class MixedCipher : Crypto
    {


        private readonly char[] adfgvx = { 'A', 'D', 'F', 'G', 'V', 'X' };

        public override string encrypt(string plainText)
        {
            plainText = plainText.ToLower();
            string cipher1 = "", cipher = "";
            var g = Grid();

            // step 1: substitution
            foreach (char c in plainText)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (g[i, j] == c)
                        {
                            cipher1 += adfgvx[i];
                            cipher1 += adfgvx[j];
                        }
                    }
                }
            }

            // step 2: transposition
            char[,] kgd = KeyGrid(key, cipher1);
            int col = 0;

            for (int i = 0; i < kgd.Length; i++)
            {
                cipher += kgd[i, col];
                col++;
            }

            return cipher;

        }

        public override string decrypt(string cipherText)
        {
            throw new NotImplementedException();
        }

        private char[,] Grid()
        {
            char[,] grid = {
                { 'k', 'j', 'y', 'b', 'r', '7' },
                { 'h', 'c', 's', 'u', '3', 'q' },
                { 't', 'm', '4', '2', 'z', 'v' },
                { '8', '9', '0', 'g', 'l', 'x' },
                { 'a', 'w', '1', 'f', '5', 'i' },
                { 'o', 'p', '6', 'n', 'e', 'd' }
            };

            return grid;
        }

        private char[,] KeyGrid(string key, string initial)
        {
            char[] kg = key.OrderBy(c => c).ToArray();
            int rowCount = initial.Length / kg.Length;
            char[,] kgd = new char[rowCount,kg.Length];
            int lastJ = 0;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < kg.Length; j++)
                {
                    int k = i * rowCount + j;
                    kgd[i, j] = initial[k];
                }
            }

            return kgd;
        }

        // brain map

        // AFDAFX

        // r = 3
        // i * r + j

        //  T T
        //  0 1
        //0 A F
        //1 D A
        //2 F X
    }
}
