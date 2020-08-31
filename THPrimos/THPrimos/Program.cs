using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THPrimos
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
                    Console.Write("Por favor ingrese un número primo: ");
                    cad = Console.ReadLine();
                } while (!EsEntero(cad));//verifica si el valor ingresado es un numero entero
                valor = Convert.ToInt32(cad);
            } while (!EsPrimo(valor));//verifica si el valor ingresado es un primo
            Console.WriteLine("El numero primo {0} esta en la posicion {1}", valor, FuncionHash(valor));
            Thread.Sleep(1000);
            Console.WriteLine("\nPresione tecla para salir");
            Console.ReadKey();
        }
        static int[] Primos(int[] arr)//devuelve el arrelgo de primos
        {
            int numero = 2, k = 0;
            do
            {
                if (EsPrimo(numero))
                    arr[k++] = numero;
                numero++;
            } while (arr[arr.Length-1] == 0);
            return arr;
        }
        static bool EsPrimo(int pri)
        {
            if (pri <= 1)
                return false;//si es menor que 1 o igual no se lo concidera como primo
            int cont = 0;
            for (int j = 2; j <= pri; j++)
            {
                if (pri % j == 0)
                    cont++;
                if (cont == 2)// si el contador es mas de dos devuelve que no es primo
                    return false;// verifica mas rapido si lo es en vez de verificar si no lo es hasta el numero
            }
            return true;
        }
        static int FuncionHash(int buscado) 
        {
            int pos = -1 ;
            int[] primos = new int[110];// al no concocer hasta que numero primo se lo puso hasta que el arreglo llene 110 posiciones
            primos = Primos(primos);
            if(primos.Contains(buscado))// busca coincidencia
                for (int i = 0; i < primos.GetUpperBound(0); i++)
                    if (buscado == primos[i])
                    {
                        pos = i;// se convierte en la posicion 
                        break;// ya no necesita verificar asi que sale del bucle
                    }
            return pos;//devuelve la posicion
        }
        public static bool EsEntero(string cad)//verifica si es entero
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
