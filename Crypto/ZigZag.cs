using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CryptoProject.Crypto
{
    class ZigZag : Crypto
    {
        public int depth;

        public ZigZag(int depth)
        {
            this.depth = depth;
        }

        public override string encrypt(String plainText)
        {
            // si le profondeur < 1 retourner le meme texte
            if (depth < 1) return plainText;

            int r = (plainText.Length % depth) + (plainText.Length / depth), cr = 0, i = 0;
            char[,] rows = new char[depth, r];

            string encrypted = "";

            foreach (char c in plainText)
            {
                rows[cr, i] = c;
                
                cr++;

                if (cr == depth)
                {
                    cr = 0;
                    i++;
                }
            }

            for (int j = 0; j < depth; j++)
            {
                encrypted += new string(GetRow(rows, j).ToArray());
            }

            return encrypted;
        }

        public override string decrypt(string cipherText)
        {
            int r = (cipherText.Length % depth) + (cipherText.Length / depth), cr = 0;
            char[,] rows = new char[depth, r];

            // split cipherText into equal strings that matches r
            List<string> arr = new List<string>(Regex.Split(cipherText, @"(?<=\G.{" + r + "})", RegexOptions.Singleline));

            string decrypted = "";

            for (int j = 0; j < r; j++)
            {
                for (int i = 0; i < depth; i++)
                {
                    if (j < arr[i].Length)
                    {
                        decrypted += arr[i][j];
                    }
                }
            }

            return decrypted;
        }
    }
}
