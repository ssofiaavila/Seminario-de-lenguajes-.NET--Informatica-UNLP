/* Crear un programa para gestionar empleados en una empresa. Los empleados deben tener las
propiedades públicas de sólo lectura Nombre, DNI, FechaDeIngreso, SalarioBase y Salario.

Los valores de estas propiedades (a excepción de Salario que es una propiedad calculada) deben
establecerse por medio de un constructor adecuado.
Existen dos tipos de empleados: Administrativo y Vendedor. No se podrán crear objetos de la
clase padre Empleado, pero sí de sus clases hijas (Administrativo y Vendedor). Aparte de las
propiedades de solo lectura mencionadas, el administrativo tiene otra propiedad pública de
lectura/escritura llamada Premio y el vendedor tiene otra propiedad pública de lectura/escritura
llamada Comision.
La propiedad de solo lectura Salario, se calcula como el salario base más la comisión o el premio
según corresponda.
Las clases tendrán además un método público llamado AumentarSalario() que tendrá una
implementación distinta en cada clase. En el caso del administrativo se incrementará el salario base
en un 1% por cada año de antigüedad que posea en la empresa, en el caso del vendedor se
incrementará el salario base en un 5% si su antigüedad es inferior a 10 años o en un 10% en caso
contrario.
El siguiente código (ejecutado el día 26/4/2020) debería mostrar en la consola el resultado indicado
CODIGO:
Empleado[] empleados = new Empleado[] {
new Administrativo("Ana", 20000000, DateTime.Parse("26/4/2018"), 10000) {Premio=1000},
new Vendedor("Diego", 30000000, DateTime.Parse("2/4/2010"), 10000) {Comision=2000},
new Vendedor("Luis", 33333333, DateTime.Parse("30/12/2011"), 10000) {Comision=2000}
};
foreach (Empleado e in empleados)
{
Console.WriteLine(e);
e.AumentarSalario();
Console.WriteLine(e);
}

TERMINAL: 
Administrativo Nombre: Ana, DNI: 20000000 Antigüedad: 2
Salario base: 10000, Salario: 11000
-------------
Administrativo Nombre: Ana, DNI: 20000000 Antigüedad: 2
Salario base: 10200, Salario: 11200
-------------
Vendedor Nombre: Diego, DNI: 30000000 Antigüedad: 10
Salario base: 10000, Salario: 12000
-------------
Vendedor Nombre: Diego, DNI: 30000000 Antigüedad: 10
Salario base: 11000, Salario: 13000
-------------
Vendedor Nombre: Luis, DNI: 33333333 Antigüedad: 8
Salario base: 10000, Salario: 12000
-------------
Vendedor Nombre: Luis, DNI: 33333333 Antigüedad: 8
Salario base: 10500, Salario: 12500
-------------

RECOMENDACIONES: 
Recomendaciones: Observar que el método AumentarSalario() y la propiedad de solo lectura
Salario en la clase Empleado pueden declararse como abstractos. Intentar no utilizar campos sino
propiedades auto-implementadas todas las veces que sea posible. Además sería deseable que la
propiedad SalarioBase definida en Empleado sea pública para la lectura y protegida para la
escritura, para que pueda establecerse desde las subclases Administrativo y Vendedor.*/

using System;

namespace practica6Ejercicio8
{
    class Program
    {
        static void Main(string[] args)
        {
         Empleado[] empleados = new Empleado[] {
        new Administrativo("Ana", 20000000, DateTime.Parse("26/4/2018"), 10000) {Premio=1000},
        new Vendedor("Diego", 30000000, DateTime.Parse("2/4/2010"), 10000) {Comision=2000},
        new Vendedor("Luis", 33333333, DateTime.Parse("30/12/2011"), 10000) {Comision=2000}
        };
        foreach (Empleado e in empleados){
            Console.WriteLine(e);
            e.AumentarSalario();
            Console.WriteLine(e);
}
        }
    }
    abstract class Empleado{
        protected DateTime fechaDeIngreso {private set; get;}
        protected String nombre {private set;get;} 
        protected double salario {get => calcularSalario();}
        public double salarioBase{protected set;get;}

        public Empleado(string nombre, double salarioBase, DateTime ingreso){
            this.fechaDeIngreso=ingreso;
            this.nombre=nombre;
            this.salarioBase=salarioBase;
        }
        public abstract double calcularSalario();
        public abstract void AumentarSalario();
    }
    class Administrativo: Empleado{
        private double premio; 
        public Administrativo(string nombre,double salarioBase, DateTime ingreso,double premio) :base(nombre,salarioBase,ingreso){
            this.premio=premio;
        }

        public double Premio {get => premio; set => premio = value;}
        public override double calcularSalario(){
            return base.salarioBase+ this.Premio;
        }
        public override void AumentarSalario(){
            DateTime fecha= DateTime.Parse("24/4/2020");
            int antiguedad= fecha.Year - this.fechaDeIngreso.Year;
            base.salarioBase+= (antiguedad*base.salarioBase)/100;
        }
       
    }
    class Vendedor:Empleado{
        private double comision;

        public Vendedor(string nombre, double salarioBase, DateTime ingreso, double comision) : base(nombre, salarioBase,ingreso){
            this.Comision=comision;
        }
        public double Comision{get => comision; set => comision = value;}
        public override double calcularSalario(){
            return base.salarioBase+this.Comision;
        }
        public override void AumentarSalario(){
            DateTime fecha= DateTime.Parse("24/4/2020");
            int antiguedad= fecha.Year - this.fechaDeIngreso.Year;
            if (antiguedad < 10){
                base.salarioBase+= (5*base.salarioBase)/100;   
            }
            else
                {
                    base.salarioBase+= (10*base.salarioBase)/100;
                }
        }

    }

}
