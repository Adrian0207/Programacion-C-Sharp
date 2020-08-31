using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshall
{
    class Program
    {
        /// Método para encontrar el camino más corto entre todos los pares de vértices
        /// usando el algoritmo de Floyd Warshall
        /// Por Jorge Alarcón. Año 2010
        public class Floyd
        {
            //Recibe como argumento una matriz de adyacencia y devuelve como resultado
            //una matriz conteniendo los costes mínimos entre cada par de vértices
            static int[,] AlgoritmoFloyd(int[,] Ady)
            {
                int i, j, k;
                for (i = 0; i < Ady.GetLength(0); i++)
                    for (j = 0; j < Ady.GetLength(0); j++)
                        for (k = 0; k < Ady.GetLength(1); k++)
                        {
                            int a = Ady[j, i];
                            int b = Ady[i, k];
                            int c = a + b;
                            int x = Ady[j, k];
                            if (c < x)
                                Ady[j, k] = Ady[j, i] + Ady[i, k];
                        }
                return Ady;
            }
            
            static void Main(string[] args)
            {
                int inf = 9999999;
                //int[,] Matriz = new int[,] {
                //    {0,1,inf,1,inf,inf,inf,inf,inf,inf,inf,inf},//0

                //    {1,0,1,inf,1,inf,inf,inf,inf,inf,inf,inf},//1

                //    {inf,1,0,inf,inf,1,inf,inf,inf,inf,inf,inf},//2

                //    {1,inf,inf,0,1,inf,1,inf,-3,inf,inf,inf},//3

                //    {inf,1,inf,1,0,1,inf,1,inf,inf,inf,inf},//4

                //    {inf,inf,1,inf,1,0,inf,inf,1,inf,inf,inf},//5

                //    {inf,inf,inf,1,inf,inf,0,1,inf,1,inf,inf},//6

                //    {inf,inf,inf,inf,1,inf,1,0,1,inf,1,inf},//7

                //    {inf,inf,inf,inf,inf,1,inf,1,0,inf,inf,1},//8

                //    {inf,inf,inf,inf,inf,inf,1,inf,inf,0,1,inf},//9

                //    {inf,inf,inf,inf,inf,inf,inf,1,inf,1,0,1},//10

                //    {inf,inf,inf,inf,inf,inf,inf,inf,1,inf,1,0},//11
                    

                //};
                int[,] Matriz = new int[,] { 
                    { 0, 1, 1, inf },
                    { 1, 0, 0, 1 },
                    { 1, 0, 0, 1 },
                    { inf, 1, 1, 0 },
                
                };
                Matriz = AlgoritmoFloyd(Matriz);
                Console.ReadKey();
            }	
        }
    }
}
