/*14. Utilizar la clase Stack (pila) para implementar un programa que pase un número en base 10 a
otra base realizando divisiones sucesivas. Por ejemplo para pasar 35 en base 10 a binario
dividimos sucesivamente por dos hasta encontrar un cociente menor que el divisor, luego el
resultado se obtiene leyendo de abajo hacia arriba el cociente de la última división seguida por
todos los restos.*/

using System;
using System.Collections;

namespace practica3Ejercicio14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese numero decimal para convertir a binario");
            int base10= int.Parse(Console.ReadLine());
            Stack pila= convertirABinario(base10);
            int dim= pila.Count;
            int i=0;
            while (i<dim){
                Console.Write(pila.Pop());
                i++;

            }
            Console.ReadLine();
            

            Stack convertirABinario(int base10){
                Stack pila= new Stack();
                pila.Clear();
                while (base10 != 0){
                    int resto= base10 % 2;
                    pila.Push(resto);
                    base10= base10 / 2;                 

                }
                return pila;

            }
        }
    }
}

