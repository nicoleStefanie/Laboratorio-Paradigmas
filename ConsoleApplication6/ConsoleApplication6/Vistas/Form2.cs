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
    public partial class Form2 : Form
    {
        Juego juego;
        Form anterior;
        ServicioSoapTarea.Jugador j;
        public Form2(ServicioSoapTarea.Jugador jugador1, Form ant)
        {
            anterior = ant;
            j = jugador1;
            InitializeComponent();
        }
        //Boton siguiente para luego ir a la ventana de juego
        public void botonSgte(object sender, EventArgs e)
        {
            int x, y, dif;
            bool bx, by, dificultad;
            dificultad = int.TryParse(this.textBox2.Text, out dif);//dificultad
            bx = int.TryParse(this.textBox1.Text, out x);//largo del tablero, fila
            by = int.TryParse(this.textBox3.Text, out y);//ancho del tablero, columna
            if (bx && by && dificultad)
            {
                juego = new Juego(j, x, y, dif,0);//Nuevo juego
                Form despues = new Form5(juego, this); // vista del tablero
                this.Hide();
                despues.Show();
            }
            else
            {
                String acum = "";
                int i = 0;
                if (!bx)
                {
                    acum = acum + "\nPosicion x";//fila
                    i++;
                }
                if (!by)
                {
                    acum = acum + "\nPosicion y";//columna
                    i++;
                }
                if (!dificultad)
                {
                    acum = acum + "\ndificultad";
                    i++;
                }
                MessageBox.Show("Error en los datos: " + acum);
            }

        }
        //Boton atrás
        public void BotonAtras(object sender, EventArgs e)
        {
            anterior.Show();
            this.Close();
        }
        //Boton modo diseñador
        public void modoDis(object sender, EventArgs e)
        {
            int x, y,moddo;
            bool bx, by,modo;
            //Dimensiones del tablero
            bx = int.TryParse(this.textBox1.Text, out x);
            by = int.TryParse(this.textBox3.Text, out y);
            //En este caso es la cantidad de tipos de caramelos que se decea para el
            //modo no diseñador, es posible solo hasta 6 tipos de caramelos
            modo = int.TryParse(this.textBox2.Text, out moddo);

            if (bx && by && modo)
            {
                juego = new Juego(j, x, y, 0,moddo);
                Form despues = new Form6(juego, this);//vista del tablero
                this.Hide();
                despues.Show();
            }
            else
            {
                String acum = "";
                int i = 0;
                if (!bx)
                {
                    acum = acum + "\nPosicion x";//fila
                    i++;
                }
                if (!by)
                {
                    acum = acum + "\nPosicion y";//columna
                    i++;
                }
                if (!modo)
                {
                    acum = acum + "\nModo ";//Modo (cantidad de tipos de caramelos)
                    i++;
                }
                MessageBox.Show("Error en los datos: " + acum);
            }
        }
    }
}
