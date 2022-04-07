using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Defina  el  delegado PrecioCambiadoEventHandler,  la  clase PrecioCambiadoEventArgs
 * y  la clase Articulo de tal forma que el programa siguiente genere la salida por 
 * consola que se muestra en la figura 1    
 
 SALIDA POR CONSOLA =>
 Artículo 1 valía 0 y ahora vale 10
Artículo 1 valía 10 y ahora vale 12
Artículo 1 valía 12 y ahora vale 14
 
 
 La clase Articulo cuenta con las propiedades de lectura/escritura Codigo y Precio. Además posee el
evento PrecioCambiado que se produce cuando se cambia el valor de la propiedad Precio (observar
que si se asigna el mismo valor el evento no se produce).
 * 
 */
delegate void PrecioCambiadoEventHandler(object sender, PrecioCambiadoEventArgs e);
class PrecioCambiadoEventArgs : EventArgs
{
    public double Codigo { get; set; }
    public double PrecioAnterior { get; set; }
    public double PrecioNuevo { get; set; }
}
namespace PrecioCambiado
{
    class Program
    {
        static void Main(string[] args)
        {           
            Articulo a = new Articulo(); 
            a.precioCambiado += precioCambiado; 
            a.Codigo = 1; 
            a.Precio = 10;
            a.Precio = 12;
            a.Precio = 12;
            a.Precio = 14;
            Console.ReadKey();
        }
        public static void precioCambiado(object sender, PrecioCambiadoEventArgs e)
        {
            string texto = $"Artículo {e.Codigo} valía {e.PrecioAnterior}";
            texto += $" y ahora vale {e.PrecioNuevo}";
            Console.WriteLine(texto);
        }
    }
    class Articulo
    {
        public PrecioCambiadoEventHandler precioCambiado;
        private double precio;
        private int codigo;

        public double Precio { get => precio; set => PreciosCambiados(value, Precio); } //cada vez que settee un nuevo valor, quiere decir que se actualiza el precio, entonces voy a tener que
        // disparar dicho evento
        public int Codigo { get => codigo; set => codigo = value; }

        public void PreciosCambiados(double nuevo,double viejo)
        {
            if ((precioCambiado != null) && (viejo != nuevo)) // ademas de comprobar que haya suscriptores al evento para dispararlo, tengo que comprobar que el precio ingresado no sea el mismo
                this.precio = nuevo; //actualizo el precio
                precioCambiado(this, new PrecioCambiadoEventArgs() { Codigo = Codigo, PrecioAnterior = viejo, PrecioNuevo = nuevo });

        }

    }

}
