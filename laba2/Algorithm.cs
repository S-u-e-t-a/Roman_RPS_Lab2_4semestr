namespace laba2
{
    internal interface ICipher
    {
        string Encode(string target);

        string Decode(string target);
    }

    class Rot13Cipher : ICipher
    {
        public string Encode(string target)
        {
            var cezar = new CezarCipher();
            return cezar.Encode(target, 13);
        }

        public string Decode(string target)
        {
            var cezar = new CezarCipher();
            return cezar.Decode(target, 13);
        }

    }

    class CezarCipher 
    {
        private const string latin = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string rus = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        private bool isLatin(char letter)
        {
            if (latin.IndexOf(char.ToUpper(letter)) == -1)
                return false;
            return true;
        }

        public  string Encode(string target, int offset)
        {
            var symbols = target.ToCharArray();
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

        public string Decode(string target, int offset)
        {
            var symbols = target.ToCharArray();
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