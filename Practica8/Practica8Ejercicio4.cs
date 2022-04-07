/*4) Teniendo en cuenta lo respondido en el ejercicio anterior
, ¿Qué salida produce en la consola la
ejecución del siguiente método?
Produce la salida
Salida: 10 9 veces
Se debe a que invoca el ultimo metodo encolado*/

using System;

namespace practica8Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            Action[] acciones = new Action[10];
            for (int i = 0; i < 10; i++)
            {
            acciones[i] = () => Console.WriteLine(i + " ");
            }
            foreach (var a in acciones){      
            a.Invoke();
            }
            Console.ReadKey();
        }
    }
}
