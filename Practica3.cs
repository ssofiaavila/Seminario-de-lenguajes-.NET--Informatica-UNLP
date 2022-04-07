using System;
using System.Collections;
namespace practica3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese ejercicio");
           int num=int.Parse(Console.ReadLine());
           switch (num){
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
                    ejercicio4();
                    break;
                case 5:
                    Console.WriteLine("Resuelto a parte");
                    break;
                case 6:
                    ejercicio6();
                    break;
                case 7:
                    ejercicio7();
                    break;
                case 8:
                    ejercicio8();
                    break;
                case 9:
                    ejercicio9();
                    break;
                case 11:
                    ejercicio11();
                    break;
                case 13:
                    ejercicio13();
                    break;
                case 14:
                    Console.WriteLine("Resuelto a parte");
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
        }


    	// /1. Ejecutar y analizar cuidadosamente el siguiente programa:
        //Comprobar tipeando teclas y modificadores (shift, ctrl, alt) para apreciar de qué manera
        //se puede acceder a esta información en el código del programa.

            void ejercicio1(){
                Console.CursorVisible = false;
                ConsoleKeyInfo k = Console.ReadKey(true);
                while (k.Key != ConsoleKey.End){
                Console.Clear();
                Console.Write($"{k.Modifiers}-{k.Key}-{k.KeyChar}");
                k = Console.ReadKey(true);
                }
            }
            //Comprobar tipeando teclas y modificadores (shift, ctrl, alt) para apreciar de qué manera
            //se puede acceder a esta información en el código del programa.

            //2. Implementar un método estático para imprimir por consola todos los elementos de una matriz
            //(arreglo de dos dimensiones) pasada como parámetro. Debe imprimir todos los elementos de
            //una fila en la misma línea en la consola.
            void ejercicio2(){
                double [,]matriz= new double [,]
                    {{2,4,6,8},
                    {10,12,14,16},
                    {18,20,22,24},
                    {26,28,30,32}};
                ImprimirMatriz(matriz);
                    

            void ImprimirMatriz(double[,] matriz){
            //Ayuda: Si A es un arreglo, A.GetLength(i) devuelve la longitud del arreglo en la
            //dimensión i.
            // CANTIDAD FILAS=4 COLUMNAS= 4 O..3
            int f,c,cantC=matriz.GetLength(0), cantF=matriz.GetLength(1);

            for (f=0;f< cantF ;f++){
                for (c=0; c< cantC; c++){
                    Console.Write(matriz[f,c]+" ");
                }
                Console.WriteLine(" ");
            }
            }//INVESTIGAR
            }
            //3. Idem al anterior pero ahora con un parámetro más que representa la plantilla de formato que
            //debe aplicarse a los números al imprimirse. La plantilla de formato es un string de acuerdo a las
            //convenciones de formato compuesto, por ejemplo “0.0” implica escribir los valores reales con
            //un dígito para la parte decimal. Observar que no hay inconveniente para implementar dos
            //métodos con el mismo nombre siempre que NO lleven la misma cantidad de parámetros con los
            //mismos tipos y en el mismo orden (sobrecarga de métodos).
            void ejercicio3(){
                double [,]matriz= new double [,]
                    {{2,4,6,8},
                    {10,12,14,16},
                    {18,20,22,24},
                    {26,28,30,32}};
                Console.WriteLine("Ingrese formato para representar numero");
                string cadena=Console.ReadLine();
                ImprimirMatriz(matriz,cadena);


                void ImprimirMatriz(double[,]matriz,String cadena){
                    int f,c,cantC=matriz.GetLength(0), cantF=matriz.GetLength(1);
                    for (f=0;f< cantF ;f++){
                        for (c=0; c< cantC; c++){
                            Console.Write(String.Format(cadena+" "+ "{0,4:#.0}", matriz[f,c])+ " ");
                    }
                    Console.WriteLine(" ");
                    }
                }

               


                }
             //4. Implementar los métodos GetDiagonalPrincipal y GetDiagonalSecundaria que
                //devuelven un vector con la diagonal correspondiente de la matriz pasada como parámetro. Si la
                //matriz no es cuadrada generar una excepción ArgumentException con un mensaje
                //explicativo.
                void ejercicio4(){
                    double [,] matriz=new double[,]
                            {{2,4,6},
                            {8,10,12},
                            {14,16,18}};   
                        double [] principal=getDiagonalPrincipal(matriz);
                        double[] secundaria=getDiagonalSecundaria(matriz);

                        double[] getDiagonalPrincipal(double [,] matriz){
                            try
                            {
                                if (matriz.GetLength(0)== matriz.GetLength(1)){
                                    int dim=matriz.GetLength(0);
                                    double[] nueva= new double[dim];
                                    int f,c;
                                    for (f=0;f<dim; f++){
                                        for (c=0;c<dim;c++){
                                            if (f==c){
                                                nueva[f]=matriz[f,c];
                                            }
                                        }
                                    }
                                    return nueva;                                
                                }
                            }
                            catch{
                                Console.WriteLine("No es una matriz simetrica");
                                return null;
                            }
                            return null;                             
                        }

                        double[] getDiagonalSecundaria(double [,] matriz){
                            try
                            {
                                if (matriz.GetLength(0)== matriz.GetLength(1)){
                                    int dim=matriz.GetLength(0);
                                    double []nueva= new double[dim];
                                    int f,c;
                                    for (f=dim;f>=0;f--){
                                        for (c=dim;c>=0;c--){
                                            if (f==c){
                                                nueva[f]=matriz[f,c];
                                            }
                                        }
                                    }
                                    return nueva;
                                }
                               
                            }
                            catch{
                                Console.WriteLine("No es una matriz simetrica");
                                return null;
                            }
                            return null;
                        }
        }

        //6. Implementar los siguientes métodos estáticos que devuelvan la suma, resta y multiplicación de
        //matrices pasadas como parámetros. Para el caso de la suma y la resta, las matrices deben ser del
        //mismo tamaño, en caso de no serlo devolver null. Para el caso de la multiplicación la cantidad
        //de columnas de A debe ser igual a la cantidad de filas de B, en caso contrario generar una
        //excepción ArgumentException con un mensaje explicativo.
        //      static double[,] Suma(double[,] A, double[,] B)
        //      static double[,] Resta(double[,] A, double[,] B)
        //      static double[,] Multiplicacion(double[,] A, double[,] B)
        void ejercicio6(){
            double [,] A= new double[,]{
                {1,2,3,4},{5,6,7,8},{9,10,11,12},{13,14,15,16},
            };
            double [,] B= new double[,]{
                {1,2,3,4},{5,6,7,8},{9,10,11,12},{13,14,15,16},
            };
            
            double [,] matrizSuma= suma(A,B);
            double [,] matrizResta= resta(A,B);
            double [,] matrizMultiplicacion= multiplicacion(A,B);

            double [,] suma(double [,] a, double [,] b){
                
                if ((A.GetLength(0)== B.GetLength(0)) && (A.GetLength(1) == B.GetLength(1))){
                    double [,] tabla= new double[A.GetLength(0),A.GetLength(1)];
                    int f,c;
                    for(f=0;f< A.GetLength(0);f++){
                        for (c=0;c< A.GetLength(1);c++){
                            tabla[f,c]= A[f,c]+B[f,c];
                        }
                    }
                    return tabla;
                }
                return null;

            }
            double [,] resta(double [,] a, double [,] b){
                if ((A.GetLength(0)== B.GetLength(0)) && (A.GetLength(1) == B.GetLength(1))){
                    double [,] tabla= new double[A.GetLength(0),A.GetLength(1)];
                    int f,c;
                    for(f=0;f< A.GetLength(0);f++){
                        for (c=0;c< A.GetLength(1);c++){
                            tabla[f,c]= A[f,c]-B[f,c];
                        }
                    }
                    return tabla;
                }
                return null;
            }

            double [,] multiplicacion(double [,] A, double [,] b){
                    try{
                        if (A.GetLength(1)== B.GetLength(0)){
                            double [,] tabla= new double [A.GetLength(0),B.GetLength(1)];
                            int f,c;
                            for (f=0; f< A.GetLength(0);f++){
                                for (c=0;f< B.GetLength(1);c++){
                                    tabla[f,c]= A[f,c] * B[f,c];
                                }
                            }
                            return tabla;
                        }
                    }
                    catch{
                        Console.WriteLine("No cumple condicion");
                        return null;
                    }
                    return null;

            }
        }
            //7. ¿De qué tipo quedan definidas las variables x, y, z 
            //en el siguiente código?
            void ejercicio7(){
                int i = 10;
                var x = i * 1.0;
                var y = 1f;
                var z = i * y;
                Console.WriteLine(x.GetType());
                Console.WriteLine(y.GetType());
                Console.WriteLine(z.GetType());
                // x= double
                // y= single
                // z =single
                /*Las variables Single (punto flotante de precisión simple)
                 se almacenan como números IEEE de coma flotante de 32 bits
                  (4 bytes) con valores que van de -3,402823E38 a -1,401298E-45
                   para valores negativos y de 1,401298E-45 a 3,402823E38 para 
                   valores positivos.*/

                
            }
             //8. ¿Qué líneas del siguiente método provocan 
            //error de compilación y por qué?  
            void ejercicio8(){
                //var a=3L;
                dynamic b=32;
                object obj= 3;
                //a= a * 2.0; //no existe conversion del tipo
                b= b * 2.0;
                b= "hola";
                obj = b;
                b= b + 11;
                //obj= obj + 11; //operador no declarado para obj
                var c= new{ Nombre = "Juan" };
                var d= new{ Nombre = "María" };
                var e= new{ Nombre = "Maria", Edad = 20 };
                var f= new { Edad = 20, Nombre = "Maria" };
                //f.Edad= 22; //no se puede modificar porque es solo de lectura
                d= c;
                //e= d;
                //f= e; //no se puede asignar porque tiene <> contenidos
            }

            //9. Señalar errores de compilación y/o ejecución en el siguiente código
            void ejercicio9(){
                object obj = new int[10];
                dynamic dyn = 13;
                // Console.WriteLine(obj.Length); no esta definito length para obj
                Console.WriteLine(dyn.Length);
            }
            //10. Verificar con un par de ejemplos si la sección opcional 
            //[:formatString] de formatos compuestos
            //redondea o trunca cuando se formatean números reales 
            //restringiendo la cantidad de decimales.
            //Plantear los ejemplos con cadenas de formato compuesto 
            //y con cadenas interpoladas.
             //CONSULTAR

            //11. Señalar errores de ejecución en el siguiente código
            void ejercicio11(){
                ArrayList a = new ArrayList() {1,2,3,4};
                a.Remove(5);
                a.RemoveAt(5);
            //el error es que no se declaró la libreria con using

            }
            //12. CONSULTAR cómo encararlo


            //13. Realizar un análisis sintáctico para determinar si los paréntesis en una expresión aritmética están
            //bien balanceados. Verificar que por cada paréntesis de apertura exista uno de cierre en la cadena
            //de entrada. Utilizar una pila para resolverlo. Los paréntesis de apertura de la entrada se
            //almacenan en una pila hasta encontrar uno de cierre, realizándose entonces la extracción del
            //último paréntesis de apertura almacenado. Si durante el proceso se lee un paréntesis de cierre y
            //la pila está vacía, entonces la cadena es incorrecta. Al finalizar el análisis, la pila debe quedar
            //vacía para que la cadena leída sea aceptada, de lo contrario la misma no es válida.
            void ejercicio13(){
            //CONSULTAR

            }


            //15. ¿Qué salida por la consola produce el siguiente código?
            void ejercicio15(){
                int x = 0;
                try
                {
                Console.WriteLine(1.0 / x);
                Console.WriteLine(1 / x);
                Console.WriteLine("todo OK");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                //Notifica que se intentó dividir por 0
            }

            //16. Implementar un programa que permita al usuario ingresar números por la consola. Debe
            //ingresarse un número por línea finalizado el proceso cuando el usuario ingresa una línea vacía.
            //A medida que se van ingresando los valores el sistema debe mostrar por la consola la suma
            //acumulada de los mismos. Utilizar la instrucción try/catch para validar que la entrada
            //ingresada sea un número válido, en caso contrario advertir con un mensaje al usuario y
            //proseguir con el ingreso de datos.
            void ejercicio16(){
                var suma=0;
                var ingreso=-1;
                try{
                    while (ingreso!= 0){
                    ingreso= int.Parse(Console.ReadLine());
                    suma=suma+ingreso;
                    Console.WriteLine(suma);
                    }
                }
                catch 
                {
                    Console.WriteLine("Se ingreso linea vacia");
                }

            }
            //17. Implementar un programa calculadora que calcule una expresión ingresada por el usuario
            //correspondiente a una operación binaria de las cuatro elementales (ejemplo “44.5/456”,
            //“456*45”, “549-12”, “54+6” ). Utilizar try/catch para validar los números y controlar
            //cualquier tipo de excepción que pudiese ocurrir en la evaluación de la expresión.
            void ejercicio17(){
                try{
                    Console.WriteLine("Division");
                    double division= double.Parse(Console.ReadLine())/double.Parse(Console.ReadLine());
                    double multiplicación=double.Parse(Console.ReadLine()) * double.Parse(Console.ReadLine());
                    int resta= int.Parse(Console.ReadLine())  - int.Parse(Console.ReadLine());
                    int suma= int.Parse(Console.ReadLine()) + int.Parse(Console.ReadLine());

                }
                catch (Exception e){
                    Console.WriteLine("Operacion invalida");
                }

            }
            //18. Cuál es la salida por consola del siguiente programa:
            //Bloque finally en Metodo1
            //Método 1 propagó una excepción no tratada
            //Método 2 propagó una excepción no tratada
            //Excepción InvalidCast en Metodo3
            //Método 3 propagó una excepción
            void ejercicio18(){
                try {
                    Metodo1();
                } 
                catch {
                Console.WriteLine("Método 1 propagó una excepción no tratada");
                }
                try {
                Metodo2();
                } 
                catch {
                Console.WriteLine("Método 2 propagó una excepción no tratada");
                }
                try {
                Metodo3();
                }
                catch {
                Console.WriteLine("Método 3 propagó una excepción");
                }
                
                static void Metodo1() {
                object obj = "hola";
                try {
                    int i = (int)obj;
                } 
                finally {
                    Console.WriteLine("Bloque finally en Metodo1");
                }
                }
                static void Metodo2() {
                    object obj = "hola";
                    try {
                    int i = (int)obj;
                    }
                    catch (OverflowException) {
                    Console.WriteLine("Overflow");
                }
                }
                static void Metodo3() {
                    object obj = "hola";
                    try {
                    int i = (int)obj;
                    }
                    catch (InvalidCastException) {
                    Console.WriteLine("Excepción InvalidCast en Metodo3");
                    throw;
                }



            }     
         
    //no imprime ningun error        
        
       
    }
     Console.ReadLine();
    }
}
}


