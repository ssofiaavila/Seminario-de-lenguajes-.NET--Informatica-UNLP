/*17) Codificar un método asincrónico que utilice el método codificado en el ejercicio anterior y que
devuelva un Task<int> con la cantidad de palabras contenidas en un archivo de texto cuyo nombre
se pasa como parámetro.*/

using System;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace practica10Ejercicio17
{
     class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = leerArchivoAsync(Console.ReadLine()); 
            Console.WriteLine(t.Result + " palabras");
            Console.ReadKey();
        }

       static async Task<int> leerArchivoAsync (string nombre)
       {
           Task<string> t = new Task<string>(()=> leerArchivo(nombre));
           t.Start();
           await t;
           
           return t.Result.Split().Length; //obtengo cantidad de palabras
       }

       static string leerArchivo(string nombre)
       {
           StreamReader st=null;
           StringBuilder str = new StringBuilder("");
           try{
               st = new StreamReader(nombre);

               while(!st.EndOfStream)
               {
                   str.Append(st.ReadLine() + '\n');
               }
           }
           catch(Exception e){
               Console.WriteLine(e.Message);
           }
           finally{
              st.Dispose();
           }

           return str.ToString();
       }
    }
}
