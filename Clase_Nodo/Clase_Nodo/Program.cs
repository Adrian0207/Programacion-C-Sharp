﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using CallCenter;

namespace CallCenter
{
    class Nodo
    {
        public Llamada_Entrada contenido;
        public Nodo siguiente;

        public Nodo()
        {
            contenido = default(Llamada_Entrada);
            siguiente = null;
        }
        public Nodo(Llamada_Entrada dato)
        {
            contenido = dato;
            siguiente = null;
        }

        public IEnumerator GetEnumerator()
        {
            return (new NodoEnumerator(this));
        }

        public bool estaVacia()
        {
            if (contenido.Equals(default(Llamada_Entrada)) && siguiente == null)
                return true;
            return false;
        }
        public int Contar()
        {
            int total = 0;
            Nodo ap = this;
            if (!estaVacia())
            {
                while (ap != null)
                {
                    total++;
                    ap = ap.siguiente;
                }
            }
            return total;
        }
        public void Enqueue(Llamada_Entrada dato)
        {
            Nodo ap = this;
            Nodo ap1 = this;

            if (estaVacia())
                this.contenido = dato;
            else
            {
                Nodo nuevo = new Nodo(this.contenido);
                nuevo.siguiente = this.siguiente;
                this.siguiente = nuevo;
                this.contenido = dato;
            }
        }
        public Llamada_Entrada Dequeue()
        {
            Nodo ap = this;
            Nodo ap1 = this.siguiente;
            Llamada_Entrada retorno = default(Llamada_Entrada);
            if (!estaVacia())
            {
                if (this.siguiente == null)
                {
                    retorno = this.contenido;
                    this.contenido = default(Llamada_Entrada);
                }
                else
                {
                    while (ap1.siguiente != null)
                    {
                        ap1 = ap1.siguiente;
                        ap = ap.siguiente;
                    }
                    retorno = ap1.contenido;
                    ap.siguiente = null;
                }
            }
            else
            {
                Console.WriteLine("Error en el Dequeue,cola esta vacia");
                retorno = default(Llamada_Entrada);
            }
            return retorno;
        }
        public Llamada_Entrada Peek()
        {
            Llamada_Entrada retorno = default(Llamada_Entrada);
            Nodo ap = this;
            while (ap.siguiente != null)
            {
                ap = ap.siguiente;
                retorno = ap.contenido;
            }
            return retorno;
        }
        public bool Contains(Llamada_Entrada dato)
        {
            Nodo ap = this;
            bool retorno = false;
            while (ap.siguiente != null)
            {
                if (ap.contenido.Equals(dato))
                {
                    retorno = true;
                    break;
                }
                ap = ap.siguiente;
            }
            if (ap.contenido.Equals(dato))
                retorno = true;
            return retorno;
        }
        public void DesplegarCola()
        {
            Nodo ap = this;
            if (!estaVacia())
            {
                if (this.siguiente == null)
                {
                    Console.WriteLine(this.contenido.ToString());
                }
                else
                {
                    while (ap.siguiente != null)
                    {
                        Console.Write(ap.contenido.ToString() + " -> ");
                        ap = ap.siguiente;
                    }
                    Console.Write(ap.contenido.ToString() + "\n");
                }
            }
            else
            {
                Console.WriteLine("Cola Vacia");
            }
        }      
    }
    class NodoEnumerator : IEnumerator
    {
        Nodo Current;
        Nodo ap1;

        object IEnumerator.Current
        {
            get { return Current; }
        }
        public NodoEnumerator(Nodo n)//constructor
        {
            Current = null;
            ap1 = n;
        }
        public bool MoveNext()
        {
            if (Current == null)
            {
                Current = ap1;
                return true;
            }
            if (Current.siguiente != null)
            {
                Current = Current.siguiente;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            Current = null;
        }

    }
    struct Llamada_Entrada
    {
        string Nombre;
        string HoraLlamada;
        string Tema;
        public Llamada_Entrada(string name, string time, string tema)
        {
            Nombre = name;
            HoraLlamada = time;
            Tema = tema;
        }
        public override string ToString()
        {
            return (String.Format("{0}-{1}-{2}", Nombre, HoraLlamada, Tema));
        }
    }
}
namespace Clase_Nodo
{
    
    class Program
    {
        static void Main(string[] args)
        {           
            Nodo n1 = new Nodo();
            Llamada_Entrada l1;

            l1 = new Llamada_Entrada("Amanda", "10:30AM", "Queja");
            n1.Enqueue(l1); 

            l1 = new Llamada_Entrada("Frank", "11:30AM", "Solicitud");
            n1.Enqueue(l1);  

            l1 = new Llamada_Entrada("Kevin", "11:45AM", "Servicio");
            n1.Enqueue(l1);  

            l1 = new Llamada_Entrada("Frank", "12:30PM", "Solicitud");            
            n1.Enqueue(l1);  

            n1.DesplegarCola();
            Console.ReadLine();
            n1.Dequeue();
            n1.DesplegarCola();
            Console.ReadLine();
            n1.Dequeue();
            n1.DesplegarCola();
            Console.ReadLine();
            n1.Dequeue();
            n1.DesplegarCola();
            Console.ReadLine();

        }
    }
}

