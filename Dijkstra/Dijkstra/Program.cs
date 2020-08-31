using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList vertices = Vertices();
            Dictionary<char, Dictionary<char, int>> coneccion = Coneccion(vertices);//clase dictionary usa claves y valores para recoger los datos adyacentes 
            char inicio = (char)coneccion.First().Key;//elemento del que partimos
            char ultimo = (char)coneccion.Last().Key;//elelemnto de llegada
            Dijkstra(inicio, ultimo, coneccion);
            Console.ReadKey();
        }
        static ArrayList Vertices()
        {
            ArrayList vertices = new ArrayList();
            Console.WriteLine("Ingreso de vértices.");
            int cont = 1;
            while (true)
            {
                try
                {
                    if (cont == 6)
                        break;
                    Console.Write("Ingrese identificador de vértice: ");
                    char a = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    
                    if (a != ';' && (char.IsLetter(a) || char.IsDigit(a)) && !vertices.Contains(a))
                        vertices.Add(a);
                    else if (vertices.Contains(a))
                        Console.WriteLine("Caracter duplicado detectado: {0} , ingreso no efectuado.", a);
                    else
                        break;
                    cont++;
                }
                catch (Exception e)
                {
                    Console.Write("Excepción en ingreso encontrada: ");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\n\t\tFinalizando ingreso de vertices.\n");
                    break;
                }
            }
            return vertices;
        }
        static Dictionary<char, Dictionary<char, int>> Coneccion(ArrayList vertices)
        {
            Dictionary<char, Dictionary<char, int>> coneccion = new Dictionary<char, Dictionary<char, int>>();
            Dictionary<char, int> valor;
            foreach (char item in vertices)
            {
                int k = 0;
                valor = new Dictionary<char, int>();
                Console.Write("N° de vertices adyacentes a {0}: ", item);
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Adyacente: ");
                    char ady = Console.ReadKey().KeyChar;
                    while (!vertices.Contains(ady)|| ady.Equals(vertices[k]))
                    {
                        Console.WriteLine("\nEl vértice ingresado está incorrecto");
                        Console.Write("\nIngrese el vértice de destino para la conexión de {0}: ", item);
                        ady = Console.ReadKey().KeyChar;
                    }
                    Console.WriteLine();
                    Console.Write("Peso de {0} a {1}: ", item, ady);
                    int peso = Convert.ToInt32(Console.ReadLine());
                    while (peso < 0)
                    {
                        Console.WriteLine("\nPeso ingresado para la conexión está incorrecto");
                        Console.WriteLine("\nIngrese el peso de para la conexión {0} a {1} nuevamente:  ", item, ady);
                        peso = Convert.ToInt32(Console.ReadLine());
                    }
                    valor.Add(ady, peso);
                }
                k++;
                Console.WriteLine();
                coneccion.Add(item, valor);
            }
            return coneccion;
        }
        static void Dijkstra(char inicio, char ultimo, Dictionary<char, Dictionary<char, int>> coneccion)
        {
            var anterior = new Dictionary<char, char>();
            var distancia = new Dictionary<char, int>();
            var nodes = new List<char>();

            ArrayList path = default(ArrayList);

            foreach (var vertex in coneccion)
            {
                if (vertex.Key == inicio)
                {
                    distancia[vertex.Key] = 0;
                }
                else
                {
                    distancia[vertex.Key] = int.MaxValue;
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distancia[x] - distancia[y]);//se ordena los vertices 

                var menor = nodes[0];
                nodes.Remove(menor);

                if (menor == ultimo)
                {
                    path = path = new ArrayList();
                    while (anterior.ContainsKey(menor))
                    {
                        path.Add(menor);
                        menor = anterior[menor];
                    }

                    break;
                }

                if (distancia[menor] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in coneccion[menor])
                {
                    var alt = distancia[menor] + neighbor.Value;
                    if (alt < distancia[neighbor.Key])
                    {
                        distancia[neighbor.Key] = alt;
                        anterior[neighbor.Key] = menor;
                    }
                }
            }
            path.Reverse();
            Console.Write("Recorrido: " + inicio + " ");
            foreach (var item in path)
            {
                Console.Write(item + " ");
            }
           
        }       
    }
}
