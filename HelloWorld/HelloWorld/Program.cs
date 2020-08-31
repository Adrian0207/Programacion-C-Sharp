using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
//Luis Vacacela, Adrián Oliva, Sebastián Villacis, Christian Sánchez.
//NIVEL: 3
//AÑO: 2017
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList contenedor = new ArrayList();
            string cad;
            do
            {
                do
                {
                    cad = Console.ReadLine();
                } while (!EsEntero(cad));
                if (Convert.ToInt32(cad) > 0 && Convert.ToInt32(cad) < 100000)
                    contenedor.Add(Convert.ToInt32(cad));
                else if(Convert.ToInt32(cad) > 100000)
                    Console.WriteLine("--->Es mayor a 100000");
                else if (Convert.ToInt32(cad) == 0)
                    Console.WriteLine("--->No puede ser 0");
            } while (Convert.ToInt32(cad) >= 0);            
            Console.WriteLine();
            MinimumPaste(contenedor);
            Console.Read();        
        }
        static void MinimumPaste(ArrayList arr)
        {
            int k = 0;
            foreach (Object item in arr)
            {
                int i = -1;
                while (true)
                    if ((int)item <= Math.Pow(2, ++i))
                    {
                        Console.WriteLine("Caso {0}: {1}", ++k, i);
                        break;
                    }
            }
        }
        static bool EsEntero(string cad)
        {
            bool resultado;
            int valor;
            try
            {
                valor = Convert.ToInt32(cad);
                resultado = true;
            }
            catch
            {
                Console.WriteLine("--->No es un entero");
                resultado = false;
            }
            return resultado;
        }
    }
}
