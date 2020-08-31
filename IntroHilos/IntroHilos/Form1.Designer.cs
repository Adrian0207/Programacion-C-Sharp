namespace IntroHilos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIniciarHilo = new System.Windows.Forms.Button();
            this.IsHilos = new System.Windows.Forms.RichTextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIniciarHilo
            // 
            this.btnIniciarHilo.Location = new System.Drawing.Point(116, 227);
            this.btnIniciarHilo.Name = "btnIniciarHilo";
            this.btnIniciarHilo.Size = new System.Drawing.Size(95, 23);
            this.btnIniciarHilo.TabIndex = 0;
            this.btnIniciarHilo.Text = "Iniciar un Hilo";
            this.btnIniciarHilo.UseVisualStyleBackColor = true;
            this.btnIniciarHilo.Click += new System.EventHandler(this.btnIniciarHilo_Click);
            // 
            // IsHilos
            // 
            this.IsHilos.Location = new System.Drawing.Point(12, 24);
            this.IsHilos.Name = "IsHilos";
            this.IsHilos.Size = new System.Drawing.Size(302, 185);
            this.IsHilos.TabIndex = 1;
            this.IsHilos.Text = "";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(116, 256);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(95, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Detener";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 322);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.IsHilos);
            this.Controls.Add(this.btnIniciarHilo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarHilo;
        private System.Windows.Forms.RichTextBox IsHilos;
        private System.Windows.Forms.Button btnStop;
    }
}

