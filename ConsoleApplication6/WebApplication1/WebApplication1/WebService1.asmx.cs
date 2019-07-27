using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;

namespace WebApplication1
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        MySqlConnection conectar;

        [WebMethod]
        public int insertar(String st)
        {
            ObtenerConexion();

            string Query = "insert into usuario(nombre,pass,puntaje) values(" + st + "0" + ");";
            MySqlCommand comando = new MySqlCommand(Query, conectar);
            int retorno = comando.ExecuteNonQuery();

            CerrarConexion();
            return retorno;
        }

        [WebMethod]
        public bool buscar(String nombre)
        {
            ObtenerConexion();

            String nom = null, pass = null;
            int ptje;
            String Query = "Select nombre, pass, puntaje from usuario where nombre = '" + nombre +
                "';";
            MySqlCommand comando = new MySqlCommand(Query, conectar);
            MySqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                nom = lector.GetString(0);
                pass = lector.GetString(1);
                ptje = lector.GetInt32(2);
            }
            lector.Close();

            CerrarConexion();
            if (nom != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public void actualizarPuntaje(int puntaje, String nombre)
        {
            ObtenerConexion();
            String Query = "update usuario set puntaje = " +
                puntaje.ToString() + " where nombre ='" +
                nombre + "';";
            MySqlCommand comando = new MySqlCommand(Query, conectar);
            MySqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {

            }
            lector.Close();
            CerrarConexion();
        }

        [WebMethod]
        public Jugador verificar(String nombre, String password)
        {
            ObtenerConexion();

            String nom = null, pass = null;
            int ptje = 0;
            Jugador j = new Jugador(nom, ptje, password);
            String Query = "Select * from usuario where nombre = '" + nombre +
                "' and  pass = '" + password + "';";
            MySqlCommand comando = new MySqlCommand(Query, conectar);
            MySqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                nom = lector.GetString(1);
                pass = lector.GetString(2);
                ptje = lector.GetInt16(3);
                j.Nombre = nom;
                j.Puntaje = ptje;
            }
            lector.Close();

            CerrarConexion();
            if (nom != null)
            {
                return j;
            }
            else
            {
                return null;
            }
        }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        public void ObtenerConexion()
        {
            conectar = new MySqlConnection("server=127.0.0.1; database=paradigmas; Uid=root; pwd=admin");
            conectar.Open();
        }
        public void CerrarConexion()
        {
            conectar.Close();
        }
    }
}
