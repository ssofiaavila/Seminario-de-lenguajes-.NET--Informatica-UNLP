/*1) Codificar el método genérico Get para que el siguiente código produzca la salida en la consola
indicada

SALIDA POR CONSOLA --> hola 7 A
*/

using System;
using System.Collections;
namespace practica9Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList lista=new ArrayList() {"hola",7,'A'};
            string st = Get<string>(lista,0);
            int i = Get<int>(lista,1);
            char c = Get<char>(lista,2);
            Console.WriteLine($"{st} {i} {c}");
            Console.ReadKey();
        }
        static T Get<T>(ArrayList l,int pos ){
            return (T)l[pos];
        }
    }
}
