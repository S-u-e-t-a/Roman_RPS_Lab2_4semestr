namespace laba2
{
    /// <summary>
    /// Интерфейс для методов шифрования
    /// </summary>
    internal interface ICipher
    {
        string Encode(string text);

        string Decode(string text);
    }
    /// <summary>
    /// Класс, реализующий шифрование ROT13
    /// </summary>
    public class Rot13Cipher : ICipher
    {
        /// <summary>
        /// Метод для шифрования
        /// </summary>
        /// <param name="text"> Текст для шифрования </param>
        /// <returns> Зашифрованный текст </returns>
        public string Encode(string text)
        {
            var cezar = new CezarCipher();
            return cezar.Encode(text, 13);
        }
        /// <summary>
        /// Метод для расшифрования
        /// </summary>
        /// <param name="text"> Текст для расшифрования </param>
        /// <returns> расшифрованный текст </returns>
        public string Decode(string text)
        {
            var cezar = new CezarCipher();
            return cezar.Decode(text, 13);
        }
    }

    public class CezarCipher 
    {
        private const string latin = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string rus = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        /// <summary>
        /// Метод проверяющий, является ли символ латинским
        /// </summary>
        /// <param name="letter"> Символ для проверки </param>
        /// <returns> Результат проверки </returns>
        private bool isLatin(char letter)
        {
            if (latin.IndexOf(char.ToUpper(letter)) == -1)
                return false;
            return true;
        }

        /// <summary>
        /// Метод для шифрования
        /// </summary>
        /// <param name="text"> Текст для шифрования </param>
        /// <param name="offset"> Смещение по алфавиту </param>
        /// <returns> Зашифрованый текст </returns>
        public string  Encode(string text, int offset)
        {
            var symbols = text.ToCharArray();
            for (var i = 0; i < symbols.Length; i++)
                if (char.IsLetter(symbols[i]))
                {
                    var isUppercase = char.IsUpper(symbols[i]);
                    if (isLatin(symbols[i]))
                        symbols[i] = latin[(latin.IndexOf(char.ToUpper(symbols[i])) + offset) % latin.Length];
                    else
                        symbols[i] = rus[(rus.IndexOf(char.ToUpper(symbols[i])) + offset) % rus.Length];
                    if (!isUppercase) symbols[i] = char.ToLower(symbols[i]);
                }

            return string.Join("", symbols);
        }

        /// <summary>
        /// Метод для расшифрования
        /// </summary>
        /// <param name="text"> Текст для расшифрования </param>
        /// <param name="offset"> Смещение по алфавиту </param>
        /// <returns> Расшифрованый текст </returns>
        public string Decode(string text, int offset)
        {
            var symbols = text.ToCharArray();
            for (var i = 0; i < symbols.Length; i++)
                if (char.IsLetter(symbols[i]))
                {
                    var isUppercase = char.IsUpper(symbols[i]);
                    if (isLatin(symbols[i]))
                        symbols[i] =
                            latin[(latin.Length + latin.IndexOf(char.ToUpper(symbols[i])) - offset) % latin.Length];
                    else
                        symbols[i] = rus[(rus.Length + rus.IndexOf(char.ToUpper(symbols[i])) - offset) % rus.Length];
                    if (!isUppercase) symbols[i] = char.ToLower(symbols[i]);
                }
            return string.Join("", symbols);
        }
    }
}