using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    /// <summary>
    /// Класс, реализующий шифрование ROT13
    /// </summary>
    public  class Rot13Cipher : ICipher
    {
        /// <summary>
        /// Метод для шифрования
        /// </summary>
        /// <param name="text"> Текст для шифрования </param>
        /// <returns> Зашифрованный текст </returns>
        public string Encode(string text, int offset=13)
        {
            if (offset != 13)
            {
                throw new ArgumentException();
            }

            var cezar = new CezarCipher();
            return cezar.Encode(text, 13);
        }
        /// <summary>
        /// Метод для расшифрования
        /// </summary>
        /// <param name="text"> Текст для расшифрования </param>
        /// <returns> расшифрованный текст </returns>
        public string Decode(string text, int offset=13)
        {
            if (offset != 13)
            {
                throw new ArgumentException();
            }
            var cezar = new CezarCipher();
            return cezar.Decode(text, 13);
        }
    }

}
