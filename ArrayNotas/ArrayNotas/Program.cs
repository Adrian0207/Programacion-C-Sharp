using System;
using System.Collections;// Para uso de la clase Array y ArrayList
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clases; 
	
namespace ArrayNotas
{
    class Program
    {       
        static void Main(string[] args)
        {
            Console.Clear();
            ConsoleKeyInfo op;// Se usa para el menu... limita la cantidad de opciones que el usuario puede hacerlo en el menu
            Console.WriteLine("Datos del Profesor:");
            Console.Write("Ingrese el Nombre del Profesor: ");
            string nprofe = Console.ReadLine();
            Console.Write("Ingrese el Apellido del Profesor: ");
            string aprofe = Console.ReadLine();
            Console.Write("Ingrese el Grado Academico del Profesor: ");
            string gradaca = Console.ReadLine();
            Console.Write("Ingrese el la Facultad del Profesor: ");
            string facu = Console.ReadLine();
            Console.Write("Ingrese el Correo del Profesor: ");
            string mailo = Console.ReadLine();

            ArrayList curso = new ArrayList(); // declaracion del ArrayList
            Array Notas;// declaracion del Array
            Console.WriteLine("\nDatos del Curso:");
            Console.Write("\nNumero de cursos: ");
            byte grade = Convert.ToByte(Console.ReadLine());


            for (byte l = 1; l <= grade; l++)
            {
                Console.Write("Nombre de la asignatura: ");
                string asig = Console.ReadLine();
                Console.Write("Ingrese el Número de Creditos: ");
                byte ncre = Convert.ToByte(Console.ReadLine());
                Console.Write("Ingrese el Número de Alumnos del curso #{0}: ", l);
                byte nalu = Convert.ToByte(Console.ReadLine());
                Console.Write("Ingrese el Número Total de notas del curso #{0}: ", l);
                byte nnot = Convert.ToByte(Console.ReadLine());

               
                Notas = Array.CreateInstance(typeof(Double), nalu, nnot + 1);//crea el arreglo en double
                byte k = 0;
                   
                for (int i = Notas.GetLowerBound(0); i <= Notas.GetUpperBound(0); i++)// va en 1ra dimension
                {
                    Console.Write("Ingrese la nota del estudiante # {0}:\n", i + 1);
                    for (int j = Notas.GetLowerBound(1); j <= Notas.GetUpperBound(1); j++)// va en 2da dimension
                    {
                        if (j == 0)
                            Notas.SetValue(++k, i, j);//lo pone dentro del arreglo en la posicion especificada el codigo de alumno
                        else
                        {
                            Console.Write("Nota #{0}: ", j);
                            double n = Convert.ToDouble(Console.ReadLine());
                            Notas.SetValue(n, i, j);// pone las notas
                        }
                    }
                }
                Curso cs = new Curso(nalu, ncre, asig, l, nnot, Notas);// se instancia el objeto 
                curso.Add(cs);// se lo pone dentro del ArrayList
                Console.WriteLine();
            }
            
            Console.WriteLine("Procesando Datos...");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            do
            {
                Console.Clear();
                Console.WriteLine("1. Listar datos del profesor");
                Console.WriteLine("2. Listar los datos de los cursos");
                Console.WriteLine("3. Listar las notas de los alumnos de un curso determinado");
                Console.WriteLine("4. Borrar un curso");
                Console.WriteLine("5. Salir");
                Console.Write("PULSE LA OPCION QUE DESEE...");
                op = Console.ReadKey();
                switch (op.Key)
                {
                        
                    case ConsoleKey.D1:// espeficica que solo es para la tecla 1 
                        {
                            Profesor p = new Profesor(nprofe, aprofe, gradaca, facu, mailo,curso);
                            Console.WriteLine("\n" + p.ToString());
                            Console.WriteLine("Presiones cualquier tecla para continuar");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.D2:// espeficica que solo es para la tecla 2
                        {
                            Console.WriteLine("\nDatos de los Cursos:");
                            foreach (Object curs in curso)
                                Console.WriteLine("\t" + curs);
                            Console.WriteLine("\nPresiones cualquier tecla para continuar");
                            Console.ReadKey();
                            break;
                        }

                    case ConsoleKey.D3:// espeficica que solo es para la tecla 3 
                        {
                            Console.Write("\nIngrese el numero curso a buscar: ");
                            byte bop = Convert.ToByte(Console.ReadLine());
                            Curso CursoABuscar = new Curso(bop);
                            bool check = false;
                            foreach (Curso c in curso)
                            {
                                check = c.Equals(CursoABuscar);
                                if (check)
                                {
                                    Notas = c.nn;
                                    if (check)
                                    {
                                        Console.WriteLine("#Estudiante\tNotas");
                                        for (int i = 0; i < Notas.GetLength(0); i++)
                                        {
                                            for (int j = 0; j < Notas.GetLength(1); j++)
                                                Console.Write(Notas.GetValue(i, j) + "\t\t");
                                            Console.WriteLine();                                             
                                        }
                                   
                                    }
                                    else
                                        Console.WriteLine("El Curso no Existe");
                                }   
                            }
                            Console.WriteLine("Presiones cualquier tecla para continuar");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.D4:// espeficica que solo es para la tecla 4 
                        {
                            
                            Console.Write("\nQue curso desea Remover: ");
                            byte num = Convert.ToByte(Console.ReadLine());
                            int cont = 1;
                            if (num <= curso.Count)
                                curso.RemoveAt(num - 1);
                            else
                                Console.WriteLine("\nEl curso no existe\n");
                            Console.WriteLine("Cursos en lista");
                            foreach (Object curs in curso)
                            {
                                Console.WriteLine(curs);
                                cont++;
                            }
                            Console.WriteLine("Presiones cualquier tecla para continuar");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.D5:// espeficica que solo es para la tecla 5 
                        break;

                }
            } while (op.Key != ConsoleKey.D5); // sale al presionar 5
        }
    }
}
namespace Clases
{
    public class Profesor
    {
        private string Nombre;
        private string Apellido;
        private string GradoAcad;
        private string Facultad;
        private string CorreoInstitucional;
        private ArrayList Cursos;

        public Profesor(string name, string lname, string gacademico, string facultad, string correoi, ArrayList curso)
        {
            this.Nombre = name;
            this.Apellido = lname;
            this.GradoAcad = gacademico;
            this.Facultad = facultad;
            this.CorreoInstitucional = correoi;
            this.Cursos = curso;
        }
        public override string ToString()
        {
            return (String.Format("\nDatos del Profesor:\n\tNombre:{0}\n\tApellido:{1}\n\tGrado Academico:{2}\n\tCI:{3}\n\tCorreo Institucional:{4}",
                 Nombre, Apellido, GradoAcad, Facultad, CorreoInstitucional));
        }
      
    }
    public class Curso
    {
        private byte NAlumnos;
        private byte NCreditos;
        private string Nombre;
        private byte NCurso;
        private byte NNotas;
        private Array Notas;      

        public Curso(byte numalum, byte numcred, string nombre, byte ncurso, byte nnotas, Array notas)
        {
            this.NAlumnos = numalum;
            this.NCreditos = numcred;
            this.NCurso = ncurso;
            this.NNotas = nnotas;
            this.Nombre = nombre;
            this.Notas = notas;
        }

        public Curso(byte nucurso)
        {
            this.NCurso = nucurso;
        }

        public override string ToString()
        {
            return (String.Format("\n\tCurso:{0}\n\tAsignatura:{1}\n\tNúmero de Alumnos:{2}\n\tNúmero de Creditos:{3}\n"
                                  ,NCurso ,Nombre, NAlumnos,NCreditos));
        }

        public Array nn
        {
            get { return Notas; }
        }

        public override bool Equals(Object obj)
        {
            Curso Aula = obj as Curso;
            if (NCurso.Equals(Aula.NCurso))
                return true;
            return false;
        }        
    }
}

