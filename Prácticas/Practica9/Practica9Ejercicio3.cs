/*3) Codificar los métodos genéricos CrearArreglo y CrearObjetoDelMismoTipo
 que faltan para que el siguiente código produzca la salida en la 
 consola indicada.
Tip: Recordar el uso de params.

SALIDA -->
uno - dos -
1 - 2,3 - 4,1 - 6,7 -
System.Collections.ArrayList
System.Int32
System.Char
System.Collections.Stack
*/


using System;
using System.Collections;

namespace practica9Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vector1 = CrearArreglo<string>("uno", "dos");
            foreach (string st in vector1) Console.Write(st + " - ");
            Console.WriteLine();
            double[] vector2 = CrearArreglo<double>(1, 2.3, 4.1, 6.7);
            foreach (double valor in vector2) Console.Write(valor + " - ");
            Console.WriteLine();
            ArrayList lista = new ArrayList();
            Stack pila = new Stack();
            var a = CrearObjetoDelMismoTipo(lista);
            var b = CrearObjetoDelMismoTipo(12);
            var c = CrearObjetoDelMismoTipo('A');
            var d = CrearObjetoDelMismoTipo(pila);
            Console.WriteLine(a.GetType());
            Console.WriteLine(b.GetType());
            Console.WriteLine(c.GetType());
            Console.WriteLine(d.GetType());
        }
        static T[] CrearArreglo <T>(params T[] v){
            T[] nuevo= new T[v.Length];
            int pos=0;
            foreach(T aux in v)
            {
                nuevo[pos++]=aux;
            }
            return nuevo;
        }
        static T CrearObjetoDelMismoTipo<T>(T a) where T: new()
                {
                    T nuevo = new T();
                    return nuevo;
                }
    }
}
