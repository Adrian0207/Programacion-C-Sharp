using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadenasAlternas
{
    class Program
    {
        static void Main(string[] args)
        {
            string cad="Mao LA tina na MiNA", aux=null;
            int i;
            char letra;
            Console.Write("Ingrese su cadena: ");
            //cad = Console.ReadLine();
            //cad = cad.Trim().ToUpper();
            for (i = 0; i < cad.Length; i++)
            {
                letra = cad[i];
                if (letra == Convert.ToChar(" "))
                {
                    aux += letra;
                    letra = cad[i];
                    if (letra == ' ' && i % 2 == 0)
                    {
                        cad = cad.ToUpper();
                        continue;
                    }
                    else
                    {
                        cad = cad.ToUpper();
                        continue;
                    }
                }
                if (i % 2 == 0)
                {
                    aux += letra;
                    cad = cad.ToLower();                                        
                }
                else 
                {
                    aux += letra;
                    cad = cad.ToUpper();
                }
            
            }

            Console.Write("\n" + aux);
            Console.Write("\nGracias por usar este programa\nPresione tecla para salir");
                           
            Console.ReadKey();

        }
    }
}
