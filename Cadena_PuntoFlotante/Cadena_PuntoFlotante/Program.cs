using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cadena_PuntoFlotante
{
    class Program
    {
        static void Main(string[] args)
        {
            string cad, aux="";
            char[] car;
            int i;
            int punt = 0, raya = 0, letra = 0;
            
            Console.Write("Ingrese una cadena para verificar si es número de punto flotante: ");
            cad = Console.ReadLine();

            car=new char[cad.Length];
            for (i = 0; i < cad.Length; i++)
            {
                car[i] = cad[i];
                aux+=cad[i];
                if (cad[i] == '.')
                    punt++;
                if (cad[i] == '-')
                    raya++;
                if (!(cad[i] == '0' || cad[i] == '1' || cad[i] == '2' || cad[i] == '3' || cad[i] == '4' || cad[i] == '5' || cad[i] == '6' || cad[i] == '7' || cad[i] == '8' || cad[i] == '9' || cad[i] == '.' || cad[i] == '-'))
                {
                    letra++;
                    break;
                }
            }
            if (aux.EndsWith(".") || aux.EndsWith("-"))
                Console.Write("Su cadena NO es un numero valido");
            else if (punt > 1 || raya > 1)
                Console.Write("Su cadena NO es un numero valido");
            else if (letra != 0)
                Console.Write("Su cadena NO es un numero valido");
            else
                Console.Write("Su cadena SI es un numero valido");
            Console.ReadKey();
        }
    }
}
