using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            string cad;
            do
            {
                Console.Write("Tamaño del arreglo: ");
                cad = Console.ReadLine();
            } while (!EsEntero(cad));
            int valor = Convert.ToInt32(cad);
            int[] arr = new int[valor];
            for (int i = 0; i < valor ; i++)
            {
                do
                {
                    Console.Write("Dato en la posicion {0}: ", i + 1);
                    cad = Console.ReadLine();
                } while (!EsEntero(cad));
                int elemento = Convert.ToInt32(cad);
                arr[i] = elemento;
            }

            //Console.Clear();         
            //int[] arr = new int[] { 8, 9, 5, 47, 56, 23, 14, 6, 54, 6, 23, 4, 56, 6, 4, 4, 56, 45, 5, 6, 8, 43, 36, 88, 9, 2, 58, 36, 366, 3, 646, 6, 36, 10, 646, 4, 545, 87, 23, 3, 415, 555 };
            int tamanio = arr.Length;
            int[] ordenado = new int[arr.Length];
            for (int i = 0; i < tamanio; i++)
            {
                ordenado[i] = Tournament(arr);
                arr = Eliminar(arr, ordenado[i]);
            }
            Ver(ordenado);
            Console.Read();
        }
        static int Tournament(int[] arr)
        {
            int[] aux = new int[Contador(arr)];
            int[] temp;
            for (int i = 0; i < arr.Length; i++)//llena el aux con los elementos del arreglo
            {
                if (arr[i] != 0)
                    if (arr[i] != 0)
                        aux[i] = arr[i];
                    else
                    {
                        aux[i] = arr[i + 1];
                        arr[i + 1] = 0;
                    }
            }
            Ver(aux);
            int contador = Contador(aux);//numero de elementos distintos a 0 dentro del arreglo
            if (contador != 1)
            {
                do
                {

                    temp = new int[arr.Length / 2 + 1];//arreglo temporal es la mitad del arrelgo orignial 
                    int k = 0;
                    for (int i = 0, j = 1; i < aux.Length; i += 2, j += 2, k++)
                    {
                        if (contador / 2 == 0)//cuando sea par todos tienen una pareja
                            if (aux[i] < aux[j])
                                temp[k] = aux[i];
                            else
                                temp[k] = aux[j];
                        else//sino se implementa que el que este solo pasa directamente a la siguiente ronda 
                            if (j > aux.Count() - 1)
                            {
                                temp[k] = aux[i];
                                break;
                            }
                            else if (aux[i] < aux[j])
                                temp[k] = aux[i];
                            else
                                temp[k] = aux[j];
                        //Ver(temp);
                    }
                    Ver(temp);
                    aux = temp;
                    contador = Contador(aux);
                } while (contador != 1);//termina cuando el arreglo auxiliar es 1 
            }
            return aux[0];//se ternora el elemento que gano
        }
        static int Contador(int[] arr)
        {
            int cont = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != 0)
                    cont++;
            return cont;
        }
        static int[] Eliminar(int[] arr, int target)//elimina el elemento ganador del arreglo
        {
            int[] aux = new int[arr.Length - 1];
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == target)
                {
                    arr[i] = 0;
                    break;
                }
            for (int i = 0; i < aux.Length; i++)
            {
                if (arr[i] != 0)
                    aux[i] = arr[i];
                else
                {
                    aux[i] = arr[i + 1];
                    arr[i + 1] = 0;
                }
            }
            return aux;
        }
        static void Ver(int[] arr)//funcion para ver el arreglo
        {
            if (Contador(arr) == 1)
                Console.Write("Ganador: " + arr[0]);
            else
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] != 0)
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
