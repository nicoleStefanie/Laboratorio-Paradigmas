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
    public partial class Form4 : Form
    {
        Form padre;
        ServicioSoapTarea.WebService1SoapClient servicio = new ServicioSoapTarea.WebService1SoapClient();

        public Form4(Form padre)
        {
            this.padre = padre;
            InitializeComponent();
        }
        //Boton atras
        public void botonAtras(object sender, EventArgs e)
        {
            this.Dispose();
            padre.Show();
        }
        //Boton para registrarse 
        public void registrar(object sender, EventArgs e)
        {
            String nom = this.textBox1.Text;//Nombre de usuario 
            String pass1 = this.textBox2.Text;//Contraseña
            String pass2 = this.textBox3.Text;//Repeticion de la contraseña
            String texto;
            if (pass1 != pass2)
            {//Contraseñas no son iguales
                MessageBox.Show("Las contraseñas no coinciden");
            }
            else
            {
                if (nom == pass1)
                {
                    MessageBox.Show("El nombre de usuario es igual a la contraseña");
                }
                else
                {
                    try
                    {
                        //Si el usuario que indicó, ya existe 
                        bool encontrado = servicio.buscar(nom);
                        if (encontrado == true)
                        {
                            MessageBox.Show("Usuario ya registrado");
                        }
                        else
                        {
                            //Se realiza el registro 
                            texto = "'" + nom + "','" + pass1 + "',";
                            int insertado = servicio.insertar(texto);
                            MessageBox.Show("Registro realizado con éxito");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Registro no se pudo realizar");
                    }
                }
            }
        }
    }
}
