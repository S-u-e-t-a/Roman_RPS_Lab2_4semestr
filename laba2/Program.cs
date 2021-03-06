using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        static void Main()
        {
            Interface.Greatings();
            while (true)
            { 
                Interface.MainMenu();
            }

        }
    }
}
