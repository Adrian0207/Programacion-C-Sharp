using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arr_ProductoX
{
    class Program
    {
        static void Main(string[] args)
        {
            int pci, pcj, pcj1, pck;//producto cruz i,j,k.
            int[] v1;
            int[] v2;
            int v1i, v1j, v1k;
            int v2i, v2j, v2k;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nVector 1");
            Console.Write("Ingrese el término en i...");
            v1i = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el término en j...");
            v1j = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el término en k...");
            v1k = Convert.ToInt32(Console.ReadLine());
            v1 = new int[] { v1i, v1j, v1k };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nVector 2");
            Console.Write("Ingrese el término en i...");
            v2i = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el término en j...");
            v2j = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el término en k...");
            v2k = Convert.ToInt32(Console.ReadLine());
            v2 = new int[] { v2i, v2j, v2k };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nResultados: ");

            // metodo de sarrus
            pci = (v1[1] * v2[2]) - (v2[1] * v1[2]);
            pcj = -((v1[0] * v2[2]) - (v2[0] * v1[2]));
            pcj1 = (v1[0] * v2[2]) - (v2[0] * v1[2]);// utilizo una variable mas para tener el valor positivo de j
            pck = (v1[0] * v2[1]) - (v2[0] * v1[1]);

            if (pcj < 0 && pck >= 0)
                Console.WriteLine("Vector1xVector2: {0}i {1}j +{2}k", pci, pcj, pck);
            else
                Console.WriteLine("Vector1xVector2: {0}i +{1}j {2}k", pci, pcj, pck);
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();  
        }
    }
}
