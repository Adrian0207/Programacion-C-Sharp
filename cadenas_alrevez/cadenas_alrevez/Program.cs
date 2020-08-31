using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cadenas_alrevez
{
    class Program
    {
        static void Main(string[] args)
        {
            string cad;
            int i;
            Console.Write("Ingrese la cadena: ");
            cad = Console.ReadLine();

            for (i = cad.Length; i > 0; i--)
                Console.Write(cad[i-1]);

            Console.ReadKey();
        }
    }
}
