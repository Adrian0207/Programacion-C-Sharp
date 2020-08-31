using System;
using System.Reflection;
using Estruc;
using Clase;
using System.Threading;
namespace InfoVehiculos
{
    class Program
   {       
        static void Main(string[] args)
        {
            int ccl = 0;
            string op = "";
            Console.Write("Ingrese el modelo del vehiculo: ");
            string md = Console.ReadLine();
            Console.Write("Ingrese la marca del vehiculo: ");
            string mcv = Console.ReadLine();
            Console.Write("Ingrese la placa del vehiculo: ");
            string pl = Console.ReadLine();
            Console.Write("Ingrese el año de fabricacion del vehiculo: ");
            string afabri = Console.ReadLine();
            int anio = Convert.ToInt32(afabri.Substring(0, 4));
            do
            {
                Console.Write("Ingrese el codigo del color del vehiculo(1-11): ");
                ccl = Convert.ToInt32(Console.ReadLine());
            } while (ccl<1||ccl>11);            
            Colores c = (Colores)ccl;                   
            string cad = "";
            switch (c)
            {
                case Colores.Barcelona_Red_Met:
                    cad+=(StringEnum.GetStringValue(Colores.Barcelona_Red_Met));
                    break;
                case Colores.Beig_Met:
                    cad += (StringEnum.GetStringValue(Colores.Beig_Met));
                    break;
                case Colores.Beige_Met:
                    cad += (StringEnum.GetStringValue(Colores.Beige_Met));
                    break;
                case Colores.Beige_Met1:
                    cad += (StringEnum.GetStringValue(Colores.Beige_Met1));
                    break;
                case Colores.Blu:
                    cad += (StringEnum.GetStringValue(Colores.Blu));
                    break;
                case Colores.Blue:
                    cad += (StringEnum.GetStringValue(Colores.Blue));
                    break;
                case Colores.Blue_Met:
                    cad += (StringEnum.GetStringValue(Colores.Blue_Met));
                    break;
                case Colores.Blue_Met1:
                    cad += (StringEnum.GetStringValue(Colores.Blue_Met1));
                    break;
                case Colores.Blue_Met2:
                    cad += (StringEnum.GetStringValue(Colores.Blue_Met2));
                    break;
                case Colores.Blue_Mica:
                    cad += (StringEnum.GetStringValue(Colores.Blue_Mica));
                    break;
                case Colores.Blue_Mica_Met:
                    cad += (StringEnum.GetStringValue(Colores.Blue_Mica_Met));
                    break;
                default:
                    cad += ("Ingreso un codigo no valido");
                    break;
            }
            
            
            //MOTOR
            Console.WriteLine("Datos del Motor");
            Console.Write("\tIngrese el numero de cilindros del motor: ");
            byte ncil = Convert.ToByte(Console.ReadLine());           
            do
            {
                Console.Write("\tEl vehiculo tiene inyeccion electrica?(s/n): ");
                op = Console.ReadLine();
            } while (op != "s" && op != "n");
            string iny;
            if (op == "s")
                iny = op + "i";
            else
                iny = op + "o";
            Console.Write("\tIngrese la Capacidad en litros del motor: ");
            double cap = Convert.ToDouble(Console.ReadLine());

            //RADIO
            Console.WriteLine("Datos de la Radio");
            Console.Write("\tIngrese la marca del radio: ");
            string mcr = Console.ReadLine();

            do
            {
                Console.Write("\tLa radio tiene DVD?(s/n): ");
                op = Console.ReadLine();
            } while (op != "s" && op != "n");
            string dvd;
            if (op == "s")
                dvd = op + "i";
            else
                dvd = op + "o";
            do
            {
                Console.Write("\tLa radio tiene USB?(s/n): ");
                op = Console.ReadLine();
            } while (op != "s" && op != "n");
            string usb;
            if (op == "s")
                usb= op + "i";
            else
                usb = op + "o";
            do
            {
                Console.Write("\tLa radio tiene pantalla touch?(s/n): ");
                op = Console.ReadLine();
            } while (op != "s" && op != "n");
            string pth;
            if (op == "s")
                pth= op + "i";
            else
                pth = op + "o";          
            do
            {
                Console.Write("\tLa radio tiene Bluetooth?(s/n): ");
                op = Console.ReadLine();
            } while (op != "s" && op != "n");
            string bth;
            if (op == "s")
                bth = op + "i";
            else
                bth = op + "o";

            Console.Write("\tIngrese el precio de la radio: ");
            double pre = Convert.ToDouble(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Generando información...");
            Thread.Sleep(3000);
            Console.WriteLine("Información generada...");
            Thread.Sleep(3000);
            Motors m1 = new Motors(ncil, iny, cap);
            Radios r1 = new Radios(mcr,dvd,usb,pth,bth, pre);
            Automovil a1 = new Automovil(md, mcv, pl, anio, cad, m1, r1);

            Console.WriteLine(a1.ToString());
            Console.ReadKey();
        }      
    }
}
namespace Clase
{
    public class Automovil  
    {
        private string Modelo;
        private string Marca;
        private string Placa;
        private int AFabri;
        private string Color;
        private Motors Motor;
        private Radios Radio;
     
