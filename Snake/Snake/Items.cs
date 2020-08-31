using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Snake
{
    class Items
    {
        protected int x, y, tamanio; 
        //protected: accesible dentro de su clase y por parte de instancias de clase heredadas.
        //x, y es la posicion en la que se encuentra cada item
        public Items()
        {
            this.tamanio = 10;// el tamaño de los items son de 10
        }
        public bool Choque(Items item)
        {
            int difx = Math.Abs(this.x - item.x); //diferencia entre distancias de los objetos 
            int dify = Math.Abs(this.y - item.y);
            if (difx >= 0 && difx < tamanio && dify >= 0 && dify < tamanio)// si es mayor o igual a 0 el objeto esta encima; si es mayor a 10 chocan 
                return true;
            else return false;

        }
        //public void Dibujar(Graphics g);

    }
}
