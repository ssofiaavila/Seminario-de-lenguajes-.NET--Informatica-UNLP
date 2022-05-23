/* 3) Incorporar al ejercicio anterior las interfaces y métodos necesarios para que el siguiente código
produzca la salida indicada 

public static void Ejecutar()
{
System.Collections.ArrayList lista = new System.Collections.ArrayList() {
new Persona(),
new Auto()
};
foreach(IComercial c in lista)
{
c.Importa();
}
foreach(IImportante i in lista)
{
i.Importa();
}
(lista[0] as Persona).Importa();
(lista[1] as Auto).Importa();
}

CONSOLA --> 

Persona vendiendo al exterior
Auto que se vende al exterior
Persona importante
Auto importante
Método Importar() de la clase Persona
Método Importar() de la clase Auto

*/


using System;

namespace practica7Ejercicio1
{

    //---------- INTERFACES ---------
    //interface alquilable
    public interface IAlquilable{
        
       public void SeAlquilaA(Persona p)=> Console.WriteLine("Alquilando " + this.GetType().Name+ " a "+ p.GetType().Name);
        public void devolver(Persona p)=> Console.WriteLine(this.GetType().Name+" devuelta por "+p.GetType().Name);
    }

    //interface vendible
    public interface IVendible{
        
        public void seVendeA(Persona p)=> Console.WriteLine("Vendiendo "+ this.GetType().Name+ " a " + p.GetType().Name);      
        

    }
    //interface lavable
    public interface ILavable{
        
        public void seLavaA()=> Console.WriteLine($"Lavando "+  this.GetType().Name);
        public void secar()=> Console.WriteLine($"Secando "+ this.GetType().Name);
        

    }
    //interface reciclable
    public interface IReciclable{
        
        public void seReciclaA()=> Console.WriteLine($"Reciclando " + this.GetType().Name); 
        

    }
    //interface atendible
    public interface IAtendible{
        
        public void seAtiendeA()=>Console.WriteLine("Atendiendo a "+ this.GetType().Name);

    }
    //interface comercial
    public interface IComercial{
        public void Importa();
    }
    public interface IImportante{
        public void Importa();

    }


    //---------- CLASES -------------
    //clase persona
    public class Persona: IAtendible, IComercial, IImportante{ 
        public Persona(){}  
        void IComercial.Importa()=> Console.WriteLine("Persona vendiendo al exterior");
        void IImportante.Importa()=> Console.WriteLine("Persona importante");
        public void Importa()=> Console.WriteLine("Metodo importar() de la clase Persona");
        
        

    }
    
    public class Auto: IVendible, ILavable, IReciclable, IComercial, IImportante{
        
        public Auto(){}
        void IComercial.Importa()=> Console.WriteLine("Auto que se vende al exterior");
        void IImportante.Importa()=> Console.WriteLine("Auto importante");
        public void Importa()=> Console.WriteLine("Metodo importar() de la clase Auto");
        
    }


    //clase Libro
    public class Libro: IAlquilable, IReciclable{
        public Libro(){}
        public void SeAlquilaA(Persona p)=> Console.WriteLine("Alquilando " + this.GetType().Name+ " a "+ p.GetType().Name);
        public void devolver(Persona p)=> Console.WriteLine(this.GetType().Name+ " devuelto por "+ p.GetType().Name);
    }


    //clase perro
    public class Perro: IVendible, IAtendible, ILavable{
        public Perro(){}
        
    }

    //clase pelicula
    public class Pelicula: IAlquilable{
        public Pelicula(){}
    }    

    public class PeliculaClasica: Pelicula, IAlquilable, IVendible{
        public PeliculaClasica(){}
    }
    //clase procesador
    static class Procesador{
    public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p);
    public static void Atender(IAtendible x)=> x.seAtiendeA();
    public static void Devolver(IAlquilable x , Persona p)=> x.devolver(p);
    public static void Lavar(ILavable x)=>x.seLavaA();
    public static void Reciclar(IReciclable x)=> x.seReciclaA();
    public static void Secar (ILavable x)=> x.secar();
    public static void Vender(IVendible x,Persona p)=> x.seVendeA(p);
    }

    




    class Program
    {

        public static void Ejecutar(){
        System.Collections.ArrayList lista = new System.Collections.ArrayList() {
        new Persona(),
        new Auto()
        };
        Console.WriteLine("-----------------");
        foreach(IComercial c in lista){
            c.Importa();
        }
        foreach(IImportante i in lista){
            i.Importa();
        }
        (lista[0] as Persona).Importa();
        (lista[1] as Auto).Importa();
        }
        static void Main(string[] args){
            Auto auto = new Auto();
            Libro libro = new Libro();
            Persona persona = new Persona();
            Perro perro = new Perro();
            Pelicula pelicula = new Pelicula();
            Procesador.Alquilar(pelicula, persona);
            Procesador.Alquilar(libro, persona);
            Procesador.Atender(persona);
            Procesador.Atender(perro);
            Procesador.Devolver(pelicula, persona);
            Procesador.Devolver(libro, persona);
            Procesador.Lavar(auto);
            Procesador.Reciclar(libro);
            Procesador.Reciclar(auto);
            Procesador.Secar(auto);
            Procesador.Vender(auto, persona);
            Procesador.Vender(perro, persona);
            Procesador.Lavar(perro);
            Procesador.Secar(perro);
            PeliculaClasica peliculaClasica = new PeliculaClasica();
            Procesador.Alquilar(peliculaClasica, persona);
            Procesador.Devolver(peliculaClasica, persona);
            Procesador.Vender(peliculaClasica, persona);
            Ejecutar();            
            Console.ReadKey();
        }
    }
}



