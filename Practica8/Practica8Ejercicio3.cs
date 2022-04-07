/*3) ¿Qué obtiene un método anónimo (o expresión lambda) cuando accede a una variable
 definida en el entorno que lo rodea, una copia del valor de la variable o la referencia 
 a dicha variable? Tip:
Observar la salida por consola del siguiente código:
Copia la referencia de dicha variable*/

using System;

namespace practica8Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            Action a = delegate ()
            {
                Console.WriteLine(i);
            };
            a.Invoke(); // => 10
            i = 20;
            a.Invoke(); // => 20
            Console.ReadKey();
        }

    }
}
