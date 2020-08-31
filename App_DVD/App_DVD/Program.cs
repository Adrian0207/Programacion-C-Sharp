using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;//libreria para trabajo con archivos
using System.Threading;

namespace App_DVD
{
    public class Rockola : IEnumerable
    {
        private LinkedList<String> MLista;
        private LinkedListNode<String> NodoF;
        private String Path;

        public Rockola(string pth)
        {
            this.MLista = new LinkedList<string>();
            this.NodoF = default(LinkedListNode<string>);
            this.Path = pth;
        }
        public String Ruta
        {
            get { return Path; }
            set { Path = value; }
        }
        public LinkedList<String> Lista
        {
            get { return MLista; }
            set { MLista = value; }
        }
        public LinkedListNode<String> Nodo
        {
            get { return NodoF; }
            set { NodoF = value; }
        }

        public void AddMusic(string musica)
        {
            MLista.AddLast(musica);
            NodoF = MLista.First;
        }
        public IEnumerator GetEnumerator()
        {
            return MLista.GetEnumerator();
        }      
    }
    class Program
    {
        static void Play(Rockola r, Process p, string cancion)
        {
            p.StartInfo.Arguments = "\"" + r.Ruta + "\\" + cancion + "\"";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            Console.Clear();
            Menu2("Tocando: " + cancion, p);
        }
        static string Adelante(Rockola r, string a)
        {
            r.Nodo = r.Nodo.Next;
            a = r.Nodo.Value;
            return a;
        }
        static string Retroceder(Rockola r, string a)
        {
            r.Nodo = r.Nodo.Previous;
            a = r.Nodo.Value;
            return a;
        }
        static void Menu()
        {
            int i = 0;
            ConsoleKeyInfo op;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetWindowSize(42, 20);
                Console.SetBufferSize(42, 20);
                Console.WriteLine("");
                Console.WriteLine("         ██ █ █ █ █ █ █ █");
                Console.WriteLine("        █                █");
                Console.WriteLine("       █ ████████████████ █       ♥");
                Console.WriteLine("      █ █                █ █      ♫ ♥");
                Console.WriteLine("     █ █                  █ █      ♫ ♥ ♫");
                Console.WriteLine("    █ █                    █ █      ♥ ♫ ♫");
                Console.WriteLine("   █ █      ██              █ █    ♫ ♥ ♫ ");
                Console.WriteLine("  █ █      ████     ██       █ █  ♫ ♥ ♫");
                Console.WriteLine(" ██ █      ████    ████      █ ██  ♥ ♫ ");
                Console.WriteLine("███ █       ██      ██       █ ███");
                Console.WriteLine(" ██ █                        █ ██");
                Console.WriteLine("  █ █     ██          ██     █ █");
                Console.WriteLine("     █     ██        ██     █");
                Console.WriteLine("      █      █████████     █");
                Console.WriteLine("       █                  █");
                Console.WriteLine("        █                █");
                Console.WriteLine("         ████████████████");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("      Espere mientras se carga.");
                Thread.Sleep(750);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");
                Console.WriteLine("         ██ █ █ █ █ █ █ █");
                Console.WriteLine("        █                █");
                Console.WriteLine("       █ ████████████████ █       ♫");
                Console.WriteLine("      █ █                █ █      ♥ ♫");
                Console.WriteLine("     █ █                  █ █      ♥ ♫ ♥ ");
                Console.WriteLine("    █ █                    █ █      ♫ ♥ ♥");
                Console.WriteLine("   █ █              ██      █ █    ♥ ♫ ♥");
                Console.WriteLine("  █ █       ██     ████      █ █  ♥ ♫ ♥");
                Console.WriteLine(" ██ █      ████    ████      █ ██  ♫ ♥");
                Console.WriteLine("███ █       ██      ██       █ ███");
                Console.WriteLine(" ██ █                        █ ██");
                Console.WriteLine("  █ █     ██          ██     █ █");
                Console.WriteLine("     █     ██        ██     █");
                Console.WriteLine("      █      █████████     █");
                Console.WriteLine("       █                  █");
                Console.WriteLine("        █                █");
                Console.WriteLine("         ████████████████");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("      Espere mientras se carga..");
                Thread.Sleep(750);
                Console.Clear();
                i++;
            } while (i != 5);
            do
            {
                Console.Clear();
                Console.SetCursorPosition(10, 9);
                Console.WriteLine("QUE EMPIEZE LA MÚSICA");
                Console.SetCursorPosition(6, 10);
                Console.WriteLine("Presiona [Enter] para continuar");
                op = Console.ReadKey();
            } while (op.Key != ConsoleKey.Enter);
            Console.Clear();
        }
        static void Menu2(string msg, Process p)
        {
            int i = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═══╗    ╔═══╗    ╔═══╗  ♫");
                Console.WriteLine("║███║    ║███║♫   ║███║♫");
                Console.WriteLine("║(o)║    ║(o)║♫   ║(o)║♫");
                Console.WriteLine("╚═══╝    ╚═══╝    ╚═══╝  ♫");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(msg);
                Thread.Sleep(750);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═══╗  ♫ ╔═══╗    ╔═══╗");
                Console.WriteLine("║███║♫   ║███║♫   ║███║");
                Console.WriteLine("║(o)║♫   ║(o)║♫   ║(o)║");
                Console.WriteLine("╚═══╝ ♫  ╚═══╝    ╚═══╝");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(msg);
                Thread.Sleep(750);
                Console.Clear();
                i++;
            } while (i != 3);          
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo op, op1;
            int ta = 0; // tamaño para consola cuando liste
            string dir = @"C:\Program Files (x86)\Webteh\BSPlayer\bsplayer.exe";// direccion donde esta el programa, dejar el @
            string ruta = @"E:/musica";// carpeta donde esta la musica, dejar el @
            Process proceso = new Process();
            proceso.StartInfo.FileName = (dir);
            Rockola rock = new Rockola(ruta);;
            DirectoryInfo di = new DirectoryInfo(ruta);//archivos en la ruta// permite trabajar con archivos de una direccion
            foreach (var fi in di.GetFiles())// devuelve los archivos de direccion
            {
                if (fi.Extension.Contains(".mp"))//solo agrega si la extension es .mp
                {
                    rock.AddMusic(fi.Name);//agregando a la lista
                    ta++;
                }
            }
            string actual = rock.Nodo.Value.ToString();
            Menu();          
            do
            {               
                Console.Clear();
                Console.SetWindowSize(60, 10);//tamaño de consola
                Console.SetBufferSize(60, 10);//tamaño del buffer
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Canción Actual: " + actual.Remove(actual.IndexOf(".mp")).Replace("_", " "));//cancion a reproducir
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nReproducir [Enter]\nListar [Espacio]\nAvanzar [Flecha -►]\nRetroceder [Flecha ◄-]\nReproduccion Continua [C]\nRandom [R]\n\nSalir [Esc]");
                op = Console.ReadKey();
                switch (op.Key)
                {
                    case ConsoleKey.Enter://reproduciendo
                        {
                            Play(rock, proceso, actual);
                            break;
                        }
                    case ConsoleKey.Spacebar://listando
                        {
                            ta = ta + 3;
                            do
                            {
                                if (ta > 58)//si el tamaño de la lista es mayor 
                                {
                                    Console.SetWindowSize(60, 58);// el tamaño se reduce pero la lista queda completa
                                    Console.SetBufferSize(60, ta);// el tamaño del buffer permitira ver toda la lista solo con subir la barra
                                }
                                else
                                    Console.SetWindowSize(60, ta);//sino solo tendra su tamaño de lista + 3
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                foreach (string s in rock)//listando con el objeto 
                                    Console.WriteLine(s.Remove(s.IndexOf(".mp")).Replace("_", " "));//remueve la extension .mp y los guiones por espacios, si esque lo tienen y presenta por pantalla
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\nPresione [Esc] para salir");
                                op1 = Console.ReadKey();
                            } while (op1.Key != ConsoleKey.Escape);
                            break;
                        }
                    case ConsoleKey.RightArrow://avanzando
                        {
                            try
                            {
                                actual = Adelante(rock, actual);
                                break;
                            }
                            catch (Exception)
                            {
                                rock.Nodo = rock.Lista.First;//apunta al ultimo 
                                actual = rock.Nodo.Value;
                                break;
                            }
                        }
                    case ConsoleKey.LeftArrow://retrocediendo
                        {
                            try
                            {
                                actual = Retroceder(rock, actual);
                                break;
                            }
                            catch (Exception)
                            {
                                rock.Nodo = rock.Lista.Last;//apunta al primero
                                actual = rock.Nodo.Value;
                                break;
                            }
                        }
                    case ConsoleKey.C://continuo
                        {
                            try
                            {
                                rock.Nodo = rock.Lista.First;
                                actual = rock.Nodo.Value;
                                foreach (string c in rock)
                                {
                                    Play(rock, proceso, actual);
                                    proceso.WaitForExit();//espera a que el programa se cierre 
                                    actual = Adelante(rock, actual);
                                }
                                break;
                            }
                            catch (Exception)
                            {
                                rock.Nodo = rock.Lista.First;// cuando se acabe, appuntara al primero
                                actual = rock.Nodo.Value;
                                break;
                            }
                        }
                    case ConsoleKey.R:
                        {
                            Random r = new Random();
                            int n = r.Next(0, rock.Lista.Count - 1);
                            actual = rock.Lista.ElementAt(n);
                            Play(rock, proceso, actual);
                            break;
                        }
                    case ConsoleKey.Escape://salida
                        {
                            Console.Clear();
                            Console.SetWindowSize(37, 8);//tamaño de consola
                            Console.SetBufferSize(37, 8);//tamaño del buffer
                            Menu2("Aun queda más musica por escuchar :)",proceso);
                            break;
                        }
                }
            } while (op.Key != ConsoleKey.Escape);
        }
    }
}
