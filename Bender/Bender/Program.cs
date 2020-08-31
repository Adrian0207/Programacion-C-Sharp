using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bender
{
    class Program
    {
        static void Main(string[] args)
        {
            int n; //Número de generación de la cual se quieren contabilizar las copias
            int[] gen; //Arreglo que contendrá la cantidad de copias por generación
            long sumagen; //Sumatoria de robots de una generación
            long total = 1; //Sumatoria de robots totales
            int i;
            Console.Write("De qué generación desea contabilizar las copias?... ");
            n = Convert.ToInt32(Console.ReadLine());
            gen = new int[n];
            for(i=0;i<n;i++)
            {
                Console.Write("Generación No. {0} Cuántos clones hay en esta generación?... ", i + 1);
                gen[i] = Convert.ToInt32(Console.ReadLine());
            }
            //Se hace el cálculo
            sumagen = 1;
            for (i = 0; i < n; i++)
            {
                sumagen *= gen[i];
                Console.WriteLine("En la generación {0} hay {1} Benders", i+1, sumagen);
                total += sumagen;
            }
            Console.WriteLine("El total de benders en la generación {0} es: {1}", n, total);
            Console.ReadKey();
        }
    }
}


/*

En un episodio de Futurama el Robot Bender para evitar trabajar hizo 2 copias más pequeñas de sí mismo, 
a su vez sus copias eran ociosas y también hicieron 2 copias de ellos, y del mismo modo continuaron creándose robots Bender. 
Dentro de algunas generaciones el número de copias era inimaginable, sin embargo resolver cuántos robots habría 
en total no es un problema muy complicado si se conoce el número de generación del cual se quiere calcular la 
cantidad y si el número de clones es constante (la operación de cálculo es solo una potencia).
El problema anterior a usted le dio curiosidad y usted quiere saber cuántos Benders habrá en cierto momento si la 
réplica de cada generación NO es constante. Para eso, usted como buen programador ha pensado en realizar un programa 
que cumpla con dicha labor.
El programa recibe como datos el número de generación del cual desea contabilizar los Benders en la que se asume 
que Bender original es la generación 0 y posteriormente solicita, para guardar en un arreglo la cantidad de copias 
que hay por cada generación.
El programa devuelve como resultado el total de Benders para la generación solicitada.

  */