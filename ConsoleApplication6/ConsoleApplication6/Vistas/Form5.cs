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
    public partial class Form5 : Form
    {
        Form padre;
        Juego actual;
        Button[,] botones;
        int cont;
        int cont2;
        //servicio 
        ServicioSoapTarea.WebService1SoapClient servicio = new ServicioSoapTarea.WebService1SoapClient();
        public Form5(Juego juego, Form ant)
        {
            InitializeComponent();
            actual = juego;
            padre = ant;
            botones = new Button[actual.tableroo.fila, actual.tableroo.columna];
            rellenar();
            this.InicioJuego.Enabled = false;
            this.intercambio.Enabled = false;
            this.grupoCaramelos.Enabled = false;
        }
        //rellenar el tablero con los caramelos segun matriz por debajo 
        public void rellenar()
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
                    //Botones 
                    Button but = new Button();
                    but.SetBounds(posx, posy, cont, cont2);
                    botones[i, j] = but;
                    this.panel1.Controls.Add(but);
                    //Colocar texto en botones segun dificultad y numeros en matriz
                    if (actual.tableroo.dificultad == 1)
                    {
                        if (actual.tableroo.tablero[i, j] == 0)
                        {
                            but.Text = "0";
                        }
                        else
                        {
                            if (actual.tableroo.tablero[i, j] == 1)
                            {
                                but.Text = "1";
                            }
                            else
                            {
                                if (actual.tableroo.tablero[i, j] == 2)
                                {
                                    but.Text = "2";
                                }
                                else
                                {
                                    if (actual.tableroo.tablero[i, j] == 3)
                                    {
                                        but.Text = "3";
                                    }
                                    else
                                    {
                                        if (actual.tableroo.tablero[i, j] == 4)
                                        {
                                            but.Text = "4";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else//dificultad 2
                    {
                        if (actual.tableroo.tablero[i, j] == 0)
                        {
                            but.Text = "0";
                        }
                        else
                        {
                            if (actual.tableroo.tablero[i, j] == 1)
                            {
                                but.Text = "1";
                            }
                            else
                            {
                                if (actual.tableroo.tablero[i, j] == 2)
                                {
                                    but.Text = "2";
                                }
                                else
                                {
                                    if (actual.tableroo.tablero[i, j] == 3)
                                    {
                                        but.Text = "3";
                                    }
                                    else
                                    {
                                        if (actual.tableroo.tablero[i, j] == 4)
                                        {
                                            but.Text = "4";
                                        }
                                        else
                                        {
                                            if (actual.tableroo.tablero[i, j] == 5)
                                            {
                                                but.Text = "5";
                                            }
                                            else
                                            {
                                                if (actual.tableroo.tablero[i, j] == 6)
                                                {
                                                    but.Text = "6";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    posx += cont;
                    j++;
                }
                posy += cont2;
                i++;
            }
            intercambio.Click += new EventHandler(intercambio_Click);//evento que lleva el metodo de intercambio (jugada)
        }
        //boton iniciar juego
        public void button2_Click(object sender, EventArgs e)
        {
            this.intercambio.Enabled = true;
            this.grupoCaramelos.Enabled = true;
            //Mostrar puntaje en 0 y cantidad de turnos segun dificultad
            String msj2 = "0";
            label2.Text = msj2;
            label2.Show();
            label1.Text = actual.turnos.ToString();
            label1.Show();

        }
        //boton intercambio, realizar toda la jugada
        public void intercambio_Click(object sender, EventArgs e)
        {
            int a, b, c, d;
            bool x, y, z, w;
            x = int.TryParse(this.textBoxFilaUno.Text, out a);
            y = int.TryParse(this.textBox2ColUno.Text, out b);
            z = int.TryParse(this.textBox3FilaDos.Text, out c);
            w = int.TryParse(this.textBox4ColDos.Text, out d);

            if ((actual.tableroo.tablero[a,b]!= 0) && (actual.tableroo.tablero[c,d]!= 0))
            {
                //intercambio de dos caramelos
                actual.intercambioCaramelos(a, b, c, d);
                mostrar();
                int puntaje;
                Console.Write("\n");
                int[] arreglo = actual.checkCandies();
                if (arreglo == null)//no hay grupo de caramelos iguales
                {
                    Console.Write("no hay grupo de caramelos");
                }
                else
                {
                    if (arreglo[0] == 0)//Grupo se encuentra en fila 
                    {
                        if (actual.tableroo.tablero[arreglo[1], arreglo[2]] == 1)
                        {//Grupo en fila de tipo 1, CARAMELO ESPECIAL 
                            actual.eliminarGrupoCaramelosFila(arreglo);
                            mostrar();
                            Console.Write("\n");
                            //Capacidad especial del caramelo tipo 1: Eliminar la fila en donde se 
                            //encuentra el grupo y ademas eliminar filas adyacentes (arriba o abajo)
                            actual.eliminarfilaUnos(arreglo);
                            mostrar();
                            Console.Write("\n");
                            actual.eliminarFilasAdyacentes(arreglo);
                            mostrar();
                            Console.Write("\n");
                            //actualizar botones
                            actualizarTablero();
                            //Si hay grupo de caramelos 
                            int[] arreglo1 = actual.checkCandies();
                            if (arreglo1 != null)//Si hay 
                            {
                                otrajugada(arreglo1);//realizar las explociones  
                                puntaje = actual.calcularPuntaje(arreglo1);//puntaje
                                //Instancia del jugador del servicio 
                                //(Se ocupa el modelo "jugador" del servicio)
                                ServicioSoapTarea.Jugador j = new ServicioSoapTarea.Jugador();
                                try
                                {//actualizar puntaje 
                                    ThreadStart start = delegate { servicio.actualizarPuntaje(puntaje, j.Nombre); };
                                    Thread t = new Thread(start);
                                    t.Start();
                                    label2.Text = puntaje.ToString();
                                    label2.Show();
                                }
                                catch (Exception r)
                                {
                                    MessageBox.Show(r.ToString());
                                }
                                if (actual.verificarRecubrimientos() == true)//si no quedan recubrimientos en tablero (ceros)
                                {
                                    MessageBox.Show("juego terminado, su puntaje es: !!" + puntaje);
                                    this.InicioJuego.Enabled = false;
                                    this.intercambio.Enabled = false;
                                    this.grupoCaramelos.Enabled = false;
                                }
                            }
                            int turn = actual.turnos - 1;//disminucion de los movimientos disponibles  
                            label1.Text = turn.ToString();//mostrar la cantidad de movimientos disponibles 
                            label1.Show();

                        }
                        else//Grupo de caramelos iguales en fila, caramelos distintos al tipo 1
                        {
                            //eliminar grupo de caramelos 
                            actual.eliminarGrupoCaramelosFila(arreglo);
                            mostrar();
                            Console.Write("\n");
                            Console.Write("\n");
                            // eliminar ceros adyacentes
                            actual.eliminarRecubrimientoFila(arreglo);
                            mostrar();
                            Console.Write("\n");
                            Console.Write("\n");
                            //actualizar botones
                            actualizarTablero();
                            //Si hay grupo de caramelos 
                            int[] arreglo1 = actual.checkCandies();
                            if (arreglo1 != null)
                            {//Hay grupo 
                                otrajugada(arreglo1);//realizar explociones 
                                puntaje = actual.calcularPuntaje(arreglo1);//punntaje
                                ServicioSoapTarea.Jugador j = new ServicioSoapTarea.Jugador();
                                try
                                {//actualizar puntaje
                                    ThreadStart start = delegate { servicio.actualizarPuntaje(puntaje, j.Nombre); };
                                    Thread t = new Thread(start);
                                    t.Start();
                                    label2.Text = puntaje.ToString();//mostrar puntaje 
                                    label2.Show();
                                }
                                catch (Exception r)
                                {
                                    MessageBox.Show(r.ToString());
                                }

                                if (actual.verificarRecubrimientos() == true)//si no quedan recubrimientos en tablero (ceros)
                                {
                                    MessageBox.Show("juego terminado, su puntaje es: !!" + puntaje);
                                    this.InicioJuego.Enabled = false;
                                    this.intercambio.Enabled = false;
                                    this.grupoCaramelos.Enabled = false;
                                }
                            }
                            int turn = actual.turnos - 1;//Disminucion de los movimientos disponibles
                            label1.Text = turn.ToString();//mostrar cantidad de movimientos 
                            label1.Show();
                        }

                    }
                    else//Grupo en columna
                    {
                        //Eliminar grupo en columna
                        actual.eliminarGrupoCaramelosCol(arreglo);
                        mostrar();
                        Console.Write("\n");
                        //eliminar ceros adyacentes
                        actual.eliminarRecubrimientoColumna(arreglo);
                        mostrar();
                        Console.Write("\n");
                        Console.Write("\n");
                        //actualizar botones
                        actualizarTablero();
                        //si hay grupo de caramelos 
                        int[] arreglo1 = actual.checkCandies();
                        if (arreglo1 != null)
                        {//si hay Grupo
                            otrajugada(arreglo1);//Realizar explociones
                            puntaje = actual.calcularPuntaje(arreglo1);//puntaje 
                            ServicioSoapTarea.Jugador j = new ServicioSoapTarea.Jugador();
                            try
                            {//actualizar puntaje 
                                ThreadStart start = delegate { servicio.actualizarPuntaje(puntaje, j.Nombre); };
                                Thread t = new Thread(start);
                                t.Start();
                                label2.Text = puntaje.ToString();//mostrar puntaje 
                                label2.Show();
                            }
                            catch (Exception r)
                            {
                                MessageBox.Show(r.ToString());
                            }
                            if (actual.verificarRecubrimientos() == true)//Si no hay recubrimientos en tablero 
                            {
                                MessageBox.Show("juego terminado, su puntaje es: !!" + puntaje);
                                this.InicioJuego.Enabled = false;
                                this.intercambio.Enabled = false;
                                this.grupoCaramelos.Enabled = false;

                            }
                        }
                        int turn = actual.turnos - 1;//Disminucion de la cantidad de movimientos disponibles
                        label1.Text = turn.ToString();//Mostrar cantidad de movimientos 
                        label1.Show();
                    }
                }
            }
            else
            {//Si se mueve un recubrimiento duro, (cero)
                MessageBox.Show("No se puede mover un recubrimiento duro !!");
            }

        }
        //realizando jugadas
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
                        //eliminar ceros adyacentes
                        actual.eliminarRecubrimientoFila(arreglo);
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
                    //eliminar ceros adyacentes
                    actual.eliminarRecubrimientoColumna(arreglo);
                    mostrar();
                    Console.Write("\n");
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
        //Metodo para actualizar los botones luego de cada modificacion 
        public void actualizarTablero()
        {
            int i = 0;
            while (i<actual.tableroo.fila)
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
        //verificar tablero válido
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
        //verificar grupo de caramelos
        private void grupoCaramelos_Click(object sender, EventArgs e)
        {
            if (actual.checkCandies() == null)
            {
                MessageBox.Show("No hay grupo que explotar");
            }
            else
            {
                int[] arreglo = actual.checkCandies();
                string resultado= string.Join(",", arreglo);

                MessageBox.Show("Caramelos a explotar en las posiciones: " + resultado);
            }
        }

        //boton Atras
        public void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            padre.Show();
        }


        //mostrar tablero en consola para seguimiento de cada paso en jugada  
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
    }
}