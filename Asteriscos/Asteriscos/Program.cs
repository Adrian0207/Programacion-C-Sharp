using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteriscos
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;//contadores
            int poi = 0, pfi = 80, poj = 0, pfj = 24;//posiciones quemadas de la consola
            int tiempo = 5; // pausa 
            Console.SetCursorPosition(35, 12);
            Console.Write("HOLA TODOSSS");
            while (poi < pfj)//para que no cree un bucle infinito
            {

                for (i = poi; i < pfi; i++)
                {
                    Console.SetCursorPosition(i, poj);//inicia en la posicion en coordenadas x,y
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("*");
                    System.Threading.Thread.Sleep(tiempo);//pausa el programa
                }
                for (j = poj; j < pfj; j++)
                {
                    Console.SetCursorPosition(pfi - 1, j);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("*");
                    System.Threading.Thread.Sleep(tiempo);
                }
                for (i = pfi - 1; i > poi; i--)
                {
                    Console.SetCursorPosition(i, pfj - 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("*");
                    System.Threading.Thread.Sleep(tiempo);
                }
                for (j = pfj - 1; j > poi; j--)
                {
                    Console.SetCursorPosition(poi, j);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("*");
                    System.Threading.Thread.Sleep(tiempo);
                }
                poi++;//aumenta y disminuyen para que se vea en efecto serpiente 
                poj++;
                pfi--;
                pfj--;

            }
            Console.ReadKey();
        }
    }
}
