using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arr_Moda
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr, aux;
            int dat,nmayor,index;//datos, mayor numero y indicador 
            int i, j;
            string op;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("B I E N V E N I D O");
            
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Cuántos datos va a ingresar?...");// ingresa de cuanto es el arreglo
                Console.ForegroundColor = ConsoleColor.Green;
                dat = Convert.ToInt32(Console.ReadLine());
                arr = new int[dat];// numero de elementos en el arreglo

                for (i = 0; i < arr.Length;i++)
                {//ingreso de los datos en el arreglo
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Dato {0}...", (i+1));//en cada posicion
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }
                aux = new int[arr.Length];// usamos un auxiliar para recolectar los datos que se repiten
                for (i = 0; i < arr.Length; i++)//recorre la cadena
                    for(j = 0;j < arr.Length; j++)                    
                        if (arr[i]==arr[j])//si en los recorridos son iguales
                            aux[i]++;//aumenta 1, 
                nmayor = 0;//buscamos el que se repite mas veces en el arreglo
                index = 0;//es un apuntador que busca cual es el mayor en el arreglo auxiliar
                for (i = 0; i < aux.Length; i++)//recorre el auxiliar
                    if (aux[i] > nmayor)//si encuetra que es mayor
                    {
                        nmayor = aux[i];//numero que mas se repite estara en la posicion del auxiliar 
                        index = i;  //toma la posicion
                    }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Moda: " + arr[index]);
                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\nDesea ingresar otro número?(s/n)...");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    op = Console.ReadLine();
                } while (op != "s" && op != "S" && op != "n" && op != "N");

            } while (op == "s" || op == "S");

            Console.ReadKey(); Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nGracias por usar este programa\nPresione una tecla para salir");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
