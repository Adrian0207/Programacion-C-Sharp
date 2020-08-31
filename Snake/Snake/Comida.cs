using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Snake
{
    class Comida : Items
    {     
        public Comida()
        {
            this.x = PosicionAleatoria(38);
            this.y = PosicionAleatoria(18);
        }
        public int PosicionAleatoria(int limite)
        {
            Random r = new Random();
            return r.Next(1, limite) * 10;//genera un numero aleatorio entre 0 y el limite de ancho y largo del lienzo
        }
        public void Dibujar(Graphics g)
        {   
            g.FillEllipse(new SolidBrush(Color.Red), this.x, this.y, this.tamanio, this.tamanio);
        }
    }
}
