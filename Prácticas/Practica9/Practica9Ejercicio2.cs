/*2) Codificar los métodos que faltan para que el siguiente código 
produzca la salida en la consola indicada.

SALIDA --> 
1 2 110
True False True
Hola Mundo! dos tres
*/

using System;
using System.Collections;

namespace practica9Ejercicio2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] vector1 = new int[] { 1, 2, 3 };
            bool[] vector2 = new bool[] { true, true, true };
            string[] vector3= new string[] { "uno", "dos", "tres" };
            Set<int>(vector1, 110, 2);
            Set<bool>(vector2, false, 1);
            Set<string>(vector3, "Hola Mundo!", 0);
            Imprimir(vector1);
            Imprimir(vector2);
            Imprimir(vector3);
            Console.ReadKey();
        }
        static void Set<T>(T[] l,T dato,int pos){
            l[pos]=dato;
        }
        static void Imprimir<T>(T[] v)
        {
            foreach(T aux in v){
                Console.Write($"{aux}  ");
            }
            Console.WriteLine();
        } 

    }
}
