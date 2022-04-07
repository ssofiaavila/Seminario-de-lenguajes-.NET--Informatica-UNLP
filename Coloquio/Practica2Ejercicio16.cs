//16. Escribir una función (método static int Fac(int n)) que calcule el factorial de un
//número n pasado al programa como parámetro por la línea de comando
//a) Definiendo una función no recursiva
//b) Definiendo una función recursiva
//c) idem a b) pero con expression-bodied methods (Tip: utilizar el operador condicional
//ternario)


using System;

namespace practica2Ejercicio16
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero=int.Parse(Console.ReadLine());
            //INCISO 1
            Console.WriteLine("Opcion 1, no recursivo: "+ FacA(numero));

            //INCISO B
            Console.WriteLine("Opcion 2, recursivo: "+ FacB(numero));


            //INCISO C
            Console.WriteLine("Opcion 3, expression-bodied methods "+ FacC(numero));

            static int FacA(int num){
                int total=1;
                while (num == 0){
                    total=total*num;
                    num--;

                }
                return total;
            }
            static int FacB(int num){
                if (num==1){
                        return 1;
                }
                return num* FacB(num-1);
            }

            static int FacC(int num) => num==1 ?  1 : num * FacC(num-1);
                

            
        }
    }
}
