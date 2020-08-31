using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cadena_Puntuada
{
    class Program
    {
        static void Main(string[] args)
        {
            string cad = "Esta.es,mi cadena de;caracteres de,...Prueba";
            string cad1;
            string[] palabra;
            char[] separadores = {' ',',' ,'.',';'};
            palabra = cad.Split(separadores);
            cad1 = String.Join(" ", palabra);
            Console.Write(cad1);
            Console.ReadKey();
        }
    }
}
