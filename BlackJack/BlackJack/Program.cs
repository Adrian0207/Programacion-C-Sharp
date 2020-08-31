using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using Mesa;

namespace Mesa 
{
    class Carta
    {
        private byte numero;
        private char figura;
        private string representacion;
        private byte valor;
        public Carta(byte num, char fig, string repre, byte val)
        {
            this.numero = num;
            this.figura = fig;
            this.representacion = repre;
            this.valor = val;
        }
        public byte NValor
        {
            get { return valor; }
            set { valor = value; }
        }
        public override string ToString()
        {
            if (representacion == "10")
                return (String.Format(("\n╔═══════╗\n║       ║\n║  {0}{1}  ║\n║       ║\n║       ║\n╚═══════╝"), representacion, figura));
            else               
                return (String.Format(("\n╔═══════╗\n║       ║\n║  {0}{1}   ║\n║       ║\n║       ║\n╚═══════╝"), representacion, figura));
        }

        
    }
}
namespace BlackJack
{ 
    class Program
    {
        public static void LlenarMazo(ArrayList arr)
        {
            byte carta = 1;
            while (carta <= 13)
            {
                arr.Add(new Carta(carta, '♥', Representacion(carta), Valor(carta)));//Corazon
                carta++;
            }
            carta = 1;
            while (carta <= 13)
            {
                arr.Add(new Carta(carta, '♦', Representacion(carta), Valor(carta)));//Diamante
                carta++;
            }
            carta = 1;
            while (carta <= 13)
            {
                arr.Add(new Carta(carta, '♣', Representacion(carta), Valor(carta)));//Trebol
                carta++;
            }
            carta = 1;
            while (carta <= 13)
            {
                arr.Add(new Carta(carta, '♠', Representacion(carta), Valor(carta)));//Pica
                carta++;
            }
        }
        public static void Barajar(Stack<Carta> CartaE, ArrayList CartaO)
        {
            Random r = new Random();
            int pos = 0;
            while (CartaE.Count < 52)
            {
                pos = r.Next(0, 52);
                if (CartaO[pos] != null)
                {
                    CartaE.Push((Carta)CartaO[pos]);
                    CartaO[pos] = null;
                }
            }
        }
        public static string Representacion(byte b)
        {
            string a = Convert.ToString(b);
            string representacion = "";
            if (a == "1")
                representacion = "A";
            else if (a == "11")
                representacion = "J";
            else if (a == "12")
                representacion = "Q";
            else if (a == "13")
                representacion = "K";
            else
                representacion = a;

            return representacion;
        }
        public static byte Valor(byte num)
        {
            byte valor = 0;
            if (num == 1)
                valor = 11;
            else if (num == 11 || num == 12 || num == 13)
                valor = 10;
            else
                valor = num;
            return valor;
        }
        public static void Instrucciones()
        {
            Console.WriteLine("Al inicio de la partida se le presentara 2 cartas y la suma de las mismas.\n\nEl objetivo es sumar con las cartas un valor de 21 o cercano pero no puede ser \nmayor a 21."
                                + "\n\nSi usted quiere otra carta para acercarse al número, usted debera ingresar \"s\""
                                + "\nCaso contrario ingresara \"n\" para no resivir más, entonces sera turno del \nCrupier"
                                +"\n\nEl Crupier sacara dos cartas y las sumara hasta acercarse al valor de 17 o más");
            Console.WriteLine("\nCondiciones para Ganar:\n\n-Gana automaticamente si saco 21"
                                + "\n-Para ganar se tiene que sumar los valores y acercarse a 21 o cercano"
                                + "\n-Si usted tiene un valor cercano a 21 y mayor al Crupier esntonces gana"
                                + "\n-Si el crupier se pasa de 21 usted gana"
                                +"\n-Si tiene mas de 21 usted pierde\n-Si el Crupier tiene mas que usted, entonces gano el Crupier");
            Console.WriteLine("\nValores de las cartas:\n-El valor de las cartas del 2 al 10 sera el mismo\n-El As vale 11\n-El valor de J,Q,K es de 10");
        }
        static void Main(string[] args)
        {
            
            ConsoleKeyInfo op, menu;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            do
            {
                Console.Clear();
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tBIENVENIDO A BLACKJACK\n\n\t\tMenu");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\t1)JUGAR\n\n\t2)INSTRUCIONES\n\n\t3)SALIR");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nHora Actual: " + DateTime.Now);
                menu = Console.ReadKey();

                switch (menu.Key)
                {
                    case ConsoleKey.D1:
                        {
                            try
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                bool salir = true;
                                Stack<Carta> Cartas_Entre = new Stack<Carta>(52);
                                ArrayList Cartas_Orden = new ArrayList(52);
                                LlenarMazo(Cartas_Orden);
                                //if (Cartas_Entre.Count.Equals(0) || Cartas_Entre.Count.Equals(5))
                                //    card.Barajar(Cartas_Entre, Cartas_Orden);
                                Barajar(Cartas_Entre, Cartas_Orden);
                                Cartas_Orden.Clear();
                                Carta[] Jugador = new Carta[10];
                                Carta[] Crupier = new Carta[10];
                                do
                                {
                                    Console.Clear();
                                    byte totalJugador = 0, totalCrupier = 0;
                                    byte i = 0, j = 0;
                                    short pausa = 1000;
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("Su turno:");
                                    Thread.Sleep(pausa);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Jugador[i] = (Carta)Cartas_Entre.Pop();
                                    Console.WriteLine("\a" + Jugador[i]);
                                    totalJugador += Jugador[i].NValor;
                                    Cartas_Orden.Add(Jugador[i]);
                                    i++;
                                    Thread.Sleep(pausa);
                                    do
                                    {
                                        Jugador[i] = (Carta)Cartas_Entre.Pop();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\a" + Jugador[i]);
                                        totalJugador += Jugador[i].NValor;
                                        Cartas_Orden.Add(Jugador[i]);
                                        i++;
                                        Thread.Sleep(pausa);
                                      
                                        if (totalJugador > 21)
                                            break;
                                        else if (totalJugador == 21)
                                        {
                                            Console.WriteLine("Ganaste");
                                            break;
                                        }
                                        else if (totalJugador <= 21)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.WriteLine("Suma: " + totalJugador);
                                            do
                                            {
                                                Console.Write("\n¿Desea sacar otra carta? (s/n)... ");
                                                op = Console.ReadKey();
                                                if (op.Key == ConsoleKey.N)
                                                {
                                                    salir = false;
                                                    break;
                                                }
                                            } while (op.Key != ConsoleKey.S);
                                        }
                                        Thread.Sleep(pausa);
                                    } while (salir);
                                    Console.Clear();

                                    if (!salir)
                                    {
                                        salir = true;
                                        Console.WriteLine("Turno del Crupier");
                                        Thread.Sleep(pausa);
                                        for (j = 0; j < 2; j++)
                                        {
                                            Crupier[j] = (Carta)Cartas_Entre.Pop();
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("\a" + Crupier[j]);
                                            Cartas_Orden.Add(Crupier[j]);
                                            totalCrupier += Crupier[j].NValor;
                                            if (totalCrupier == 21)
                                            {
                                                Console.WriteLine("Perdiste");
                                                break;
                                            }
                                            else if (totalCrupier > 21)
                                            {
                                                Console.WriteLine("Ganaste");
                                                break;
                                            }
                                            Thread.Sleep(pausa);
                                        }
                                        if (totalCrupier <= 17)
                                        {
                                            do
                                            {
                                                Crupier[j] = (Carta)Cartas_Entre.Pop();
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("\a" + Crupier[j]);
                                                Cartas_Orden.Add(Crupier[j]);
                                                totalCrupier += Crupier[j].NValor;
                                                j++;
                                                Thread.Sleep(pausa);
                                                
                                                Thread.Sleep(pausa);
                                            } while (totalCrupier < totalJugador && totalCrupier > 16  && totalCrupier < 21);
                                        }
                                    }
                                   
                                    Console.WriteLine();
                                    
                                    if (totalCrupier == 21)
                                        Console.WriteLine("Perdiste");
                                    else if (totalJugador == 21)
                                            Console.WriteLine("Ganaste");
                                    else if (totalCrupier > 21)
                                        Console.WriteLine("Ganaste");
                                    else if (totalJugador == totalCrupier)
                                        Console.WriteLine("Empate");
                                    else if (totalJugador > 21)
                                        Console.WriteLine("Perdiste");
                                    else if (totalJugador > totalCrupier && totalJugador < 21)
                                        Console.WriteLine("Ganaste");
                                    else if (totalCrupier > totalJugador && totalCrupier < 21)
                                        Console.WriteLine("Perdiste");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Puntaje:\nJugador: {0}\nCrupier: {1}", totalJugador, totalCrupier);
                                    Console.WriteLine("Desea jugar de nuevo?(s/n)");
                                    op = Console.ReadKey();
                                    if (op.Key == ConsoleKey.N)
                                        salir = false;
                                } while (salir);
                                break;

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nEl crupier se ha quedado sin cartas... Presione una tecla para salir al Menu");                              
                                Console.ReadKey();
                                break;
                            }
                        }
                    case ConsoleKey.D2:
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Instrucciones();
                            Console.WriteLine("Presione una tecla para salir para volver al menu");
                            Console.ReadKey();

                            break;
                        }
                    case ConsoleKey.D3:
                        break;
                }
            } while (menu.Key != ConsoleKey.D3);
                     
            Console.Clear();
            Console.WriteLine("\n\n\tGRACIAS POR JUGAR!!");
            Console.ReadKey();
        }
    }
}
