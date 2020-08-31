using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;
namespace Clases
{
    class nodo
    {
        protected string contenido;
        protected nodo siguiente;
        protected ArrayList Arreglo;

        public nodo()
        {
            this.contenido = null;
            this.siguiente = null;
        }

        public nodo(string dato)
        {
            this.contenido = dato;
            this.siguiente = null;
        }

        public bool estaVacia()
        {
            if (this.siguiente == null && this.contenido == null)
                return true;
            else
                return false;
        }

        public void Push(string dato)
        {
            nodo ap = this;
            nodo nuevo;
            if (estaVacia())
                contenido = dato;
            else
            {
                nuevo = new nodo(dato);
                while (ap.siguiente != null)
                    ap = ap.siguiente;
                ap.siguiente = nuevo;
            }//end if
        }//end push

        public string Pop()
        {
            string retorno = null;
            nodo ap;
            nodo ap1;
            if (!estaVacia())
            {
                if (!estaVacia() && this.siguiente == null)
                {
                    retorno = this.contenido;
                    this.contenido = null;
                }
                else
                {
                    ap = this.siguiente;
                    ap1 = this;
                    while (ap.siguiente != null)
                        ap = ap.siguiente;
                    while (ap1.siguiente != ap)
                        ap1 = ap1.siguiente;
                    ap1.siguiente = null;
                    retorno = ap.contenido;
                }
            }// end if
            else
            {
                Console.WriteLine("Pop Invalido");
                retorno = null;
            }
            return retorno;
        }//end Pop

        public int Contar()
        {
            nodo ap = this;
            int c = 1;
            if (ap.contenido == null)
                c = 0;
            while (ap.siguiente != null)
            {
                ap = ap.siguiente;
                c++;
            }
            return c;
        }
        public void DesplegarCola()
        {
            nodo ap = this;
            nodo ap1 = this;
            if (estaVacia())
                Console.WriteLine("Desplegar invalido, cola vacia");
            else
            {
                if (ap.siguiente == null)
                    Console.Write(ap.contenido);
                else
                {
                    while (ap.siguiente != null)
                        ap = ap.siguiente;
                    Console.Write(ap.contenido + "->");
                    while (ap1.siguiente != ap && ap1.siguiente != null)
                        ap1 = ap1.siguiente;
                    Console.Write(ap1.contenido);
                    ap = this;
                    for (int i = Contar() - 2; i > 0; i--)
                    {
                        while (ap.siguiente != ap1 && ap.siguiente != null)
                            ap1 = ap1.siguiente;
                        if (i != 0)
                            Console.Write("->");
                        Console.Write(ap.contenido);
                        ap1 = ap;
                    }//end for
                }
                Console.WriteLine();
            }//end else
        }// end DesplegarCola
        public void DesplegarFifo()
        {
            nodo ap = this;
            nodo ap1 = this;
            if (estaVacia())
                Console.WriteLine("Desplegar invalido, cola vacia");
            else
            {
                if (ap1.siguiente == null)
                    Console.Write(ap1.contenido);
                else
                {
                    while (ap.siguiente != null)
                    {
                        Console.Write(ap.contenido + "->");
                        ap = ap.siguiente;
                    }
                    Console.Write(ap.contenido);
                }
                Console.WriteLine();
            }//end else

        }

    }// en nodo
}
namespace StackNodo
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arr = new ArrayList();
            nodo n1 = new nodo();
            arr.Add("Primero elemento");
            arr.Add("Segundo elemento");
            arr.Add("Tercero elemento");

            n1.Push("Primero elemento");
            n1.Push("Segundo elemento");
            n1.Push("Tercero elemento");

            n1.DesplegarCola();
            n1.DesplegarFifo();
            n1.Pop();
            n1.DesplegarCola();
            n1.DesplegarFifo();
            n1.Pop();
            n1.DesplegarCola();
            n1.DesplegarFifo();
            n1.Pop();
            Console.ReadLine();
            //n1.Pop();
            Console.ReadLine();
        }   
    }
}
