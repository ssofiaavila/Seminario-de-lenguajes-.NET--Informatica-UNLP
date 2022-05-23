using System;

namespace practica8Ejercicio2
{
    delegate void AccionInt(ref int i);
    class Program
    {
    static void Main(string[] args)
    {
        AccionInt a1 = (ref int i) => i = i * 2;
        a1 += a1;
        a1 += a1;
        a1 += a1;
        int i = 1;
        a1(ref i);
        // Responder respecto de este punto en el programa
    }
    /*Cuál es el tamaño de la lista de invocación de a1 y cual es el valor de la variable i luego de la
invocación a1(ref i)?
    a1= 3
    Luego de a1(ref i) i= 2
*/
}
}
