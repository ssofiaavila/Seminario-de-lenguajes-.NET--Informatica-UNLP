using System;
using System.Collections;

namespace practica5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese ejercicio:");
            int ejercicio=int.Parse(Console.ReadLine());
            switch (ejercicio){
                case 1:
                    ejercicio1();
                    break;
                case 2:
                    ejercicio2();
                    break;
                case 3:
                    Console.WriteLine("Coloquio");
                    break;
                case 4:
                    Console.WriteLine("Codigo leido");
                    break;
                case 5:
                    Console.WriteLine("Resuelto a parte");
                    break;
     
                
            } 
            Console.ReadKey();
            // 1) Codificar la clase Cuenta de tal forma que el siguiente código produzca la salida por consola que
            //se indica.
            void ejercicio1(){
                Cuenta c1 = new Cuenta();
                c1.Depositar(100).Depositar(50).Extraer(120).Extraer(50);
                Cuenta c2 = new Cuenta();
                c2.Depositar(200).Depositar(800);
                new Cuenta().Depositar(20).Extraer(20);
                c2.Extraer(1000).Extraer(1);
                Console.WriteLine("\nDETALLE");
                Cuenta.ImprimirDetalle();

        }   
            void ejercicio2(){
                new Cuenta();
                new Cuenta();
                ArrayList cuentas = Cuenta.GetCuentas();
                // se recuperó la lista de cuentas creadas
                (cuentas[0] as Cuenta).Depositar(50);
                // se depositó 50 en la primera cuenta de la lista devuelta
                cuentas.RemoveAt(0);
                Console.WriteLine(cuentas.Count);
                // se borró un elemento de la lista devuelta
                // pero la clase Cuenta sigue manteniendo todos
                // los datos "La cuenta id: 1 tiene 50 de saldo"
                cuentas = Cuenta.GetCuentas();
                Console.WriteLine(cuentas.Count);
                // se recupera nuevamente la lista de cuentas
                (cuentas[0] as Cuenta).Extraer(30);
                //se extrae 25 de la cuenta id: 1 que tenía 50 de saldo
            }  
            //EJERCICIO 9
            /* el problema es que es case-sensitive entonces devolverá otro valor y lo conveniente es agregar el _ para evitar confundirse */
            
            
            //EJERCICIO 10
            /*Identificar todos los miembros en la siguiente declaración de clase. Indicar si se trata de un
constructor, método, campo, propiedad o indizador, si es estático o de instancia, y en caso que
corresponda si es de sólo lectura, sólo escritura o lectura y escritura. En el caso de las propiedades
indicar también si se trata de una propiedad auto-implementada.
Nota: La clase compila perfectamente. Sólo prestar atención a la sintaxis, la semántica es irrelevante.*/
            /*class A
            {
            private static int a; --------> CAMPO ESTÁTICO
            private static readonly int b; ----> CAMPO ESTÁTICO
            A() { }  ---> CONSTRUCTOR
            public A(int i) : this() { } --> CONSTRUCTOR
            static A() => b = 2; ---> METODO ESTÁTICO 
            int c; ---> CAMPO
            public static void A1() => a = 1; ---> METODO ESTÁTICO
            public int A1(int a) => A.a + a; --> METODO DE INSTANCIA
            public static int A2; ---> CAMPO ESTÁTICO
            static int A3 => 3; 
            private int A4() => 4; --> PROP AUTOIMPLEMENTADA
            public int A5 { get => 5; } --> PROPIEDAD AUTOIMPLEMENTADA
            int A6 { set => c = value; }  
            public int A7 { get; set; } --> PROP AUTOIMPLEMENTADA
            public int A8 { get; } = 8; --> PROP DE LECTURA
            public int this[int i] => i; --> INDIZADOR
}*/

        }
    }
    class Cuenta{
        static int cuentasCreadas=0;
        static int depositos=0;
        static int extracciones=0;
        static int extraccionesFallidas=0;
        static double totalDepositado=0;
        static double totalExtradido=0;
        static double saldoTotal=0;
        static ArrayList cuentas = new ArrayList();
        private int _id;
        private double _saldo=0;

        public Cuenta(){
            cuentasCreadas++;
            this._id=cuentasCreadas;
            Console.WriteLine("Se creo la cuenta con ID={0}",this._id);
            cuentas.Add(this);
        }
        
        public Cuenta Depositar(double monto){
            this._saldo=this._saldo+monto;
            depositos++;
            totalDepositado+=monto;
            saldoTotal+=monto;
            Console.WriteLine("Se deposito {0} en la cuenta con ID={1}",monto,_id);
            return this;
        }
        public Cuenta Extraer(double monto){
            if (_saldo>=monto){
                this._saldo=this._saldo-monto;
                extracciones++;
                totalExtradido+=monto;
                saldoTotal-=monto;
                Console.WriteLine("Se extrajo {0} de la cuenta con ID={1}",monto,_id);

            }
            else{
                extraccionesFallidas++;
            }
            return this;
        }

         public static void ImprimirDetalle(){
            Console.WriteLine("CUENTAS CREADAS {0}",cuentasCreadas);
            Console.WriteLine("DEPOSITOS {0}",depositos);
            Console.WriteLine("EXTRACCIONES: {0}", extracciones);
            Console.WriteLine("Total depositado: {0}",totalDepositado);
            Console.WriteLine("Total extraido {0}",totalExtradido);
            Console.WriteLine("Saldo {0}",saldoTotal);
            Console.WriteLine("Se denegaron {0} extracciones por falta de fondos",extraccionesFallidas);
        }
        public static ArrayList GetCuentas(){
            return cuentas;
        }


    }
    class A{
        char c;
        static string st;
        void metodo1()
        {
        st = "string";
        c = 'A';
        }
        static void metodo2()
        {
        // No existe new ClaseA().c = 'a';
        st = "st2";
        // no es un tipo estático c = 'B';
        // No puedo instanciar y acceder a un estado new A().st = "otro string";
        }
    }
}
