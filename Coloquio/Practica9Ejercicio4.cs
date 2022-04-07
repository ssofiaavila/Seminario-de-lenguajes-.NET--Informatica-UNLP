/*4) Dada la siguiente clase genérica*
Codificar una lista enlazada genérica de tal manera que el código 
siguiente produzca la salida
indicada:
SALIDA -->
0 100 3 10 11*/

using System.Collections.Generic;
using System;
using System.Collections;

namespace practica9Ejercicio4
{
     class Program
            {
                static void Main()
                {
                    ListaGenerica <int> lista = new ListaGenerica<int>(); //intancio una clase genérica con parámetros de tipo int
                    lista.AgregarAdelante(3);
                    lista.AgregarAdelante(100);
                    lista.AgregarAtras(10);
                    lista.AgregarAtras(11);
                    lista.AgregarAdelante(0);
                    IEnumerator <int> enumerador = lista.GetEnumerator(); 
                    while (enumerador.MoveNext()) //recorro el IEnumerator
                    {
                        int i = enumerador.Current;
                        Console.Write(i + " ");
                    }
                    
                    Console.ReadKey();
                }
               
            }

            class Nodo<T> 
            {
                    public T Valor { get; private set; }
                    public Nodo<T> Proximo { get; set; } = null;
                    public Nodo(T valor) => Valor = valor;
            }

            class ListaGenerica<T> : IEnumerable<T> //es posible implementar esta interfaz porque es genérica
            { 
                private Nodo<T> primerElemento = null; // al igual que la clase ListaGenerica, Nodo es una clase genérica
                public void AgregarAdelante(T dato)
                {
                    Nodo <T> nodoNuevo = new Nodo<T>(dato);
                    if(primerElemento == null) //en caso de que el nodo sea vacío
                    {
                        primerElemento = nodoNuevo;
                    }
                    else
                    {
                        nodoNuevo.Proximo = primerElemento; //si no, se inserta adelante
                        primerElemento=nodoNuevo;
                    }
                }
                public void AgregarAtras(T dato)
                {
                    Nodo <T> nodoNuevo = new Nodo<T>(dato);
                    if(primerElemento == null) //en caso que la lista esté vacía
                    {
                        primerElemento = nodoNuevo;
                    }
                    else
                    {
                        Nodo<T> aux = primerElemento;  //instancio un "puntero"
                        while(aux.Proximo !=null){ //recorro la lista hasta el último elemento
                            aux = aux.Proximo; //voy actualizando el "puntero" 
                        }
                        aux.Proximo = nodoNuevo;
                    }
                }

                public IEnumerator<T> GetEnumerator()
                {
                    return new EnumeradorLista<T>(primerElemento); //obtenemos la estructura que nos permite recorrer la estructura
                }

                private IEnumerator GetEnumerator1()
                {
                    return this.GetEnumerator();
                }
                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetEnumerator1();
                }
                
            }
            class EnumeradorLista<T> : IEnumerator<T>
            {
                Nodo<T> Inicio;
                Nodo<T> Actual; 

                bool PrimerNext = true; //como hacemos moveNext y despues leemos , si o si en el primer MoveNext() no me debo de mover porque sino
                                        // no leiría el primer valor
                public EnumeradorLista(Nodo<T> primero)
                {
                    Inicio=primero;
                    Actual=primero;
                }


                //implemento los metodos del IEnumerator
                public bool MoveNext()  //retorna true si avanzó al siguiente elemento, de lo contrario significa que no hay más elementos en la colección
                {
                    if(!PrimerNext) 
                    {
                        Actual = Actual.Proximo;
                    }
                    else
                    {
                        PrimerNext=false; 
                    }
                       
                    if(Actual != null)
                    {
                        return true; //en caso que haya siguiente elemento
                    }
                    else
                    {
                        return false;
                    }
                }
                public void Reset() //settea el IEnumerator a tu posicion inicial, el cual está antes que el primer elemento de la coleccion 
                {
                    PrimerNext = true;
                    Actual = null;
                }
                public T Current{   //Valor actual en el que está posicionado el IEnumerator
                    get{
                        return Actual.Valor;
                    }
                }
                object IEnumerator.Current 
                {
                    get{
                        return Actual.Valor;
                    }
                }

                void IDisposable.Dispose() { }
            }
}
