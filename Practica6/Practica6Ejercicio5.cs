/* 5) ¿Qué líneas del siguiente código provocan error de compilación y por qué? 
    Linea 23 --> Persona es menos accesible que el método, Persona es privado y getPrimerDueño es público
    Linea 25 --> Persona es menos accesible que el método, Persona es privdado y segundoDueño es protegido
*/ 


using System;

namespace practica6Ejercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Persona{
        public string Nombre { get; set; }
    }
    public class Auto{
        private Persona _dueño1, _dueño2;
        public Persona GetPrimerDueño() => _dueño1;
        protected Persona SegundoDueño{
            set => _dueño2 = value;
        }
    }
}
