using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace EDD
{
    class MateriasPorAlumno
    {
        //Declaración de los atributos
        private string iDAsoc;
        private string iDAlumno;
        private string iDMateria;
        private double calificacion;

        //Constructor para crear una MateriaPorAlumno
        public MateriasPorAlumno(string iDAsoc, string iDAlumno, string iDMateria, double calificacion)
        {
            this.iDAsoc = iDAsoc;
            this.iDAlumno = iDAlumno;
            this.iDMateria = iDMateria;
            this.calificacion = calificacion;
        }

        public string DatosMateriasPorAlumno()
        {
            return string.Format("\t{0,-20}{1,-20}{2,-20}{3,-20}",iDAsoc,iDAlumno,iDMateria,calificacion);
        }

        //propiedades
        public string IDAsoc { get=>iDAsoc;}      
        public string IDAlumno { get=>iDAlumno;}    
        public double Calificacion { get=>calificacion;} 
    }
}