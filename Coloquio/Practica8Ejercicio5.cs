/*5) En este ejercicio, se requiere extender el tipo int[] con algunos
    métodos de extensión. Se presenta el código del método de extensión
    Print(this int[] vector, string leyenda) que imprime en la consola 
    los elementos del vector precedidos por una leyenda que se pasa como 
    parámetro. Se requiere codificar el método de extensión 
    Select(...) que recibe como parámetro un delegado de
    tipo FuncionEntera y devuelve un nuevo vector de enteros 
    producto de aplicar la función recibida
    como parámetro a cada uno de los elementos del vector. 
    El siguiente programa debe producir la
    salida indicada.

SALIDA POR CONSOLA:
    Valores iniciales: 1, 2, 3, 4, 5
    Valores triplicados: 3, 6, 9, 12, 15
    Cuadrados: 1, 4, 9, 16, 25

Para ello, completar el código de la 
siguiente clase estática VectorDeEnterosExtension
*/


using System;

namespace practica8Ejercicio5
{
    delegate int FuncionEntera(int n);
class Program
{
    static void Main(string[] args){
        int[] vector = new int[] { 1, 2, 3, 4, 5 };
        vector.Print("Valores iniciales: "); 
        var vector2 = vector.Select(n => n * 3); //metodo anonimo que va a pasarse
        vector2.Print("Valores triplicados: ");
        vector.Select(n => n * n).Print("Cuadrados: "); 
        Console.ReadKey();
    }
}
static class VectorDeEnterosExtension{
    public static void Print(this int[] vector, string leyenda){
        string st = leyenda;
        if (vector.Length > 0){
            foreach (int n in vector) st += n + ", ";
            st = st.Substring(0, st.Length - 2);
        }
        Console.WriteLine(st);
    }

    public static int[] Select(this int []v, FuncionEntera f){
        for (int i = 0; i < v.Length; i++){
            v[i] = f(v[i]);
            return v;
        }
        return v;
    }

}
}
