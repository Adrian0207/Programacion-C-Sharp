using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arr_Tornado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t TORNADO ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            int[] postes;
            int np, p;
            int i, j, cp = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Ingrese la cantidad de postes que tiene la cerca?...");//ingreso de datos
            Console.ForegroundColor = ConsoleColor.Gray;
            np = Convert.ToInt32(Console.ReadLine());
            postes = new int[np];//se genera el arrglo para los postes
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Ingrese la situacion actual de cada poste mediante 0 (si el poste se ha caido o se ha roto) y 1 (Si el poste sigue en pie) ");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (i = 0; i < np; i++)//llena el arreglo
            {
                do
                {
                    p = Convert.ToInt32(Console.ReadLine());
                } while (p != 0 && p != 1);
                postes[i] = p;//llena el arreglo
            }
            for (i = 0, j = i + 1; i < postes.Length - 1; )//recorre el arreglo
            {
                if (j < postes.Length)
                {
                    if (postes[i] == 0)
                    {
                        if (postes[i] == postes[j])//si son iguales
                        {
                            cp++;//contador aumenta
                            i = i + 2;//aumenta en 2
                            j = i + 1;//aumenta 3
                        }
                        else
                        {
                            i++;
                            j = i + 1;
                        }
                    }
                    else
                    {
                        i++;
                        j = i + 1;
                    }
                }
            }
            if (postes[0] != postes[1])
            {
                if (postes[0] == postes[postes.Length - 1])
                    cp++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Se necesitan {0} postes de madera para la cerca", cp);
            Console.ReadKey();
        }
    }
}
