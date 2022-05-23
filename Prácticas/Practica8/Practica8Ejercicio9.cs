/*9) Codificar una clase Ingresador con un método público Ingresar() 
que permita al usuario ingresar líneas por la consola hasta que se
ingrese la línea con la palabra "fin". Ingresador debe implementar 
dos eventos. Uno sirve para notificar que se ha ingresado una línea 
vacía ( "" ). El otro para indicar que se ha ingresado un valor
numérico (debe comunicar el valor del número ingresado como argumento 
cuando se genera el evento). A modo de ejemplo observar el siguiente 
código que hace uso de un objeto Ingresador.

IMPRIME
Ingresador ingresador = new Ingresador();
ingresador.LineaVaciaIngresada += (sender, e) =>
{ Console.WriteLine("Se ingresó una línea en blanco"); };
ingresador.NroIngresado += (sender, e) =>
{ Console.WriteLine($"Se ingresó el número {e.Valor}"); };
ingresador.Ingresar();

2 eventos => LINEA VACÍA Y VALOR NUMERICO



*/



using System;

namespace practica8Ejercicio9
{
    class Program
            {
                static void Main()
                {
                ContadorDeLineas contador = new ContadorDeLineas(); //instancio el objeto de la clase ContadorDeLineas
                contador.Contar(); // invoco el metodo para empezar a leer lineas
                }
            }
            class ContadorDeLineas
            {
                private int _cantLineas = 0;
                public void Contar(){
                    Ingresador _ingresador = new Ingresador(); 
                    _ingresador.OtraLinea +=UnaLineaMas; //me suscribo al evento de la clase Ingresador
                    _ingresador.Ingresar();
                    Console.WriteLine($"Cantidad de líneas ingresadas: {_cantLineas}");
                }
                public void UnaLineaMas(object sender,EventArgs e) => _cantLineas++; // cada vez que se lee una linea, se ingrementará la cantidad
            }
            class Ingresador
            {
                private EventHandler _otraLinea;
                public event EventHandler OtraLinea
                {
                    add
                    {
                        _otraLinea += value;
                    }
                    remove
                    {
                        _otraLinea -= value;
                    }
                }
                public void Ingresar()
                {
                    string st = Console.ReadLine();
                    while (st != "")
                    {
                        _otraLinea(this,new EventArgs()); //cada vez que escribo algo por consola se genera un evento al cual la clase ContadorDeLineas está suscripto
                        st = Console.ReadLine();
                    }
                }
            }
}
