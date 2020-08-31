using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arr_MatrizTranspuesta
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matz;
            int fil, col;
            int i, j;

            Console.Write("Ingrese el número de filas...");
            fil = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el número de columnas...");
            col = Convert.ToInt32(Console.ReadLine());

            matz = new int[fil, col];
            for (i = 0; i < fil; i++)
                for (j = 0; j < col; j++)
                {
                    Console.Write("Dato [{0},{1}]...", (i + 1), (j + 1));
                    matz[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            Console.Clear();
            Console.WriteLine("\t\tMATRIZ ORIGINAL");
            for (i = 0; i < fil; i++)
            {
                Console.Write("|");
                for (j = 0; j < col; j++)
                    Console.Write(matz[i, j] + "\t");
                Console.WriteLine("|");
            }

            Console.Write("\n\n");
            Console.WriteLine("\t\tMATRIZ TRANSPUESTA");
            for (i = 0; i < col; i++)
            {
                Console.Write("|");
                for (j = 0; j < fil; j++)
                        Console.Write(matz[j, i] + "\t");
                Console.WriteLine("|");
            }


            Console.ReadKey();
        }
    }
}
