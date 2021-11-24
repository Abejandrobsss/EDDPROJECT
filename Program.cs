using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace EDD
{
    public class ClaseGeneral
    {
        public int opcion;

        //Parámetros para la clase Alumno
        int idAlumno;
        string nombreAlumno;
        string apellidoPaternoAlumno;
        string apellidoMaternoAlumno;
        string fechaNacimientoAlumno;

        //Parámetros para la clase Materias
        int idMaterias;
        string nombreMaterias;

        //Parámetros para la clase MateriasPorAlumno
        int idAsocMatPorAlumno;
        int idAlumnoMatPorAlumno;
        int idMateriaMatPorAlumno;
        double calificacionMatPorAlumno;

        public void menuInsertar()
        {
            Console.WriteLine("\n\t═════ INSERTAR ════════════════════════════════════════════════════════════════");
            Console.Write("\n\t» 1 Alumnos\n\t» 2 Materias\n\t» 3 Materias por alumno\n\n\t  > ");
            opcion = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n\t───────────────────────────────────────────────────────────────────────────────\n");

            switch (opcion)
            {
                case 1:
                Console.Write("\tID: ");
                idAlumno = Convert.ToInt32(Console.ReadLine());
                Console.Write("\tNombre: ");
                nombreAlumno = Console.ReadLine();
                Console.Write("\tApellido paterno: ");
                apellidoPaternoAlumno = Console.ReadLine();
                Console.Write("\tApellido materno: ");
                apellidoMaternoAlumno = Console.ReadLine();
                Console.Write("\tFecha de nacimiento: ");
                fechaNacimientoAlumno = Console.ReadLine();
                Alumno alumno1 = new Alumno(idAlumno,nombreAlumno,apellidoPaternoAlumno,apellidoMaternoAlumno,fechaNacimientoAlumno);
                break;

                case 2:
                Console.Write("\tID: ");
                idMaterias = Convert.ToInt32(Console.ReadLine());
                Console.Write("\tNombre: ");
                nombreMaterias = Console.ReadLine();
                Materias materia1 = new Materias(idMaterias, nombreMaterias);
                break;

                case 3:
                Console.Write("\tID asociado: ");
                idAsocMatPorAlumno = Convert.ToInt32(Console.ReadLine());
                Console.Write("\tID alumno: ");
                idAlumnoMatPorAlumno = Convert.ToInt32(Console.ReadLine());
                Console.Write("\tID materia: ");
                idMateriaMatPorAlumno = Convert.ToInt32(Console.ReadLine());
                Console.Write("\tCalificación: ");
                calificacionMatPorAlumno = Convert.ToDouble(Console.ReadLine());
                MateriasPorAlumno materiaporalumno1 = new MateriasPorAlumno(idAsocMatPorAlumno,idAlumnoMatPorAlumno,idMateriaMatPorAlumno,calificacionMatPorAlumno);
                break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ClaseGeneral prueba1 = new ClaseGeneral();
            prueba1.menuInsertar();
        }
    }
}
