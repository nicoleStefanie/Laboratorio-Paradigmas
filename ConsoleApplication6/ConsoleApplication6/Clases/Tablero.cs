using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Clases
{
    public class Tablero
    {
        public int[,] tablero;
        int fiila;
        int coolumna;
        int dif;
        int modoo;
        Random rand = new Random();
        //Atributos de la clase Tablero
        public int fila
        {
            set { this.fiila = value; }
            get { return this.fiila; }
        }
        public int columna
        {
            set { this.coolumna = value; }
            get { return this.coolumna; }
        }

        public int dificultad
        {
            set { this.dif = value; }
            get { return this.dif; }
        }
        public int modo
        {
            set { this.modoo = value; }
            get { return this.modoo; }
        }
        //Inicializa el tablero
        public void crearTablero()
        {
            tablero = new int[fiila, coolumna];
        }

        //Crea tablero rellenandolo con caramelos segun dificultad para luego revisar que no existe grupo
        //de 3 o mas caramelos iguales, tambien se tiene en cuenta el modo, si es en modo diseñador o no
        public Tablero(int x, int y, int dificultadd,int modo)
        {
            fiila = x;
            coolumna = y;
            dificultad = dificultadd;
            int i, j;
            crearTablero();
            if (modo==0)
            {
                if (dificultad == 1)
                {
                    colocarCaramelos1();
                    for (i = 0; i < fiila; i++)
                    {
                        for (j = 0; j < coolumna; j++)
                        {
                            int caramelo = revisarGrupoCaramelos(tablero[i, j], i, j);
                            tablero[i, j] = caramelo;
                        }
                    }
                }
                else
                {
                    colocarCaramelos2();
                    for (i = 0; i < fiila; i++)
                    {
                        for (j = 0; j < coolumna; j++)
                        {
                            int caramelo = revisarGrupoCaramelosDos(tablero[i, j], i, j);
                            tablero[i, j] = caramelo;
                        }
                    }
                }
            }
            else
            {
                colocarCaramelos3(modo);
                for (i = 0; i < fiila; i++)
                {
                    for (j = 0; j < coolumna; j++)
                    {
                        int caramelo = revisarGrupoCaramelosDos(tablero[i, j], i, j);
                        tablero[i, j] = caramelo;
                    }
                }

            }
        }
        //Coloca caramelos aleatorios segun dificultad 1 en tablero
        public void colocarCaramelos1()
        {
            for (int i = 0; i < fiila; ++i)
                for (int j = 0; j < coolumna; ++j)
                    tablero[i, j] = rand.Next(0, 5);
        }
        //Coloca caramelos aleatorios segun dificultad 2 en tablero
        public void colocarCaramelos2()
        {
            for (int i = 0; i < fiila; ++i)
                for (int j = 0; j < coolumna; ++j)
                    tablero[i, j] = rand.Next(0, 8);
        }
        //Colocar caramelos aleatorios segun cantidad de tipos de caramelos (modo)
        public void colocarCaramelos3(int modo)
        {
            for (int i = 0; i < fiila; ++i)
                for (int j = 0; j < coolumna; ++j)
                    tablero[i, j] = rand.Next(0, modo);
        }
        //Genera caramelo aleatorio segun dificultad en una posicion especifica
        public int generarCaramelo(int posFila, int posColumna, int dificultadd)
        {
            if (dificultadd == 1)
            {
                tablero[posFila, posColumna] = rand.Next(1, 4);
                return tablero[posFila, posColumna];
            }
            if (dificultadd == 2)
            {
                tablero[posFila, posColumna] = rand.Next(1, 7);
                return tablero[posFila, posColumna];

            }
            return 0;
        }

        //Revisar que el tablero creado no contenga grupos de 3 o mas caramelos iguales
        public int revisarGrupoCaramelos(int caramelo, int fila, int columna)
        {
            int otroCaramelo;
            int dim1 = fiila;
            int dim2 = coolumna;
            if ((columna <= (dim2 - 3)) && (fila <= (dim1 - 3)))
            {
                if ((tablero[fila, columna + 1] == caramelo) && (tablero[fila, columna + 2] == caramelo))
                {
                    if (caramelo > 1)
                    {
                        otroCaramelo = rand.Next(1, 4) + 1;
                        return otroCaramelo;
                    }
                    else if (caramelo == 1)
                    {
                        otroCaramelo = rand.Next(0, 4) + 1;
                        return otroCaramelo;
                    }
                    else
                    {
                        return caramelo;
                    }
                }
                if ((tablero[fila + 1, columna] == caramelo) && (tablero[fila + 2, columna] == caramelo))
                {
                    if (caramelo > 1)
                    {
                        otroCaramelo = rand.Next(1, 4) - 1;
                        return otroCaramelo;
                    }
                    else if (caramelo == 1)
                    {
                        otroCaramelo = rand.Next(0, 4) + 1;
                        return otroCaramelo;
                    }
                    else
                    {
                        return caramelo;
                    }
                }
                else
                {
                    return caramelo;
                }
            }
            if (fila <= (dim1 - 3))
            {
                if ((tablero[fila + 1, columna] == caramelo) && (tablero[fila + 2, columna] == caramelo))
                {
                    if (caramelo > 1)
                    {
                        otroCaramelo = rand.Next(1, 4) + 1;
                        return otroCaramelo;
                    }
                    else if (caramelo == 1)
                    {
                        otroCaramelo = rand.Next(0, 4) + 1;
                        return otroCaramelo;
                    }
                    else
                    {
                        return caramelo;
                    }
                }
                else
                {
                    return caramelo;
                }
            }
            if (columna <= (dim2 - 3))
            {
                if ((tablero[fila, columna + 1] == caramelo) && (tablero[fila, columna + 2] == caramelo))
                {
                    if (caramelo > 1)
                    {
                        otroCaramelo = rand.Next(1, 4) + 1;
                        return otroCaramelo;
                    }
                    else if (caramelo == 1)
                    {
                        otroCaramelo = rand.Next(0, 4) + 1;
                        return otroCaramelo;
                    }
                    else
                    {
                        return caramelo;
                    }
                }
                else
                {
                    return caramelo;
                }
            }
            else
            {
                return caramelo;
            }
        }

        //Revisar que el tablero creado no contenga grupos de 3 o mas caramelos iguales
        public int revisarGrupoCaramelosDos(int caramelo, int fila, int columna)
        {
            int otroCaramelo;
            int dim1 = fiila;
            int dim2 = coolumna;
            if ((columna <= (dim2 - 3)) && (fila <= (dim1 - 3)))
            {
                if ((tablero[fila, columna + 1] == caramelo) && (tablero[fila, columna + 2] == caramelo))
                {
                    if (caramelo > 1)
                    {
                        otroCaramelo = rand.Next(1, 7) + 1;
                        return otroCaramelo;
                    }
                    else if (caramelo == 1)
                    {
                        otroCaramelo = rand.Next(1, 7) + 1;
                        return otroCaramelo;
                    }
                    else
                    {
                        return caramelo;
                    }
                }
                if ((tablero[fila + 1, columna] == caramelo) && (tablero[fila + 2, columna] == caramelo))
                {
                    if (caramelo > 1)
                    {
                        otroCaramelo = rand.Next(1, 7) - 1;
                        return otroCaramelo;
                    }
                    else if (caramelo == 1)
                    {
                        otroCaramelo = rand.Next(1, 7) + 1;
                        return otroCaramelo;
                    }
                    else
                    {
                        return caramelo;
                    }
                }
                else
                {
                    return caramelo;
                }
            }
            if (fila <= (dim1 - 3))
            {
                if ((tablero[fila + 1, columna] == caramelo) && (tablero[fila + 2, columna] == caramelo))
                {
                    if (caramelo > 1)
                    {
                        otroCaramelo = rand.Next(1, 7) + 1;
                        return otroCaramelo;
                    }
                    else if (caramelo == 1)
                    {
                        otroCaramelo = rand.Next(1, 7) + 1;
                        return otroCaramelo;
                    }
                    else
                    {
                        return caramelo;
                    }
                }
                else
                {
                    return caramelo;
                }
            }
            if (columna <= (dim2 - 3))
            {
                if ((tablero[fila, columna + 1] == caramelo) && (tablero[fila, columna + 2] == caramelo))
                {
                    if (caramelo > 1)
                    {
                        otroCaramelo = rand.Next(1, 7) + 1;
                        return otroCaramelo;
                    }
                    else if (caramelo == 1)
                    {
                        otroCaramelo = rand.Next(1, 7) + 1;
                        return otroCaramelo;
                    }
                    else
                    {
                        return caramelo;
                    }
                }
                else
                {
                    return caramelo;
                }
            }
            else
            {
                return caramelo;
            }
        }

        //Verificar que no haya ningun grupo de 3 o mas caramelos juntos
        //retornar un booleano
        public bool revisarGruposBool(int caramelo, int fila, int columna)
        {
            int dim1 = fiila;
            int dim2 = coolumna;
            int sigue = 0;
            if ((columna <= (dim2 - 3)) && (fila <= (dim1 - 3)))
            {
                if ((tablero[fila, columna + 1] == caramelo) && (tablero[fila, columna + 2] == caramelo))
                {
                    if (caramelo>0)
                    {
                        return false;
                    }

                }
                if ((tablero[fila + 1, columna] == caramelo) && (tablero[fila + 2, columna] == caramelo))
                {
                    if (caramelo > 0)
                    {
                        return false;
                    }
                }
                else
                {
                    sigue++;
                }
            }
            if (fila <= (dim1 - 3))
            {
                if ((tablero[fila + 1, columna] == caramelo) && (tablero[fila + 2, columna] == caramelo))
                {
                    if (caramelo > 0)
                    {
                        return false;
                    }
                }
                else
                {
                    sigue++;
                }
            }
            if (columna <= (dim2 - 3))
            {
                if ((tablero[fila, columna + 1] == caramelo) && (tablero[fila, columna + 2] == caramelo))
                {
                    if (caramelo > 0)
                    {
                        return false;
                    }
                }
                else
                {
                    sigue++;
                }
            }
            else
            {
                sigue++;
            }
            return true;
        }

        //verficar tablero válido, retornar true o false
        public bool checkBoard()
        {
            int filas = fila;
            int columnas = columna;
            int dif = dificultad;
            int i, j;
            bool booleano;
            int sigue = 0;
            if (dif == 1)
            {
                for (i = 0; i < filas; i++)
                {
                    for (j = 0; j < columnas; j++)
                    {
                        if (tablero[i, j] < 5)
                        {
                            booleano= revisarGruposBool(tablero[i,j],i,j);
                            if (booleano==true)
                            {
                                sigue++;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            if (dif == 2)
            {
                for (i = 0; i < filas; i++)
                {
                    for (j = 0; j < columnas; j++)
                    {
                        if (tablero[i, j] < 7)
                        {
                            booleano = revisarGruposBool(tablero[i, j], i, j);
                            if (booleano == true)
                            {
                                sigue++;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                for (i = 0; i < filas; i++)
                {
                    for (j = 0; j < columnas; j++)
                    {
                        booleano = revisarGruposBool(tablero[i, j], i, j);
                        if (booleano == true)
                        {
                            sigue++;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }
}
