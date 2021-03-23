using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    /// <summary>
    /// Интерфейс для методов шифрования
    /// </summary>
    interface ICipher
    {
        string Encode(string text, int offset);

        string Decode(string text, int offset);
    }
}
