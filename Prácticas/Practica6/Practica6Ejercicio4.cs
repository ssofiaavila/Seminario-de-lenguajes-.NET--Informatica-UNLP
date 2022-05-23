using System;

/* 4) Contestar sobre el siguiente programa: 
    ¿Por qué no es necesario agregar :base en el constructor de Taxi? Eliminar el segundo constructor
de la clase Auto y modificar la clase Taxi para el programa siga funcionando
    No es necesario agregar :base en el constructor de Taxi porque ya es implementado un constructor vacío para la clase Auto y el valor de la variable de Auto ya es asignada a la hora de 
    construir el objeto

*/

namespace practica6Ejercicio4
{
    class Program{
        static void Main(string[] args)
        {
        Taxi t = new Taxi(3,"Ford");
        Console.WriteLine($"Un {t.Marca} con {t.Pasajeros} pasajeros");
        Console.ReadKey();
        }
    }
    class Auto{
        public string Marca { get; private set; }
        public Auto(string marca) => this.Marca = marca;    
    }
    class Taxi : Auto
    {
        public int Pasajeros { get; private set; }
        public Taxi(int pasajeros, string marca): base(marca)
         => this.Pasajeros = pasajeros;
}
}
