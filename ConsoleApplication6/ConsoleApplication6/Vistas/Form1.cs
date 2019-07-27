using System;
using ConsoleApplication6.Clases;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication6.Vistas
{
    public partial class Form1 : Form
    {
 
        public Form1()
        {

            InitializeComponent();
        }
        //Iniciar sesion 
        public void button3_Click(object sender, EventArgs e)
        {

            Form despues = new Form3(this);//Ingresar usuario y contraseña
            despues.Show();
            this.Hide();
        }

        //Registrarse (login)
        public void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conecta3");
            Form4 despues = new Form4(this);//Registrarse
            despues.Show();
            this.Hide();
        }
        //Entrar sin registrarse
        public void button2_Click(object sender, EventArgs e)
        {
            ServicioSoapTarea.Jugador j = new ServicioSoapTarea.Jugador();
            Form despues = new Form2(j, this);//Caracteristicas del tablero
            despues.Show();
            this.Hide();
        }
    }
}
