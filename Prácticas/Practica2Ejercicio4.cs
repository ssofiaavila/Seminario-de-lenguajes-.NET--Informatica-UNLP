using System;


//4. ¿Cuál es la salida por consola si no se pasan argumentos por la línea de comandos?
namespace practica2Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
           System.Console.WriteLine(args == null);
            System.Console.WriteLine(args.Length);
            // args== null FALSE
            // args.Length 0
        }
    }
}
