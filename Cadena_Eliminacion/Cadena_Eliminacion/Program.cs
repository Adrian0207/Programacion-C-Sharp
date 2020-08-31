using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cadena_Eliminacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string cad1, cad2;// original y copia
            string subcad1, subcad2; // original y copia
            bool contiene,booleano=false; // contiene para saber si la cadena contiene la subcadena
            string op;//opcion para salir
            int i;// contador
            Console.Write("Ingrese la cadena original: ");
            cad1 = Console.ReadLine();
            cad2 = cad1.ToLower().Trim();// se guarda en la copia y lo combierte en minusculas y sin espacion finales e iniciales
            Console.Write("Ingrese la cadena a buscar: ");
            subcad1 = Console.ReadLine();
            subcad2 = subcad1.ToLower().Trim();
            contiene = cad2.Contains(subcad2);//Contains busca similitudes en la cadena
            
            if (contiene == true)//devuelve un true si lo tiene 
            {
                do
                {
                    Console.Write("Eliminar 1 o todas las concurrencias(1/t)?...");
                    op = Console.ReadLine();
                    op = op.ToLower().Trim();
                } while (op != "1" && op != "t");//bucle hata que coloque la opcion correcta
                Console.Write("\n");
                if (op == "1")
                {  
                    for (i = 0; i < cad2.Length; i++)
                        if (booleano == false)// booleano va hasta que encuetra la subcad en la cad
                        {
                            if (cad2.Substring(i, subcad2.Length).Equals(subcad2))
                            {
                                i = i + subcad2.Length - 1;
                                booleano = true;// borra la subcad de la cad y booleano es true
                            }
                            else
                                Console.Write(cad2.Substring(i, 1));// sigue ingresando lo demas
                        }
                        else
                            Console.Write(cad2.Substring(i, 1));
                    Console.Write("\n");
                }
                else
                { 
                    for (i = 0; i < cad1.Length; i++)
                    {
                        
                        if (cad2.Substring(i, subcad2.Length).Equals(subcad2))
                        {
                            i = i + subcad2.Length - 1;
                            cad2 += " ";
                        }
                        
                        else
                        Console.Write(cad1.Substring(i, 1));
                    }
                    Console.Write("\n");
               }
            }
            else
                Console.Write("\nNo se han encontrado coincidencias en la cadena");

            Console.Write("\nGracias por usar este programa\nPresione tecla para continuar");
            Console.ReadKey();
        }
    }
}
