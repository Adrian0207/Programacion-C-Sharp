using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shell
{
    class Program
    {
        static void Main(string[] args)
        {
            //string cad;
            //do
            //{
            //    Console.Clear();
            //    Console.WriteLine("Ingrese los números separados por un espacios");
            //    cad = Console.ReadLine();
            //    cad = LimpiarCadena(cad.Trim());
            //} while (!TodosNumeros(cad));
            //Console.WriteLine();
            //List<int> arr = Arreglo(cad); // lista de numeros
            //Ordenar(arr.ToArray());
            int[] arr = new int[] { 9, 4, 2, 6, 5, 3, 1, 7, 5, 3, 1, 6, 7, 5 };//arreglo prueba
            Ordenar(arr);
            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey();
            

        }
        static void Ordenar(int[] arr)
        {

            int gap = (arr.Length - 1 + 0) / 2;
            bool NoGap = false;
            do
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                    if (i - gap <= -1)
                    {
                        NoGap = true;
                        break;
                    }
                    else if (arr[i] <= arr[i - gap])
                    {
                        int aux = arr[i];
                        arr[i] = arr[i - gap];
                        arr[i - gap] = aux;
                        NoGap = false;
                        break;
                    }
                    else
                        NoGap = true;
                if(NoGap)
                    gap--;
                Ver(arr);
            } while (gap > 0);          
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
        static void Ver(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
