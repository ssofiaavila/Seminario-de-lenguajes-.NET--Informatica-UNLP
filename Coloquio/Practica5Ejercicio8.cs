using System;
using System.Collections;

namespace practica5Ejercicio8
{
    class Persona{
        private String nombre {get; set;}
        private char sexo {get; set;}
        public int dni {get;set;}
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


    class ListaDePersonas{
        private Hashtable ht = new Hashtable();
        public void Agregar(Persona p){
            ht[p.dni] = p;
        }


        
    }
}
