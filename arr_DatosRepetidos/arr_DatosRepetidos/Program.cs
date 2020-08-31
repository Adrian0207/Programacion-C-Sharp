using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arr_DatosRepetidos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1, arr2, result;//arreglos 
            int tam;//datos de los arreglos
            int i, j, k, cont;//contadores
            string op;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("B I E N V E N I D O");
            
            do
            {
                k = 0;
                cont = 0;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Primer grupo, cuántos datos?...");
                Console.ForegroundColor = ConsoleColor.Green;
                tam = Convert.ToInt32(Console.ReadLine());
                arr1 = new int[tam];//el primer arreglo es igual al tamaño que el usuario ingresa
                for (i = 0; i < arr1.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Dato {0}...", (i + 1));// se ingresa los datos en el arreglo
                    Console.ForegroundColor = ConsoleColor.Green;
                    arr1[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Segundo grupo, cuántos datos?...");
                Console.ForegroundColor = ConsoleColor.Green;
                tam = Convert.ToInt32(Console.ReadLine());
                arr2 = new int[tam];//el segundo arreglo es igual al tamaño que el usuario ingresa
                for (i = 0; i < arr2.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Dato {0}...", (i + 1));// se ingresa los datos en el arreglo
                    Console.ForegroundColor = ConsoleColor.Green;
                    arr2[i] = Convert.ToInt32(Console.ReadLine());
                }
                result = new int[arr2.Length];//arreglo resultado sera igual a la longitud del arreglo 2
                for (i = 0; i < arr1.Length; i++) // recorre el primer arreglo 
                    for (j = 0; j < arr2.Length; j++) // recorre el segundo arreglo
                        if (arr1[i] == arr2[j])//si hay similitudes entre los dos
                            if (result.Contains(arr2[j]))// buscamos si el resultado ya contiene ese dato
                            { }// y si lo tiene no rellena nada para no sacar otra vez el mismo número
                            else
                            {
                                result[k] = arr1[i];//almacena los nuevos datos en el arreglo resultado
                                k++;// el contador k aumente
                                cont++; //el contador de datos que se repite aumente
                            }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Los números que se repiten son: ");
                for (k = 0; k < cont; k++)// for para que sacar a pantalla el resultado
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(result[k]);
                    if (k < cont - 1)// condición para la coma
                        Console.Write(",");
                }
                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\nDesea ingresar otro número?(s/n)...");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    op = Console.ReadLine();
                } while (op != "s" && op != "S" && op != "n" && op != "N");

            } while (op == "s" || op == "S");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nGracias por usar este programa\nPresione una tecla para salir");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Gray;


        }
    }
}
