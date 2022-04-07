//14. Implementar un programa que muestre todos los números primos entre 1 y un número natural
//dado (pasado al programa como argumento por la línea de comandos). Definir el método
//static bool esPrimo(int n) que devuelve true sólo si n es primo. Esta función debe
//comprobar si n es divisible por algún número entero entre 2 y la raíz cuadrada de n. (Nota:
//Math.sqrt(d) devuelve la raíz cuadrada de d)


using System;

namespace practica2Ejercicio14
{
    class Program
    {
        static void Main(string[] args)
        {
            int num= int.Parse(args[0]);
            for (int i=2; i<=num ;i++){
                if (esPrimo(i)){
                    Console.WriteLine(i+ " es primo");
                }
            }


            static bool esPrimo(int num){
                int c=2,raiz= Convert.ToInt32(Math.Sqrt(num));
                while (c<=raiz){
                    if (num % c == 0){
                        return false;
                    }
                    c++;

                }
                return true;

            }
           



           }
        }
    }

