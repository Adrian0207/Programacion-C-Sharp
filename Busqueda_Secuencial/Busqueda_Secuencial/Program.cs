using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Busqueda_Secuencial
{
    class Lista
    {
        private string elemento;
        private Lista sig;
        public Lista(string dato = null)//constructor
        {
            elemento = dato;
            sig = null;
        }

        public bool Vacia()//detecta si esta vacio
        {
            if (elemento == null && sig == null)
                return true;
            else
                return false;
        }
        public string Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }// propertys para usar las propiedades de la lista
        public Lista Siguiente
        {
            get { return sig; }
            set { sig = value; }
        }//avanza
        public ArrayList toArray()
        {
            Lista ap = this;
            ArrayList arr = new ArrayList();
            while (ap != null)
            {
                arr.Add(ap.elemento);
                ap = ap.sig;
            }

            return arr;
        }//comvierte en un arraylist
        public void Agregar(string dato)
        {
            Lista nuevo, ap;
            if (Vacia())
                this.elemento = dato;
            else
            {
                nuevo = new Lista(dato);
                ap = this;
                while (ap.sig != null)
                    ap = ap.sig;
                ap.sig = nuevo;
            }
        }//agrega un elemtno y si hay mas elementos los encadena
        public void Buscar(string item)
        {
            Lista ap = this;
            while (ap.elemento != item && ap.sig != null)
                ap = ap.sig;
            if (ap.elemento == item)
                Console.WriteLine("El elemento {0} SI existe en la lista", item);
            else
                Console.WriteLine("El elemento {0} NO existe en la lista", item);
        }//busca coincidencias
        public void Buscar_posicion(string item)
        {
            int count = 1;
            Lista ap = this;
            if (!Vacia())
                while (ap.elemento != item && ap.sig != null)
                {
                    ap = ap.sig;
                    count++;
                }
            if (ap.elemento == item)
                Console.WriteLine("El elemento {0} SI existe en la lista en el nodo {1}", item, count);
            else
                Console.WriteLine("El elemento {0} NO existe en la lista", item);
        }
        public void BuscarTodo(string item)
        {
            int count = 0;
            ArrayList arr = this.toArray();
            Console.Write("El elemento se encuentra en el nodo: ");
            for (int i = 0; i < arr.ToArray().Length; i++)
            {
                if (arr[i].Equals(item))
                {
                    Console.Write(i + " ");
                    count++;
                }
            }
            Console.WriteLine("\nEl elemento {0} se repite {1} veces", item, count);
        }
        public void Buscar_Nodo_Ocurrencia(string buscar)
        {
            Lista lis = this;
            int pos = 1;
            if (!Vacia())
            {
                while (lis != null)
                {
                    if (lis.Elemento.Contains(buscar))
                    {
                        Console.WriteLine("'{0}' -> ESTA en el nodo {1}", buscar, pos);
                        break;
                    }
                    lis = lis.Siguiente;
                    pos++;
                }
                if (lis == null)
                    Console.WriteLine("'{0}' -> NO ESTA en el nodo", buscar);
            }
        }
        public int Contar
        {
            get
            {
                Lista ap = this;
                int count = 0;
                if (!Vacia())
                {
                    while (ap != null)
                    {
                        ap = ap.sig;
                        count++;
                    }
                }
                return count;
            }

        }//property para contar
        public string EliminarUltimo()
        {
            Lista ap;
            string retorno = null;
            if (!Vacia())
            {
                ap = this;
                if (Contar >= 2)
                {
                    while (ap.sig.sig != null)
                        ap = ap.sig;
                    retorno = ap.sig.elemento;
                    ap.sig = null;
                }
                else
                {
                    retorno = elemento;
                    elemento = null;
                }
            }
            return retorno;
        }
        public void DesplegarLista()
        {
            Lista ap = this;
            if (!Vacia())
                if (ap.sig == null)
                    Console.WriteLine(ap.elemento);
                else
                {
                    while (ap.sig != null)
                    {
                        Console.Write(ap.elemento + "-> ");
                        ap = ap.sig;
                    }
                    Console.Write(ap.elemento);
                }
            else
                Console.WriteLine("Lista vacia");
        }
        public Lista AntesDe(string buscado)
        {
            Lista ap = this;
            while (ap.sig != null && ap.sig.elemento != buscado)
                ap = ap.sig;
            return ap;

        }
        public void InsertarAntes(string item, string anterior)
        {
            Lista ap;
            Lista nuevo = new Lista(item);
            ap = AntesDe(anterior);
            if (ap.sig != null)
            {
                nuevo.sig = ap.sig;
                ap.sig = nuevo;
            }
            else
                Console.WriteLine("No existe el Nodo anterior");
        }
        public void Insertar_posicion(int posicion, string item)
        {
            Lista ap = this;
            Lista nuevo = new Lista(item);

            if (posicion == 0)
            {

                ArrayList aux = new ArrayList();
                aux = this.toArray();
                foreach (string nodo in aux)
                {
                    nuevo.Agregar(nodo);

                }
                this.elemento = nuevo.elemento;
                this.sig = nuevo.sig;

            }
            else
            {
                if (!Vacia() && posicion < Contar)
                {
                    for (int i = 0; i < posicion; i++)
                        ap = ap.sig;
                    nuevo.sig = ap.sig;
                    ap.sig = nuevo;
                }
            }
        }
    }
    class Program
    {
        public static Lista Llenar(Lista lista)
        {
            ConsoleKeyInfo op;
            bool salir = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese la cadena: ");
                string cad = Console.ReadLine();
                lista.Agregar(cad);
                do
                {
                    Console.WriteLine("Desea agregar otra cadena?(s/n)");
                    op = Console.ReadKey();
                    if (op.Key == ConsoleKey.N)
                    {
                        salir = true;
                        break;
                    }
                    else if (op.Key == ConsoleKey.S)
                        salir = false;
                    else
                        salir = true;
                    Console.Clear();
                } while (salir);
            } while (!salir);
            return lista;
        }//opcion 1

        static void Main(string[] args)
        {
            ConsoleKeyInfo menu = default(ConsoleKeyInfo), op;//para uso del menu
            int pausa = 100;//pausa
            string cad;//cadena de strings
            Lista MiLista = new Lista();
            do
            {
                try
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Presione: \n\nLlenar Lista -> [A]\n\nVer Lista -> [S]\n\nInsertar un nodo antes de otro conocido -> [D]");
                    Console.WriteLine("\nInsertar un nodo en una posición dada -> [F]\n\nBuscar la primera ocurrencia de una cadena -> [G]");
                    Console.WriteLine("\nBuscar la primera ocurrencia de una cadena \ne indicar en qué nodo de la lista se encuentra -> [H]");
                    Console.WriteLine("\nBuscar todas las ocurrencias de una cadena \ne indicar cuántas ocurrencias existen y en qué nodos se ubican -> [J]");
                    Console.WriteLine("\nBuscar la primera ocurrencia de una cadena\no sub-string de una cadena e indicar en qué nodo se encuentra -> [K]");
                    Console.WriteLine("\nSalir -> [ESC]");
                    menu = Console.ReadKey();
                    switch (menu.Key)
                    {
                        case ConsoleKey.A:
                            {
                                Thread.Sleep(pausa);
                                Llenar(MiLista);
                                break;
                            }
                        case ConsoleKey.S:
                            {
                                do
                                {
                                    Console.Clear();
                                    MiLista.DesplegarLista();
                                    Console.WriteLine("\nPresione [Espacio] para salir");
                                    op = Console.ReadKey();
                                } while (op.Key != ConsoleKey.Spacebar);//lo hace hasta que el usuario presione espacio
                                break;

                            }
                        case ConsoleKey.D:
                            {
                                if (!MiLista.Vacia())
                                {
                                    Thread.Sleep(pausa);
                                    Console.Clear();
                                    Console.WriteLine("Ingrese una nueva cadena: ");
                                    cad = Console.ReadLine();
                                    Console.WriteLine("Ingrese el elemento anterior: ");
                                    string anterior = Console.ReadLine();
                                    MiLista.InsertarAntes(cad, anterior);// ingresa una cadena en un elemnto anterior
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lista vacia");
                                    Thread.Sleep(2000);
                                }

                                break;
                            }
                        case ConsoleKey.F:
                            {

                                if (!MiLista.Vacia())
                                {
                                    Thread.Sleep(pausa);
                                    Console.Clear();
                                    Console.Write("Ingrese una nueva cadena: ");
                                    cad = Console.ReadLine();
                                    Console.Write("Ingrese la posición entre 0 y {0}: ", MiLista.Contar - 1);
                                    byte pos = Convert.ToByte(Console.ReadLine());
                                    MiLista.Insertar_posicion(pos, cad);//ingresa la cadena en una posicion
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lista vacia");
                                    Thread.Sleep(2000);
                                }
                                break;
                            }
                        case ConsoleKey.G:
                            {
                                if (!MiLista.Vacia())
                                {
                                    Thread.Sleep(pausa);
                                    Console.Clear();
                                    Console.Write("¿Qué elemento desea buscar?: ");
                                    cad = Console.ReadLine();
                                    do
                                    {
                                        Console.Clear();
                                        MiLista.Buscar(cad);
                                        Console.WriteLine("\nPresione [Espacio] para salir");
                                        op = Console.ReadKey();
                                    } while (op.Key != ConsoleKey.Spacebar);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lista vacia");
                                    Thread.Sleep(2000);
                                }
                                break;
                            }
                        case ConsoleKey.H:
                            {
                                if (!MiLista.Vacia())
                                {
                                    Thread.Sleep(pausa);
                                    Console.Clear();
                                    Console.Write("¿Qué elemento desea buscar?: ");
                                    cad = Console.ReadLine();
                                    do
                                    {
                                        Console.Clear();
                                        MiLista.Buscar_posicion(cad);
                                        Console.WriteLine("\nPresione [Espacio] para salir");
                                        op = Console.ReadKey();
                                    } while (op.Key != ConsoleKey.Spacebar);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lista vacia");
                                    Thread.Sleep(2000);
                                }
                                break;
                            }
                        case ConsoleKey.J:
                            {
                                if (!MiLista.Vacia())
                                {
                                    Thread.Sleep(pausa);
                                    Console.Clear();
                                    Console.Write("¿Qué elemento desea buscar?: ");
                                    cad = Console.ReadLine();
                                    do
                                    {
                                        Console.Clear();
                                        MiLista.BuscarTodo(cad);
                                        Console.WriteLine("\nPresione [Espacio] para salir");
                                        op = Console.ReadKey();
                                    } while (op.Key != ConsoleKey.Spacebar);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lista vacia");
                                    Thread.Sleep(2000);
                                }
                                break;
                            }
                        case ConsoleKey.K:
                            {
                                if (!MiLista.Vacia())
                                {
                                    Thread.Sleep(pausa);
                                    Console.Clear();
                                    Console.Write("¿Qué elemento desea buscar?: ");
                                    cad = Console.ReadLine();
                                    do
                                    {
                                        Console.Clear();
                                        MiLista.Buscar_Nodo_Ocurrencia(cad);
                                        Console.WriteLine("\nPresione [Espacio] para salir");
                                        op = Console.ReadKey();
                                    } while (op.Key != ConsoleKey.Spacebar);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Lista vacia");
                                    Thread.Sleep(2000);
                                }
                                break;
                            }
                        case ConsoleKey.Escape://salida
                            {
                                Console.Clear();
                                Console.WriteLine("Arigato");
                                Console.WriteLine("Presiona una tecla para salir");
                                Console.ReadKey();
                                break;
                            }
                    }
                }
                catch (Exception e)// algun error que no este incluido sera capturado por el catch
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }

            } while (menu.Key != ConsoleKey.Escape);
        }
    }
}
