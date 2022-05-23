/* 2) Incorporar al ejercicio anterior la posibilidad también de lavar a los perros. También se debe
incorporar una clase derivada de Película, las “películas clásicas” que además de alquilarse pueden
venderse. Estos cambios deben poder realizarse sin necesidad de modificar la clase estática
Procesador. El siguiente código debe producir la salida indicada

Auto auto = new Auto();
Libro libro = new Libro();
Persona persona = new Persona();
Perro perro = new Perro();
Pelicula pelicula = new Pelicula();
Procesador.Alquilar(pelicula, persona);
Procesador.Alquilar(libro, persona);
Procesador.Atender(persona);
Procesador.Atender(perro);
Procesador.Devolever(pelicula, persona);
Procesador.Devolever(libro, persona);
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
Procesador.Devolever(peliculaClasica, persona);
Procesador.Vender(peliculaClasica, persona);

Alquilando película a persona
Alquilando libro a persona
Atendiendo persona
Atendiendo perro
Película devuelta por persona
Libro devuelto por persona
Lavando auto
Reciclando libro
Reciclando auto
Secando auto
Vendiendo auto a persona
Vendiendo perro a persona
Lavando perro
Secando perro
Alquilando película clásica a persona
Película clásica devuelta por persona
Vendiendo película clásica a persona

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


    //---------- CLASES -------------
    //clase persona
    public class Persona: IAtendible{ 
        public Persona(){}  
        
        

    }
    
    public class Auto: IVendible, ILavable, IReciclable{
        
        public Auto(){}
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
        static void Main(string[] args)
        {
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
            Console.ReadKey();
        }
    }
}



