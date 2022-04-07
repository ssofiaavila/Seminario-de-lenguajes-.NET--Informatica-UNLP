/*1) Declarar los tipos delegados necesarios para que el siguiente programa compile y produzca la
salida en la consola indicada*/

using System;

namespace practica8Ejercicio1
{
    delegate void Del1 (int n);
    delegate void Del2(int[] n);
    delegate int Del3(int n);
    delegate bool Del4(String st);
    class Program
{
    static void Main(string[] args)
    {
    Del1 d1 = delegate (int x) { Console.WriteLine(x); };
    d1(10);
    Del2 d2 = x => Console.WriteLine(x.Length);
    d2(new int[] { 2, 4, 6, 8 });
    Del3 d3 = x =>
    {
        int sum = 0;
        for (int i = 1; i <= x; i++){
            sum += i;
        }
        return sum;
    };
    Console.WriteLine(d3(10));
    Del4 d4 = new Del4(LongitudPar);
    Console.WriteLine(d4("hola mundo"));
    }
    public static bool LongitudPar(string st)
    {
    return st.Length % 2 == 0;
    }
}
}
