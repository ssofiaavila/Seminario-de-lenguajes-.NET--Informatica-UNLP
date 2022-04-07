using System;

namespace practica1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese numero de ejercicio");
            int ejercicio= int.Parse(Console.ReadLine());
            switch(ejercicio){
                case 1 :
                    ejercicio1();
                    break;
                case 2 :
                    ejercicio2();
                    break;
                case 3 :
                    ejercicio3();
                    break;
                case 4 :
                    ejercicio4();
                    break;
                case 5 :
                    ejercicio5();
                    break;
                case 6 :    
                    ejercicio6();
                    break;
                case 7 :
                    ejercicio7();
                    break;
                case 8 :
                    ejercicio8();
                    break;
                case 9 :
                    ejercicio9();
                    break;
                case 10:
                    ejercicio10();
                    break;
                case 11:
                    Console.WriteLine("No lo hice");
                    break;
                case 12:
                    ejercicio12();
                    break;
                case 13: 
                    Console.WriteLine("No lo hice");
                    break;
                case 14:
                    ejercicio14();
                    break;
                case 15:
                    ejercicio15();
                    break;
                case 16:
                    ejercicio16();
                    break;
                case 17:
                    ejercicio17();
                    break;
                case 18:
                    ejercicio18();
                    break;
                case 19:
                    Console.WriteLine("No lo hice");
                    break;
                case 20:
                    Console.WriteLine("No lo hice");
                    break;
                case 21:
                    ejercicio21();               
                    break;



            }

            //PRACTICA 1 EJERCICIO 1
            //Escribir un programa que imprima en la consola la frase “Hola Mundo”
            //haciendo una pausa entre palabra y palabra esperando a que el usuario presione una tecla para
            //continuar   
            void ejercicio1(){
                Console.WriteLine("Hola");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                Console.WriteLine(" ");
                Console.WriteLine("mundo!");
                Console.ReadKey();	
            }

             //2. Investigar por las secuencias de escape \n , \t , \" y \\. Escribir un programa que las utilice
            //para imprimir distintos mensajes en la consola.
            void ejercicio2(){               
                Console.WriteLine("Opcion 1");
                Console.WriteLine("Hola \n mundo");
                Console.WriteLine("Opcion 2");
                Console.WriteLine("Hola \t mundo");
                Console.WriteLine("Opcion 3");
                Console.WriteLine("Hola \\ mundo");

            }

             //3. El carácter @ delante de un string desactiva los códigos de escape. Probar el siguiente
            //fragmento de código, eliminar el carácter @ y utilizar las secuencias de escape necesarias para
            //que el programa siga funcionando de igual manera
            void ejercicio3(){
                string st = @"c:\windows\system";
                Console.WriteLine(st);
                st= "c:\\windows\\system";
                Console.WriteLine(st);
            //En vez de \ tuve que usar  \\
            }


            //4. Escribir un programa que solicite al usuario ingresar su nombre e imprima en la consola un
            //saludo personalizado utilizando ese nombre o la frase “Hola mundo” si el usuario ingresó una
            //línea en blanco. Para ingresar un string desde el teclado utilizar
            //System.Console.ReadLine()
            void ejercicio4(){ 
            Console.WriteLine("Ingrese nombre");
            string usuario=System.Console.ReadLine();
            if (usuario != " "){
                Console.WriteLine("Bienvendido! \n "+ usuario);
            }
            else
                Console.WriteLine("Hola mundo!");
            }


            //5. Idem. al ejercicio anterior salvo que se imprimirá un mensaje de saludo diferente según sea el
            //nombre ingresado por el usuario. Así para “Juan” debe imprimir “¡Hola amigo!”, para “María”
            //debe imprimir “Buen día señora”, para “Alberto” debe imprimir “Hola Alberto”. En otro caso,
            //debe imprimir “Buen día ” seguido del nombre ingresado o “¡Buen día mundo!” si se ha
            //ingresado una línea vacía.
            //a) utilizando if ... else if
            //b) utilizando switch
            void ejercicio5(){
                // INCISO A
            Console.WriteLine("Ejercicio 4, inciso A");
            Console.WriteLine("Ingrese nombre ");
            string usuario=System.Console.ReadLine();
            if (usuario == "Juan")
                Console.WriteLine("Hola amigo!");
            else
                if (usuario == "Maria")
                    Console.WriteLine("Buen dia señora");
                
                else
                    if (usuario == "Alberto")
                        Console.WriteLine("Hola Alberto");
                    
                    else
                        Console.WriteLine("Hola mundo!");
                
            //  INCISO B
                
		   switch(usuario){
                case "Juan" :
                    Console.Write("Hola amigo!");
                    break;
                case "Maria" :
                    Console.Write("Buen dia señora");
                    break;
                case "Alberto" :
                    Console.Write("Hola Alberto");
                    break;
                case "" :
                    Console.Write("Buen dia mundo!");
                    break;
                default :
                    Console.Write("Hola " + usuario);
                    break;


            }
            }
            
            //6. Utilizar System.Console.ReadLine() para leer líneas de texto (secuencia de caracteres que
            //finaliza al presionar <ENTER> ) por la consola. Por cada línea leída se debe imprimir la cantidad
            //de caracteres de la misma. El programa termina al ingresar la cadena vacía. (si st es una
            //variable de tipo string , entonces st.Length devuelve la cantidad de caracteres del string ).
            void ejercicio6(){
                Console.WriteLine("Ingrese lineas de texto");
            string cadena=Console.ReadLine();
            while (!string.IsNullOrEmpty(cadena)){
                int cant= cadena.Length;
                Console.WriteLine("La linea tiene "+ cant+ " caracteres");
                cadena=Console.ReadLine();
            
            }

            }
            // EJERCICIO 7
            //Qué hace la instrucción System.Console.WriteLine("100".Length); ?
            void ejercicio7(){
                System.Console.WriteLine("100".Length);
                //Imprime la cantidad de caracteres que tiene el string entre los ""
            }
           

            //EJERCICIO 8
            //8. Sea st una variable de tipo string correctamente declarada. ¿Es válida la siguiente instrucción:
            //Console.WriteLine(st=Console.ReadLine());
            void ejercicio8(){
            string st;
            Console.WriteLine( st=Console.ReadLine());
            // Es correcto
            } 

            //EJercicio 9
            //Escribir un programa que lea dos palabras separadas por un blanco que terminan con <ENTER> ,
            //y determinar si son simétricas (Ej: 'abbccd' y 'dccbba' son simétricas).
            //Tip: si st es un string , entonces st[0] devuelve el primer carácter de st, y st[st.Length-1]
            //devuelve el último carácter de st 
            void ejercicio9(){
            Console.WriteLine("Ingrese dos palabras");
            string st1=Console.ReadLine();
            string st2=Console.ReadLine();
            }

            //Ejercicio 10
            // 10. Escribir un programa que imprima en la consola todos los números que sean múltiplos de 17 o
            //de 29 comprendidos entre 1 y 1000
            void ejercicio10(){
                Console.WriteLine("Ejercicio 10");
            int num=1;
            while (num!= 1000){
                if ((num % 17 ==0) ||  (num % 29 == 0)){
                    Console.WriteLine(num+ "es multiplo de 17 o 29");
                }
                num++;
            }
            }

             //EJERCICIO 12
            //12. Escribir un programa que imprima todos los divisores de un número entero ingresado desde la
            //consola. Para obtener el entero desde un string st utilizar int.Parse(st) .
            void ejercicio12(){
                Console.WriteLine("Ingrese numero");
            int i,nro=int.Parse(Console.ReadLine());
            for (i=1;i<= nro;i++){
                if (nro  % i ==0){
                    Console.WriteLine("El numero es divisible por "+ i );
                }
            }          
            }
             //EJERCICIO 14
            //14. Escribir un programa que multiplique por 365 el número entero ingresado por el usuario desde
            //la consola. El resultado debe imprimirse en la consola dígito por dígito, separado por un espacio
            //comenzando por el dígito menos significativo al más significativo.
            void ejercicio14(){
                Console.WriteLine("Ejercicio 14, ingrese numero entero");
            int nro=int.Parse(Console.ReadLine());
            while (nro  != 0){
                int aux=nro % 10;
                Console.WriteLine(aux+ "\n");
                nro/=10;
            }
            }

             //EJERCICIO 15
            //15. Escribir un programa que solicite un año por pantalla y diga si es bisiesto. Un año es bisiesto si
            //es divisible por 4 pero no por 100. Si es divisible por 100, para ser bisiesto debe ser divisible
            //por 400
            void ejercicio15(){
                Console.WriteLine("Ejercicio 15, ingrese un nro entero");
            int nro=int.Parse(Console.ReadLine());
            if (((nro % 4 == 0) && (nro % 100 != 0)) || ((nro % 100 == 0) && (nro% 400 == 0)))
                Console.WriteLine("El anio es bisiesto");
            }

            //EJERCICIO 16
            //16. Si a y b son variables enteras, identificar el problema (y la forma de resolverlo) de la siguiente
            //expresión ( tip: observar qué pasa cuando b = 0 ):
            void ejercicio16(){
                int a=10, b=4;
            if ((b!= 0) && (a/b > 5))
                Console.WriteLine(a/b);
            }


            //EJERCICIO 17
            // /17. Utilizar el operador ternario condicional para establecer el contenido de una variable entera con
            //el menor valor de otras dos variables enteras.
            void ejercicio17(){
            int a=4;
            int b=11;
            int c= (a<b) ? c=4 : c=b;
            }

            //EJERCICIO 18
            //18. Cual es la salida del siguiente codigo
            void ejercicio18(){ 
            int i;
            for (i = 0 ; i <= 4 ; i ++)
            {
                string st = i < 3 ? i == 2 ? "dos" : i == 1 ? "uno" : "< 1" : i < 4 ? "tres" : "> 3" ;
                Console.WriteLine(st);
                //Imprime <1  uno dos tres >3
            }
            } 


            //EJERCICIO 21
            //21. Analizar el siguiente codigo, cual es su salida
            void ejercicio21(){
                int i= 1 ;
            if (-- i == 0 )
                {
                Console.WriteLine ( "cero" );
                }
            if ( i ++ == 0 )
                {
                Console.WriteLine ( "cero" );
                }
            Console.WriteLine ( i );
            // Su salida sera: cero cero 1		

            }




        }
    }
}
