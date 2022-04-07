using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace practica10Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            var alumnos= Alumno.getLista();
            var examenes= Examen.getLista();
            var cursos= Curso.getLista();
            /*a) Obtener el listado con los nombres de los alumnos que rindieron al menos un examen,
ordenado alfabéticamente (tip: puede utilizarse el método de extensión Distint() para obtener
una secuencia de elementos no repetidos). 
SALIDA DE CONSOLA:
            Ana
            Andrés
            Camila
            María
            Paula
            Raúl*/
            Console.WriteLine("Inciso A");
            var listadoA = alumnos.GroupJoin(examenes, //el elemento en comun son los ID de examenes el cual será el key
                            a => a.id,
                            e => e.alumnoID,
                            (a, examenes) => new
                            {
                                NombreAlumno = a.nombre, //la nueva estructura contendrá el nombre del alumno y los examenes que rindió
                                Examenes = examenes 
                            }).OrderBy(f => f.NombreAlumno); //y luego listadoA lo ordeno por nombre de alumno
            listadoA.Where(l => l.Examenes.Count() >0).ToList().ForEach(l => Console.WriteLine(l.NombreAlumno));
            //termino filtrando listadoA con los que tienen mas de un examen y luedo imprimo su nombre


            /* b) Obtener el listado con los cursos donde se hayan rendido exámenes. Se debe listar el título
del curso junto con la cantidad de exámenes. El listado debe ordenarse por cantidad de
exámenes. La salida debería ser:
SALIDA -->
{ Título = Inglés, Cantidad = 2 }
{ Título = Historia, Cantidad = 2 }
{ Título = Literatura, Cantidad = 3 }
{ Título = Geografía, Cantidad = 4 } */
            //Inciso B
            Console.WriteLine($"Inciso B: ");
            var listadoB = cursos.GroupJoin(examenes, //en este caso el key es el ID del curso
                            a => a.cursoID,
                            e => e.cursoID,
                            (a, examenes) => new
                            {
                                Cantidad = examenes,
                                Titulo = a.titulo,
                            }).Where(f => f.Cantidad.Count() >0).OrderBy(f => f.Cantidad.Count()).ToList(); 
                            //filtra y almacena solamente los cuales tengan mas de un examen 
            foreach (var obj in listadoB){
                Console.WriteLine($"titulo = {obj.Titulo}, cantidad = {obj.Cantidad.Count()}");
            }


            /*c) Obtener el listado con los alumnos que hayan rendido al menos un exámen informando el
nombre del alumno, el título del curso y la nota del examen. La salida debería ser:
{ Alumno = Ana, Curso = Inglés, Nota = 5 }
{ Alumno = Ana, Curso = Geografía, Nota = 8 }
{ Alumno = Andrés, Curso = Geografía, Nota = 10 }

*/
Console.WriteLine($"Inciso C: ");
            var listadoAA = alumnos.GroupJoin(examenes, //primero obtengo los alumnos usando como key el ID
                            a => a.id,
                            e => e.alumnoID,
                            (a, examenes) => new
                            {
                                NombreAlumno = a.nombre,
                                id = a.id,
                                Examenes = examenes
                            }).Where(f => f.Examenes.Count() >0).OrderBy(f => f.NombreAlumno);
                            //a su vez los filtro para que tengan al menos un examen y los ordeno por nombre de alumno
            //en listadoAA tengo un key de cada nombre junto con su ID y los examenes que dio

            var listadoC = cursos.Join(examenes, //obtengo los cursos y los examenes de cada uno, su key es el ID de curso
                            a => a.cursoID,
                            e => e.cursoID,
                            (a, examenes) => new
                            {
                                Cursos = a.titulo,
                                Examenes = examenes,
                            });
            // en listadoC tengo una estructura con el nombre de curso y la coleccion de examenes


             //finalmente creo la nueva estructura de cada alumno con su nombre, titulo de curso y nota               
            var listadoInicisoC = listadoAA.Join(listadoC,
                            a => a.id,  //en comun tienen el id de alumno
                            c => c.Examenes.alumnoID, //filtro por id de alumno de cada examen
                            (a,c) => new
                            {
                                NombreAlumno = a.NombreAlumno,
                                Titulo = c.Cursos,
                                Nota = c.Examenes.nota,
                            });
            

            foreach(var obj in listadoInicisoC){
                Console.WriteLine($"Alumno = {obj.NombreAlumno}, Curso = {obj.Titulo}, Nota = {obj.Nota}");
            }

            /*d) Filtrar el listado del punto anterior para mostrar sólo los casos aprobados (nota >=6).*/
             Console.WriteLine($"Inciso D: ");
            var listadoD = alumnos.GroupJoin(examenes, 
                            a => a.id,
                            e => e.alumnoID,
                            (a, examenes) => new
                            {
                                NombreAlumno = a.nombre,
                                id = a.id,
                                Examenes = examenes
                            }).Where(f => f.Examenes.Count() > 0).OrderBy(f => f.NombreAlumno);
            var listadoDD = cursos.Join(examenes, 
                            a => a.cursoID,
                            e => e.cursoID,
                            (a, examenes) => new
                            {
                                Cursos = a.titulo,
                                Examenes = examenes,
                            });
            var listadoInicisoD = listadoD.Join(listadoDD,
                            a => a.id,
                            c => c.Examenes.alumnoID,
                            (a,c) => new
                            {
                                NombreAlumno = a.NombreAlumno,
                                Titulo = c.Cursos,
                                Nota = c.Examenes.nota, 
            //hago el mismo procedimiento que en C pero ahora los filtro =>6
                            }).Where(f => f.Nota >= 6);
            foreach(var obj in listadoInicisoD){
                Console.WriteLine($"Alumno = {obj.NombreAlumno}, Curso = {obj.Titulo}, Nota = {obj.Nota}");
            }

            /*e) Obtener el listado con los nombres de los alumnos que no han rendido ningún examen.*/
            Console.WriteLine($"Inciso E: ");
            var listadoE = alumnos.GroupJoin(examenes, 
                            a => a.id,
                            e => e.alumnoID,
                            (a, examenes) => new
                            {
                                NombreAlumno = a.nombre,
                                Examenes = examenes
                            }).OrderBy(f => f.NombreAlumno); //filtra los que tienen lista vacia
            listadoE.Where(f => f.Examenes.Count() == 0).ToList().ForEach(obj => Console.WriteLine($"Alumno = {obj.NombreAlumno}"));

            // Inciso F 
            Console.WriteLine($"Inciso F: ");
            var listadoF = alumnos.GroupJoin(examenes, 
                    a => a.id,
                    e => e.alumnoID,
                    (a, examenes) => new
                    {
                        Alumno = a,
                        Examenes = examenes
                        //el where es para filtrar los que al menos hicieron un examen y despues los ordena
                    }).Where(p => p.Examenes.Count() >= 1).OrderBy(p => p.Alumno.nombre).ToList();
            foreach (var obj in listadoF){
                var promedio = obj.Examenes.Average(e => e.nota); //obtengo el promedio de los examenes
                Console.WriteLine($"Alumno = {obj.Alumno.nombre} , Promedio = {promedio}");

            Console.ReadKey();

        }
    }

    class Alumno{ //para los alumnos tengo los fields de nombre y su ID 
        public String nombre {get;set;} 
        public int id {get;set;}
        public Alumno(String nombre, int id){
            this.nombre=nombre;
            this.id=id;
        }
        public static List<Alumno> getLista(){ //instancio y retorno la lista del diagrama de la práctica
            return new List<Alumno>(){
                new Alumno("Juan",1),
                new Alumno("Ana",2),
                new Alumno("Andres",3),
                new Alumno("Paula",4),
                new Alumno("Sebastian",5),
                new Alumno("Maria",6),
                new Alumno("Camila",7),
                new Alumno("Ivan",8),
                new Alumno("Raul",9),
            };
        }
    }
    class Examen{ //examen tiene los field alumnoID, nota y ID de curso
        public int alumnoID{get;set;}
        public int nota{get;set;}
        public int cursoID{get;set;}
        public Examen(int alumnoID,int nota,int cursoID){
            this.alumnoID=alumnoID;
            this.nota=nota;
            this.cursoID=cursoID;
        }
        public static List<Examen> getLista(){ //intancio los de la practica
            return new List<Examen>(){
                new Examen(2,5,1),
                new Examen(4,7,5),
                new Examen(4,9,3),
                new Examen(3,10,4),
                new Examen(7,5,3),
                new Examen(2,8,4),
                new Examen(6,9,5),
                new Examen(9,7,1),
                new Examen(6,5,4),
                new Examen(9,1,4),
                new Examen(7,9,5),
            };
        }
    }

    class Curso{ //tiene de datos el ID del curso y el nombre
        public int cursoID{get;set;}
        public String titulo{get;set;}
        public Curso(int curso,String titulo){
            this.cursoID=curso;
            this.titulo=titulo;
        }

        public static List<Curso> getLista(){ //instancio los de la práctica
            return new List<Curso>(){
                new Curso(1,"Ingles"),
                new Curso(2,"Matematica"),
                new Curso(3,"Historia"),
                new Curso(4,"Geografia"),
                new Curso(5,"Literatura"),
                new Curso(6,"Contabilidad"),
            };

        }
    }
}
}
