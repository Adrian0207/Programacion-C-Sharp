using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

namespace Simulador_Scheduler
{
    class PQueue : Queue, IComparer
    {
        public PQueue()
            : base()
        { }
        int IComparer.Compare(object a, object b)
        {
            Proceso x = (Proceso)a;
            Proceso y = (Proceso)b;
            if (x.Privilegio > y.Privilegio)
                return -1;
            else if (x.Privilegio < y.Privilegio)
                return 1;
            else
                return 0;
        }
        public override object Dequeue()
        {
            ArrayList ar = new ArrayList(ToArray());
            ar.Sort(this);
            Clear();
            object retorno = ar[0];
            ar.RemoveAt(0);
            foreach (Proceso it in ar)
                Enqueue(it);
            return retorno;
        }      
    }
    public class Proceso
    {
        private int PID;
        private string Nombre;
        private int Prioridad;
        private int TiempoARecorrer;
        public Proceso()
        {
            this.PID = 0;
            this.Nombre = "idleTrhead";
            this.Prioridad = 0;
            this.TiempoARecorrer = 999999999;
        }
        public Proceso(int pid, string nm, int prioridad, int time)
        {
            this.PID = pid;
            this.Nombre = nm;
            this.Prioridad = prioridad;
            this.TiempoARecorrer = time;
        }
        public int Pid
        {
            get { return PID; }
            set { PID = value; }
        }
        public string NM
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public int Time
        {
            get { return TiempoARecorrer; }
            set { TiempoARecorrer = value; }
        }
        public int Privilegio 
        {
            get { return Prioridad; }
            set { Prioridad = value; }
        }

        public override string ToString()
        {
            return String.Format("PID:{0}\nNombre: {1}\nPrioridad: {2}\nTiempo: {3}", PID,Nombre,Prioridad,TiempoARecorrer);
        }
    }
    public struct Core//LISTO
    {
        private string Modelo;
        private string Fabricante;
        private string AnoFabricacion;
        private int ID;
        private double Frecuencia;

        public Core(string modelo, string fabicante, string anof, int id, double frec)
        {
            this.Fabricante = fabicante;
            this.Modelo = modelo;
            this.ID = id;
            this.AnoFabricacion = anof;   
            this.Frecuencia = frec;
        }
        public string MD
        {
            get { return Modelo; }
            set { Modelo = value; }
        }
        public string Fab
        {
            get { return Fabricante; }
            set { Fabricante = value; }
        }
        public string Anio
        {
            get { return AnoFabricacion; }
            set { AnoFabricacion = value; }
        }
        public int Ident
        {
            get { return ID; }
            set { ID = value; }
        }
        public double GHz
        {
            get { return Frecuencia; }
            set { Frecuencia = value; }
        }

        public override string ToString()
        {
            return (String.Format("Procesador: {0}{1}-{2}"
                                +"\nAño de Fabricacion: {3}"
                                +"\nFrecuencia de Reloj: {4}GHz"
                                ,Fabricante,Modelo,ID,AnoFabricacion,Frecuencia));
        }
    }
    public class Scheduler
    {
        private PQueue ReadyQ;
        private Queue Running;
        private Queue Wait;
        private int TimeSlice;
        private Core[] ArrCores;
        public Scheduler()
        {
            this.ReadyQ = new PQueue();
            this.Running = new Queue();
            this.Wait = new Queue();
            this.TimeSlice = 1000;
            this.ArrCores = new Core[Environment.ProcessorCount];
        }
        public void New(Proceso p)
        {
            ReadyQ.Enqueue(p);
        }
        public void Shedule()
        {
            bool exit = true;
            do
            {
                for (int i = 0; i <= ArrCores.GetUpperBound(0); i++)
                {
                    ArrCores[i].Anio = "2010";
                    ArrCores[i].Fab = "Intel";
                    ArrCores[i].MD = "Core i7";
                    ArrCores[i].Ident = 6920;
                    ArrCores[i].GHz = 3.07;
                }
                for (int j = 0; j <= ArrCores.GetUpperBound(0); j++)
                {
                    if (ReadyQ.Count != 0)
                    {
                        Proceso temp = (Proceso)ReadyQ.Dequeue();
                        Running.Enqueue(temp);
                        Console.WriteLine("\nEjecutando: \n{0}", temp);
                    }
                }
                Thread.Sleep(TimeSlice);
                foreach (Proceso clock in Running)
                {
                        
                    if (clock.Time >= 0)
                    {
                        float TempTimeSlice = (float)(TimeSlice * 0.001);
                        int tiempo = clock.Time - (int)TempTimeSlice;

                        if (tiempo <= 0)
                            clock.Time = 0;
                        else
                        {
                            clock.Time = tiempo;
                            ReadyQ.Enqueue(clock);
                        }
                    }                 
                }
                for (int i = 0; i <= ArrCores.GetUpperBound(0); i++)
                {
                    if (Running.Count != 0)
                        Running.Dequeue();   
                }
                Console.Clear();
                if (Running.Count == 0 && ReadyQ.Count == 0)
                    exit = false;
            } while (exit);
            
        }
        public void Idle(Proceso idle)
        {
            do
            {
                ArrCores[0].Anio = "2010";
                ArrCores[0].Fab = "Intel";
                ArrCores[0].MD = "Core i7";
                ArrCores[0].Ident = 6920;
                ArrCores[0].GHz = 3.07;
              
                Running.Enqueue(idle);
                Console.WriteLine("\nEjecutando: \n{0}", idle);
                Thread.Sleep(TimeSlice);
                foreach (Proceso clock in Running)
                {

                    if (clock.Time >= 0)
                    {
                        float TempTimeSlice = (float)(TimeSlice * 0.001);
                        int tiempo = clock.Time - (int)TempTimeSlice;

                        if (tiempo <= 0)
                            clock.Time = 0;
                        else
                        {
                            clock.Time = tiempo;
                            ReadyQ.Enqueue(clock);
                        }
                    }
                }
                for (int i = 0; i <= ArrCores.GetUpperBound(0); i++)
                {
                    if (Running.Count != 0)
                        Running.Dequeue();
                }
                Console.Clear();
            } while (true);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Scheduler s = new Scheduler();
            Proceso p = default(Proceso);
            Proceso idle = new Proceso();
            ConsoleKeyInfo op;
            bool salir = true;
            Console.WriteLine("Numero de Cores en esta computadora: {0}.",Environment.ProcessorCount);
            Core mycore = new Core("Core i7", "Intel®", "2010", 6920, 3.07);
            Console.WriteLine(mycore.ToString());
            Console.WriteLine("Presione tecla para continuar");
            Console.ReadLine();
            Console.WriteLine("PID, Prioridad y Tiempo es aleatorio");
            Console.WriteLine("Ingrese el nombre del proceso...");
            Thread.Sleep(3000);
            Console.Clear();
            do
            {
               
                Console.Write("Nombre del proceso: ");
                string NMapp = Console.ReadLine();
                p = new Proceso(r.Next(0, 500), NMapp, r.Next(1, 169), r.Next(15, 60));
                s.New(p);
                do
                {
                    Console.Write("¿Desea ingresar otro proceso? (s/n)... ");
                    op = Console.ReadKey();
                    if (op.Key == ConsoleKey.N)
                    {
                        salir = false;
                        break;
                    }
                    Console.Clear();
                } while (op.Key != ConsoleKey.S);
            } while (salir);
            Console.WriteLine("\n--Procesos Creados--\nPresione tecla para ejecutar");
            Console.ReadLine();
            Console.Clear();
            s.Shedule();
            s.Idle(idle);
            Console.ReadLine();
        }
    }
}
