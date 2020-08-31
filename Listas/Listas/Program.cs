using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    public class Node
    {
        public object Element;
        public Node Link;
        public Node()
        {
            Element = null;
            Link = null;
        }
        public Node(object TheElement)
        {
            Element = TheElement;
            Link = null;
        }
    }
    public class LinkedList
    {
        protected Node header;
        public LinkedList()
        {
            header = new Node("Header");
        }
        private Node Find(object item)
        {
            Node current = new Node();
            current = header;
            while (current.Element != item)
                current = current.Link;
            return current;
        }
        private Node FindPrevious(object n)
        {
            Node current = header;
            while (current.Link != null && current.Link.Element != n)
                current = current.Link;
            return current;
        }
        public void InsertAfter(object newItem, object after)
        {
            Node current = new Node();
            Node newNode = new Node(newItem);
            current = Find(after);
            newNode.Link = current.Link;
            current.Link = newNode;
        }
        public void InsertBefore(object newItem, object before)
        {
            Node current = new Node();
            Node newNode = new Node(newItem);
            current = FindPrevious(before);
            newNode.Link = current.Link;
            current.Link = newNode;
        }
        public void InsertFirst(object newItem)
        {
            Node current = new Node();
            Node newNode = new Node(newItem);
            current = header;
            newNode.Link = current.Link;
            current.Link = newNode;
        }

        public void Remove(object n)
        {
            Node p = FindPrevious(n);
            if (p.Link != null)
                p.Link = p.Link.Link;
        }
        public void RemoveLast()
        {
            Node current = new Node();
            current = header;
            while (current.Link != null)
                current = current.Link;
            this.Remove(current.Element);
        }
        public void RemoveFirst()
        {
            Node current = new Node();
            current = header;
            this.Remove(current.Link.Element);
        }
        public void PrintList()
        {
            Node current = new Node();
            current = header;
            while (current.Link != null)
            {
                Console.WriteLine(current.Link.Element.ToString());
                current = current.Link;
            }
        }
    }
    public class Actividad : IComparable
    {
        public string Nombre;
        public int ID;
        public string Tipo;
        public int TiempoEstimado;
        public string Estado;
        public Actividad(string nombre, int id, string tipo, int tiempo, string estado)
        {
            Nombre = nombre;
            ID = id;
            Tipo = tipo;
            TiempoEstimado = tiempo;
            Estado = estado;
        }
        public int CompareTo(object obj)
        {
            Actividad aux = (Actividad)obj;
            return this.ID.CompareTo(aux.ID);
        }
        public override string ToString()
        {
            return "\tNombre: " + Nombre + "\tID: " + ID + "\tTipo: " + Tipo + "\tTiempo: " + TiempoEstimado + "\tEstado:" + Estado;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Console.SetWindowSize(120, 30);
            LinkedList L1 = new LinkedList();
            Actividad n1 = new Actividad("Winrar", 12, "Manual", r.Next(10,60), "Pendiente");
            Actividad n2 = new Actividad("Sky", 11, "Manual", r.Next(10, 60), "Concluido");
            Actividad n3 = new Actividad("Chrome", 12, "Auto", r.Next(10, 60), "Pendiente");
            Actividad n4 = new Actividad("Word", 22, "Manual", r.Next(10, 60), "Concluido");
            Actividad n5 = new Actividad("Lol", 33, "Auto", r.Next(10, 60), "Pendiente");

            L1.InsertAfter(n1, "Header");
            L1.InsertAfter(n2, "Header");
            L1.InsertAfter(n3, "Header");
            L1.InsertAfter(n4, "Header");
            L1.InsertAfter(n5, "Header");

            //L1.InsertFirst(n2);
            L1.InsertBefore(n3, n2);
            //L1.InsertFirst(n3);
            //L1.InsertAfter(n1, n3);
            //L1.RemoveLast();
            //L1.RemoveFirst();

           
            Console.WriteLine("La Lista Enlazada Queda: ");

            L1.PrintList();

            Console.WriteLine(n2.CompareTo(n1));
            Console.WriteLine(n2.CompareTo(n2));
            Console.WriteLine(n2.CompareTo(n3));

            Console.ReadLine();
        }
    }
}
