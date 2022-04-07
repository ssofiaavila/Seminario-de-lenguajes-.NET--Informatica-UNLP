//17. Ídem. al ejercicio 16.a) y 16.b) pero devolviendo el resultado en un parámetro de salida
//static void Fac(int n, out int f)

using System;

namespace practica2Ejercicio17
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero=int.Parse(Console.ReadLine()),resultado1,resultado2; 
            FacA(numero,out resultado1);
            FacB(numero, out resultado2);

            Console.WriteLine("Opcion 1: "+ resultado1);
            Console.WriteLine("Opcion 2:"+ resultado2);
            String n=Console.ReadLine();

            static void FacA(int numero, out int rtdo){
                rtdo=1;
                while (numero>0 ){
                    rtdo=rtdo*numero;
                    numero--;
                }
                
            } 
            static void FacB(int numero, out int rtdo){
                if (numero==1){
                    rtdo=1;
                }
                else
                    {
                    FacB(numero -1, out rtdo);
                    int aux=rtdo;
                    rtdo= numero * aux;
                }
                
                

            //CONSULTAR
            }

        }


    }
}
