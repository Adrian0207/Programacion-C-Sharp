﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodoCola
{
    class Nodo
    {
        string contenido;
        Nodo siguiente;
        public Nodo()
        {
            contenido = null;
            siguiente = null;
        }
        public Nodo(string dato)
        {
            contenido = dato;
            siguiente = null;
        }
        public Nodo(ArrayList list)
        {
            Nodo ap = this;
            Nodo ap1 = this;
            int i = 0;
            foreach (var obj in list)
            {
                if (estaVacia())
                {
                    this.contenido = (string)list[i];
                }
                else
                {
                    Nodo nuevo = new Nodo(this.contenido);
                    nuevo.siguiente = this.siguiente;
                    this.siguiente = nuevo;
                    this.contenido = (string)list[i];
                }
                i++;
            }
        }
        public bool estaVacia()
        {
            if (contenido == null && siguiente == null)
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
        public void Enqueue(string dato)
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
        public string Dequeue()
        {
            Nodo ap = this;
            Nodo ap1 = this.siguiente;

            string retorno = null;
            if (!estaVacia())
            {
                if (this.siguiente == null)
                {
                    retorno = this.contenido;
                    this.contenido = null;
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
                retorno = null;
            }
            return retorno;
        }
        public string Peek()
        {
            string retorno = null;
            Nodo ap = this;
            while (ap.siguiente != null)
            {
                ap = ap.siguiente;
                retorno = ap.contenido;
            }
            return retorno;
        }
        public bool Contains(string dato)
        {
            Nodo ap = this;
            bool retorno = false;
            while (ap.siguiente != null)
            {
                if (ap.contenido == dato)
                {
                    retorno = true;
                    break;
                }
                ap = ap.siguiente;
            }
            if (ap.contenido == dato)
                retorno = true;
            return retorno;
        }
        public Array toArray()
        { 
            Nodo ap = this;
            int pos = ap.Contar() - 1;
            Array arr = Array.CreateInstance(typeof(String),ap.Contar());
            if (!estaVacia())
            {
                if (this.siguiente == null)
                {
                    arr.SetValue(this.contenido, pos);
                }
                else
                {
                    while (ap.siguiente != null)
                    {
                        arr.SetValue(ap.contenido, pos--);
                        ap = ap.siguiente;
                    }
                    arr.SetValue(ap.contenido, pos--);
                }
            }
            else
            {
                Console.WriteLine("Cola vacia");
                arr = null;
            }
            return arr;
        }
        public void DesplegarCola()
        {
            Nodo ap = this;
            if (!estaVacia())
            {
                if (this.siguiente == null)
                {
                    Console.WriteLine(this.contenido);
                }
                else
                {
                    while (ap.siguiente != null)
                    {
                        Console.Write(ap.contenido + " -> ");
                        ap = ap.siguiente;
                    }
                    Console.Write(ap.contenido + "\n");
                }
            }
            else
            {
                Console.WriteLine("Cola Vacia");
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Nodo n1 = new Nodo();           
            n1.Enqueue("dato1");
            n1.Enqueue("dato2");
            n1.Enqueue("dato3");
            Array arr = n1.toArray();

            ArrayList lista = new ArrayList();
            lista.Add("dato4");
            lista.Add("dato5");
            lista.Add("dato6");
            Nodo n2 = new Nodo(lista);

            Console.WriteLine("El dato3 esta dentro de la cola?: " + n1.Contains("dato3")); //true
            Console.WriteLine("El dato4 esta dentro de la cola?: " + n1.Contains("dato4")); //faker

            n1.DesplegarCola();
            n1.Dequeue();
            n1.Peek();
            n1.DesplegarCola();
            n1.Dequeue();
            n1.Peek();
            n1.DesplegarCola();
            n1.Dequeue();
            n1.Peek();

            Console.ReadLine();
            n1.Dequeue();
            Console.ReadLine();

        }
    }
}