using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
//Adrián Oliva
namespace IntroHilos
{
    public partial class Form1 : Form
    {
        private Thread hiloContador;//Hilo secundario
        private delegate void SetItemListDelegate(string prItems);
        private int idHilo;
        public int varX;
        public ManualResetEvent controladorParaHiloSecundario;
        public ManualResetEvent controladorHiloSecundarioParado;
        public Form1()
        {
            InitializeComponent();       
        }

        private void btnIniciarHilo_Click(object sender, EventArgs e)
        {
            controladorParaHiloSecundario = new ManualResetEvent(false);
            controladorHiloSecundarioParado = new ManualResetEvent(false);
            Contador nuevoContador = new Contador(this, idHilo);
            ThreadStart delegado = new ThreadStart(nuevoContador.TareaHilo);
            hiloContador = new Thread(delegado);
            idHilo++;
            hiloContador.IsBackground = true;
            hiloContador.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {            
                PararHiloSecundario();
                idHilo = 0;
            }
            catch (Exception)
            {
                IsHilos.AppendText("Inicie un proceso\n");
            }               
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PararHiloSecundario();
        }

        public void SetItem_IsHilo(string item)
        {
            if (IsHilos.InvokeRequired)
            {
                SetItemListDelegate delegado = new SetItemListDelegate(SetItem_IsHilo);
                IsHilos.Invoke(delegado, new object[] { item });
            }
            else
                IsHilos.AppendText(item + "\n");
        }

        public void SetItem_IsHilo()
        {
            IsHilos.Text = "";
        }

        private bool PararHiloSecundario()
        { 
            //Método utilizado por elhilo principal para detener la ejecucion del hilo secundario
            if(hiloContador == null || !hiloContador.IsAlive)
                return false;
            //Cambia el estado de este controlador de espera a señalizado para informar
            //al hilo secundario de que debe parar
            controladorParaHiloSecundario.Set();
            //Esperar a que el hilo secundario informe que ha parado
            while (hiloContador.IsAlive)
            {
                //Muy importante:
                /*No se puede utilizar una espera indefinida por que el
                 * hilo secundario hace llamadas sincronas al hilo principal,
                 * y esto podria causar abrazos mortales(interbloqueos).
                 * Por esta razón, se espera por controladorHiloSecundarioParado
                 * (un tiempo apropiado) y se permite procesar otros eventos.
                 * Estos eventos pueden incluir llamadas Invoke
                 */
                //WaitAll es para que la espera no sea activa(para no ocupar al procesador mientras esperamos).
                //Tambien se lo consigue con una llamada Sleep, sin embargo no es buena
                WaitHandle.WaitAll((new ManualResetEvent[] { controladorHiloSecundarioParado }), 100, false);
                Application.DoEvents();//procesa otros eventos
            }
            hiloContador = null;
            return true;
        }
    }
    public class Contador
    {
        private Form1 m_Form;
        private int m_idHilo;
        public Contador(Form1 formulario, int id_hilo)
        {
            this.m_Form = formulario;
            this.m_idHilo = id_hilo;
        }
        public void TareaHilo()
            {
                string item;
                MethodInvoker delegado = new MethodInvoker(m_Form.SetItem_IsHilo);
                try
                {
                    do
                    {
                        lock (m_Form)
                        {
                            int i = m_Form.varX;
                            Thread.Sleep(DateTime.Now.Second % 100);
                            i++;
                            m_Form.varX = i;
                            item = "Hilo " + m_idHilo + ": " + m_Form.varX;
                            m_Form.SetItem_IsHilo(item);
                            if (m_Form.controladorParaHiloSecundario.WaitOne(0, false))
                            {
                                //Tarea de limpieza.
                                //Informa al hilo principal que este hilo ha parado
                                m_Form.controladorHiloSecundarioParado.Set();
                                return;
                            }
                        }
                    } while (true);
                }
                catch (Exception e)
                {

                    Debug.WriteLine("Error inesperado en hilo " + m_idHilo);
                    Debug.WriteLine(e.Message);
                }
            }
    }
}
//Adrián Oliva