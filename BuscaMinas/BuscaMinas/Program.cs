using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuscaMinas
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] buscaminas;// arreglos para el buscaminas
            char[] campo;//colocador de minas
            int casillas, porcentaje;//nmero de casillas y porcentaje
            int minas, posicion;//posicion y numero minas
            int i, j;//contadores
            string op;//opcion repetir
            do
            {
                Console.Write("Ingrese el número de casillas mayor a 3:...");
                casillas = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingrese el porcentaje de minas (0-80%):...");
                porcentaje = Convert.ToInt32(Console.ReadLine());
                minas = (casillas * porcentaje) / 100;//numero de minas
                Console.WriteLine("Numero de minas: "+minas);
                Console.Write("Loading");
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
                System.Threading.Thread.Sleep(300);
                if (casillas > 2)
                {
                    campo = new char[casillas];
                    for (i = 0; i < casillas; i++)
                        campo[i] = '-';
                    buscaminas = PosicionMinas(casillas, minas);//funcion para las posiciones de minas aleatorias
                    IndicarMinas(buscaminas);//indica la psocion
                    for (i = 0; i <= casillas - minas; i++)//sale a pantalla el juego y repite hasta quese encuntren todas las posiciones
                    {
                        Console.Clear();

                        Console.WriteLine("\nSituación actual");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        for (j = 0; j < casillas; j++)
                            Console.Write(campo[j] + " ");
                        if (campo.Contains('*'))//si encuntra una mina sale del bucle y pierde
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("YOU LOSE");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            for (j = 0; j < casillas; j++)
                            {
                                DescubrirPosicion(buscaminas, campo, j);
                                Console.Write(campo[j] + " ");
                            }
                            break;
                        }
                        else if (i == casillas - minas)//si rellena todas las posciones sin equivocarse gana
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("YOU WIN");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            for (j = 0; j < casillas; j++)
                            {
                                DescubrirPosicion(buscaminas, campo, j);
                                Console.Write(campo[j] + " ");
                            }
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\nQue posicion desea descubrir?...");
                        posicion = Convert.ToInt32(Console.ReadLine());
                        DescubrirPosicion(buscaminas, campo, posicion - 1);
                    }
                }
                else
                    Console.WriteLine("Ingrese un número mayor a 2 para jugar");
                do//opcion para repetir
                {
                    Console.Write("\nDesea jugar otra vez(s/n)...");
                    op = Console.ReadLine();
                } while (op != "s" && op != "S" && op != "n" && op != "N");//control para la opcion
            } while (op == "s" || op == "S");

            Console.Write("Presione tecla para continuar");
            Console.ReadKey();
        }
        static int[] PosicionMinas(int posicion, int maxminas)//indica la posicion aleatoria en el arreglo de buscaminas
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int[] resultado = null;
            int i;
            int aleatorio;
            if (maxminas <= posicion)
            {
                resultado = new int[posicion];
                i = 0;
                while (i < maxminas)
                {
                    do
                    {
                        aleatorio = r.Next(1,resultado.Length-1);// busca una posicion aleatoria
                    } while (resultado[aleatorio] != 0);
                    resultado[aleatorio] = -1;//coloca un -1 que es una mina en la posicion
                    i++;
                }  
            }
            return resultado;//devuelve el arreglo
        }
        static int[] IndicarMinas(int[] arr)//coloca 0,1 y2
        {
            int i;
            if (arr[1] == -1)
                arr[0] = 1;

            for (i = 1; i < arr.Length - 1 ; i++)
            {
                if (arr[i] == 0 && arr[i - 1] == -1 && arr[i + 1] == -1)// si esta en el medio de dos coloca un 2
                    arr[i] = 2;

                else if (arr[i] == 0 && arr[i - 1] == 0 && arr[i + 1] == 0)// si no hay nunguna coloca un cero
                    arr[i] = 0;

                else if ((arr[i] == 0 && arr[i - 1] == -1 && arr[i + 1] == 0) || (arr[i] == 0 && arr[i - 1] == 0 && arr[i + 1] == -1))//coloca un 1 si esta alado de una mina
                    arr[i] = 1;
            }

            if (arr[arr.Length - 2] == -1)
                arr[arr.Length - 1] = 1;
            return arr;
        }
        static char[] DescubrirPosicion(int[] arr, char[] res, int pos)// coloca la mina como *
        {
            if (arr[pos] == -1)
                res[pos] = '*';//si encunetra una posicion pone un *
            else
                res[pos] = Convert.ToChar(Convert.ToString(arr[pos])); // devuelve una conversion doble de char a string para colocar 0,1 o 2
            return res;//retorna el arreglo
        }
    }
}
