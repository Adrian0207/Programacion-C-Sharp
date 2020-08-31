using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num_Romanos
{

    class Program
    {

        public static void ConvertirARomano(int numero)// funcion para convertir a numeros romanos
        {
            if (numero <= 3500 && numero > 0)//Delimita los valores entre 1 y 3500
            {
                Console.Write(numero + "   ");

                while (numero >= 1000)// Escribe el simbolo de 1000 el numero de veces necesario
                {
                    Console.Write("m");
                    numero -= 1000;
                }
                while (numero >= 500 && numero < 1000)// Escribe el simbolo de 500 el numero de veces necesario siempre que sea menor a 1000 el numero
                {
                    if (numero / 100 == 9)// Codicion para que no se repita 3 veces un simbolo
                    {
                        Console.Write("cm");
                        numero -= 900;
                    }
                    else
                    {
                        Console.Write("d");
                        numero -= 500;
                    }
                }
                while (numero >= 100 && numero < 500)
                {
                    if (numero / 100 == 4)// Codicion para que no se repita 3 veces un simbolo
                    {
                        Console.Write("cd");
                        numero -= 400;
                    }
                    else
                    {
                        Console.Write("c");
                        numero -= 100;
                    }
                }
                while (numero >= 50 && numero < 100)
                {
                    if (numero / 10 == 9 )// Codicion para que no se repita 3 veces un simbolo
                    {
                        Console.Write("xc");
                        numero -= 90;
                    }
                    else
                    {
                        Console.Write("l");
                        numero -= 50;
                    }
                }
                while (numero >= 10 && numero < 50)
                {
                    if (numero / 10 == 4)// Codicion para que no se repita 3 veces un simbolo
                    {
                        Console.Write("xl");
                        numero -= 40;
                    }
                    else
                    {
                        Console.Write("x");
                        numero -= 10;
                    }
                }
                while (numero >= 5 && numero < 10)// Escribe el simbolo de 5 siempre que el numero no sea mayor a 10 
                {
                    if (numero / 1 == 9)// Codicion para que no se repita 3 veces un simbolo
                    {
                        Console.Write("ix");
                        numero -= 9;
                    }
                    else
                    {
                        Console.Write("v");
                        numero -= 5;
                    }
                }
                while (numero >= 1 && numero < 5)// Escribe el simbolo de 5 siempre que el numero no sea mayor a 5
                {
                    if (numero / 1 == 4)// Codicion para que no se repita 3 veces un simbolo
                    {
                        Console.Write("iv");
                        numero -= 4;
                    }
                    else
                    {
                        Console.Write("i");
                        numero -= 1;
                    }
                }
                Console.WriteLine();
            }
            else
                if (numero > 3500) Console.WriteLine(" No se puede convertir...Numero mayor a 3500");



        }
        public static bool EsEntero(string cad)// funcion para determinar si es un numero entero
        {
            bool resultado;
            int valor;
            try
            {
                valor = Convert.ToInt32(cad);
                resultado = true;
            }
            catch
            {
                resultado = false;
            }
            return resultado;
        }
        static void Main(string[] args)
        {
            string cad;
            int valor;
            do
            {
                do
                {
                    Console.Write("Ingrese el numero a convertir  ");
                    cad = Console.ReadLine();
                } while (!EsEntero(cad));// Compureba que lo ingresado por el usuario se un numero entero
                valor = Convert.ToInt32(cad);
                ConvertirARomano(valor);// se llama a la funcion y como parametros esta el valor a convertir
            } while (valor != 0);// termina si el numero es igual a 0

            Console.WriteLine("Gracias Por usar el programa. Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
