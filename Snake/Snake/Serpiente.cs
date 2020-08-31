using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Serpiente : Items
    {
        Serpiente alargar;
        public Serpiente(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.alargar = null; 
        }
        public void Dibujar(Graphics g)
        {
            if (alargar != null)
                alargar.Dibujar(g);//se llama recursivamente para dibujarse
            g.FillRectangle(new SolidBrush(Color.Blue), this.x, this.y, this.tamanio, this.tamanio);
        }

        public int X 
        {
            get { return x; } 
            set 
            {
                if (alargar != null)
                    alargar.X = x;
                x = value;    
            } 
        }
        public int Y 
        { 
            get { return y; }
            set
            {
                if (alargar != null)
                    alargar.Y = y;
                y = value;    
            }
        }
        public void Comer()
        {
            if (alargar == null)
                alargar = new Serpiente(this.x, this.y);
            else
                alargar.Comer();
        }
        public Serpiente Siguiente()
        {
            return alargar;
        }
    }
}
