/* 8) Codificar usando iteradores los métodos:
Rango(i, j, p) que devuelve la secuencia de enteros desde i hasta j con un paso de p
Potencia(b,k) que devuelve la secuencia b1,b2,....bk
DivisiblePor(e,i) retorna los elementos de e que son divisibles por i
Observar la salida que debe producir el siguiente código:

Salida por consola -->
6 9 12 15 18 21 24 27 30
2 4 8 16 32 64 128 256 512 1024
6 12 18 24 30

*/

using System;
using System.Collections;

namespace practica7Ejercicio8
{
    static  class Program
    {
        
        public static void Main(){
            IEnumerable rango = Rango(6, 30, 3);
            IEnumerable potencias = Potencias(2, 10);
            IEnumerable divisibles = DivisiblesPor(rango, 6);
            foreach (int i in rango)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            foreach (int i in potencias)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            foreach (int i in divisibles)
            {
                Console.Write(i + " ");
            }
             Console.ReadKey();
        }
        static IEnumerable Rango(int i, int j , int p) //puede devolver IEnumerator pero vamos a tener que usar los métodos .MoveNext() en un while
        {
            //este bloque de código es mi iterador los yield te simplifican todo
            //este método no se ejecuta nunca,  el compilador se encarga de generar una máquina de estados finitos
             int aux =i;
            while (true) {
                i=aux;
                if (i <= j) 
                {
                    aux+=p;
                    yield return i; 
                }
                else {
                    yield break; //detiene la iteracion
                }
            }   
        }  

        static IEnumerable Potencias(int Base,int exponenteMax)
        {
            int exponenteAct=0;
            while(true){
                if(exponenteAct < exponenteMax)
                {
                    exponenteAct++;
                    yield return (int)Math.Pow(Base,exponenteAct);
                }
                else
                {
                    yield break;
                }
            }
        }

        static IEnumerable DivisiblesPor(IEnumerable rango,int divisor)
        {
            foreach(int i in rango)
            {
                if(i % divisor == 0)
                {
                    yield return i;
                }
            }
            yield break;
        }

        
    }
}
