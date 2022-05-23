using System;
using System.IO;
using System.Text;
namespace practica7Ejercicio9b
{
    class Program
    {
        static void Main (String[] args)
            {
                StringBuilder strB = new StringBuilder();
                Console.WriteLine("Ingrese el texto");
                String aux;
                aux=Console.ReadLine();
                while(aux != ""){
                        strB.Append(aux + "\n");
                        aux=Console.ReadLine();
                }
                

                
                Console.WriteLine();

                Console.WriteLine("Ingrese el nombre del archivo");

                StreamWriter sw = null;

                try
                {
                    sw=new StreamWriter(Console.ReadLine());
                    sw.Write(strB);
                    Console.WriteLine($"Se guardó en {Environment.CurrentDirectory}");
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
                Console.ReadKey();
                   
            }
    }
}
