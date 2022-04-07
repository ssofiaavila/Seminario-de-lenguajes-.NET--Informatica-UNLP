using System;
using System.Collections;
using System.IO;
using System.Text;
namespace practica7Ejercicio10
{
    class Program
    {
            static ArrayList listaAutos = new ArrayList();
            static void Main (String[] args)
            {
                
                Boolean finalizar=false;
                while(!finalizar)
                {
                    ImprimirMenuDeOpciones();
                    ConsoleKeyInfo opcion = Console.ReadKey(); 
                    Console.WriteLine();
                    switch(opcion.KeyChar)
                    {
                        case '1': 
                            AgregarAutosListaActual();
                            break;
                        case '2': 
                            CargarEnMemoriaListaDeAutos();
                            break;
                        case '3': 
                            GuardarEnArchivoDeTextoListaActual();
                            break;
                        case '4': 
                            ListarListaActual();
                            break;
                        case '5': 
                            finalizar = true;
                            break;
                        default: 
                            Console.WriteLine("opción invalida");
                            break;
                    }
                    finalizar=true;
                }
                
                Console.ReadKey();
                   
            }
            private static void ImprimirMenuDeOpciones()
            {
                Console.WriteLine("Menú de opciones");
                Console.WriteLine("================");
                Console.WriteLine();
                Console.WriteLine("   1. Ingresar autos desde la consola");
                Console.WriteLine("   2. Cargar lista de autos desde el disco");
                Console.WriteLine("   3. Guardar lista de autos en el disco");
                Console.WriteLine("   4. Listar por consola");
                Console.WriteLine("   5. Salir");
                Console.WriteLine();
                Console.WriteLine("Ingrese su opción");

            }

            private static void AgregarAutosListaActual()
            {
                while(true){
                    Console.WriteLine("Ingrese marca");
                    String marca = Console.ReadLine();
                    if(marca == ""){
                        break;
                    }
                    Console.WriteLine("Ingrese modelo");
                    String modelo = Console.ReadLine();
                    listaAutos.Add(new Auto(marca,modelo));
                }
                
            }
        
            private static void CargarEnMemoriaListaDeAutos()
            {
                listaAutos = new ArrayList();

                using(StreamReader sr = new StreamReader("listaAutos.txt"))
                {
                    while(!sr.EndOfStream)
                    {
                        listaAutos.Add(new Auto(sr.ReadLine(),sr.ReadLine()));
                    }
                }

            }
        
            private static void GuardarEnArchivoDeTextoListaActual()
            {
               
               
                    using(StreamWriter sw = new StreamWriter("archivoOpcion3.txt"))
                    {
                             foreach(Auto i in listaAutos)
                             {
                                 sw.WriteLine(i.Marca);
                                 sw.WriteLine(i.Modelo);
                             }
                    }
            }
        
            private static void ListarListaActual()
            {
                foreach(Auto i in listaAutos)
                {
                    Console.WriteLine(i.Marca +"  " + i.Modelo);
                }
            }
        }
        class Auto
        {   
            public String Modelo{get;}
            public String Marca{get;}
           
           public Auto (String marca, String modelo)
           {
               Modelo=modelo;
               Marca=marca;
           }    
        }
    }

