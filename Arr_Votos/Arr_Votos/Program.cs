using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arr_Votos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] votos = new int [3];
            int i;
            int v;
            string op;
            do
	        {
	         Console.Write("Ingrese el voto (1.RE,2.CRI,3.PA)...");
             v=Convert.ToInt32(Console.ReadLine());
                switch (v)
                {
                    case 1: votos[0]++;
                        break;
                    case 2: votos[1]++;
                        break;
                    case 3: votos[2]++;
                        break;
                    default: Console.WriteLine("No exite ese opción");
                        break;
                }
                do
                {
                    Console.Write("Existe mas votos (s/n)...");
                    op = Console.ReadLine();
                } while (op != "s" && op != "n");
	        } while (op=="s");

            if (votos[0] == votos[1])
                if (votos[1]==votos[2])
                    Console.WriteLine("Existe un empate entre las 3");
                else
                    Console.WriteLine("Existe un empate entre RE y CRI");
            else if (votos[1]==votos[2])
                Console.WriteLine("Existe un empate entre CRI y PA");
            else 
                if (votos[0] > votos[1] && votos[0]>votos[2])
                    Console.WriteLine("GANA RE");
                else if (votos[1] > votos[0] && votos[1] > votos[2])
                    Console.WriteLine("GANA CRI");
                else
                    Console.WriteLine("GANA PA");
                    
                Console.ReadKey();
        }
    }
}
