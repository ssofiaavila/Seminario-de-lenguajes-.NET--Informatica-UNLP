using System;
using System.IO;


namespace practica4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese ejercicio");
            int ejer= int.Parse(Console.ReadLine());
            switch (ejer){
                case 1:
                    ejercicio1();
                    break;
                case 2:
                    Console.WriteLine("Ya implementado en la clase ");
                    break;
                case 3:
                    ejercicio1();
                    break;
                case 4:
                    ejercicio4();
                    break;
                //REVISAR 5
                case 6:
                    ejercicio6();
                    break;
                case 7:
                    Console.WriteLine("Resuelto a parte");
                    break;
                case 8:
                    Console.WriteLine("Resuelto a parte");
                    break;
                case 9:
                    Console.WriteLine("Es analizar lineas");
                    break;
                case 10:
                    Console.WriteLine("Es analizar lineas");
                    break;
                case 12:
                    ejercicio12();
                    break;
                
            }

            /* 1) Definir una clase Persona con 3 campos públicos: Nombre, Edad y DNI. Escribir un algoritmo
            que permita al usuario ingresar por consola una serie de datos de la forma
            Nombre,Documento,Edad<ENTER>. Una vez finalizada la entrada de datos, el programa debe
            imprimir en la consola un listado con 4 columnas de la siguiente forma:
            Nro) Nombre Edad DNI.
            Ejemplo de listado por consola:
            1) Juan Perez 40 2098745
            2) José García 41 1965412 
            
            NOTA: Puede utilizar: Console.SetIn(new System.IO.StreamReader(nombreDeArchivo));
            para cambiar la entrada estándar de la consola y poder leer directamente desde un archivo de texto.*/
            void ejercicio1(){
                Console.SetIn(new System.IO.StreamReader("prueba.txt"));
                Persona [] vector= new Persona[4];
                for (int i=0;i<4;i++){
                    String nombre=Console.ReadLine();
                    int edad= int.Parse(Console.ReadLine());
                    int dni=int.Parse(Console.ReadLine());
                    Persona persona=new Persona(nombre,edad,dni);
                    vector[i]=persona;                 

                }
                for (int i=0;i<4;i++){
                    vector[i].Imprimir();                    
                }
                Console.WriteLine("Ahora buscaré la persona más joven de la lista");
                int edadMin=100,dniMin=0;
                for (int i=0;i<3;i++){
                    if(!vector[i].esMayorQue(vector[i+1])&&(vector[i].getEdad()<edadMin)){
                        edadMin=vector[i].getEdad();
                        dniMin=vector[i].getDNI();                        
                    }
                }
                    
                
                Console.WriteLine($"El dni del mas chico es {dniMin}");
                String st=Console.ReadLine();
            }
            /*2) Modificar el programa anterior haciendo privados todos los campos. Definir un constructor
            adecuado y un método público Imprimir() que escriba en la consola los campos del objeto con el
            formato requerido para el listado.*/
            //  IMPLEMENTADO

            /* 3) Agregar a la clase Persona un método EsMayorQue(Persona p) que devuelva verdadero si la
persona que recibe el mensaje tiene más edad que la persona enviada como parámetro. Utilizarlo
para realizar un programa que devuelva la persona más joven de la lista.*/



