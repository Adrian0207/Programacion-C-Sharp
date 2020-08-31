using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Snake
{
    public partial class Snake : Form
    {
        Serpiente serpiente;
        Graphics g, g1;
        Comida comida;
        SoundPlayer Player = new SoundPlayer();
        SoundPlayer Lvlup = new SoundPlayer();
        int puntaje = 0;
        int xdir = 0, ydir = 0, cuadro = 10;// direcciones y los cuadros que se mueven
        bool ejex = true, ejey = true; // eje que se encuentra la serpiente
        public Snake()
        {
            InitializeComponent();
            Player.SoundLocation = "Gangplank_Galleon.wav";
            serpiente = new Serpiente(190, 90);
            comida = new Comida();
            g = Lienzo.CreateGraphics();
            
        }

        private void bucle_Tick(object sender, EventArgs e)// efecto de animacion
        {
        
            g.Clear(Color.White);//redibuja un espectro de movimiento
            serpiente.Dibujar(g);
            comida.Dibujar(g);
            Movimiento();
            ChocarCuerpo();
            ChocarParded();
            FrutaChoca();
            if (serpiente.Choque(comida))//cuando la serpiente choque con la comida
            {
                comida = new Comida();//se reescribira la posicion de la comida
                serpiente.Comer();
                lblPuntuacion.Text = (++puntaje).ToString();
            }
            if (puntaje <= 50)
            {
                if (puntaje == 10)
                    bucle.Interval = 90;
                else if (puntaje == 20)
                    bucle.Interval = 80;
                else if (puntaje == 30)
                    bucle.Interval = 70;
                else if (puntaje == 40)
                    bucle.Interval = 60;
                else if (puntaje == 50)
                    bucle.Interval = 50;
                
            }            
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)//Evento que se produce cuando se presiona una tecla
        {
            if (ejex)//mientras estemos en el eje x solo podemos movernos en el eje y es decir arriba y abajo
            {
                if (e.KeyCode == Keys.Up)//obtiene el la tecla que esta siendo presionada y la compara
                {
                    ydir = -cuadro;//disminuye los cuadros en direccion vertical
                    xdir = 0;//los cuadros horizontales siguen iguales
                    ejex = false;//no puede moverse en x mientras se mueva en horizontal
                    ejey = true;//puede moverse en y mientras se mueve en horizontal
                }
                else if (e.KeyCode == Keys.Down)
                {
                    ydir = cuadro;//aumenta los cuadros en direccion vertical
                    xdir = 0;//los cuadros horizontales siguen iguales
                    ejex = false;//no puede moverse en x mientras se mueva en horizontal
                    ejey = true;//puede moverse en y mientras se mueve en horizontal
                }
            }
            if (ejey)//mientras estemos en el eje y solo podemos movernos en el eje x es decir derecha e izquierda
            {
                if (e.KeyCode == Keys.Right)
                {
                    ydir = 0;//los cuadros verticales siguen iguales
                    xdir = cuadro;//aumenta los cuadros en direccion horizontal
                    ejex = true;//puede moverse en x mientras se mueve en vertical
                    ejey = false;//no puede moverse en y mientras se mueva en horizontal
                }
                else if (e.KeyCode == Keys.Left)
                {
                    ydir = 0;//los cuadros verticales siguen iguales
                    xdir = -cuadro;//disminuyen los cuadros en direccion horizontal
                    ejex = true;//puede moverse en x mientras se mueve en vertical
                    ejey = false;//no puede moverse en y mientras se mueva en horizontal
                }
            }
        }
        public void Movimiento()
        {
            serpiente.X += xdir; // direccion en la que se encuentra se le suma al eje x un numero de cuadros 
            serpiente.Y += ydir; // direccion en la que se encuentra se le suma al eje y un numero de cuadros 
        }
        public void GameOver()
        {
           
            lblPuntuacion.Text = "0";
            ejex = ejey = true;
            xdir = ydir = 0;
            serpiente = new Serpiente(190, 90);
            comida = new Comida();
            MessageBox.Show("Game Over: Puntaje " + puntaje);
            puntaje = 0;
            bucle.Interval = 100;
           
        }
        public void ChocarCuerpo()
        {
            Serpiente temp;
            try
            {
                temp = serpiente.Siguiente().Siguiente();
            }
            catch (Exception e)
            {
                temp = null;
            }
            while (temp != null)
            {
                if (serpiente.Choque(temp))
                    GameOver();
                else
                    temp = temp.Siguiente();
            }
        }
        public void ChocarParded()
        {
            if (serpiente.X < 0 || serpiente.X > Lienzo.Width - 10 || serpiente.Y < 0 || serpiente.Y > Lienzo.Height - 10)
                GameOver();
        }
        public void FrutaChoca()
        {
            Serpiente temp;
            try
            {
                temp = serpiente.Siguiente();
            }
            catch (Exception e)
            {
                temp = null;
            }
            while (temp != null)
            {
                if (comida.Choque(temp))
                    comida = new Comida();
                else
                    temp = temp.Siguiente();
            }
        }
        private void Lienzo1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Lienzo1.Width; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), i, 0, 10, 10);
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), i, Lienzo1.Height - 10, 10, 10);
                
            }
            for (int i = 0; i < Lienzo1.Height; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, i, 10, 10);
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), Lienzo1.Width - 10, i, 10, 10);
            }
        }

        private void Snake_Load(object sender, EventArgs e)
        {
            Player.PlayLooping();
        }

        
    }
}
