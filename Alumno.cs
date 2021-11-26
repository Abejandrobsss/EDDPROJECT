using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace EDD
{
    class Alumno
    {
        
        //Declaración de los Atributos
        private string iDAlumno;
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private string fechaNacimiento;
        private int semestre;

        //Constructor para crear un Alumno.
        public Alumno(string iDAlumno, string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento, int semestre)
        {
            this.iDAlumno = iDAlumno;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.fechaNacimiento = fechaNacimiento;
            this.semestre = semestre;
        }

        public string DatosAlumno()
        {
            return string.Format("\t{0,-20}{1,-20}{2,-20}{3,-20}{4,20}{5,20}",iDAlumno,nombre,apellidoPaterno,apellidoMaterno,fechaNacimiento,semestre);
        }

        public string IDAlumno { get=> iDAlumno;}
        public string NombreAlumno { get=> nombre;}
        
        
    }
}