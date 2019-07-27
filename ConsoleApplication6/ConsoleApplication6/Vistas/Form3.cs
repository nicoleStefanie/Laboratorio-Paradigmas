using System;
using ConsoleApplication6.Clases;
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
    public partial class Form3 : Form
    {
        Form padre;
        ServicioSoapTarea.WebService1SoapClient servicio = new ServicioSoapTarea.WebService1SoapClient();

        public Form3(Form ant)
        {
            this.padre = ant;
            InitializeComponent();
        }
        //boton siguiente
        public void button1_Click(object sender, EventArgs e)
        {
            String nombre;
            String pass;
            if (this.textBox1.Text == null || this.textBox2.Text == null)
            {
                MessageBox.Show("Campos incompletos");
            }
            else
            {
                nombre = this.textBox1.Text;//Nombre de usuario 
                pass = this.textBox2.Text;//Contraseña 
                try
                {
                    //Verificar que el usuario y contraseña exista 
                    ServicioSoapTarea.Jugador j = new ServicioSoapTarea.Jugador();
                    j =servicio.verificar(nombre, pass);
                    if (j != null)
                    {
                        MessageBox.Show("Datos correctos, Ingresando...");
                        Form2 nuevo = new Form2(j,this);//Vista de las caracteristicas del tablero
                        nuevo.Show();
                        this.Hide();
                    }
                    else
                    {
                        //Si se equivoco en algun campo o los datos no existen
                        MessageBox.Show("Datos incorrectos");
                    }

                }
                catch (Exception w)
                {
                    MessageBox.Show(w.ToString());
                }
            }
        }
        //boton atras
        public void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            padre.Show();
        }
    }
}
