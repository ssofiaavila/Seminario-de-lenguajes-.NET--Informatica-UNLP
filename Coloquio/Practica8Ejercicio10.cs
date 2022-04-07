/*10) Codificar la clase Temporizador con un evento Tic que se genera 
cada cierto intervalo de tiempo medido en milisegundos una vez que el 
temporizador se haya habilitado. La clase debe contar con
dos propiedades: Intervalo de tipo int y Habilitado de tipo bool. 
No se debe permitir establecer la propiedad Habilitado en true si 
no existe ninguna suscripción al evento Tic!!!. No se debe permitir
establecer el valor de Intervalo menor a 100. En el lanzamiento del 
evento, el temporizador debe informar la cantidad de veces que se provocó 
el evento. Para detener los eventos debe establecerse la propiedad
 Habilitado en false. A modo de ejemplo, el siguiente código debe producir 
 la salida
indicada.
SALIDA:
10:58:43 10:58:45 10:58:47 10:58:49 10:58:51
10:58:52 10:58:53 10:58:54 10:58:55 10:58:56 */

using System;
using System.Threading;

namespace practica8Ejercicio10
{
    class Program
            {
                static void Main()
                {
                    Temporizador t = new Temporizador(); //intancio un objeto de la clase Temporizador
                    t.Tic += (sender, e) => /// me suscribo al evento, instanciando el evento y el EventArgs
                    { //esto es lo que haré una vez ocurrido el evento
                        Console.Write(DateTime.Now.ToString("HH:mm:ss") + " ");
                        if (e.Tics == 5) {
                            t.Habilitado = false;//va a hacer 5 tics y se deshabilitará
                        }
                    };
                    t.Intervalo = 2000; //setteo el intervalo, cada 2 milisegundos
                    t.Habilitado = true;
                    Console.WriteLine();
                    t.Intervalo = 1000; //ahora será cada 1 miliseg
                    t.Habilitado = true;

                    Console.ReadKey();
                }

                
            }

            public class TicEventArgs : EventArgs //clase donde declaro cuáles serán los eventArgs, en este caso la cantidad de tics
            {
                    public int Tics { get; set; }
            }

            delegate void TicEventHandler(object sender, TicEventArgs e); //manejador del evento

            class Temporizador
            {
                private TicEventHandler _tic; // es una conversión 
                public event TicEventHandler Tic // es lo que voy a hacer cada vez que alguien se suscribe al evento
                {
                    add
                    {
                        _tic+=value;
                    }
                    remove
                    {
                        _tic-=value;
                    }
                }
                private int _intervalo;

                private bool _habilitado=false; 

            
                public int Intervalo{
                    get
                    {
                        return this._intervalo;
                    }
                    set
                    { 
                        if(value>=100) // debido a que solo permite indicar intervalos mayores a 100
                        {
                            this._intervalo=value;
                        }
                    }
                }
               
                public bool Habilitado 
                {
                    get
                    {
                        return this._habilitado;
                    }
                    set 
                    {
                        if(value == false)
                        {
                             this._habilitado=value;
                        }
                         else
                        if(this._tic != null) //ademas de settear que está habitado, se disparará el evento porque comienza a funcionar el temporizador 
                        {
                            this._habilitado=value;
                            TicTock();
                        }
                    }
                }

               
                public void TicTock()
                {
                    int tics = 0;
                    while(_habilitado){

                        Thread.Sleep(_intervalo); //está especificado en milisegundos, por eso el 2000

                        if(_tic!= null)
                        {
                            _tic(this,new TicEventArgs(){Tics=tics});
                        }
                        tics++;
                    }
                   

                }
            }
}
