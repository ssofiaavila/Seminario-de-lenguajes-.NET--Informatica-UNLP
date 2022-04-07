/*18) Codificar un método asincrónico que utilice el método codificado en el ejercicio anterior y que
devuelva un Task<int[]> con la cantidad de palabras contenidas en cada uno de los archivos de
texto cuyos nombres se pasan como parámetro en un string[]. Este método debe invocar varias
veces al método definido en el ejercicio anterior lo que generará varias tareas que deben esperarse
asincrónicamente. 
Para esperar varias tareas de manera asincrónica se puede usar
Task.WenAll(...) que crea una tarea que finalizará cuando se hayan completado todas las tareas
proporcionadas, por lo tanto se puede usar await Task.WenAll(...).*/
using System;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;


namespace practica10Ejercicio18
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strVector = {"arch1.txt", "arch2.txt", "arch3.txt"};
            Task<int[]> t = cantPalabras(strVector);
            
            int i=0;
            foreach(int aux in t.Result)
            {
                Console.WriteLine($"en el archivo {i++} se encontraron {aux} palabras");
            }
            Console.ReadKey();
        }




        static async Task<int[]> cantPalabras(params string[] aux)
        {
            int[] v = new int[aux.Length];
            List<Task<int>> l = new List<Task<int>> ();
            for(int i=0; i<aux.Length; i++)
            {
                l.Add(leerArchivoAsync(aux[i]));
            }

            await Task.WhenAll(l);

            int k=0;
            foreach(Task<int> z in l)
            {
                v[k++]= z.Result;
            }

            return v;
        }

       static async Task<int> leerArchivoAsync (string nombre)
       {
           Task<string> t = new Task<string>(()=> leerArchivo(nombre));
           t.Start();
           await t;
           
           return t.Result.Split().Length;
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
