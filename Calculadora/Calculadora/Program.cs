using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculadora
{
    class Program
    {
        static double Suma (double x, double y)
        {
            double resp;
            resp = x + y;
            return resp;
        }
        static double Resta(double x, double y)
        {
            double resp;
            resp = x - y;
            return resp;
        }
        static double Multiplicacion(double x, double y)
        {
            double resp;
            resp = x * y;
            return resp;
        }
        static double Division(double x, double y)
        {
            double resp;
            resp = x / y;
            return resp;
        }
        static int Leer(string literal)
        {
            int valor;
            string cad;
            do
            {
              Console.Write("Ingrese su valor #{0}...", literal);
              cad = Console.ReadLine();
            } while (!EsNumero(cad));
            valor = Convert.ToInt32(cad);
            return valor;
            
        }
        static bool EsNumero(string num)
        {
            bool resultado;
            double valor;
            try
            {
                valor = Convert.ToDouble(num);
                resultado = true;
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }
        static void Main(string[] args)
        {
            double a = 0, b = 0, ans = 0;
            string op1, cad;
            bool repe = true;
            do
            {
                do
                {
                    Console.WriteLine("B I E N V E N I D O");
                    Console.Write("Elija la operacion que desea realizar mediante los literales:\n1)SUMA\n2)RESTA\n3)MULTIPLICACION\n4)DIVISION\n...");
                    op1 = Console.ReadLine();
                    Console.Clear();
                } while (op1 != "1" && op1 != "2" && op1 != "3" && op1 != "4");

                Console.Write("Usted a elejido: ");
                if (op1 == "1")
                    Console.Write("SUMAR");
                else if (op1 == "2")
                    Console.Write("RESTAR");
                else if (op1 == "3")
                    Console.Write("MULTIPLICAR");
                else if (op1 == "4")
                    Console.Write("DIVIDIR");
                Console.WriteLine();
                if (repe)
                {
                    Console.WriteLine("INGRESE LOS VALORES:");
                    cad = Convert.ToString(Leer("1"));
                    a = Convert.ToInt32(cad);
                    cad = Convert.ToString(Leer("2"));
                    b = Convert.ToInt32(cad);
                }
                else
                {
                    Console.WriteLine("El valor #1 es: " + ans);
                    cad = Convert.ToString(Leer("2"));
                    b = Convert.ToInt32(cad);
                }
                switch (op1)
                {
                    case "1":
                        {
                            Console.WriteLine("La respuesta de {0} + {1} = {2}", a, b, Suma(a, b));
                            ans = Suma(a, b);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("La respuesta de {0} - {1} = {2}", a, b, Resta(a, b));
                            ans = Resta(a, b);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("La respuesta de {0} * {1} = {2}", a, b, Multiplicacion(a, b));
                            ans = Multiplicacion(a, b);
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("La respuesta de {0} / {1} = {2}", a, b, Division(a, b));
                            ans = Division(a, b);
                            break;
                        }
                    default:
                        break;
                }
                do
                {
                    Console.WriteLine("Quiere realizar otra acción:\n1)Realizar operaciones con la respuesta anterior\n2)Nueva Operacion\n3)Salir\n...");
                    op1 = Console.ReadLine();
                    Console.Clear();
                } while (op1 != "1" && op1 != "2" && op1 != "3");
                if (op1=="1")
                {
                    a = ans;
                    repe = false;   
                }
                else
                    repe = true;
            } while (op1 == "1" || op1 == "2");
            
            

            Console.Write("\nARIGATO");
            Console.ReadKey();

        }
    }
}
