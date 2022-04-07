/*7) Definir la clase Persona con las siguientes propiedades de lectura y escritura: Nombre de tipo
string, Sexo de tipo char, DNI de tipo int, y FechaNacimiento de tipo DateTime. Además
definir una propiedad de sólo lectura (calculada) Edad de tipo int. Definir un indizador de
lectura/escritura que permita acceder a las propiedades a través de un índice entero. Así, si p es un
objeto Persona, con p[0] se accede al nombre, p[1] al sexo p[2] al DNI, p[3] a la fecha de
nacimiento y p[4] a la edad. En caso de asignar p[4] simplemente el valor es descartado. Observar
que el tipo del indizador debe ser capaz almacenar valores de tipo int, char, DateTime y string.*/

using System;

namespace practica5Ejercicio7
{
    class Persona{
        private String nombre {get; set;}
        private char sexo {get; set;}
        private int dni {get;set;}
        private DateTime fechaNacimiento {get;set;}
        private int edad {
            get{
                return DateTime.Now.Year-fechaNacimiento.Year;
            }
        }

        public string this[int i]{
            get
                { 
                    if (i==0){
                        return nombre;
                    }
                    else {
                        if (i==1){
                            return Char.ToString(sexo);
                        }
                        else{
                            if(i==2){
                                return Convert.ToString(dni);
                            }
                            else
                                if(i==3){
                                    return fechaNacimiento.ToString();
                                }
                                else
                                    return Convert.ToString(edad);
                        }    
                    }
                }
            set
                { 
                    if (i==0){
                         nombre=value;
                    }
                    else {
                        if (i==1){
                            sexo=Convert.ToChar(value);
                        }
                        else{
                            if(i==2){
                                dni=Convert.ToInt32(value);
                            }
                            else
                                if(i==3){
                                   fechaNacimiento=Convert.ToDateTime(value);
                                }
                                
                        }    
                    }
                }
        }
   }


    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