/*4) Codificar la clase Hora de tal forma que el siguiente código produzca la salida por consola que se
observa. 23 horas, 30 minutos, 15 segundos */
        void ejercicio4(){
            Hora h = new Hora(23, 30, 15);
            h.Imprimir();
        }
        /*6) Codificar una clase llamada Ecuacion2 para representar una ecuación de 2º grado. Esta clase
debe tener 3 campos privados, los coeficientes a, b y c de tipo double. La única forma de establecer
los valores de estos campos será en el momento de la instanciación de un objeto Ecuacion2.
Codificar los siguientes métodos:
● GetDiscriminante(): devuelve el valor del discriminante (double), el discriminante tiene
la siguiente fórmula, b2-4ac
● GetCantidadDeRaices(): devuelve 0, 1 ó 2 dependiendo de la cantidad de raíces reales
que posee la ecuación. Si el discriminante es negativo no tiene raíces reales, si el
discriminante es cero tiene una única raíz, si el discriminante es mayor que cero posee 2
raíces reales.
● ImprimirRaices(): imprime la única o las 2 posibles raíces reales de la ecuación. En caso
de no poseer soluciones reales debe imprimir una leyenda que así lo especifique.*/
        void ejercicio6(){
            Ecuacion2 e1= new Ecuacion2(15,2,8);
            e1.imprimirRaices();

        }
        //9) Prestar atención a los siguientes programas (ninguno funciona correctamente):
        //¿Qué se puede decir acerca de la inicialización de los objetos? ¿En qué casos son inicializados
        //automáticamente y con qué valor?
        /* OPCION 1

            class Program1
            {
                static Auto a;
                static void Main()
                {
                a.Velocidad = 10;
            }
            }
            class Auto
            {
            public double Velocidad;
            }


            OPCION 2
            class Program2
            {
            static void Main()
            {
            Auto a;
            a.Velocidad = 10;
            }
            }
            class Auto
            {
            public double Velocidad;
            }

        */
        /* 10) ¿Qué se puede decir en relación a la sobrecarga de métodos en este ejemplo?
        class A
        {
            public void Metodo(short n)
        {
        Console.Write("short {0} - ", n);
        }
        public void Metodo(int n)
        {
        Console.Write("int {0} - ", n);
        }
        public int Metodo(int n)
        {   
        return n + 10;
        }
        }
             el tercer metodo no podrá ser implementado porque ya el hay uno que tiene un parameto int y para aplicar la sobre carga no alcanza
              con solo cambiar el tipo de retorno  
        */ 

        /*12) Completar la clase Cuenta para que el siguiente código produzca la salida indicada:*/
        void ejercicio12(){
            Cuenta cuenta = new Cuenta();
            cuenta.Imprimir();
            cuenta = new Cuenta(30222111);
            cuenta.Imprimir();
            cuenta = new Cuenta("José Perez");
            cuenta.Imprimir();
            cuenta = new Cuenta("Maria Diaz", 20287544);
            cuenta.Imprimir();
            cuenta.Depositar(200);
            cuenta.Imprimir();
            cuenta.Extraer(150);
            cuenta.Imprimir();
            cuenta.Extraer(1500);
            Console.ReadKey();

        }
        void ejercicio13(){
         /*   if (st1 == null){
                if (st2 == null){
                        st = st3;
                }
                 else
                {
                st = st2;
                }
            } 
            else
                {
                st = st1;
                } 
            if (st4 == null)
            {
            st4 = "valor por defecto";
            }*/
            //st= st1 ?? st2 ?? st3 ?? st2  ?? st1
            //st4= st4?? "valor por defecto"
}



}
class Cuenta{
    private String nombre;
    private int nroCuenta;
    private double fondos;

    public void Imprimir(){
        Console.WriteLine("Nombre: {0} numero de cuenta: {1}, fondos: {2}",this.nombre,this.nroCuenta,this.fondos);
    }
    public Cuenta(){
        this.fondos=0;
        this.nombre="No espeficicado";
        this.nroCuenta=0;
    }
    public Cuenta(String nombre):this(){
        this.nombre=nombre;
    }
    public Cuenta(int nro):this(){
        this.nroCuenta=nro;
    }
    public Cuenta(String nombre, int nro):this(){
        this.nombre=nombre;
        this.nroCuenta=nro;
    }
    public void Depositar(double monto){
        this.fondos=fondos+monto;
    }
    public void Extraer(double monto){
        if (this.fondos<monto){
            Console.WriteLine("Operacion cancelada, monto insuficiente");
        }
        else
            this.fondos=fondos-monto;
    }




}
class Ecuacion2{
    private double _A,_B,_C;
    
    public Ecuacion2(double A,double B,double C){
        this._A=A;
        this._B=B;
        this._C=C;
    }
    public double getDiscriminantante(){
        return Math.Pow(this._B,2)-4*this._A*this._C;
    }
    public double getCantidadDeRaices(){
        if (this.getDiscriminantante()< 0){
            return 0;
        }
        else {
            if(this.getDiscriminantante()== 0){
            return 1;
            }
            else
                return 2;
        }
    }
    public void imprimirRaices(){
        if (getCantidadDeRaices()==0){
            Console.WriteLine("No tiene raices");
        }
        else{
            if (getCantidadDeRaices()==1){
                Console.WriteLine( -(this._B/2*this._A));
            }
            else{
                double x1,x2;
                x1=(-this._B + (Math.Sqrt((Math.Pow(this._B,2))-(4 * this._A * this._C)))) / (2 * this._A);
                x2=(this._B + (Math.Sqrt((Math.Pow(this._B,2))-(4 * this._A * this._C)))) / (2 * this._A);
                Console.WriteLine($"Las raices son {x1} y {x2}");
            }

        }

    }



}
        
}
    class Hora{
            private int _hora,_min,_seg;

    public Hora(int hora, int min, int seg){
        this._hora=hora;
        this._min=min;
        this._seg=seg;
    }
    public void Imprimir(){
        Console.WriteLine($"{this._hora} horas, {this._min} minutos, {this._seg} segundos");
    }
        


        
    }
    class Persona{
        private String _nombre;
        private int _edad,_dni;

        public Persona(String nombre, int edad, int dni){
            this._nombre=nombre;
            this._edad=edad;
            this._dni=dni;

        }
        public int getEdad(){
            return this._edad;
        }
        public int getDNI(){
            return this._dni;
        }
        public void Imprimir(){
            Console.Write($" {_nombre}\t{ _edad}\t{_dni} \n");
        }
        public Boolean esMayorQue(Persona p){
            return this._edad> p.getEdad();

        }

        

    }
}
