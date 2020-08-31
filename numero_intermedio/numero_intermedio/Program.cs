using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace numero_intermedio
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.Write("Ingrese su primer valor... ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese su segundo valor... ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese su tercer valor... ");
            c = Convert.ToInt32(Console.ReadLine());

            if (a > b)
                if (a < c)
                    Console.Write("\nEl número intermedio es: " + a);
                else
                    if (b < c)
                        Console.Write("\nEl número intermedio es: " + c);
                    else
                        Console.Write("\nEl número intermedio es: " + b);
            else
                if (b < c)
                    Console.Write("\nEl número intermedio es: " + b);
                else
                    if (a < c)
                        Console.Write("\nEl número intermedio es: " + c);
                    else
                        Console.Write("\nEl número intermedio es: " + a);


            Console.Write("\nARIGATO");
            Console.ReadKey();

        }
    }
}
