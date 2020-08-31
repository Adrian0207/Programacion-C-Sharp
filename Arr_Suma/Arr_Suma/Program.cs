using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arr_Suma
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A, B, C;
            int n = 10;
            int i;
            A = new int[n];
            B = new int[n];
            C = new int[n];
            for (i = 0; i < n; i++)
            {
                Console.Write("Ingrese el valor en el vector A en la posicion {0}...", i + 1);
                A[i] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingrese el valor en el vector B en la posicion {0}...", i + 1);
                B[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
            Console.WriteLine("A \tB \tC ");
            for (i = 0; i < n; i++)
            {
                C[i] = A[i] + B[i];
                Console.WriteLine(A[i] + " \t" + B[i] + " \t" + C[i]);
            }

            Console.ReadKey();
        }
    }
}
