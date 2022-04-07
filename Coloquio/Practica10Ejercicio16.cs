/*16) Codificar un método asincrónico que devuelva un Task<string> con el contenido de un archivo
de texto cuyo nombre se pasa como parámetro.*/

using System;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace practica10Ejercicio16
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> t = leerArchivoAsync(Console.ReadLine()); //creo la variable t que será el task y tendré el String devuelvo una vez finalizado
            Console.WriteLine(t.Result);
            Console.ReadKey();
        }

       static async Task<string> leerArchivoAsync (string nombre) //es un metodo asincronico, interactúa con main y el método leerArchivo
       {
           Task<string> t = new Task<string>(()=> leerArchivo(nombre)); //instancio y asigno el task
           t.Start(); //lo comienzo
           await t; //permito que siga funcionando el programa mientras se finaliza el task
           return t.Result; //retorno el resultado
       }

       static string leerArchivo(string nombre) //metodo que lee el nombre del archivo
       {
           StreamReader st=null;//sirve para leer archivos de texto etc
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
