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
        private string semestre;

        //Constructor para crear un Alumno.
        public Alumno(string iDAlumno, string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento)
        {
            this.iDAlumno = iDAlumno;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.fechaNacimiento = fechaNacimiento;
        }

        public string DatosAlumno()
        {
            return string.Format("\t{0}\t{1}\t{2}\t{3}\t{4}",iDAlumno,nombre,apellidoPaterno,apellidoMaterno,fechaNacimiento);
        }

        public string IDAlumno { get=> iDAlumno;}
        public string NombreAlumno { get=> nombre;}
        
        
    }
}