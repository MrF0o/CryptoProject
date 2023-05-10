using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProject.Crypto
{
    abstract public class Crypto
    {
        public bool isKeyRequired = false;
        protected string key;

        public string Key
        {
            set { this.key = value; }
        }

        public abstract string encrypt(string plainText);
        public abstract string decrypt(string cipherText);

        public static IEnumerable<T> GetRow<T>(T[,] array, int index)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                yield return array[index, i];
            }
        }

        public static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
