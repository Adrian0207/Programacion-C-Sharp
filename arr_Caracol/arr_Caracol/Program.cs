using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arr_Caracol
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr;
            int fil, col;
            int fi, ff, ci, cf;// fila inicial y final, columna inicial y final
            int i, j, k=0, cont = 1;

            Console.Write("Cuántas filas?...");
            fil = Convert.ToInt32(Console.ReadLine());
            Console.Write("Cuántas columnas?...");
            col = Convert.ToInt32(Console.ReadLine());
            
            fi = 0;
            ci = 0;
            ff = fil - 1;
            cf = col - 1;
            arr = new int[fil, col];
            int num = arr.Length;
            do
            {
                for (i = ci; i <= cf; i++)
                {
                    if (arr.Length == k)
                        break;
                    arr[fi, i] = cont++;
                    k++;
                }
                fi++;
                for (j = fi; j <= ff; j++)
                {
                    if (arr.Length == k)
                        break;
                    arr[j, cf] = cont++;
                    k++;    
                }
                cf--;
                
                for (i = cf; i >= ci; i--)
                {
                    if (arr.Length == k)
                        break;
                    arr[ff, i] = cont++;
                    k++;
                }
                ff--;
                for (j = ff; j >= fi; j--)
                {
                    if (arr.Length == k)
                        break;
                    arr[j, ci] = cont++;
                    k++;
                }
                ci++;
            } while (arr.Length > k);

            for (i = 0; i < fil; i++)
            {
                Console.Write("|");    
                for (j = 0; j < col; j++)
                    Console.Write(" {0}\t",arr[i, j]);
                Console.WriteLine("|");
            }

            Console.WriteLine("\nARIGATO");
            Console.ReadLine();
        }
    }
}
