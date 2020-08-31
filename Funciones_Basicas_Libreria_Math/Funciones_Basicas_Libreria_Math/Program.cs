using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Funciones_Basicas_Libreria_Math
{
    class Program
    {
        static void Main(string[] args)
        {
            double num;

            Console.Write("Ingrese un número... ");
            num = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Valor absoluto: " + Math.Abs(num)); 
            Console.WriteLine("Potencia: " + Math.Pow(num,2));// (numero,petencia)
            Console.WriteLine("Raiz Cuadrada: " + Math.Sqrt(num));
            Console.WriteLine("Seno: " + Math.Sin(num*Math.PI/180));
            Console.WriteLine("Coseno: " + Math.Cos(num*Math.PI/180));
            Console.WriteLine("Número Máximo: " + Math.Max(num,50));
            Console.WriteLine("Número Mínimo: " + Math.Min(num,50));
            Console.WriteLine("Parte Entera: " + Math.Truncate(num));
            Console.WriteLine("Redondeo: " + Math.Round(num));
            Console.Write("Pulse una tecla para salir");
            Console.ReadKey();




            
            
           

        }
    }
}
