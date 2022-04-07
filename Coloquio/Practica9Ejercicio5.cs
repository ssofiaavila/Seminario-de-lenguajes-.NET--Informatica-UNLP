/*Tomar como base el ejercicio 7 de la práctica 4 para transformar la clase Nodo de dicho ejercicio
en una clase genérica Nodo<T> de un árbol binario de búsqueda de valores de tipo T. Claramente T
tiene que ser de un tipo que pueda ser ordenado.
Desarrollar los siguientes métodos y propiedades
1. Insertar(valor): Inserta valor (de tipo T) en el árbol descartándolo en caso que ya exista.
2. Inorden: devuelve un List<T> con los valores ordenados en forma creciente.
3. Altura: devuelve la altura del árbol.
4. CantNodos: devuelve la cantidad de nodos que posee el árbol.
5. ValorMáximo: devuelve el valor máximo que contiene el árbol.
6. ValorMínimo: devuelve el valor mínimo que contiene el árbol.*/


using System;
using System.Collections;
using System.Collections.Generic;
namespace practica9Ejercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
    
            Nodo<int> n = new Nodo<int>(7); //instancio el arbol con el tipo int
            n.Insertar(3);
            n.Insertar(1);
            n.Insertar(5);
            n.Insertar(12);
            foreach (int elem in n.InOrder) //obtengo la lista de los elementos del arbol
            {
            Console.Write(elem + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Altura: {n.Altura}");
            Console.WriteLine($"Cantidad: {n.CantNodos}");
            Console.WriteLine($"Mínimo: {n.ValorMinimo}");
            Console.WriteLine($"Máximo: {n.ValorMaximo}");
            Nodo<string> n2 = new Nodo<string>("hola"); // ahora instancio un arbol con el tipo String porque tambien es comparable
            n2.Insertar("Mundo");
            n2.Insertar("XYZ");
            n2.Insertar("ABC");
            foreach (string elem in n2.InOrder)
            {
            Console.Write(elem + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Altura: {n2.Altura}");
            Console.WriteLine($"Cantidad: {n2.CantNodos}");
            Console.WriteLine($"Mínimo: {n2.ValorMinimo}");
            Console.WriteLine($"Máximo: {n2.ValorMaximo}");

            Console.ReadKey();

        }
    }
    

    class Nodo<T> where T: IComparable<T> // implemento IComparable porque el arbol debe contener elementos ordenables
    {
        private T valor;
        private Nodo<T> hijoIzquierdo=null;
        private Nodo<T> hijoDerecho=null;

        public Nodo(T n){
            this.valor=n; //la raiz
        }

        public Boolean Insertar (T n){
            if(n.CompareTo(valor)==0) 
            {
                Console.WriteLine("El valor ingresado ya está dentro del arbol");
                return false;
            }
            if(n.CompareTo(valor) > 0){ //si n es mas grande que valor me devuelve un numero positivo
                if(hijoDerecho != null) // en caso que ya tenga HD, sigue recursivamete para insertarse
                {
                    return hijoDerecho.Insertar(n);
                }
                else
                {
                    hijoDerecho = new Nodo<T>(n);
                    return true;
                }
            }
            else //en caso que sea menor, va por el HI
            {
                if(hijoIzquierdo != null)
                {
                    return hijoIzquierdo.Insertar(n);
                }
                else
                {
                    hijoIzquierdo = new Nodo<T>(n);
                    return true;
                }
            }
        }


        public List<T> InOrder{
                get{
                    List<T> l = new List<T>();
                    GetInOrder(ref l);
                    return l;
                }
        }

        private void GetInOrder (ref List<T> l) //obtengo una lista del arbol ordenado, recursivamente
        {
            if(hijoIzquierdo!= null)
            {
                hijoIzquierdo.GetInOrder(ref l);
            }

            l.Add(this.valor);
            if(hijoDerecho != null)
            {
                hijoDerecho.GetInOrder(ref l);
            }
        }

        public int Altura{
            get{
                int x=0;
                GetAltura(ref x,0);
                return x;
            }
        }
        private void GetAltura(ref int n,int k){ // n devolverá la altura del arbol, por eso es de tipo ref
            if(n < k) { //una vez que paso una altura, se actualizará el valor de ref
                n=k; 
            }
            if(hijoIzquierdo!=null)
            {
                hijoIzquierdo.GetAltura(ref n,k+1); // o sea que tiene elemento, por eso se incrementa en 1
            }
            if(hijoDerecho!= null)
            {
                hijoDerecho.GetAltura(ref n,k+1);
            }
        }


        public int CantNodos
        {
           get{
                int x = 0;
                GetCantNodos(ref x);
                return x;
           } 
        }
        private void GetCantNodos(ref int n)
        {
            n++; //a medida que avanzo, se va actualizando el valor ref
            if(hijoIzquierdo != null){
                hijoIzquierdo.GetCantNodos(ref n);
            }  
            if(hijoDerecho != null)
            {
                hijoDerecho.GetCantNodos(ref n);
            }
        }

        public T ValorMaximo //me voy al elemento más a la derecha del arbol
        {
           get{
                if(hijoDerecho!= null)
                {
                    return hijoDerecho.ValorMaximo;
                }
                else
                {
                    return valor;
                }
           } 
        }

        public T ValorMinimo //voy al elemento más a la izquierda del arbol
        {
            get{
                if(hijoIzquierdo!= null) 
                {
                    return hijoIzquierdo.ValorMinimo;
                }
                else
                {
                    return valor;
                }
            }
            
        }
           
    }  
}
