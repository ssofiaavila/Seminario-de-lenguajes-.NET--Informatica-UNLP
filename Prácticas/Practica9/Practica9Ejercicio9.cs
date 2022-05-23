/*9) Solicitar al usuario que ingrese el nombre por consola de dos archivo 
de texto. Si existen ambos se debe mostrar por consola un listado con
cada una de las palabras que se encuentran en ambos archivos a la vez. 
Por ejemplo, si el primer archivo contiene el texto del primer párrafo 
del punto 8, y el segundo archivo contiene este párrafo, la salida 
debería ser:*/

using System;
using System.IO;
using System.Collections.Generic;

namespace practica9Ejercicio9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);

            String strAux1,strAux2;
            Console.WriteLine("Ingrese nombre del archivo1");        
            strAux1=Console.ReadLine();
            Console.WriteLine("Ingrese nombre del archivo2");
            strAux2=Console.ReadLine();

                StreamReader sw1 = null;
                StreamReader sw2 = null;
                List<String> lista1;
                List<String> lista2;

                try
                {
                    sw1=new StreamReader(strAux1);
                    sw2=new StreamReader(strAux2);

                    //sw1=new StreamReader("archivo1.txt");
                    //sw2=new StreamReader("archivo2.txt");

                    lista1= StringsToListaOrdenada(sw1);
                    lista2= StringsToListaOrdenada(sw2);


                    foreach(string aux in lista1)
                    {
                        Console.WriteLine(aux);
                    }
                    Console.WriteLine();
                    foreach(string aux in lista2)
                    {
                        Console.WriteLine(aux);
                    }
                    Console.WriteLine();
                        
                   
                    var listaFinal =lista1.Union(lista2);
                    int espaciado =0;
                    foreach(string aux in listaFinal)
                    {
                        Console.Write($" {aux} -");
                        if(espaciado == 5)
                        {
                            Console.WriteLine();
                        }
                    }
                   

                    
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if(sw1==null)
                    {
                        sw1.Dispose();
                    }
                    if(sw2==null)
                    {
                        sw2.Dispose();
                    }
                }

                Console.ReadLine();
        }  

        public static List<string> StringsToListaOrdenada(StreamReader sr)
        {
            List<string> lista = new List<string>();
            string strAux;
            string[] vectorStrings;
             while((strAux=sr.ReadLine()) != null)
                    {
                        vectorStrings=strAux.Split(' ');
                        foreach(string aux in vectorStrings)
                        {
                            if(aux!= "")
                            {
                                lista.Add(aux);
                            }
                            
                        }
                       
                    }

                     lista.Sort();
            return lista;
        }
    }
}
