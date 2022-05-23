using System;
/* 3) ¿Por qué no funciona el siguiente código? ¿Cómo se puede solucionar fácilmente?
    No funcionaba porque velocidad de la clase padre estaba declarada como privada y queria accederse desde la subclase por lo tanto hubo que modificar su nivel de proteccion a "protected"
*/
namespace practica6Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Auto{
        protected double velocidad; //modifiqué privacidad
        public virtual void Acelerar() => Console.WriteLine("Velocidad = {0}", velocidad += 10);
    }
    class Taxi : Auto{
        public override void Acelerar()=> Console.WriteLine("Velocidad = {0}", velocidad += 5);
}

}
