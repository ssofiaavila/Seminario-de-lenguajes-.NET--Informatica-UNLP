/*6) Agregar al ejercicio anterior el método de extensión Where(...)
 para el tipo int[] que recibe como parámetro un delegado de tipo
  Predicado y devuelve un nuevo vector de enteros con los
elementos del vector que cumplen ese predicado. El siguiente 
programa debe producir la salida
indicada.*/

using System;
using System.Collections;
using System.Collections.Generic;
namespace practica8Ejercicio5
{
delegate bool Predicado(int n);
delegate int FuncionEntera(int n);
class Program
{
static void Main(string[] args)
{
    int[] vector = new int[] { 1, 2, 3, 4, 5 };
    vector.Print("Valores iniciales: ");
    vector.Where(n => n % 2 == 0).Print("Pares: ");
    vector.Where(n => n % 2 == 1).Select(n => n * n).Print("Impares al cuadrado: "); //filtra los que sean impares y los eleva al cuadrado
}


}
static class VectorDeEnterosExtension
{
    public static void Print(this int[] vector, string leyenda)
    {
    string st = leyenda;
    if (vector.Length > 0){
        foreach (int n in vector) st += n + ", ";
            st = st.Substring(0, st.Length - 2);
        }
        Console.WriteLine(st);
        Console.ReadKey();
    }
public static int[] Select(this int []v, FuncionEntera f){
    for (int i = 0; i < v.Length; i++){
        v[i] = f(v[i]);
        return v;
    }
    return v;
}
public static int[] Where(this int[]v, Predicado f){
    List <int> lista = new List <int>();
    for (int i=0;i< v.Length; i++){
        if (f(v[i])){
           lista.Add(v[i]);
        }
    
    }
    return lista.ToArray();
}
}
}
