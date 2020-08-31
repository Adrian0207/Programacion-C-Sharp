using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCD_electro
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo op;
            string numDecimal, temp="", numBin;
            string resultado = "";
          
            do
            {
                
                Console.WriteLine("\t \t \t \t BINARY CODED DECIMAL");
                Console.WriteLine("1. PROCESO DE EMISIÓN");
                Console.WriteLine("2. PROCESO DE RECEPCIÓN");
                Console.WriteLine("PULSE LA OPCION QUE DESEE");
                op = Console.ReadKey();
                    switch (op.Key)
                    {
                        case ConsoleKey.D1:
                            {
                                Console.WriteLine("Ingrese el codigo que desea emitir (numero en base decimal)");
                                numDecimal = Console.ReadLine();
                                for (int i = 0; i < numDecimal.Length; i++)
                                {
                                    temp = numDecimal.Substring(i,1);
                                    if (temp == "0")                                
                                        temp = "0000";                                  
                                    else if (temp == "1")
                                        temp = "0001";
                                    else if (temp == "2")
                                        temp = "0010";
                                    else if (temp == "3")
                                        temp = "0011";
                                    else if (temp == "4")
                                        temp = "0100";
                                    else if (temp == "5")
                                        temp = "0101";
                                    else if (temp == "6")
                                        temp = "0110";
                                    else if (temp == "7")
                                        temp = "0111";
                                    else if (temp == "8")
                                        temp = "1000";
                                    else if (temp == "9")
                                        temp = "1001";
                                    resultado += temp;
                                }
                                Console.WriteLine(resultado);

                                break;
                            }
                        case ConsoleKey.D2:
                            {
                                Console.WriteLine("Ingrse el codigo que desea emitir (numero en base binaria)");
                                numBin = Console.ReadLine();
                                //temp = numBin.Remove(0, 4);


                                for (int k=0, i = numBin.Length, j=4; i >= 0; i--)
                                {
                                
                                    if (numBin.Length >= 4)
                                    {
                                        temp = numBin.Substring(((numBin.Length) -(k+ j)), 4);
                                        if (temp == "0000")
                                            temp = "0";
                                        else if (temp == "0001")
                                            temp = "1";
                                        else if (temp == "0010")
                                            temp = "2";
                                        else if (temp == "0011")
                                            temp = "3";
                                        else if (temp == "0100")
                                            temp = "4";
                                        else if (temp == "0101")
                                            temp = "5";
                                        else if (temp == "0110")
                                            temp = "6";
                                        else if (temp == "0111")
                                            temp = "7";
                                        else if (temp == "1000")
                                            temp = "8";
                                        else if (temp == "1001")
                                            temp = "9";
                                        else
                                        {
                                            Console.WriteLine("este numero no se admite");
                                            //break;
                                        }
                                        k = j;
                                    
                                    }
                                    else if (numBin.Length == 1)
                                    {
                                        temp = "000" + numBin;
                                        //temp = numBin.Substring(i, 4);
                                        if (temp == "0000")
                                            temp = "0";
                                        else if (temp == "0001")
                                            temp = "1";
                                        else if (temp == "0010")
                                            temp = "2";
                                        else if (temp == "0011")
                                            temp = "3";
                                        else if (temp == "0100")
                                            temp = "4";
                                        else if (temp == "0101")
                                            temp = "5";
                                        else if (temp == "0110")
                                            temp = "6";
                                        else if (temp == "0111")
                                            temp = "7";
                                        else if (temp == "1000")
                                            temp = "8";
                                        else if (temp == "1001")
                                            temp = "9";
                                    }
                                    else if (numBin.Length == 2)
                                    {
                                        temp = "00" + numBin;
                                        //temp = numBin.Substring(i, 4);
                                        if (temp == "0000")
                                            temp = "0";
                                        else if (temp == "0001")
                                            temp = "1";
                                        else if (temp == "0010")
                                            temp = "2";
                                        else if (temp == "0011")
                                            temp = "3";
                                        else if (temp == "0100")
                                            temp = "4";
                                        else if (temp == "0101")
                                            temp = "5";
                                        else if (temp == "0110")
                                            temp = "6";
                                        else if (temp == "0111")
                                            temp = "7";
                                        else if (temp == "1000")
                                            temp = "8";
                                        else if (temp == "1001")
                                            temp = "9";
                                    }
                                    else if (numBin.Length == 3)
                                    {
                                        temp = "0" + numBin;
                                        //temp = numBin.Substring(i, 4);
                                        if (temp == "0000")
                                            temp = "0";
                                        else if (temp == "0001")
                                            temp = "1";
                                        else if (temp == "0010")
                                            temp = "2";
                                        else if (temp == "0011")
                                            temp = "3";
                                        else if (temp == "0100")
                                            temp = "4";
                                        else if (temp == "0101")
                                            temp = "5";
                                        else if (temp == "0110")
                                            temp = "6";
                                        else if (temp == "0111")
                                            temp = "7";
                                        else if (temp == "1000")
                                            temp = "8";
                                        else if (temp == "1001")
                                            temp = "9";
                                    }
                                    resultado += temp;
                                }
                                Console.WriteLine(resultado);

                                break;
                            }
                    }


                } while (op.Key != ConsoleKey.Escape);

        }
    }
}
