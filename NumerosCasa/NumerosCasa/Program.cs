using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Corrección al ejercicio de números de casa sin repetidos
/// Por: Jorge Alarcón
/// 2017

namespace NumerosCasa
{
    class Program
    {
        //static int iteraciones = 0; //Descomente si desea contabilizar las iteraciones

        //Verifica que un entro no tenga dígitos repetidos.
        //De ser ese el caso retorna true;
        static bool SinRepetidos(int n)
        {
            int i, j;
            bool repetido = false; //Será true si se enuentra un repetido
            string numero; //n trasnformado a string
            //int iter = 0; //Descomente si desea contabilizar las iteraciones
            numero = Convert.ToString(n);
            for (i = 0; i < numero.Length - 1; i++)
            {
                for (j = i + 1; j < numero.Length; j++)
                {
                    //iter++; //Descomente si desea contabilizar las iteraciones
                    if (((numero[i] == numero[j]))) //Hay un reptido
                    {
                        repetido = true;
                        break; //Si ya hubo un repetido no debe seguir verificando
                    }
                }
                if (repetido) //Si ya hubo un repetido no debe seguir verificando
                    break;
            }
            //iteraciones += iter; //Descomente si desea contabilizar las iteraciones
            return !repetido; //Se devuelve lo opuesto, ya que se buscó un repetido
        }

        //Devuelve el número de casas disponible sin números repetidos en un rango
        static int ContarCasas(int casaini, int casafin)
        {
            int i;
            int total = 0;
            for (i = casaini; i <= casafin; i++)
            {
                if (SinRepetidos(i))
                    total++;
            }
            return total;
        }

        //Retorna un arreglo de ints con todas las parejas que se van a verificar
        //Las cuales deben ser introducidas por consola, tal y como plante el ejercicio
        static int[,] TomarDatos()
        {
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            string[] datos;
            int[,] r=null;
            char[] sep = new char[] { ' ' };
            string cad;
            int i;
            Console.WriteLine("Ingrese todos los casos de prueba como se india en el texto del ejericio");
            Console.WriteLine("Dos valores separados por un espacio hasta colocar un 0");
            Console.WriteLine();
            do
            {
                cad = Console.ReadLine();
                if (cad != "0")
                {
                    datos = cad.Split(sep);
                    a.Add(Convert.ToInt32(datos[0]));
                    b.Add(Convert.ToInt32(datos[1]));
                }
            } while (cad != "0") ;
            r = new int[a.Count, 2];

            for (i = 0; i<a.Count; i++)
            {
                r[i, 0] = a[i];
                r[i, 1] = b[i];
            }
            return r;
        }

        static void Resolver()
        {
            int[,] parejas;
            int i;
            string cad="";
            parejas = TomarDatos();
            for (i = 0; i < parejas.GetLength(0); i++)
                cad += ContarCasas(parejas[i, 0], parejas[i, 1]) + "\n";
            Console.WriteLine();
            Console.WriteLine(cad);
            //Console.WriteLine("Iteraciones totales: " + iteraciones); //Descomente si desea contabilizar las iteraciones
            Console.WriteLine("Si desea conocer el número de iteraciones utilizado descomente las 5 líneas que dicen:");
            Console.WriteLine("Descomente si desea contabilizar las iteraciones");

        }

        static void Main(string[] args)
        {
            Resolver();
            Console.Write("\nGracias por usar este programa. Presione tecla para salir... ");
            Console.ReadKey();

        }
    }
}

/*
Los habitantes de Nlogonia son personas muy supersticiosas. Una de sus creencias es que, si hay números de casas con dígitos repetidos, eso traerá mala suerte a sus residentes. Por lo tanto, ellos nunca vivirían en una casa cuyo número sea 838 o 1004.

La reina de Nlogonia ha ordenado la construcción de una nueva calle llena de casas, en espera de no afectar las creencias de su pueblo ha solicitado la creación de un sistema de numeración para casas sin números repetidos.  Su majestad ha contratado sus servicios para escribir un programa en el cual dados 2 enteros N y M, se determine el máximo número de casas que se pueden asignar en esa calle sin números repetidos e incluyendo los valores N y M.

Input: 

Cada caso de prueba se ingresa con una sola línea conteniendo los enteros M y N como han sido descritos donde (1<=M<=N<=5000). Al ingresar un único 0 se indica que los datos han sido ingresados en su totalidad.

Output:
Para cada caso de prueba, se presenta una línea con un valor indicando el número de casas que se pueden obtener entre M y N (inclusive) sin dígitos repetidos.

Sample Input
87 104
989 1022
22 25
1234 1234
0

Sample Output
14
0
3
1

No necesita verificar que los valores se encuentren en los rangos indicados, ni hacerlo a prueba de usuarios. Pero si debe haber un modo de conocer cuántas iteraciones toma su programa para resolver el ejercicio, este modo pude estar comentado, pero al descomentarlo debe funcionar.

Calificación (6 puntos):

•	Se ingresan los datos y se imprimen los resultados como está en el documento (1 punto)
•	Contabiliza y permite conocer correctamente el número de iteraciones que le toma al programa para resolver el ejercicio (1 punto)
•	Se resuelve el problema correctamente sin desperdiciar iteraciones (4 puntos)
•	Si el programa no compila, se calificará sobre la mitad de la nota

*/