        public Automovil(string modelo, string marca, string placa, int fabricacion, string color, Motors motor, Radios radio)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.Placa = placa;
            this.AFabri=fabricacion;
            this.Color = color;
            this.Motor = motor;
            this.Radio = radio;
        }
        public override string ToString()
        {
            return (String.Format("\nModelo:{0}\nMarca:{1}\nPlaca:{2}\nColor:{3}\nAño:{4}\nMotor{5}\nRadio{6}", Modelo, Marca, Placa, Color, AFabri, Motor, Radio));
        }
        
    }
    public class StringValueAttribute : System.Attribute
    {       
        private string Valor;

        public StringValueAttribute(string value)//constructor
        {
            this.Valor = value;
        }

        public string Value//metodo
        {
            get { return Valor; }
        }
    }
    public class StringEnum
    {
        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            StringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attrs.Length > 0)
                output = attrs[0].Value;
            return output;
        }
    }

}   
namespace Estruc
{
    public struct Motors
    {
        public byte NCilindros;
        public string Inyeccion;
        public double CLitros;

        public Motors(byte numcilin, string inyec, double clitros)
        {
            this.NCilindros = numcilin;
            this.Inyeccion = inyec;
            this.CLitros = clitros;
        }
        public override string ToString()
        {
            return (String.Format(":\n\tNumero de Cilindros: {0}\n\tInyección  electrónica: {1}\n\tCapacidad en Litros:{2}", NCilindros, Inyeccion, CLitros));
        }
    }
    public struct Radios
    {
        public string Marca;
        public string DVD;
        public string USB;
        public string Pantalla;
        public string Blueth;
        public double Precio;

        public Radios(string marca, string dvd, string usb, string panta, string bluet, double precio)
        {
            this.Marca = marca;
            this.DVD = dvd;
            this.USB = usb;
            this.Pantalla = panta;
            this.Blueth = bluet;
            this.Precio = precio;
        }
        public override string ToString()
        {
            return (String.Format(":\n\tMarca: {0}\n\tDVD: {1}\n\tUSB: {2}\n\tPantalla Touch: {3}\n\tBluetooth: {4}\n\tPrecio: {5}", Marca, DVD, USB, Pantalla, Blueth, Precio));
        }
    }
    public enum Colores
    {
     [StringValue("3R3->Barcelona Red Met")] 
     Barcelona_Red_Met = 1,
     [StringValue("4L5->Beig Met")]
     Beig_Met = 2,
     [StringValue("4SO->Beige Met")]
     Beige_Met = 3,
     [StringValue("4T8->Beige Met")]
     Beige_Met1 = 4,
     [StringValue("8M4->Blu")]
     Blu = 5,
     [StringValue("8H6->Blue")]
     Blue = 6,
     [StringValue("8D7->Blue Met")]
     Blue_Met = 7,
     [StringValue("8T4->Blue Met")]
     Blue_Met1 = 8,
     [StringValue("8U6->Blue Met")]
     Blue_Met2 = 9,
     [StringValue("8L5->Blue Mica")]
     Blue_Mica = 10,
     [StringValue("8M8->Blue Mica Met")]
     Blue_Mica_Met = 11,
    }   
}

    