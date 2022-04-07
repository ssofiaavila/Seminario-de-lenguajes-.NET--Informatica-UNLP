/*6) Señalar el error en cada uno de los siguientes casos:*/ 

using System;

namespace practica6Ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    //6.1
    class A{
    public string M1()=> "A.M1";
}
    class B : A{
    public override string M1()=> "B.M1"; //Error porque en la clase A no está decladado con "virtual" el método M1()
}

    // 6.2
    abstract class A2{
        public abstract string M1()=> "A.M1"; //si es declarado como un método abstracto no puede tener cuerpo
    }
    class B2 : A2{
        public override string M1()=> "B.M1";
}

    //6.3
    abstract class A3{
        public abstract string M1()=> "A.M1"; //si es declarado com un método abstracto no puede tener cuerpo
    }
    class B3 : A3{
        public override string M1()=> "B.M1";
}
    //6.4
    class A4{
        public override string M1()=> "A.M1"; //no hay ningun método para invalidar ya que no se hereda 
    }
    class B4 : A4{
        public override string M1()=> "B.M1";
}

    //6.5
    class A5{
        public virtual string M1()=> "A.M1";
}
    class B5 : A5{
        protected override string M1()=> "B.M1"; //no puedo cambiar los modificadores de acceso 
}

    //6.6
    class A6{
    public static virtual string M1()=> "A.M1"; //Un miembro estático 'virtual' no se puede marcar como invalidación, virtual o abstracto
}
    class B6 : A6{
    public static override string M1()=> "B.M1"; //Un miembro estático 'override' no se puede marcar como invalidación, virtual o abstracto
}

    //6.7
    class A7{
        virtual string M1() => "A.M1"; //los metodos virtual no pueden ser declarados como privados
}
    class B7 : A7
{
    override string M1() => "B.M1"; //no puedo acceder al metodo ya que fue declarado como privado
}

    //6.8
    class A8
{
    protected A8(int i) { }
}
    class B8 : A8
{
    B() { } //no tiene tipo de retorno
}

    //6.9
    class A9{
        private int _id;
        protected A9(int i) => _id = i;
}
    class B9 : A9{
    B(int i):base(5) { //no tiene tipo de retorno
    _id=i;  // no puedo acceder ya que es declarado como privado
}
}

    //6.10
    class A10{
        private int Prop {set; public get;}  //el get debe ser mas retrictivo ya que Prop es private
}
class B10 : A10
{
}

    //6.11
    abstract class A11{
    public abstract int Prop {set; get;}
}
    class B11 : A11{
        public override int Prop{get => 5;} //no implementa el miembro abstracto 
}

    //6.12
    abstract class A12{
        public int Prop {set; get;}
}
    class B12 : A12{
        public override int Prop {get => 5; set {} //el miembro Prop de la clase A12 no tiene "virtual"
}
}
}
