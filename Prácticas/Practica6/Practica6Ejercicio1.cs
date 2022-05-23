using System;
/*Sin borrar ni modificar ninguna línea, completar la definición de las clases B, C y D para que el siguiente código produzca la salida indicada:
A[]

SALIDA POR CONSOLA: 
    A_3
    B_5 --> A_5
    C_15 --> B_15 --> A_15
    D_41 --> C_41 --> B_41 --> A_41
*/


namespace practica6Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
           A[] vector = new A[] { new A(3), new B(5), new C(15), new D(41) };
            foreach (A a in vector){
                a.Imprimir();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }


    class A{
        protected int _id;
        public A(int id) => _id = id;
        public virtual void Imprimir() => Console.Write($"A_{_id}");
    }

    class B : A{
        public B(int id) : base(id){}
        public override void Imprimir(){
            base.Imprimir();
            Console.Write($"--> B_{_id}");
        }
        
    }

    class C : B{
        public C(int id): base(id){}
        public override void Imprimir()
        {
            base.Imprimir();
            Console.Write($"--> C_{_id}");
        }
    }
    class D : C{ 
        public D(int id): base(id){}
        public override void Imprimir(){
            base.Imprimir();
            Console.Write($"--> D_{_id}");
        }
    }


}

