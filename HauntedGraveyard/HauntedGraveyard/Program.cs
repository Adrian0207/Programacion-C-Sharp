using System;
using System.Collections.Generic;

namespace Dijkstras
{
    class Graph
    {
        Dictionary<char, Dictionary<char, int>> vertices = new Dictionary<char, Dictionary<char, int>>();

        public void add_vertex(char name, Dictionary<char, int> edges)
        {
            vertices[name] = edges;
        }

        public List<char> shortest_path(char start, char finish)
        {
            var previous = new Dictionary<char, char>();
            var distances = new Dictionary<char, int>();
            var nodes = new List<char>();

            List<char> path = null;

            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<char>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return path;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Graph g = new Graph();
            g.add_vertex('A', new Dictionary<char, int>() { { 'B', 7 }, { 'C', 8 } });
            g.add_vertex('B', new Dictionary<char, int>() { { 'A', 7 }, { 'F', 2 } });
            g.add_vertex('C', new Dictionary<char, int>() { { 'A', 8 }, { 'F', 6 }, { 'G', 4 } });
            g.add_vertex('D', new Dictionary<char, int>() { { 'F', 8 } });
            g.add_vertex('E', new Dictionary<char, int>() { { 'H', 1 } });
            g.add_vertex('F', new Dictionary<char, int>() { { 'B', 2 }, { 'C', 6 }, { 'D', 8 }, { 'G', 9 }, { 'H', 3 } });
            g.add_vertex('G', new Dictionary<char, int>() { { 'C', 4 }, { 'F', 9 } });
            g.add_vertex('H', new Dictionary<char, int>() { { 'E', 1 }, { 'F', 3 } });

            g.shortest_path('A', 'H').ForEach(x => Console.WriteLine(x));
            Console.ReadKey();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Collections;
//using System.Linq;
//using System.Text;

//namespace HauntedGraveyard
//{
//    class Program
//    {
//        static int[] desde;
//        static int[] hacia;
//        static int[] tiempo;
//        static int E = 0;
//        static string[] Scan(string cad)
//        {
//            string[] cadena = cad.Split(' ');
//            return cadena;
//        }
//        static void Datos()
//        {
//            string cad;
//            string[] dato; 
//            ArrayList respuesta = new ArrayList();
//            do
//            {
//                E = 0;
//                cad = Console.ReadLine().Trim();
//                if (cad.Equals("00") || cad.Equals("0 0"))
//                    break;
//                dato = Scan(cad);
//                int Ancho = Convert.ToInt32(dato[0]);
//                int Altura = Convert.ToInt32(dato[1]);
//                int tamano = Ancho * Altura;
//                bool[][] graves = Tumbas(Ancho, Altura);
//                bool[][] holes = Agujero(Ancho, Altura, ref E);
//                Console.WriteLine();
//                respuesta.Add(Adyacencia(Ancho, Altura, graves, holes, tamano, desde, hacia, tiempo, E));
//            } while (true);
//            foreach (object resp in respuesta)
//                Console.WriteLine(resp);
//        }
//        static bool[][] Tumbas(int Ancho, int Altura)
//        {
//            bool[][] grave = new bool[Ancho][];
//            for (int i = 0; i < Ancho; i++)
//                grave[i] = new bool[Altura];
//            int Grave = Convert.ToInt32(Console.ReadLine().Trim());
//            for (int i = 0; i < Grave; ++i)
//            {
//                string cad = Console.ReadLine().Trim();
//                string[] dato = Scan(cad);
//                grave[Convert.ToInt32(dato[0])][Convert.ToInt32(dato[1])] = true;
//            }
//            return grave;
//        }
//        static bool[][] Agujero(int Ancho, int Altura,ref int E)
//        {
//            desde = new int[Ancho * Altura * 4];
//            hacia = new int[Ancho * Altura * 4];
//            tiempo = new int[Ancho * Altura * 4];
//            bool[][] hole = new bool[Ancho][];
//            for (int i = 0; i < Ancho; i++)
//                hole[i] = new bool[Altura];
//            int Hole = Convert.ToInt32(Console.ReadLine().Trim());
//            for (int i = 0; i < Hole; i++)
//            {
//                string cad = Console.ReadLine().Trim();
//                string[] dato = Scan(cad);
//                hole[Convert.ToInt32(dato[0])][Convert.ToInt32(dato[1])] = true;

//                desde[E] = Convert.ToInt32(dato[0]) * Altura + Convert.ToInt32(dato[1]);
//                hacia[E] = Convert.ToInt32(dato[2]) * Altura + Convert.ToInt32(dato[3]);
//                tiempo[E] = Convert.ToInt32(dato[4]);
//                E++;
//            }
//            return hole;
//        }
//        static string Adyacencia(int Ancho, int Altura, bool[][] grave, bool[][] hole, int V, int[] desde, int[]hasta, int[] tiempo, int E)
//        {
//            int x1, y1, x2, y2;
//            int[] dirF = new int[] { -1, 1, 0, 0 };//Adyacentes en filas
//            int[] dirC = new int[] { 0, 0, -1, 1 };//Adyacentes en columnas
//            for (x1 = 0; x1 < Ancho; x1++)
//                for (y1 = 0; y1 < Altura; y1++)
//                {
//                    if (grave[x1][y1] || hole[x1][y1] || (x1 == Ancho - 1 && y1 == Altura - 1))
//                        continue;
//                    int inicia = x1 * Altura + y1;
//                    for (int k = 0; k < 4; k++)
//                    {
//                        x2 = x1 + dirF[k];
//                        y2 = y1 + dirC[k];
//                        if (x2 >= 0 && x2 < Ancho && y2 >= 0 && y2 < Altura && !grave[x2][y2])
//                        {
//                            desde[E] = inicia;
//                            hacia[E] = x2 * Altura + y2;
//                            tiempo[E] = 1;
//                            E++;
//                        }
//                    }
//                }
//            return Solucion(V, E, desde, hacia, tiempo);
//        }
//        static void Main(string[] args)
//        {
//            while (true)
//            {
//                Datos();
//                Console.ReadKey();
//            }       
//        }
//        static string Solucion(int V, int E, int[] u, int[] v, int[] w)
//        {
//            string cad = "";
//            const int INF = 10000000;
//            int[] dist = new int[V];
//            bool[] paso = new bool[V];
//            for (int i = 0; i < V; ++i)
//            {
//                dist[i] = INF;
//                paso[i] = false;
//            }
	
//            dist[0] = 0; paso[0] = true;

//            for (int i = 1; i < V; i++)
//                for (int j = 0; j < E; j++)
//                    if (dist[u[j]] + w[j] < dist[v[j]])
//                    {
//                        if (paso[u[j]])
//                            paso[v[j]] = true;
//                        dist[v[j]] = dist[u[j]] + w[j];
//                    }

//            for (int i = 0; i < E; i++) 
//                if (paso[u[i]] && dist[u[i]] + w[i] < dist[v[i]])
//                {
//                    cad = "Never\n";
//                    return cad;
//                }
//            if (!paso[V - 1])
//                cad = "Impossible\n";
//            else
//                cad = (dist[V - 1] + "\n");
//            return cad;
//        }
//    }
//}
