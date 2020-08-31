using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusquedaBinaria
{
    class Program
    {
        static void Main(string[] args)
        {
            string cad;
            int valor;
            do
            {
                do
                {
                    Console.Clear();
                    Console.Write("De qué tamaño desea el arreglo? ");
                    cad = Console.ReadLine();
                } while (!EsEntero(cad));//verifica si es entero
                valor = Convert.ToInt32(cad);
            } while (valor <= 0);// si es unn valor negativo lo vuelve a preguntar
            int[] arr = new int[valor];
            for (int i = 0; i < arr.Length; i++)
            {
                do
                {
                    Console.Write("Ingrese el dato en la posicion {0}: ", i + 1);
                    cad = Console.ReadLine();
                } while (!EsEntero(cad));
                valor = Convert.ToInt32(cad);
                arr[i] = valor;
            }
            do
            {
                Console.Write("Qué dato desea buscar? ");
                cad = Console.ReadLine();
            } while (!EsEntero(cad));
            int buscado  = Convert.ToInt32(cad);

            Console.WriteLine();
            arr = Ordenar(arr);//ordena el arreglo de menor a mayor
            int []pos = BusquedaB(arr, buscado);
            if (pos[0] == -1)
                Console.WriteLine("No existe en el arreglo");
            else
            {
                if (arr[pos[0]] == arr[0] || arr[pos[0]] == arr[arr.Length - 1])
                {
                    Console.WriteLine("Encontrado en la posición: " + (pos[0] + 1));
                    Console.WriteLine("Numero de iteraciones: " + (pos[1]));
                }
                else 
                {
                    Console.WriteLine(arr[pos[0]]);
                    Console.WriteLine("Encontrado en la posición: " + (pos[0] + 1));
                    Console.WriteLine("Numero de iteraciones: " + (pos[1]));
                }
            }
            Thread.Sleep(1000);
            Console.WriteLine("\nPresione tecla para salir");
            Console.ReadKey();
        }
        static int[] BusquedaB(int[] arr, int buscado)
        {
            int[] solucion = { -1, 0 };
            int mitad = 0;
            int li = 0, ls = arr.Length - 1; // limite inferior, limite superior
            bool salir = false;
            VerDatos(arr, li, ls + 1);
            if (buscado < arr[0] || buscado > arr[ls])// si el buscado es mayor o menor que los elementos limites, no realiza una busqueda
                salir = true;
            else
            {
                while (!salir)
                {
                    mitad = (li + ls) / 2;//la mitad del arrelog
                    if (arr[mitad] == buscado)
                    {
                        solucion[0] = mitad;// busca coincidencia en la mitad del arreglo
                        salir = true;
                    }
                    else if (li == ls)
                    {
                        solucion[0] = -1;
                        salir = true;
                    }
                    if (!salir)
                    {
                        if (buscado < arr[mitad])// si el buscado es menor al elemento de la mitad
                        {
                            ls = mitad;// la mitad se vuelve el limite superior
                            VerDatos(arr, li, ls + 1);

                        }
                        else
                        {
                            li = mitad + 1;// sino lo es se, el limite inferior se vuelve la mitad + 1
                            VerDatos(arr, li, ls + 1);
                        }
                    }
                    solucion[1]++;
                }
                if (mitad == 0)
                    VerDatos(arr, li, ls);
            }
            return solucion;// se devuelve la posicion y el numero de iteraciones en un arreglo
        }
        static void VerDatos(int[] arr, int inicio, int final)//permite sacar por consola las iteraciones que va haciendo
        {
            for (int i = inicio; i < final; i++)
            {
                Console.Write(arr[i] + " ");    
            }
            Console.WriteLine();
        }
        static int[] Ordenar(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int aux = Menor(arr, i);//buca el menor
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] == aux)// cuando encuentra el elemnto
                    {
                        arr[j] = arr[i];// la posicion cambia con el que estaba antes
                        arr[i] = aux;// y se pone el de menor valor primero
                        break;
                    }
                }
            }

            return arr;
        }//ordena el arreglo
        static int Menor(int[] arr, int inicio)
        {
            int menor = arr[inicio];
            for (int i = inicio + 1; i < arr.Length; i++)
            {
                if (arr[i] < menor)
                    menor = arr[i];
            }
            return menor;
        }
        public static bool EsEntero(string cad)
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
