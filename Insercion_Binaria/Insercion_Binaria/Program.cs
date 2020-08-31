using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insercion_Binaria
{
    class Program
    {
        static void Main(string[] args)
        {
            string cad;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese los números separados por un espacios");
                cad = Console.ReadLine();
                cad = LimpiarCadena(cad.Trim());
            } while (!TodosNumeros(cad));
            Console.WriteLine();
            List<int> arr = Arreglo(cad); // lista de numeros
            Insercion(arr.ToArray());
            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey();
        }
        static void Insercion(int[] arr)
        {
            Ver(arr);
            int[] arx = arr;
            int hasta, mitad, temp;//mitad temporal donde se guardara el intercambio
            for (int i = arr.Length - 2, desde = arx.Length - 1; i >= 0 && desde >= 0; i--, desde--)
            {              
                hasta = arr.Length - 1;
                temp = arx[i];
                while (desde <= hasta)
                {
                    mitad = (desde + hasta) / 2;//
                    if (temp <= arx[mitad])
                        hasta = mitad - 1;
                    else
                        desde = mitad + 1;
                }
                desde--;
                for (int j = i + 1; j <= desde; j++)
                    arx[j - 1] = arx[j];
                arx[desde] = temp;
                Ver(arx);
            }
        }
        static void Ver(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        static List<int> Arreglo(string cad)
        {
            int valor;
            string[] arrstring = cad.Split(' ');
            List<int> arr = new List<int>();
            for (int i = 0; i < arrstring.Length; i++)
                if (arrstring[i] != "")
                {
                    valor = Convert.ToInt32(arrstring[i]);
                    arr.Add(valor);
                }
            return arr;//duevuelve los numeros ya en la lista
        }
        static string LimpiarCadena(string cad)//limpia la cadena de signos no deseados
        {
            string cadena = "";
            char[] separadores = { ' ', ',', '.', '+', '-', ';', ':', '-' };
            string[] arrstring = cad.Split(separadores);
            cadena = string.Join(" ", arrstring);
            return cad;
        }
        static bool TodosNumeros(string cad)
        {
            bool verificar = true;
            for (int i = 0; i < cad.Length; i++)
                if (cad.Substring(i, 1) != " ")
                {
                    verificar = EsEntero(cad.Substring(i, 1));//verifica si en la cadena existe solo numero
                    if (!verificar)//si existen cualquier otro caracter que no sea un numero entero devolvera un false
                        break;
                }
            return verificar;
        }
        static bool EsEntero(string cad)//verifica si es entero
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
    }
}




