using System;
using System.Collections.Generic;


namespace laba2
{
    internal static class Interface
    {
        private enum SaveChoice
        {
            Yes = 1,
            No
        }

        private enum MenuChoice
        {
            Encode = 1,
            Decode,
            Help,
            Exit
        }

        private enum CipherChoice
        {
            Cezar = 1,
            Rot13
        }

        private enum InputChoice
        {
            Keyboard = 1,
            File
        }

        /// <summary>
        /// Приветсвие/Помощь
        /// </summary>
        public static void Greatings()
        {
            Console.WriteLine("Данная программа шифрует/дешифрует введеную строку с помощью шифра Цезаря/ROT13. \n" +
                              "Сначала выберите что вы хотите сделать (зашифровать/расшифровать),\n" +
                              "далее выберите тип шифра и способ ввода.\n" +
                              "Автор: Хлебников Роман \n" +
                              "Группа: 494 \n" +
                              "Лабароторная работа №1 \n" +
                              "Вариант 15 (5)");
        }

        /// <summary>
        /// Основное меню программы
        /// </summary>
        public static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите вариант:");
            Console.WriteLine("1. Зашифровать текст");
            Console.WriteLine("2. Расшифровать текст");
            Console.WriteLine("3. Показать помощь");
            Console.WriteLine("4. Выход");
            var variant = InputInt();
            switch (variant)
            {
                case (int) MenuChoice.Encode:
                    CipherMenu((int)MenuChoice.Encode);
                    break;
                case (int) MenuChoice.Decode:
                    CipherMenu((int)MenuChoice.Decode);
                    break;
                case (int) MenuChoice.Help:
                    Greatings();
                    break;
                case (int) MenuChoice.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Вы ввели неправильное значение, введите число от 1 до 4");
                    break;
            }
        }

        /// <summary>
        /// Вспомогательно меню для кодирования 
        /// </summary>
        /// <param name="method">Варивнт работы шифрования</param>
        private static void CipherMenu(int method)
        {
            Console.WriteLine();
            Console.WriteLine("Выберите вариант:");
            Console.WriteLine("1. Шифр Цезаря");
            Console.WriteLine("2. ROT13");
            var variant = Interface.InputInt();
            var variantIsCorrect = false;
            string str = "";
            string transformedStr = "";
            while (!variantIsCorrect)
                switch (variant)
                {
                    case (int)CipherChoice.Rot13:
                        Rot13Cipher rot13 = new Rot13Cipher();
                        str = InputString();
                        if (method == (int)MenuChoice.Decode)
                        {
                            transformedStr = rot13.Decode(str);
                        }
                        else
                        {
                            transformedStr = rot13.Encode(str);
                        }
                        variantIsCorrect = true;
                        break;

                    case (int)CipherChoice.Cezar:
                        CezarCipher cezar = new CezarCipher();
                        str = InputString();
                        int offset = InputOffset();
                        if (method == (int)MenuChoice.Decode)
                        {
                            transformedStr = cezar.Decode(str,offset);
                        }
                        else
                        {
                            transformedStr = cezar.Encode(str,offset);
                        }
                        variantIsCorrect = true;
                        break;

                    default:
                        Console.WriteLine("Ввод некорректен, попробуйте снова:");
                        variant = Interface.InputInt();
                        break;
                }
            Console.WriteLine();

            PrintAnswer(str,transformedStr);
            SaveInitialData(str);


        }

        /// <summary>
        /// Функция для ввода строки
        /// </summary>
        /// <returns>Введенная строка</returns>
        private static string InputString()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите вариант:");
            Console.WriteLine("1. Ввести строку вручную");
            Console.WriteLine("2. Ввести строку из файла");
            var variant = InputInt();
            var variantIsCorrect = false;
            string str ="";
            while (!variantIsCorrect)
                switch (variant)
                {
                    case (int)InputChoice.Keyboard:
                        Console.WriteLine("Введите строку");
                        str = Console.ReadLine();
                        variantIsCorrect = true;
                        break;
                    case (int)InputChoice.File:
                        str = FileSystem.ReadInitialData();
                        variantIsCorrect = true;
                        break;
                    default:
                        Console.WriteLine("Ввод некорректен, попробуйте снова:");
                        variant = InputInt();
                        break;
                }

            return str;
        }

        /// <summary>
        /// Записывает или не записывает ответ в зависимости от выбора пользователя
        /// </summary>
        /// <param name="initial"> Изначальный текст </param>
        /// <param name="transformed"> Измененный текст </param>
        private static void PrintAnswer(string initial, string transformed)
        {
            Console.WriteLine();
            var answer = MakeAnswer(initial,transformed);
            Console.WriteLine(answer);
            Console.WriteLine();
            Console.WriteLine("Записать ответ в файл?");
            Console.WriteLine("1 - Да | 2 - Нет");
            var variant = InputInt();
            var isChoiceCorrect = false;
            while (!isChoiceCorrect)
                if (variant >= (int) SaveChoice.Yes && variant <= (int) SaveChoice.No)
                {
                    isChoiceCorrect = true;
                }
                else
                {
                    Console.WriteLine("Ввод некорректен, попробуйте снова:");
                    variant = InputInt();
                }

            if (variant == (int) SaveChoice.Yes)
            {
                FileSystem.OpenFileForWrite(answer);
            }
        }

        /// <summary>
        /// Записывает или не записывает исходные данные в зависимости от выбора пользователя
        /// </summary>
        /// <param name="initial">Изначальный текст</param>
        private static void SaveInitialData(string initial)
        {
            Console.WriteLine("Записать начальные данные в файл?");
            Console.WriteLine("1 - Да | 2 - Нет");
            var variant = InputInt();
            var isChoiceCorrect = false;
            while (!isChoiceCorrect)
                if (variant >= (int) SaveChoice.Yes && variant <= (int) SaveChoice.No)
                {
                    isChoiceCorrect = true;
                }
                else
                {
                    Console.WriteLine("Ввод некорректен, попробуйте снова:");
                    variant = InputInt();
                }

            if (variant == (int) SaveChoice.Yes)
            {
                FileSystem.OpenFileForWrite(initial);
            }
        }

        /// <summary>
        /// Создает строку с ответом для последующего вывода/сохранения
        /// </summary>
        /// <param name="initial">Изначальный текст</param>
        /// <param name="transformed">Измененный текст</param>
        /// <returns></returns>
        private static string MakeAnswer(string initial, string transformed)
        {
            Console.WriteLine();
            var answer = "Введенная строка: \n" +
                         initial +
                         "\nИзмененная строка: \n" +
                         transformed;
            return answer;
        }

        /// <summary>
        /// Функция для корректного ввода числа типа int
        /// </summary>
        /// <returns>Число int</returns>
        public static int InputInt()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number)) Console.WriteLine("Ошибка ввода! Введите число");

            return number;
        }

        /// <summary>
        /// Функция для корректного ввода смещения при работе с шифром Цезаря
        /// </summary>
        /// <returns>Количество букв алфавита для смещения</returns>
        private static int InputOffset()
        {
            Console.WriteLine("Введите количество букв для смещения");
            var isNumberCorrect = false;
            var size = InputInt();
            while (!isNumberCorrect)
                if (size <= 0)
                {
                    Console.WriteLine("Смещение в шифре цезаря должно быть больше 0. Попробуйте еще раз");
                    size = InputInt();
                }
                else
                {
                    isNumberCorrect = true;
                }

            return size;
        }

    }
}