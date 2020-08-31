using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArregloDeAleatorios
{
    class Program
    {
        static bool EsEntero(string cad)
        {
            bool resultado;
            int valor;
            try
            {
                valor = Convert.ToInt32(cad);
                resultado = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Por favor ingrese un número entero");
                resultado = false;
            }
            return resultado;
        }
        static int[] GeneralAleatorio(int cantidad)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int i;
            int x;//valor aleatorio generado 
            int[] arr = new int [cantidad];
            for (i = 0; i < cantidad; i++)
            {
                x = r.Next(1, 11);
                arr[i] = x;
            }
            return arr;
        }
        static int[] Contador(int[] arr)
        {
            int[] aux = new int [arr.Length];
            int mayor;
            Imprimir(arr);
            Console.Write("\n");
            aux = Repetidos(arr, aux);
            mayor = Mayor(aux);
            aux = NumRep(aux, mayor, arr);
            aux = Respuesta(aux);         
            return aux;
        }
        static void Imprimir(int[] arreglo)
        {
            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.Write(arreglo[i]);
                if (i < arreglo.Length - 1)
                    Console.Write(",");
            }
        }
        static int[] Repetidos(int[] arr, int[] aux)
        {
            int i, j;
            for (i = 0; i < arr.Length; i++)
                for (j = 0; j < arr.Length; j++)
                    if (arr[i] == arr[j])
                        aux[i]++;
            return aux;
        }
        static int Mayor(int[] arreglo)
        {
            int i;
            int mayor = 0;
            for (i = 0; i < arreglo.Length; i++)
                if (arreglo[i] > mayor)
                    mayor = arreglo[i];
            return mayor;
        }
        static int[] NumRep(int[] arreglo, int max, int[] original)
        {
            int i, j = 0;
            int[] arr= new int [arreglo.Length];
            if (max == 1)
                arreglo = null;
            else
                for (i = 0; i < arreglo.Length; i++)
                    if (arreglo[i] == max)
                        arr[j++] = original[i];
            return arr;
        }
        static int[] Respuesta(int[] arreglo)
        {
            int i, j = 0, cont = 0;
            int[] arr = new int[arreglo.Length];
            if (arreglo[0] == 0)
                Console.Write("No existen números repetidos");
            else
            {
                for (i = 0; i < arreglo.Length; i++)
                    if (arr.Contains(arreglo[i]))
                        continue;
                    else
                    {
                        arr[j++] = arreglo[i];
                        cont++;
                    }
                ImprimirRepetidos(cont, arr);
            }
            return arr;
        }
        static void ImprimirRepetidos(int contador, int[]arreglo)
        {
            int i;
            Console.Write("Los numeros que se repiten son: ");
            for (i = 0; i < contador; i++)
            {
                Console.Write(arreglo[i]);
                if (i < contador - 1)
                    Console.Write(",");
            }
        }
        static void Main(string[] args)
        {
            string cad;
            int tam;
            int[] arr, rep;
            do
            {
                Console.Write("Ingrese el tamaño del arreglo...");
                cad = Console.ReadLine();
            } while (!EsEntero(cad));
            tam = Convert.ToInt32(cad);
            arr = GeneralAleatorio(tam);
            rep = Contador(arr);
            Console.ReadKey();
        }
    }
}
//3er Examen de Programación Básica

//Escriba un programa que solicite a un usuario 2 valores: n y m.
//A continuación se genera un arreglo con n números aleatorios enteros que van desde 1 hasta m.
//El programa presenta por pantalla el arreglo generado y seguidamente indica cual el valor que más se ha repetido en la generación.
//Si hay vario valores que sean solución, con que presente 1 (el que le parezca más fácil) es suficiente. 

//Su programa debe contener obligatoriamente, al menos una función que reciba al menos un argumento y que devuelva un resultado. Usted debe indicar para qué usa dicha función mediante comentarios. En caso de no existir la función, el programa se calificará sobre la mitad de la nota.

//Ejemplo:
//Cuántos elementos desea?... 8
//Hasta qué valor?... 6
//Datos generados: 6, 3, 2, 6, 2, 1, 6, 5, 6
//Valor qué más se repite: 6
