namespace ConsoleApplication6.Vistas
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.posFilaUno = new System.Windows.Forms.Label();
            this.posColumnaUno = new System.Windows.Forms.Label();
            this.posFilaDos = new System.Windows.Forms.Label();
            this.PosColumnaDos = new System.Windows.Forms.Label();
            this.puntaje = new System.Windows.Forms.Label();
            this.textBoxFilaUno = new System.Windows.Forms.TextBox();
            this.textBox2ColUno = new System.Windows.Forms.TextBox();
            this.textBox3FilaDos = new System.Windows.Forms.TextBox();
            this.textBox4ColDos = new System.Windows.Forms.TextBox();
            this.botonAtras = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.InicioJuego = new System.Windows.Forms.Button();
            this.intercambio = new System.Windows.Forms.Button();
            this.grupoCaramelos = new System.Windows.Forms.Button();
            this.turnoss = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 415);
            this.panel1.TabIndex = 0;
            // 
            // posFilaUno
            // 
            this.posFilaUno.AutoSize = true;
            this.posFilaUno.Location = new System.Drawing.Point(700, 35);
            this.posFilaUno.Name = "posFilaUno";
            this.posFilaUno.Size = new System.Drawing.Size(74, 26);
            this.posFilaUno.TabIndex = 0;
            this.posFilaUno.Text = "Posición fila \r\ncaramelo uno:";
            // 
            // posColumnaUno
            // 
            this.posColumnaUno.AutoSize = true;
            this.posColumnaUno.Location = new System.Drawing.Point(699, 79);
            this.posColumnaUno.Name = "posColumnaUno";
            this.posColumnaUno.Size = new System.Drawing.Size(93, 26);
            this.posColumnaUno.TabIndex = 1;
            this.posColumnaUno.Text = "Posición columna \r\ncaramelo uno:";
            // 
            // posFilaDos
            // 
            this.posFilaDos.AutoSize = true;
            this.posFilaDos.Location = new System.Drawing.Point(700, 126);
            this.posFilaDos.Name = "posFilaDos";
            this.posFilaDos.Size = new System.Drawing.Size(73, 26);
            this.posFilaDos.TabIndex = 2;
            this.posFilaDos.Text = "Posición fila \r\ncaramelo dos:";
            // 
            // PosColumnaDos
            // 
            this.PosColumnaDos.AutoSize = true;
            this.PosColumnaDos.Location = new System.Drawing.Point(700, 176);
            this.PosColumnaDos.Name = "PosColumnaDos";
            this.PosColumnaDos.Size = new System.Drawing.Size(90, 26);
            this.PosColumnaDos.TabIndex = 3;
            this.PosColumnaDos.Text = "Posición columna\r\ncaramelo dos:";
            // 
            // puntaje
            // 
            this.puntaje.AutoSize = true;
            this.puntaje.Location = new System.Drawing.Point(700, 366);
            this.puntaje.Name = "puntaje";
            this.puntaje.Size = new System.Drawing.Size(46, 13);
            this.puntaje.TabIndex = 4;
            this.puntaje.Text = "Puntaje:";
            // 
            // textBoxFilaUno
            // 
            this.textBoxFilaUno.Location = new System.Drawing.Point(804, 35);
            this.textBoxFilaUno.Name = "textBoxFilaUno";
            this.textBoxFilaUno.Size = new System.Drawing.Size(36, 20);
            this.textBoxFilaUno.TabIndex = 5;
            // 
            // textBox2ColUno
            // 
            this.textBox2ColUno.Location = new System.Drawing.Point(804, 79);
            this.textBox2ColUno.Name = "textBox2ColUno";
            this.textBox2ColUno.Size = new System.Drawing.Size(36, 20);
            this.textBox2ColUno.TabIndex = 6;
            // 
            // textBox3FilaDos
            // 
            this.textBox3FilaDos.Location = new System.Drawing.Point(804, 126);
            this.textBox3FilaDos.Name = "textBox3FilaDos";
            this.textBox3FilaDos.Size = new System.Drawing.Size(36, 20);
            this.textBox3FilaDos.TabIndex = 7;
            // 
            // textBox4ColDos
            // 
            this.textBox4ColDos.Location = new System.Drawing.Point(804, 176);
            this.textBox4ColDos.Name = "textBox4ColDos";
            this.textBox4ColDos.Size = new System.Drawing.Size(36, 20);
            this.textBox4ColDos.TabIndex = 8;
            // 
            // botonAtras
            // 
            this.botonAtras.Location = new System.Drawing.Point(51, 435);
            this.botonAtras.Name = "botonAtras";
            this.botonAtras.Size = new System.Drawing.Size(101, 38);
            this.botonAtras.TabIndex = 9;
            this.botonAtras.Text = "Atrás";
            this.botonAtras.UseVisualStyleBackColor = true;
            this.botonAtras.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 38);
            this.button1.TabIndex = 10;
            this.button1.Text = "Verificar Tablero";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InicioJuego
            // 
            this.InicioJuego.Location = new System.Drawing.Point(424, 435);
            this.InicioJuego.Name = "InicioJuego";
            this.InicioJuego.Size = new System.Drawing.Size(129, 38);
            this.InicioJuego.TabIndex = 11;
            this.InicioJuego.Text = "Iniciar Juego";
            this.InicioJuego.UseVisualStyleBackColor = true;
            this.InicioJuego.Click += new System.EventHandler(this.button2_Click);
            // 
            // intercambio
            // 
            this.intercambio.Location = new System.Drawing.Point(703, 225);
            this.intercambio.Name = "intercambio";
            this.intercambio.Size = new System.Drawing.Size(137, 30);
            this.intercambio.TabIndex = 12;
            this.intercambio.Text = "Intercambio";
            this.intercambio.UseVisualStyleBackColor = true;
            this.intercambio.Click += new System.EventHandler(this.intercambio_Click);
            // 
            // grupoCaramelos
            // 
            this.grupoCaramelos.Location = new System.Drawing.Point(703, 273);
            this.grupoCaramelos.Name = "grupoCaramelos";
            this.grupoCaramelos.Size = new System.Drawing.Size(137, 39);
            this.grupoCaramelos.TabIndex = 13;
            this.grupoCaramelos.Text = "Verificar grupo de caramelos";
            this.grupoCaramelos.UseVisualStyleBackColor = true;
            this.grupoCaramelos.Click += new System.EventHandler(this.grupoCaramelos_Click);
            // 
            // turnoss
            // 
            this.turnoss.AutoSize = true;
            this.turnoss.Location = new System.Drawing.Point(702, 330);
            this.turnoss.Name = "turnoss";
            this.turnoss.Size = new System.Drawing.Size(72, 13);
            this.turnoss.TabIndex = 14;
            this.turnoss.Text = "Movimientos: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(780, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(766, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "label2";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 504);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.turnoss);
            this.Controls.Add(this.grupoCaramelos);
            this.Controls.Add(this.intercambio);
            this.Controls.Add(this.InicioJuego);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.botonAtras);
            this.Controls.Add(this.textBox4ColDos);
            this.Controls.Add(this.textBox3FilaDos);
            this.Controls.Add(this.textBox2ColUno);
            this.Controls.Add(this.textBoxFilaUno);
            this.Controls.Add(this.puntaje);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PosColumnaDos);
            this.Controls.Add(this.posFilaUno);
            this.Controls.Add(this.posFilaDos);
            this.Controls.Add(this.posColumnaUno);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label posFilaUno;
        private System.Windows.Forms.Label posColumnaUno;
        private System.Windows.Forms.Label posFilaDos;
        private System.Windows.Forms.Label PosColumnaDos;
        private System.Windows.Forms.Label puntaje;
        private System.Windows.Forms.TextBox textBoxFilaUno;
        private System.Windows.Forms.TextBox textBox2ColUno;
        private System.Windows.Forms.TextBox textBox3FilaDos;
        private System.Windows.Forms.TextBox textBox4ColDos;
        private System.Windows.Forms.Button botonAtras;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button InicioJuego;
        private System.Windows.Forms.Button intercambio;
        private System.Windows.Forms.Button grupoCaramelos;
        private System.Windows.Forms.Label turnoss;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}