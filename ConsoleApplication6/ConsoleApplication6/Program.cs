using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proyecto.Clases;
using System.Windows.Forms;
using System.Threading.Tasks;
using ConsoleApplication6.Clases;
using ConsoleApplication6.Vistas;


namespace Proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
