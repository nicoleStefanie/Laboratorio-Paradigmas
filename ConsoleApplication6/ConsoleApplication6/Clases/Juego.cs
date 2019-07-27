using System;
using Proyecto.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6.Clases
{
    public class Juego
    {
        ServicioSoapTarea.Jugador j1;
        Tablero tablero;
        int turnoss;
        Random rand = new Random();
        //Atributos de la clase Juego
        public Tablero tableroo
        {
            get { return tablero; }
            set { tablero = value; }
        }
        public int turnos
        {
            set { this.turnoss = value; }
            get { return this.turnoss; }
        }   
        //crear un juego, a partir de dos dimenciones, un modo de juego, dificultad ...
        public Juego(ServicioSoapTarea.Jugador jugador, int x, int y, int dificultad,int modo)
        {
            j1 = jugador;
            if (modo == 0)//modo no diseñador
            {
                if (dificultad == 1)
                {
                    tablero = new Tablero(x, y, dificultad,0);
                    turnoss = 20;
                }
                if (dificultad == 2)
                {
                    tablero = new Tablero(x, y, dificultad,0);
                    turnoss = 30;
                }
            }
            else//modo diseñador
            {
                tablero = new Tablero(x, y, dificultad, modo);
            }
        }

        //verifica si hay grupo de caramelos iguales en el tablero
        //la cual retorna un arreglo con las pociones de la siguiente manera:
        //si el grupo se encuentra fila: [0,fila,columa1,columna2,columna3.,..]
        //si el grupo se enccuentra en columna: [1,columna,fila1,fila2,fila3,...]
        public int[] checkCandies()
        {
            int[] grupoCaramelos = new int[tablero.fila];
            int encontrado = 0;
            for (int i = 0; i < tablero.fila; ++i)
            {
                for (int j = 0; j < tablero.columna; ++j)
                {
                    int caramelo = tablero.tablero[i, j];
                    if (caramelo != 0)
                    {
                        if (encontrado == 1)//salirse del ciclo luego de encontrar el primer grupo
                        {
                            i = tablero.fila + 1;
                            j = tablero.columna + 1;
                        }
                        else
                        {
                            if ((i <= (tablero.fila - 3)) && (j <= tablero.columna - 3))
                            {
                                if ((tablero.tablero[i, j + 1] == caramelo) && (tablero.tablero[i, j + 2] == caramelo))//fila
                                {
                                    int contador = 3;
                                    int c;
                                    int[] aux1 = new int[tablero.columna];
                                    aux1[0] = 0;
                                    aux1[1] = i;
                                    aux1[2] = j;
                                    aux1[3] = j + 1;
                                    aux1[4] = j + 2;
                                    int k = 4;
                                    while (k < tablero.columna)
                                    {
                                        for (c = j + 3; c < tablero.columna; c++)
                                        {
                                            k++;
                                            if (tablero.tablero[i, c] == caramelo)
                                            {
                                                aux1[k] = c;
                                                contador++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    int x;
                                    for (x = 0; x < contador + 2; x++)
                                    {
                                        grupoCaramelos[x] = aux1[x];
                                    }
                                    encontrado = 1;
                                    return grupoCaramelos;
                                }
                                if ((tablero.tablero[i + 1, j] == caramelo) && (tablero.tablero[i + 2, j] == caramelo))//columna
                                {
                                    int contador = 3;
                                    int c;
                                    int[] aux1 = new int[tablero.fila];
                                    aux1[0] = 1;
                                    aux1[1] = j;
                                    aux1[2] = i;
                                    aux1[3] = i + 1;
                                    aux1[4] = i + 2;
                                    int k = 4;
                                    while (k < tablero.fila)
                                    {
                                        for (c = j + 3; c < tablero.fila; c++)
                                        {
                                            k++;
                                            if (tablero.tablero[i, c] == caramelo)
                                            {
                                                aux1[k] = c;
                                                contador++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    int x;
                                    for (x = 0; x < contador + 2; x++)
                                    {
                                        grupoCaramelos[x] = aux1[x];
                                    }
                                    encontrado = 1;
                                    return grupoCaramelos;
                                }
                            }
                            if (i <= (tablero.fila - 3) && (j > (tablero.columna - 3)))
                            {
                                if ((tablero.tablero[i + 1, j] == caramelo) && (tablero.tablero[i + 2, j] == caramelo))
                                {
                                    int contador = 3;
                                    int c;
                                    int[] aux1 = new int[tablero.fila];
                                    aux1[0] = 1;
                                    aux1[1] = j;
                                    aux1[2] = i;
                                    aux1[3] = i + 1;
                                    aux1[4] = i + 2;
                                    int k = 4;
                                    while (k < tablero.fila)
                                    { //recorre aux[]
                                        for (c = i + 3; c < tablero.fila; c++)
                                        { //revisar si los siguientes son iguales a los anteriores 
                                            k++;
                                            if (tablero.tablero[c, j] == caramelo)
                                            {
                                                aux1[k] = c;
                                                contador++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    int x;
                                    for (x = 0; x < contador + 2; x++)
                                    {
                                        grupoCaramelos[x] = aux1[x];
                                    }
                                    encontrado = 1;
                                    return grupoCaramelos;
                                }
                            }
                            if (j <= (tablero.columna - 3) && (i > (tablero.fila - 3)))
                            {
                                if ((tablero.tablero[i, j + 1] == caramelo) && (tablero.tablero[i, j + 2] == caramelo))
                                { //fila
                                    int contador = 3; //caramelos iguales 
                                    int c;
                                    int[] aux1 = new int[tablero.fila];
                                    aux1[0] = 0;
                                    aux1[1] = i;
                                    aux1[2] = j;
                                    aux1[3] = j + 1;
                                    aux1[4] = j + 2;
                                    int k = 4;
                                    while (k < tablero.fila)
                                    { //recorre aux[]
                                        for (c = j + 3; c < tablero.fila; c++)
                                        { //revisar si los siguientes son iguales a los anteriores 
                                            k++;
                                            if (tablero.tablero[i, c] == caramelo)
                                            {
                                                aux1[k] = c;
                                                contador++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    int x;
                                    for (x = 0; x < contador + 2; x++)
                                    {
                                        grupoCaramelos[x] = aux1[x];
                                    }
                                    encontrado = 1;
                                    return grupoCaramelos;
                                }
                            }
                        }
                    }
                }
             }
            return null;
        }
        //verificar que no haya ningun recubrimiento duro, osea verifica que en tablero
        //no se encuentre ningun numero 0, que represente el recubrimiento (fin del juego)
        public bool verificarRecubrimientos()
        {
            int i, j, sigue = 0;
            for (i = 0; i < tablero.fila; i++)
            {
                for (j = 0; j < tablero.columna; j++)
                {
                    if (tablero.tablero[i, j] != 0)
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
        //calcular puntaje en jugada segun el arreglo de posiciones entregado por
        //el metodo checkCandies
        public int calcularPuntaje(int[] arreglo)
        {
            if (((arreglo.Length == 5) && (arreglo[1] == 1)) || ((arreglo.Length > 5) && (arreglo[1] == 1)))
            {//grupo de 3 caramelos tipo 1 o mas de 3 caramelos tipo 1
                int puntaje= j1.Puntaje += 200;
                Console.Write(j1.Puntaje);
                return puntaje;
            }
            else
            {
                if ((arreglo.Length == 5) && (arreglo[1] != 1))
                {//grupo de 3 caramelos distintos al tipo 1
                    int puntaje= j1.Puntaje += 50;
                    Console.Write(j1.Puntaje);
                    return puntaje;
                }
                else
                {
                    if ((arreglo.Length > 5) && (arreglo[1] != 1))
                    {//grupo de mas de 3 caramelos distintos al tipo 1
                        int puntaje= j1.Puntaje += 100;
                        Console.Write(j1.Puntaje);
                        return puntaje;

                    }
                    return -1;
                }
            }
        }

        //intercambio de caramelos
        public void intercambioCaramelos(int posFila1, int posCol1, int posFila2, int posCol2)
        {
            if ((tablero.tablero[posFila1, posCol1] != 0) && tablero.tablero[posFila2, posCol2] != 0)
            {
                int aux;
                aux = tablero.tablero[posFila1, posCol1];
                tablero.tablero[posFila1, posCol1] = tablero.tablero[posFila2, posCol2];
                tablero.tablero[posFila2, posCol2] = aux;
            }
        }

        //eliminar grupo de caramelos debido al arreglo de checkcandies en fila
        public void eliminarGrupoCaramelosFila(int[] array)
        {
            int i;
            for (i = array[2]; i < array.Length - 3; i++)
            {
                int caramelo = tablero.generarCaramelo(array[1], i, tablero.dificultad);
                tablero.tablero[array[1], i] = caramelo;
            }
        }

        //eliminar grupo de caramelos debido al arreglo de checkcandies en columna
        public void eliminarGrupoCaramelosCol(int[] array)
        {
            int i;
            for (i = array[2]; i < array.Length - 3; i++)
            {
                int caramelo = tablero.generarCaramelo(i, array[1], tablero.dificultad);
                tablero.tablero[i, array[1]] = caramelo;
            }
        }
        //Grupo de caramelos en fila, se elimina ceros arriba o abajo segun corresponda
        //[0, fila, columnas1, columna2, columna3...]
        public void eliminarRecubrimientoFila(int[] array)
        {
            int i;
            if (array[1] == 0)//eliminar ceros abajo
            {
                for (i = array[2]; i < array.Length-1; i++)
                {
                    if (tablero.tablero[1, i] == 0)
                    {
                        
                        int caramelo = tablero.generarCaramelo(1, i, tablero.dificultad);
                        tablero.tablero[1, i] = caramelo;
                    }
                }
            }
            if ((array[1] > 0) && (array[1] < tablero.columna - 1))// eliminar ceros arriba y abajo
            {
                for (i = array[2]; i < array.Length-1; i++)//eliminar ceros bajo
                {
                    if (tablero.tablero[array[1] + 1, i] == 0)
                    {
                        int caramelo = tablero.generarCaramelo(array[1] + 1, i, tablero.dificultad);
                        tablero.tablero[array[1] + 1, i] = caramelo;
                    }

                }
                for (i = array[2]; i < array.Length-1; i++)//eliminar ceros arriba
                {
                    if (tablero.tablero[array[1] - 1, i] == 0)
                    {
                        int caramelo = tablero.generarCaramelo(array[1] - 1, i, tablero.dificultad);
                        tablero.tablero[array[1] - 1, i] = caramelo;
                    }
                }
            }
            if (array[1] == tablero.fila - 1)//eliminar ceros arriba
            {
                for (i = array[2]; i < array.Length-1; i++)
                {
                    if (tablero.tablero[array[1] - 1, i] == 0)
                    {
                        int caramelo = tablero.generarCaramelo(array[1] - 1, i, tablero.dificultad);
                        tablero.tablero[array[1] - 1, i] = caramelo;
                    }
                }
            }
        }
        //Grupo de caramelos en fila, se elimina ceros izquierda o derecha segun corresponda
        //[0, columna, fila1, fila2, fila3...]
        public void eliminarRecubrimientoColumna(int[] arreglo)
        {
            int i;
            if (arreglo[1] == 0)//eliminar ceros derecha
            {
                for (i = arreglo[2]; i < arreglo.Length-2; i++)
                {
                    if (tablero.tablero[i, 1] == 0)
                    {
                        int caramelo = tablero.generarCaramelo(i, 1, tablero.dificultad);
                        tablero.tablero[i, 1] = caramelo;
                    }
                }
            }
            if ((arreglo[1] > 0) && (arreglo[1] < tablero.columna - 1))// eliminar ceros izquierda y derecha
            {
                for (i = arreglo[2]; i < arreglo.Length-2; i++)//eliminar ceros derecha
                {
                    if (tablero.tablero[i, arreglo[1] + 1] == 0)
                    {
                        int caramelo = tablero.generarCaramelo(i, arreglo[1] + 1, tablero.dificultad);
                        tablero.tablero[i, arreglo[1] + 1] = caramelo;
                    }
                }
                for (i = arreglo[2]; i < arreglo.Length-2; i++)//eliminar ceros izquierda
                {
                    if (tablero.tablero[i, arreglo[1] - 1] == 0)
                    {
                        int caramelo = tablero.generarCaramelo(i, arreglo[1] - 1, tablero.dificultad);
                        tablero.tablero[i, arreglo[1] - 1] = caramelo;
                    }
                }
            }
            if (arreglo[1] == tablero.columna - 1)//eliminar ceros izquierda
            {
                for (i = arreglo[2]; i < arreglo.Length-2; i++)
                {
                    if (tablero.tablero[i, arreglo[1] - 1] == 0)
                    {
                        int caramelo = tablero.generarCaramelo(i, arreglo[1] - 1, tablero.dificultad);
                        tablero.tablero[i, arreglo[1] - 1] = caramelo;
                    }
                }
            }
        }

        //eliminar la fila en donde se encuentra el grupo de unos
        public void eliminarfilaUnos(int[] arreglo)
        {
            int i;
            for (i = 0; i < tablero.columna; i++)
            {
                int caramelo = tablero.generarCaramelo(arreglo[1],i, tablero.dificultad);
                tablero.tablero[arreglo[1],i] = caramelo;
            }
        }
        //eliminar filas completas adyacentes debido a la eliminacion de un grupo de caramelos tipo 1
        public void eliminarFilasAdyacentes(int[] arreglo)
        {
            int i;
            if (arreglo[1] == 0)//eliminar fila de abajo 
            {
                for (i = 0; i < tablero.columna; i++)
                {
                    tablero.tablero[1, i] = tablero.generarCaramelo(1, i, tablero.dificultad);
                }

            }
            if ((arreglo[1] > 0) && (arreglo[1] < tablero.columna - 1))//eliminar fila abajo y arriba
            {
                for (i = 0; i < tablero.columna; i++)//afila arriba
                {
                    tablero.tablero[arreglo[1] - 1, i] = tablero.generarCaramelo(arreglo[1] - 1, i, tablero.dificultad);
                }
                for (i = 0; i < tablero.columna; i++)//afila abajo
                {
                    tablero.tablero[arreglo[1] + 1, i] = tablero.generarCaramelo(arreglo[1] + 1, i, tablero.dificultad);
                }
            }
            if (arreglo[1] == tablero.fila - 1)//aliminar fila de arriba
            {
                for (i = 0; i < tablero.columna; i++)
                {
                    tablero.tablero[arreglo[1] - 1, i] = tablero.generarCaramelo(arreglo[1] - 1, i, tablero.dificultad);
                }
            }
        }
        //Para mostrar la matrix del tablero en la consola, para seguir un seguimiento 
        public void mostrar()
        {
            int i, j;
            for (i = 0; i < tablero.fila; i++)
            {
                Console.Write("");
                for (j = 0; j <tablero.columna; j++)
                {
                    Console.Write(tablero.tablero[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
