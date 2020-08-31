using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//Libreria para trabajar con archivos
namespace AudioLibros
{
    class Program
    {
        //Lee el programa de texto cuyo nombre se recibe como argumento
        //y retorna su contenido como una variable string
        static string LeerArchivo(string nombre)
        {
            StreamReader lector = new StreamReader(nombre);//Se apunta al inicio del archivo
            string linea;
            string cad = "";
            do
            {
                linea = lector.ReadLine();
                cad += linea + "\n";//Lee una linea del archivo y pasa el apuntador a la siguiente
            } while (linea != null);
            //cad = lector.ReadToEnd();//Lee todo el archivo y lo almacena en cad
            lector.Close();//Se cierra el archivo
            return cad;//Se retona el caontenido del archivo
        }
        static string Lineas(string cad)
        {
            string[] linea;
            string resp;
            linea = cad.Split('\n');//divide el texto por lineas
            Punto(linea);//Colocacion de puntos
            Guion(linea);//unir palabras con guion
            Abrev(linea);//abreviarutas
            SinSalto(linea);//saltos de lineas 
            resp = String.Join("\n", linea);//une todas las lineas ya modificadas
            return resp;
        }
        static string[] Punto(string[] cad)
        {
            string[] mayus = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int i, j, cont = 0;
            int numL = cad.Length;//numero de lineas o tamaño de arreglo
            for (i = 0; i < numL - 1; i++)
                if (!cad[i].EndsWith("."))//verifica si no tiene un punto al final de la linea
                {
                    if (cad[i].Equals(""))// si no hay noncetido 
                        continue;//continua el bucle
                    for (j = 0; j < mayus.Length; j++)
                        if (cad[i + 1].StartsWith(mayus[j]) || cad[i + 1].Equals(""))//si el cotenido siguiente es empieza con mayusculas o es vacio
                        {
                            cad[i] += '.';//coloca un punto al final
                            cont++;//contador de puntos
                            break;
                        }
                        else
                            break;
                }
            ContP(cont);//funcion para los funtos
            return cad;
        }//punto
        static string[] Guion(string[] cad)
        {
            int i, cont = 0;
            int numL = cad.Length;//numero de lineas
            for (i = 0; i < numL; i++)
                if (cad[i].EndsWith("-"))//busca si al fina l de la linea hay un gion
                {
                    cad[i] = cad[i].Substring(0, cad[i].Length - 1);
                    cad[i] += cad[i + 1];//sube una linea
                    cad[i + 1] = "";//y deja vacia la siguiente
                    cont++;
                }
            ContG(cont);//funcion para los guiones
            return cad;
        }//guion
        static string[] Abrev(string[] cad)//Cambia las abreviaturas mas comunes por la palabra completa y los cuenta
        {
            string[] abr = { "Abgdo", "Adm", "Alcde", "Almte", "Anl", "Arq", "Arz", "Bach", "Brig", "Cnal", 
                               "Clg", "Comte", "Coord", "CP", "Cnel", "Cdor", "Dir", "Dr", "Dra", "Econ", "Enf", "Gte", 
                               "Gdor", "Gral", "Hno","Hna", "Ing", "Jr", "Jz", "Lcdo", "Lcda", "Not", "Pdte", "Prof", "Psic", 
                               "Psiq", "Soc", "Superv", "Tte", "Tnco","Vet","Etc","abgdo", "adm", "alcde", "almte", "anl", "arq", "arz", "bach", "brig", "cnal", 
                               "clg", "comte", "coord", "cp", "cnel", "cdor", "dir", "dr", "dra", "econ", "enf", "gte", 
                               "gdor", "gral", "hno","hna", "ing", "jr", "jz", "lcdo", "lcda", "not", "pdte", "prof", "psic", 
                               "psiq", "soc", "superv", "tte", "tnco","vet","etc"};
            string[] comp ={ "Abogado", "Administrador", "Alcalde", "Almirante", "Analista", "Arquitecto", "Arzobispo", "Bachiller", 
                              "Brigadier", "Cardenal", "Clérigo", "Comandante", "Coordinador", "Contador Público", "Coronel", 
                              "Contador", "Director", "Doctor", "Doctora", "Economista", "Enfermera", "Gerente", "Gobernador", "General", 
                              "Hermano", "Hermano", "Ingeniero", "Junior", "Juez", "Licenciado","Licenciada", "Notario", "Presidente", 
                              "Profesor", "Psicólogo", "Psiquiatra", "Sociólogo", "Supervisor", "Tenente", "Tecnico","Veterinario","Etecetera",
                              "Abogado", "Administrador", "Alcalde", "Almirante", "Analista", "Arquitecto", "Arzobispo", "Bachiller", 
                              "Brigadier", "Cardenal", "Clérigo", "Comandante", "Coordinador", "Contador Público", "Coronel", 
                              "Contador", "Director", "Doctor", "Doctora", "Economista", "Enfermera", "Gerente", "Gobernador", "General", 
                              "Hermano", "Hermano", "Ingeniero", "Junior", "Juez", "Licenciado","Licenciada", "Notario", "Presidente", 
                              "Profesor", "Psicólogo", "Psiquiatra", "Sociólogo", "Supervisor", "Tenente", "Tecnico","Veterinario","Etecétera" };
            int i, j, k, cont = 0; 
            int numL = cad.Length;
            for (i = 0; i < numL - 1; i++)//recorre la lineas
                for (k = 0; k < abr.Length; k++)//recorre las abreviarturas
                    if (cad[i].Contains(abr[k]))
                    {
                        for (j = 0; j < abr.Length; j++)
                            cad[i] = cad[i].Replace(abr[j], comp[j]);//remplaza la abreviatura por el completo       
                        cont++;
                    }
            ContA(cont);
            return cad;
        }
        static string[] SinSalto(string[] cad)
        {
            int i, j, cont = 0;
            int numL = cad.Length;
            for (i = 2; i < numL - 1; i++)
            {
                if (cad[i].Equals(""))//busca si es vacio
                {
                    if (!cad[i - 1].EndsWith("."))//si el anterior tiene un putno
                    {
                        cad[i] += cad[i + 1];//la linea se cambia
                        cad[i + 1] = "";// y la otra queda vacia
                    }
                    cont++;
                }
            }
            ContS(cont);
            return cad;
        }
        static string ContP(int puntos)
        {
            string cad = "";
            cad += "Puntos agregados: " + puntos;
            Console.WriteLine(cad);
            return cad;
        }
        static string ContG(int guiones)
        {
            string cad = "";
            cad += "Separaciones de líneas por guiones eliminadas: " + guiones;
            Console.WriteLine(cad);
            return cad;
        }
        static string ContS(int espacios)   
        {
            string cad = "";
            cad += "Saltos de línea innecesarios eliminados: " + (espacios - 3);
            Console.WriteLine(cad);
            return cad;
        }
        static string ContA(int abrev)
        {
            string cad = "";
            cad += "Abreviaciones expandidas: " + abrev;
            Console.WriteLine(cad);
            return cad;
        }
        static void EscribirArchivo(string nombre, string contenido)//Escribe un contenido recibido como un string en un archivo
        {
            StreamWriter escritor = new StreamWriter(nombre);//Se apunta al inicio del archivo
            escritor.WriteLine(contenido);
            escritor.Close();
        }
        static void Main(string[] args)
        {
            string cad;
            string rcad;
            string nombre;
            int pausa = 500;
            //Lee el archivo
            Console.WriteLine("Resumen:");
            cad = LeerArchivo("Texto.txt");// por el debug del programa
            rcad = Lineas(cad);
            Console.Write(rcad);
            Console.Write("\nEscriba el nombre del nuevo archivo...");
            nombre = Console.ReadLine();
            EscribirArchivo(nombre+".txt", rcad);//se guarda un archivo con el nombre que el usuario al lo que va a guardar //debug del archivo se guarda el nuevo

            Console.Write("Loading");
            Console.Write(".");
            System.Threading.Thread.Sleep(pausa);
            Console.Write(".");
            System.Threading.Thread.Sleep(pausa);
            Console.Write(".");
            System.Threading.Thread.Sleep(pausa);
            Console.Write(".");
            System.Threading.Thread.Sleep(pausa);
            Console.Write(".");
            System.Threading.Thread.Sleep(pausa);
            Console.Write(".");
            System.Threading.Thread.Sleep(pausa);
            System.Threading.Thread.Sleep(300);
            Console.Write("Archivo generado correctamente.");

            Console.ReadKey();
        }
    }
}
