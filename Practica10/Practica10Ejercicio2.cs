/*2) Listar por consola la cantidad de veces que se repiten los elementos 
de un vector de enteros. Ordenar por cantidad de repeticiones.
 Completar el siguiente código para que la salida por consola
sea la indicada*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace practica10Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] vector = new int[] { 1, 3, 4, 5, 9, 4, 3, 4, 5, 1, 1, 4, 9, 4, 3, 1 };
vector.GroupBy(n => n)
// . . . completar aquí las líneas que faltan usando fluent API
.ForEach(obj => Console.WriteLine(obj));
        }
    }
}
