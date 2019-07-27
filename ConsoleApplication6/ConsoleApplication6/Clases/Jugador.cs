using System;
using Proyecto.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication6.ServicioSoapTarea;

namespace ConsoleApplication6.Clases
{
    public class Jugador
    {
        String nombre;
        String contraseña;
        int puntaje = 0;
        //Atributos de la clase Jugador
        public String Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Puntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }

        public Jugador(String nombre, int puntaje, String contraseña)
        {
            this.puntaje = puntaje;
            this.nombre = nombre;
            this.contraseña = contraseña;
        }

        public Jugador()
        {
        }
    }
}
