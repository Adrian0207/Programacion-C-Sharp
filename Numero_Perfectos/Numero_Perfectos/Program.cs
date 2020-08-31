using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Numero_Perfectos
{
    class Program
    {
        static void Main(string[] args)
        {
            long num;
            long i,j,k=0;
  
            Console.Write("Hasta que numero desea evaluar...");
            num = Convert.ToInt64(Console.ReadLine());

            Console.Write("\nLos siguientes numeros son perfectos: ");
            for (i = 1; i <= 10000000000000000; i++)
            {
                long suma = 0;
                for (j = 1; j < i; j++)
                    if (i % j == 0)
                        suma = suma + j;
                if (suma == i)
                {
                    Console.Write(i + " ");
                    k++;
                }
                if (k == num)
                    break;
            }
            Console.Write("\nARIGATO");
            Console.ReadKey();      

        }
    }
}
