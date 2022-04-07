/* 7) Ofrecer una implementación polimórfica para mejorar el siguiente programa:*/ 

using System;

namespace practica6Ejercicio7{
    class Program {
        static void Main(string[] args) {
            Imprimidor.Imprimir(new A(), new B(), new C(), new D());
            Console.ReadKey();
        }
}
    abstract class Letra{
        public abstract void Imprimir();
    }
    class A: Letra{
        public override void Imprimir() => Console.WriteLine("Soy una instancia A");
    }
    class B:Letra {
        public override void Imprimir() => Console.WriteLine("Soy una instancia B");
}
    class C: Letra {
        public override void Imprimir() => Console.WriteLine("Soy una instancia C");
}
    class D: Letra {
        public override void Imprimir() => Console.WriteLine("Soy una instancia D");
}
    static class Imprimidor {
    public static void Imprimir(params object[] vector) {
        foreach (Letra o in vector) {
            o.Imprimir();
}
}
}
}
