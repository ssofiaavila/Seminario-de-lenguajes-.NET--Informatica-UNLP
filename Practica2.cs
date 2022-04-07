using System;
using System.Text;
enum Meses{
                enero,febrero,marzo,abril,mayo,junio,julio,agosto,septiembre,octubre,noviembre,diciembre
            }

        //  EJERCICIOS 14 16 Y 17 SON OBLIGATORIOS
namespace practica2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Ingresa ejercicio");
            int ejercicio= int.Parse(Console.ReadLine());

            switch (ejercicio){
                case 1:
                    ejercicio1();
                    break;
                case 2:
                    ejercicio2();
                    break;
                case 3:
                    ejercicio3();
                    break;
                case 4:
                    Console.WriteLine("Hecho en otro proyecto");
                    break;
                case 5:
                    ejercicio5();
                    break;
                case  6:
                    Console.WriteLine("Hecho en otro proyecto");
                    break;
                case 7:
                    ejercicio7();
                    break;
                case 8:
                    ejercicio8();
                    break;
                case 9:
                    Console.WriteLine("Resuelto en hoja");
                    break;
                case 10:
                    Console.WriteLine("Resuelto en hoja");
                    break;
                case 11:
                    ejercicio11();
                    break;
                case 12:
                    ejercicio12();
                    break;
                case 13:
                    ejercicio13();
                    break;
                case 15:
                    ejercicio15();
                    break;
                case 18:
                    ejercicio18();
                    break;
                case 19:
                    Console.WriteLine("Resuelto a parte");
                    break;
            }



        //1. Qué líneas del siguiente código provocan conversiones boxing y unboxing.
        void ejercicio1(){
            char c1 = 'A';
            string st1 = "A";
            object o1 = c1; //boxing
            object o2 = st1; //boxing
            char c2 = (char)o1; //umboxing
            string st2 = (string)o2; 



        }


        //El tipo object es un tipo referencia, por lo tanto luego de la sentencia o2 = o1 ambas
        //variables están apuntando a la misma dirección. ¿Cómo explica entonces que el resultado en la
        //consola no sea “Z Z”?
        void ejercicio2(){
            object o1 = "A";
            object o2 = o1;
            o2 = "Z";
            Console.WriteLine(o1 + " " + o2);
            //Al ser un string, cada vez que se modifica, se crea una nueva referencia con el nuevo valor, porque no se modifica el que apunta
            //es un objeto inmutable
        }

        //3. Analizar la siguiente porción de código para calcular la sumatoria de 1 a 10. ¿Cuál es el error?
        //¿Qué hace realmente?
        void ejercicio3(){
            int sum = 0;
            int i = 1;
            while (i <= 10)
            {   
                sum += i++;
                }
        
    //1 3 6 10 15 21 28 36 45 55 
        //Hace una sucesion n_i=n_i-1 +i
        }


        // 5. Qué hace la instrucción?
        // asigna a vector el valor null?
        void ejercicio5(){
            int[] vector = new int[0];
            Console.WriteLine(vector == null);
        // No le asigna el valor null, consultar por qué
        }


        
        //7. Analizar el siguiente código. ¿Qué líneas producen error de compilación y por qué?
        void ejercicio7(){ 
            //char c;
            //char? c2;
            //string st;
            //c = ""; // error porque no puedo convertir string a char
            //c = ''; //no existe char vacio
            //c = null; // no fue declarado como nulleable
            //c2 = null;  // en este caso sí
            //c2 = (65 as char?);
            //st = "";
            //st = '';
            //st = null;
            //st = (char)65; //no es casteable implicitamente
            //st = (string)65;
            //st = 47.89.ToString();
        }



        //8. Escribir un programa que reciba una lista de nombres como parámetro e imprima por consola un 
        //saludo personalizado para cada uno de ellos.
        //a) utilizando la sentencia for
        //b) utilizando la sentencia foreach
        void ejercicio8(){
            Console.WriteLine("Ingrese 4 nombres");
            saludar("Sofia", "Rufina", "Bono", "Maxi");

            
            void saludar(params string[]vector){
                //Usando FOR
                int i;
                int nro= vector.Length-1;
                for (i=0; i<= nro; i++){
                    Console.WriteLine("Hola "+ vector[i]+"!");
                }           
                //Usando FOREACH
                foreach (string n in vector){
                    Console.WriteLine("Hola "+ n+ "!");
                }
            }



        }

        //11. ¿Para qué sirve el método Split de la clase string? Usarlo para escribir en la consola todas
        //las palabras (una por línea) de una frase ingresada por el usuario.
        //El metodo sirve para separar cadenas o chars
        void ejercicio11(){
            Console.WriteLine("Ingrese oracion");
            string cadena=Console.ReadLine();
            string []palabras= cadena.Split();
            foreach(var word in palabras){
                Console.WriteLine(word);

            }
        }

        //12. Comprobar el funcionamiento del siguiente programa y dibujar el estado de la pila y la memoria
        //heap cuando la ejecución alcanza los puntos indicados (comentarios en el código)
        void ejercicio12(){
            object[] v = new object[10];
            v[0] = new StringBuilder("Net");
            for (int i = 1; i < 10; i++)
            {
                v[i] = v[i - 1];
            }
            (v[5] as StringBuilder).Insert(0, "Framework .");
            foreach (StringBuilder s in v)
            Console.WriteLine(s);
            //dibujar el estado de la pila y la mem. heap
            //en este punto de la ejecución
            v[5] = new StringBuilder("CSharp");
            foreach (StringBuilder s in v)
            Console.WriteLine(s);
            //dibujar el estado de la pila y la mem. heap
            //en este punto de la ejecución


        }

        //13. Definir el tipo de datos enumerativo llamado Meses y utilizarlo para:
        //a) Imprimir en la consola el nombre de cada uno de los meses en orden inverso (diciembre,
        //noviembre, octubre …, enero)
        //b) Solicitar al usuario que ingrese un texto y responder si el texto tipeado corresponde al
        //nombre de un mes
        //Nota: en todos los casos utilizar un for iterando sobre una variable de tipo Meses
        void ejercicio13(){           
            
            //INCISO A
                Meses d;
                for (d= Meses.diciembre; d >= Meses.enero; d--){
                    Console.WriteLine("Mes: "+ d);
                }
            //INCISO B
                Console.WriteLine("Ingrese mes");
                String mes=Console.ReadLine();
                for (d= Meses.enero; d<=Meses.diciembre;d++){
                    if (mes.Equals(d.ToString())){
                        Console.WriteLine("Corresponde al mes de "+ d);
                    }
                }
            //  d.equals(e.tostring()
        }
        //USANDO RECURSIVIDAD
        //15. Escribir una función (método static int Fib(int n)) que calcule el término n de la
        //serie de Fibonacci.
        //Fib(n) = 1, si n <=2
        //Fib(n) = Fib(n-1) + Fib(n-2), si n > 2
        void ejercicio15(){
            int n=int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(n));

            int Fib(int n){
                if (n<=2){
                    return 1;
                }
                else
                {
                    return Fib(n-1)+ Fib(n-2);
                }
            }

        }

        // 18. Codificar el método Swap que recibe 2 parámetros enteros e intercambia sus valores. El cambio
        //debe apreciarse en el método invocador.
        void ejercicio18(){
            int a=15,b=25;
            Console.WriteLine("a= "+ a+ " b="+b);
            Swap(ref a,ref b);
            Console.WriteLine("a= "+a+ "  b= "+b);

            void Swap(ref int a,ref int b){
                int aux=a;
                a=b;
                b=aux;
            }
           

        }

        String fin=Console.ReadLine();    






        }




        

        
    }
}
