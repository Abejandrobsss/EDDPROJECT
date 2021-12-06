using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace EDD
{
    public class Alumno
    {
        
        //Declaración de los Atributos
        private string iDAlumno;
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private string fechaNacimiento;
        private string semestre;
        private string[] alumnoArr;

        //Constructor para crear un Alumno.
        public Alumno(string iDAlumno, string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento, string semestre)
        {
            this.iDAlumno = iDAlumno;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.fechaNacimiento = fechaNacimiento;
            this.semestre = semestre;
            alumnoArr = new string[6] { iDAlumno, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, semestre };
        }

        public string DatosAlumno()
        {
            return string.Format("\t{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}",iDAlumno,nombre,apellidoPaterno,apellidoMaterno,fechaNacimiento,semestre);
        }

        public string IDAlumno { get=> iDAlumno; set => iDAlumno = value; }
        public string NombreAlumno { get=> nombre; set => nombre = value;}
        public string ApellidoPaterno { get=> apellidoPaterno; set => apellidoPaterno = value;}
        public string ApellidoMaterno { get=> apellidoMaterno; set => apellidoMaterno = value;}
        public string DiaDeNacimiento { get=> fechaNacimiento; set => fechaNacimiento = value;}
        public string Semestre { get=> semestre; set => semestre = value;}
        public string[] AlumnoArr { get => alumnoArr; }
        
        
    }
}