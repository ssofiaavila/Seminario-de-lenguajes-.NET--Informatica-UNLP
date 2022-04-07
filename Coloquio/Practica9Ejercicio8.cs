/*8) Solicitar al usuario que ingrese el nombre de un archivo de texto 
por la consola. Si el archivo existe mostrar por consola un listado 
con cada una de las palabras encontradas en ese archivo seguida
de dos puntos (:) y de la cantidad de ocurrencias de la misma 
en el archivo. Además deben presentarse ordenadas alfabéticamente. 
Es decir si el archivo de texto tuviese este párrafo, la salida
sería:
SALIDA -->
8: 1
Además: 1
al: 1
alfabéticamente: 1
archivo: 5
cada: 1
cantidad: 1
con: 1
consola: 2
de: 8
deben: 1
decir: 1
dos: 1
el: 4
en: 2
encontradas: 1*/

using System;
using System.IO;
using System.Collections.Generic;
namespace practica9Ejercicio8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            Console.WriteLine("Ingrese nombre del archivo");
            String strAux;
            strAux=Console.ReadLine();

            Console.WriteLine("Ingrese el nombre del archivo");

                StreamReader sw = null;

                try
                {
                    sw=new StreamReader(strAux); //leo el string 

                    SortedDictionary<string,int> Diccionario = new SortedDictionary<string,int>(); /* <String> será la llave o sea cada palabra e <int> será la 
                    cantidad de ocurrencias de esa palabra */

                    while((strAux=sw.ReadLine()) != null)
                    {
                        string[] vectorStrings=strAux.Split(' '); //separo las palabras
                       
                            foreach(string aux in vectorStrings)
                            {
                                if(aux!=""){
                                    if(!Diccionario.ContainsKey(aux)) //si no contiene esa palabra, la agrego y aumento en 1 ocurrencia
                                    {
                                        Diccionario.Add(aux,1);
                                    }
                                    else
                                    {
                                        Diccionario[aux]++; //si ya existe, solo aumento la ocurrencia
                                    }
                                }
                                
                                
                            }  
                    }

                    foreach (KeyValuePair<string,int> aux in Diccionario) 
                    {
                            Console.WriteLine($"{aux.Key} : {aux.Value}"); //para imprimir los valores y sus ocurrencias
                    }

                    
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if(sw!=null)
                    {
                        sw.Dispose();
                    }
                }

                Console.ReadLine();
        }  
    }
}
