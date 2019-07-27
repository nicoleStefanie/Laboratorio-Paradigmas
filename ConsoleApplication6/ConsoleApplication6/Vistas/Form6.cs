using System;
using Proyecto.Clases;
using ConsoleApplication6.Clases;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication6.Vistas
{
    public partial class Form6 : Form
    {
        Form padre;
        Juego actual;
        Button[,] botones;
        int cont;
        int cont2;
        ServicioSoapTarea.WebService1SoapClient servicio = new ServicioSoapTarea.WebService1SoapClient();

        public Form6(Juego juego, Form ant)
        {
            InitializeComponent();
            actual = juego;
            padre = ant;
            botones = new Button[actual.tableroo.fila, actual.tableroo.columna];
            rellenar1();
            this.InicioJuego.Enabled = false;
            this.intercambio.Enabled = false;
            this.grupoCaramelos.Enabled = false;
        }

        //Rellenar el tablero con los caramelos
        public void actualizarTablero()
        {
            int i = 0;
            while (i < actual.tableroo.fila)
            {
                int j = 0;
                while (j < actual.tableroo.columna)
                {
                    if (actual.tableroo.tablero[i, j] == 0)
                    {
                        botones[i, j].Text = "0";
                    }
                    else
                    {
                        if (actual.tableroo.tablero[i, j] == 1)
                        {
                            botones[i, j].Text = "1";
                        }
                        else
                        {
                            if (actual.tableroo.tablero[i, j] == 2)
                            {
                                botones[i, j].Text = "2";
                            }
                            else
                            {
                                if (actual.tableroo.tablero[i, j] == 3)
                                {
                                    botones[i, j].Text = "3";
                                }
                                else
                                {
                                    if (actual.tableroo.tablero[i, j] == 4)
                                    {
                                        botones[i, j].Text = "4";
                                    }
                                    else
                                    {
                                        if (actual.tableroo.tablero[i, j] == 5)
                                        {
                                            botones[i, j].Text = "5";
                                        }
                                        else
                                        {
                                            if (actual.tableroo.tablero[i, j] == 6)
                                            {
                                                botones[i, j].Text = "6";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    j++;
                }
                i++;
            }
        }
        //boton atras
        public void botonAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            padre.Show();
        }
        //verificar tablero
        public void button1_Click(object sender, EventArgs e)
        {
            if (actual.tableroo.checkBoard() == true)
            {
                MessageBox.Show("Tablero válido, puede jugar");
                this.InicioJuego.Enabled = true;
            }
            else
            {
                MessageBox.Show("Tablero no válido vuelva al menu anterior y pruebe de nuevo");
            }
        }
        //Inicializar el tablero antes de darle la cantidad de movimientos 
        public void rellenar1()
        {
            int i = 0;
            int posy = 0;
            cont = 553 / actual.tableroo.fila;
            cont2 = 421 / actual.tableroo.columna;
            while (i < actual.tableroo.fila)
            {
                int posx = 0;
                int j = 0;
                while (j < actual.tableroo.columna)
                {
                    Button but = new Button();
                    but.SetBounds(posx, posy, cont, cont2);
                    botones[i, j] = but;
                    this.panel1.Controls.Add(but);
                    but.Text = "-";
                    posx += cont;
                    j++;
                }
                posy += cont2;
                i++;
            }
     
        }
        //iniciar juego
        public void InicioJuego_Click(object sender, EventArgs e)
        {
            this.intercambio.Enabled = true;
            this.grupoCaramelos.Enabled = true;
            //Mostrar puntaje y turnos 
            String msj2 = "0";
            label3.Text = msj2;
            label3.Show();
            label4.Text = actual.turnos.ToString();
            label4.Show();

        }
        //realizar la jugada (misma que en modo no diseñador 
        private void intercambio_Click(object sender, EventArgs e)
        {
            int a, b, c, d;
            bool x, y, z, w;
            x = int.TryParse(this.textBoxFilaUno.Text, out a);
            y = int.TryParse(this.textBox2ColUno.Text, out b);
            z = int.TryParse(this.textBox3FilaDos.Text, out c);
            w = int.TryParse(this.textBox4ColDos.Text, out d);

            if ((actual.tableroo.tablero[a, b] != 0) && (actual.tableroo.tablero[c, d] != 0))
            {
                actual.intercambioCaramelos(a, b, c, d);
                actualizarTablero();
                mostrar();
                int puntaje;
                Console.Write("\n");
                int[] arreglo = actual.checkCandies();
                if (arreglo == null)
                {
                    Console.Write("no hay grupo de caramelos");
                }
                else
                {
                    if (arreglo[0] == 0)
                    {
                        if (actual.tableroo.tablero[arreglo[1], arreglo[2]] == 1)
                        {
                            actual.eliminarGrupoCaramelosFila(arreglo);
                            mostrar();
                            Console.Write("\n");
                            actual.eliminarfilaUnos(arreglo);
                            mostrar();
                            Console.Write("\n");
                            actual.eliminarFilasAdyacentes(arreglo);
                            mostrar();
                            Console.Write("\n");
                            actualizarTablero();
                            int[] arreglo1 = actual.checkCandies();
                            if (arreglo1 != null)
                            {
                                actual.turnos--;
                                Console.Write(actual.turnos);
                                otrajugada(arreglo1);//termino de jugada 
                                puntaje = actual.calcularPuntaje(arreglo1);
                                ServicioSoapTarea.Jugador j = new ServicioSoapTarea.Jugador();
                                try
                                {
                                    ThreadStart start = delegate { servicio.actualizarPuntaje(puntaje, j.Nombre); };
                                    Thread t = new Thread(start);
                                    t.Start();
                                    label3.Text = puntaje.ToString();
                                    label3.Show();
                                }
                                catch (Exception r)
                                {
                                    MessageBox.Show(r.ToString());
                                }
                                if (actual.verificarRecubrimientos() == true)
                                {
                                    MessageBox.Show("juego terminado, su puntaje es: !!" + puntaje);
                                    this.InicioJuego.Enabled = false;
                                    this.intercambio.Enabled = false;
                                    this.grupoCaramelos.Enabled = false;
                                }
                            }
                            int turn = actual.turnos - 1;
                            label4.Text = turn.ToString();
                            label4.Show();

                        }
                        else
                        {
                            actual.eliminarGrupoCaramelosFila(arreglo);
                            mostrar();
                            Console.Write("\n");
                            Console.Write(arreglo.Length);
                            actual.eliminarRecubrimientoFila(arreglo);//eliminar ceros adyacentes
                            mostrar();
                            Console.Write("\n");
                            Console.Write("\n");
                            actualizarTablero();
                            int[] arreglo1 = actual.checkCandies();
                            if (arreglo1 != null)
                            {
                                actual.turnos--;
                                Console.Write(actual.turnos);
                                otrajugada(arreglo1);
                                puntaje = actual.calcularPuntaje(arreglo1);
                                ServicioSoapTarea.Jugador j = new ServicioSoapTarea.Jugador();
                                try
                                {
                                    ThreadStart start = delegate { servicio.actualizarPuntaje(puntaje, j.Nombre); };
                                    Thread t = new Thread(start);
                                    t.Start();
                                    label3.Text = puntaje.ToString();
                                    label3.Show();
                                }
                                catch (Exception r)
                                {
                                    MessageBox.Show(r.ToString());
                                }

                                if (actual.verificarRecubrimientos() == true)
                                {
                                    MessageBox.Show("juego terminado, su puntaje es: !!" + puntaje);
                                    this.InicioJuego.Enabled = false;
                                    this.intercambio.Enabled = false;
                                    this.grupoCaramelos.Enabled = false;
                                }
                            }
                            int turn = actual.turnos - 1;
                            label4.Text = turn.ToString();
                            label4.Show();
                        }

                    }
                    else//grupo en columna
                    {
                        actual.eliminarGrupoCaramelosCol(arreglo);
                        mostrar();
                        Console.Write("\n");
                        actual.eliminarRecubrimientoColumna(arreglo);//eliminar ceros adyacentes
                        mostrar();
                        Console.Write("\n");
                        Console.Write("\n");
                        actualizarTablero();
                        int[] arreglo1 = actual.checkCandies();
                        if (arreglo1 != null)
                        {
                            actual.turnos--;
                            Console.Write(actual.turnos);
                            otrajugada(arreglo1);
                            puntaje = actual.calcularPuntaje(arreglo1);
                            ServicioSoapTarea.Jugador j = new ServicioSoapTarea.Jugador();
                            try
                            {
                                ThreadStart start = delegate { servicio.actualizarPuntaje(puntaje, j.Nombre); };
                                Thread t = new Thread(start);
                                t.Start();
                                label3.Text = puntaje.ToString();
                                label3.Show();
                            }
                            catch (Exception r)
                            {
                                MessageBox.Show(r.ToString());
                            }
                            if (actual.verificarRecubrimientos() == true)
                            {
                                MessageBox.Show("juego terminado, su puntaje es: !!" + puntaje);
                                this.InicioJuego.Enabled = false;
                                this.intercambio.Enabled = false;
                                this.grupoCaramelos.Enabled = false;

                            }
                        }
                        int turn = actual.turnos - 1;
                        label4.Text = turn.ToString();
                        label4.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se puede mover un recubrimiento duro !!");
            }
        }
        //Metodo para seguir realizando explociones 
        public void otrajugada(int[] arreglo)
        {
            if (arreglo == null)
            {
                Console.Write("no hay grupo de caramelos");
            }
            else
            {
                if (arreglo[0] == 0)//grupo en fila [0,fila,columnas..]
                {
                    if (actual.tableroo.tablero[arreglo[1], arreglo[2]] == 1)
                    {
                        actual.eliminarGrupoCaramelosFila(arreglo);
                        mostrar();
                        Console.Write("\n");
                        actual.eliminarfilaUnos(arreglo);
                        mostrar();
                        Console.Write("\n");
                        actual.eliminarFilasAdyacentes(arreglo);
                        mostrar();
                        Console.Write("\n");
                        actualizarTablero();
                        int[] arreglo1 = actual.checkCandies();
                        if (arreglo1 != null)
                        {
                            otrajugada(arreglo1);
                        }
                    }
                    else
                    {
                        actual.eliminarGrupoCaramelosFila(arreglo);
                        mostrar();
                        Console.Write("\n");
                        actual.eliminarRecubrimientoFila(arreglo);//eliminar ceros adyacentes
                        mostrar();
                        Console.Write("\n");
                        actualizarTablero();
                        int[] arreglo1 = actual.checkCandies();
                        if (arreglo1 != null)
                        {
                            otrajugada(arreglo1);
                        }
                    }
                }
                else//grupo en columna
                {
                    actual.eliminarGrupoCaramelosCol(arreglo);
                    mostrar();
                    Console.Write("\n");
                    actual.eliminarRecubrimientoColumna(arreglo);//eliminar ceros adyacentes
                    mostrar();
                    Console.Write("\n");
                    actualizarTablero();
                    int[] arreglo1 = actual.checkCandies();
                    if (arreglo1 != null)
                    {
                        otrajugada(arreglo1);
                    }
                }
            }
        }

        //Boton para cantidad de movimientos
        public void button2_Click(object sender, EventArgs e)
        {
            int a;
            bool mov;
            mov = int.TryParse(this.textBox1.Text, out a);
            if (mov)
            {
                actual.turnos = a;
                MessageBox.Show("Usted dispone de: "+a+"movimientos");
            }
            actualizarTablero();
            mostrar();
        }
        //Mostrar el tablero por consola para tener un seguimiento de cada paso de la jugada 
        public void mostrar()
        {
            int i, j;
            for (i = 0; i < actual.tableroo.fila; i++)
            {
                Console.Write(" ");
                for (j = 0; j < actual.tableroo.columna; j++)
                {
                    Console.Write(actual.tableroo.tablero[i, j]);
                }
                Console.Write("\n");
            }
        }
        //Verificar grupo de caramelos
        private void grupoCaramelos_Click(object sender, EventArgs e)
        {
            if (actual.checkCandies() == null)
            {
                MessageBox.Show("No hay grupo que explotar");
            }
            else
            {
                int[] arreglo = actual.checkCandies();
                string resultado = string.Join(",", arreglo);

                MessageBox.Show("Caramelos a explotar en las posiciones: " + resultado);
            }
        }
    }
}
