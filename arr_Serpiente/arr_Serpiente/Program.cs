using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arr_Serpiente
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr;
            int fil, col;
            int i=0, j, cont=1;

            Console.Write("Ingrese el numero de filas...");
            fil = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el numero de columnas...");
            col = Convert.ToInt32(Console.ReadLine());

            arr = new int[fil, col];
            for (i = 0; i < fil; i++)
                if (i % 2 == 0)
                    for (j = 0; j < col; j++)
                        arr[i, j] = cont++;
                else
                    for (j = col-1; j >= 0; j--)
                        arr[i, j] = cont++;

            for (i = 0; i < fil; i++)
            {
                Console.Write("|");
                for (j = 0; j < col; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine("|");
            }
                Console.Write("\ARIGATO");
                Console.ReadKey();
        }
    }
}
