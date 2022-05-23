/* Dado el siguiente codigo
a) Ejecutar paso a paso el programa y observar cuidadosamente su 
funcionamiento. Para ejecutar paso a paso colocar un punto de 
interrupción (breakpoint) en la primera línea ejecutable del
método Main() */

using System;

namespace practica8Ejercicio7
{
    class Program
    {
        static void Main(string[] args)
        {
            Trabajador t1 = new Trabajador();
            t1.Trabajar();
            Console.ReadKey();
        }
        public static void T1Trabajando(object sender, EventArgs e)
        => Console.WriteLine("Se inició el trabajo");
    }
    class Trabajador
    {
        public EventHandler Trabajando; //No es necesario definir un tipo delegado propio
        //porque la plataforma provee el tipo EventHandler
        //que se adecua a lo que se necesita
        public void Trabajar()
        {
        Trabajando(this, EventArgs.Empty);
        //realiza algún trabajo
        Console.WriteLine("Trabajo concluido");
}
}
}
/* b) qué salida produce por consola?
Produce: 
Se inició el trabajo
Trabajo concluido
 ---------------------
 c) Borrar (o comentar) la instrucción t1.Trabajando = T1Trabajando; 
 del método Main y contestar:
    c.1) ¿Cuál es el error que ocurre? ¿Dónde y por qué?
        Da error ya que el delegado eventHandler no tiene ningún valor
    c.2) ¿Cómo se debería implementar el método Trabajar() 
    para evitarlo? Resolverlo.
        static void Main(string[] args)
                    {
                        Trabajador t1 = new Trabajador();
                   --   t1.Trabajando = (sender, e) => Console.WriteLine("Se inició el trabajo"); 
                        t1.Trabajar();
                        Console.ReadKey();
                    }

d) Eliminar el método T1Trabajando de la clase Program y suscribirse al 
evento con una expresión lambda.    
     t1.Trabajando += (sender, e) => Console.WriteLine("Se inició el trabajo");           

*/
