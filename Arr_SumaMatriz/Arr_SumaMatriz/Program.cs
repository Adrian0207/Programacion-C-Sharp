using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arr_SumaMatriz
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr;
            int[] resp;
            int tam = 4;
            int i,j;

            arr = new int[tam, tam];
            resp = new int[tam];
            for (i = 0; i < tam ; i++)
                 for (j = 0; j < tam; j++)
			    {
                    Console.Write("Ingrese un numero para la posicion [{0},{1}]...", i + 1, j + 1);
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                    resp[i] += arr[i, j];
			    }
            for (i = 0; i < tam; i++)
            {
                for (j = 0; j < tam; j++)
                {
                    Console.Write(arr[i, j] + "\t");                   
                }
                Console.Write("= " + resp[i]);
                Console.WriteLine();
                
            }

                Console.ReadKey();
        }
    }
}
