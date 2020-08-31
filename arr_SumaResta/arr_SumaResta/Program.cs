using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace arr_SumaResta
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr1, arr2, resp1, resp2;
            int fil,col;
            int i, j;
            string op; // opcion de repetir el programa
            do
            {
                Console.Clear();
                Console.Write("Cuántas filas?...");
                fil = Convert.ToInt32(Console.ReadLine());
                Console.Write("Cuántas columnas?...");
                col = Convert.ToInt32(Console.ReadLine());

                arr1 = new int[fil, col];
                arr2 = new int[fil, col];
                resp1 = new int[fil, col];
                resp2 = new int[fil, col];
                Console.Clear();
                Console.WriteLine("Ingrese los valores de la primera matriz");
                for (i = 0; i < fil; i++)
                    for(j = 0;j < col; j++)
                {
                    Console.Write("Dato [{0},{1}]...",(i+1),(j+1));
                    arr1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.Clear();
                Console.WriteLine("Ingrese los valores de la segunda matriz");
                for (i = 0; i < fil; i++)
                    for (j = 0; j < col; j++)
                    {
                        Console.Write("Dato [{0},{1}]...", (i + 1), (j + 1));
                        arr2[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                Console.Clear();
                //suma
                for (i = 0; i < fil; i++)
                    for (j = 0; j < col; j++)
                        resp1[i, j] = arr1[i, j] + arr2[i, j];
                //resta
                for (i = 0; i < fil; i++)
                    for (j = 0; j < col; j++)
                        resp2[i, j] = arr1[i, j] - arr2[i, j];
                Console.Write("\tSUMA\n");
                for (i = 0; i < fil; i++)
                {
                    Console.Write("|");
                    for (j = 0; j < col; j++)
                        Console.Write(arr1[i, j] + "\t");
                    Console.WriteLine("|");
                }
                Console.Write("\t+\n");
                for (i = 0; i < fil; i++)
                {
                    Console.Write("|");
                    for (j = 0; j < col; j++)
                        Console.Write(arr2[i, j] + "\t");
                    Console.WriteLine("|");
                }
                Console.Write("\t=\n");
                for (i = 0; i < fil; i++)
                {
                    Console.Write("|");
                    for (j = 0; j < col; j++)
                        Console.Write(resp1[i, j] + "\t");
                    Console.WriteLine("|");
                }
                Console.Write("\tRESTA\n");
                for (i = 0; i < fil; i++)
                {
                    Console.Write("|");
                    for (j = 0; j < col; j++)
                        Console.Write(arr1[i, j] + "\t");
                    Console.WriteLine("|");
                }
                Console.Write("\t-\n");
                for (i = 0; i < fil; i++)
                {
                    Console.Write("|");
                    for (j = 0; j < col; j++)
                        Console.Write(arr2[i, j] + "\t");
                    Console.WriteLine("|");
                }
                Console.Write("\t=\n");
                for (i = 0; i < fil; i++)
                {
                    Console.Write("|");
                    for (j = 0; j < col; j++)
                        Console.Write(resp2[i, j] + "\t");
                    Console.WriteLine("|");
                }
                Thread.Sleep(10000);//pausa el programa
                Console.Clear();
                do // mientras el usuario no correcta...
                {
                    Console.Write("\nDesea ingresar otro número?(s/n)...");
                    op = Console.ReadLine();
                } while (op != "s" && op != "S" && op != "n" && op != "N"); // se le preguntara lo mismo hasta que lo ingrese la opcion valida 

            } while (op == "s" || op == "S");
            Console.WriteLine("\nGracias por usar este programa");
            Console.WriteLine("<Presione tecla para continuar");
            Console.ReadKey();
            
        }
    }
}
