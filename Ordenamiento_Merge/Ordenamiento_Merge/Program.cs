using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ordenamiento_Merge
{
    class Program
    {
        static void Main(string[] args)
        {
            //string cad;
            //do
            //{
            //    Console.Write("Tamaño del arreglo: ");
            //    cad = Console.ReadLine();
            //} while (!EsEntero(cad));
            //int valor = Convert.ToInt32(cad);
            //int[] arr = new int[valor];
            //for (int i = 0; i < valor; i++)
            //{
            //    do
            //    {
            //        Console.Write("Dato en la posicion {0}: ", i + 1);
            //        cad = Console.ReadLine();
            //    } while (!EsEntero(cad));
            //    int elemento = Convert.ToInt32(cad);
            //    arr[i] = elemento;
            //}
            
            Random r = new Random();
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(1, 1000);   
            }
            //int[] arr = new int[] { 9, 4, 2, 6, 5, 3, 1, 7, 5, 3, 1, 6, 7, 5 };//arreglo prueba
            Ver(arr);
            Console.WriteLine();
            int[] ordenado = Mergesort(arr);
            Console.Read();
        }
        static int[] MitadIzquierda(int[] arr)
        {
            int[] arri = new int[(arr.Length) / 2];
            for (int i = 0; i < arri.Length; i++)
                arri[i] = arr[i];
            return arri;
        }
        static int[] MitadDerecha(int[] arr)
        {
            int mit = arr.Length - (arr.Length / 2);
            int[] arrd = new int[mit];
            if (mit == 1)
                arrd[0] = arr[1];
            else
                for (int i = arr.Length - 1, j = mit - 1; i >= (mit - 1); i--, j--)
                    if (arrd[0] != 0)
                        break;
                    else
                    arrd[j] = arr[i];
            return arrd;
        }
        
        static int[] Mergesort(int[] arr)
        {          
            int[] arr1, arr2;
            int li = 0, ls = arr.Length - 1;
            if ((ls - li) > 0)
            {
                arr1 = Mergesort(MitadIzquierda(arr));// divide el arrelgo desde el inicio a la mitad
                arr2 = Mergesort(MitadDerecha(arr));// divide el arreglo desde la mitad hasta el final
                return Merge(arr1, arr2);//fusiona los dos arreglos
            }
            else 
                return arr;          
        }
        static int[] Merge(int[] izq, int[] der)
        {        
            int ni = izq.Length, nd = der.Length;
            int[] arr = new int[ni + nd];
            int i = 0, j = 0;
            for (int k = 0; k < arr.Length; k++)
            {
                if (ni == 0)//cuando el arreglo izquierdo no tenga elementos se colocaran los restantes del derechi
                {
                    arr[k] = der[j];
                    j++;
                }
                else if (nd == 0)//lo mismo que el anterior pero vicevera 
                {
                    arr[k] = izq[i];
                    i++;
                }
                else
                    if (izq[i] <= der[j])// ve cual de los dos elementos en cierta posicion es menor
                    {
                        arr[k] = izq[i];
                        i++;
                        ni--;
                    }
                    else if (izq[i] >= der[j])
                    {
                        arr[k] = der[j];
                        j++;
                        nd--;
                    }
            }
            Ver(arr);
            return arr;
        }
        static void Ver(int[]arr)
        {
            
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        static bool EsEntero(string cad)
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
