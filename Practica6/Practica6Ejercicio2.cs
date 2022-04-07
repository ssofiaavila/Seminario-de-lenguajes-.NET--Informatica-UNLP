/*2) Aunque consultar en el código por el tipo de un objeto indica habitualmente un diseño ineficiente,
por motivos didácticos vamos a utilizarlo. Completar el siguiente código, que utiliza las clases
definidas en el ejercicio anterior, para que se produzca la salida indicada:
SALIDA
    B_3 --> A_3
    B_5 --> A_5

*/

using System;

namespace practica6Ejercicio2{
    class Program
    {
        static void Main(string[] args)
        {
           A[] vector = new A[] { new C(1), new D(2), new B(3), new D(4), new B(5) };
            foreach (A a in vector){ //inciso a) con is
                if (!(a is D )&& !(a is C)) {
                    (a as B).Imprimir();
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            foreach (A ob in vector){ // inciso b) con getType() y typeOf
                if (!(ob.GetType()== typeof(D))){
                    if (!(ob.GetType()== typeof(C)))
                        (ob as B).Imprimir();
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
    /* The typeof is an operator keyword which is used to get a type at the compile-time. Or in other words, this operator is used to get the System.Type object for a type*/

    class A{
        protected int _id;
        public A(int id) => _id = id;
        public virtual void Imprimir() => Console.Write($"A_{_id}");
    }

    class B : A{
        public B(int id) : base(id){}
        public override void Imprimir(){
            Console.Write($" B_{_id} --> ");

            base.Imprimir();
            
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
