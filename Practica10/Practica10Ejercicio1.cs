/*1) Utilizando el método Range de la clase System.Linq.Enumerable y 
los métodos de LINQ que sean necesarios, obtener:
    a) Lista con todos los múltiplos de 5 entre 100 y 200
    b) Lista con todos los números primos menores que 100
    c) Lista con las potencias de 2, desde 20 a 210
    d) La suma y el promedio de los valores de la lista anterior
    e) Lista de todos los n2 que terminan con el dígito 6, para n entre 1 y 20
f) Lista con los nombres de los días de la semana en inglés que contengan una letra ‘u’
(tip: utilizar el enumerativo DayOfWeek)

*/

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace practica10Ejercicio1
{
    class Program
    {
        public enum DayOfWeek{Monday,Tuesday,Wednesday,Thursday, Friday,
        Saturday,Sunday}
        static void Main(string[] args)
        {
            //inciso a
            var a= Enumerable.Range(1,200);
            var a_numero= a.Select(n => n%5 ==0 ); // selecciono los que el resto sea 0
            //inciso b
            var b= Enumerable.Range(0,100);
            var b_nuevo= b.Select(IsPrime); //selecciona los que son primos a partir de la funcion
            //inciso c
            var c= Enumerable.Range(20,210);
            var c_nuevo= c.Select(IsPowerOfTwo);
            //inciso d
            var sumaC= c_nuevo.Sum();
            var promedioC= sumaC/ c.Count; 

            //inciso e
            var e= Enumerable.Range(1,20);
            var e_nuevo= e.Select(cumple);

            //inciso f
            

            static bool IsPrime(int number)
{
    for (int i = 2; i < number; i++)
    {
        if (number % i == 0 && i != number)
            return false;
    }
    return true;
}
    static bool IsPowerOfTwo(ulong n) {
      if (n == 0)
         return false;
      while (n != 1) {
         if (n % 2 != 0)
            return false;
         n = n / 2;
      }
      return true;
   }

   static bool cumple(ulong n){
       if (IsPowerOfTwo(n)){
           return n%10 ==6;
       }
       return false;
   }

    
        }
    }
}
