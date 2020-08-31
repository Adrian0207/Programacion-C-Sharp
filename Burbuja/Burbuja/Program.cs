using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burbuja
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
            Ordenamiento(arr.ToArray());
            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey();

        }
        static void Ordenamiento(int[] arr)
        {
            Ver(arr);
            int aux = 0;
            do
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                        if (arr[i] > arr[j])
                        {
                            aux = arr[i];
                            arr[i] = arr[j];
                            arr[j] = aux;

                        }
                    Ver(arr);
                } 
            } while (arr[arr.Length - 1] <= arr[arr.Length - 2]);
                
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
