using System;
using Microsoft.EntityFrameworkCore; // instalo el paquete necesario para la BD 
using System.Collections.Generic;
using System.Linq;

namespace ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            var juego1 = new Juegos() //se instancia un juego
            {
                Nombre = "Cama Elastica",
                Descripcion = "Medida de 2 x 2",
                Estado = "Bueno",
                PrecioPorDia = 1000
            };
            var juego2 = new Juegos() //instancia otro juego
            {
                Nombre = "Castillo",
                Descripcion = "Hasta 10 personas",
                Estado = "Nuevo",
                PrecioPorDia = 1200
            };
            AgregarJuego(juego1);
            AgregarJuego(juego2); 
            ListarJuegos();
            var cliente1 = new Clientes()
            {
                DNI = "20569784",
                ApellidoYNombre = "Perez, Juan",
                Direccion = "48 e/ 5 y 6 N°520"
            };
            var cliente2 = new Clientes()
            {
                DNI = "10569784",
                ApellidoYNombre = "Gonzalez, Alejandra",
                Direccion = "25 e/ 9 y 10 N°520",
                Mail = "gale@gmail.com",
                Telefono = "221-15-569874"
            };
            AgregarCliente(cliente1);
            AgregarCliente(cliente2);
            ListarClientes();
            var alquiler1 = new Alquileres()
            {
                IdCliente = 1,
                IdJuego = 1,
                Fecha = DateTime.Now
            };
            var alquiler2 = new Alquileres()
            {
                IdCliente = 1,
                IdJuego = 2,
                Fecha = DateTime.Now
            };
            AgregarAlquiler(alquiler1);
            AgregarAlquiler(alquiler2);
            ListarAlquileres();
            ModificarCliente("10569784", "Gonzalez, Alejandra", "52 e/ 9 y 10 N°520",
            "gale@gmail.com", "221-15-569874");
            ListarClientes();
            EliminarCliente("10569784");
            ListarClientes();
            ModificarJuego(1, "Cama Elastica", "Medida de 2 x 2", "Roto", 1500);
            ModificarAlquiler(1, 1562.25, new DateTime(2021 / 11 / 12));
            ListarAlquileres();
        }

        public static void AgregarJuego(Juegos dato){
            using (var db = new AlquileresContext()){ 
                db.Juegos.Add(dato); //agrego a la tabla pero no de forma permanente
                db.SaveChanges(); //grabo los cambios finalmente
                Console.WriteLine($"Se agrego el juego {dato.Nombre} al que se le asigno el id {dato.id}");
            }      
        }

        public static void ListarJuegos(){
            using (var db = new AlquileresContext()){
                foreach (var j in db.Juegos){
                    Console.WriteLine(j);
                }
            }
        }

        public static void AgregarCliente(Clientes dato){
            using (var db = new AlquileresContext()){
                db.Clientes.Add(dato);
                db.SaveChanges();
                Console.WriteLine($"-- Se agrego el Cliente {dato.ApellidoYNombre} al que se le asigno el id {dato.Id}");
            } 
        }

        public static void ListarClientes(){
            Console.WriteLine($"-- Listado de Clientes --");
            using (var db = new AlquileresContext()){
                foreach (var j in db.Clientes){
                    Console.WriteLine(j);
                }
            }
        }
        public static void AgregarAlquiler(Alquileres dato){
            using (var db = new AlquileresContext()){
                db.Alquileres.Add(dato);
                db.SaveChanges();
                Console.WriteLine($"Se agrego el Alquiler al que se le asigno el id {dato.id}");
            } 
        }

        public static void ListarAlquileres(){
            using (var db = new AlquileresContext()){
                Console.WriteLine($"-- Listado de Alquileres "); 
                var listado = db.Alquileres.Join(db.Clientes, //creo un join donde el dato en comun es el ID de cliente
                        a => a.IdCliente, 
                        c => c.Id,
                (a,c) => new{ 
                    Alquiler = a, //la nueva estructura guardará el alquiler y el nombre y apellido del cliente
                    Cliente = c.ApellidoYNombre,
                });

             /* LISTADO 
                ALQUILER Y NOMBRE DE CLIENTE
             */ 
                var listadoJ = db.Juegos.Join(listado, //el nuevo join tendrá en común el id del juego
                        j => j.id,
                        a => a.Alquiler.IdJuego,
                        (j,a) => new
                    {
                        nombre= a.Cliente, 
                        juegos = j.Nombre,
                        idAlquiler= a.Alquiler.id,
                        fecha=a.Alquiler.Fecha,
                        monto= a.Alquiler.CostoTotal,                    


                    });                      

                 //imprimo cada uno de los objetos de la nueva estructura listadoAlquileress
                foreach(var obj in listadoJ){
                    Console.WriteLine(obj);
                }
            } 
        }

        public static void ModificarCliente(String dni, String nombreYApellido, String direccion, String mail,String numero){
            
            using (var db = new AlquileresContext()){
                var clienteAModificar = db.Clientes.Where( a => a.DNI == dni).SingleOrDefault(); //busco el cliente el cual coincide su DNI y puedo obtener uno o null
                if (clienteAModificar != null){ // o sea si se encontró
                   clienteAModificar.Direccion = direccion;
                   clienteAModificar.ApellidoYNombre=nombreYApellido;
                   clienteAModificar.Direccion=direccion;
                   clienteAModificar.Mail=mail;
                   clienteAModificar.Telefono=numero; 
                   //modifico todos sus datos
                   Console.WriteLine($"Se modifico el cliente con dni = {clienteAModificar.DNI}");
                }
                db.SaveChanges();
            }
        }

        public static void EliminarCliente(String dni){
            
            using (var db = new AlquileresContext()){
                var clienteABorrar = db.Clientes.Where( a => a.DNI == dni).SingleOrDefault(); //busco el cliente con igual DNI
                if (clienteABorrar != null){ //si existe
                   db.Clientes.Remove(clienteABorrar); //lo elimino
                   Console.WriteLine($"Se elimino el cliente con dni = {clienteABorrar.DNI}");
                }
                db.SaveChanges(); ///guardo cambios
            }
        }

        public static void ModificarJuego(int id, String nombre, String Descripcion, String estado, double precioPorDia){
            
            using (var db = new AlquileresContext()){
                var juegoAModificar = db.Juegos.Where( a => a.id == id).SingleOrDefault();
                if (juegoAModificar != null){
                   juegoAModificar.Descripcion = Descripcion;
                   juegoAModificar.PrecioPorDia = precioPorDia;
                   juegoAModificar.Estado = estado;
                   Console.WriteLine($"Se modifico el juego con id = {juegoAModificar.id}");
                }
                db.SaveChanges();
            }
        }

        public static void ModificarAlquiler(int id, double costoTotal, DateTime fecha){
            using (var db = new AlquileresContext()){
                var alquilerAModificar = db.Alquileres.Where(a => a.id == id).SingleOrDefault();
                if(alquilerAModificar != null){
                    alquilerAModificar.CostoTotal = costoTotal;
                    alquilerAModificar.Fecha = fecha;
                    Console.WriteLine($"Se modifico el alquiler con id = {alquilerAModificar.id}");
                }
                db.SaveChanges();
            }
        }
    }

    //coinciden con los datos creados en la BD
    public class Juegos{
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public string Estado {get;set;}
        public double PrecioPorDia {get;set;}

        public int id {get;set;}

        public override string ToString(){
            return ($"Id = {this.id}, Nombre = {this.Nombre}, Descripcion = {this.Descripcion}, Estado = {this.Estado}, Precio por dia = {this.PrecioPorDia}");
        }

    }
    public class Alquileres{
        public int IdCliente {get;set;}
        public DateTime Fecha {get;set;}
        public DateTime FechaDevolucion {get;set;}
        public int IdJuego{get;set;}
        public double CostoTotal {get;set;}
        public int id {get;set;}

        public override string ToString(){
            return ($"Id = {this.id}, Fecha = {this.Fecha}, Fecha de devolucion = {this.FechaDevolucion}");
        }
    }

    public class Clientes{

        public int Id {get;set;}
        public string DNI {get;set;}
        public string ApellidoYNombre{get;set;}
        public string Direccion {get;set;}
        public string Mail {get;set;}
        public string Telefono {get;set;}

        
        public override string ToString(){
            return ($"Id = {this.Id}, Nombre = {this.ApellidoYNombre}, Direccion = {this.Direccion}, Tel = {this.Telefono}");
        }
    }
    public class AlquileresContext : DbContext{ //corresponden con las estructuras de DB 
        public DbSet<Clientes> Clientes {get;set;}
        public DbSet<Alquileres> Alquileres {get;set;}
        public DbSet<Juegos> Juegos {get;set;}
        protected override void OnConfiguring( DbContextOptionsBuilder options){ //configuracion necesaria para construir otros objetos
             options.UseSqlite("data source=Servicio.db"); //indico la BD que voy a usar
        }
    }
}
