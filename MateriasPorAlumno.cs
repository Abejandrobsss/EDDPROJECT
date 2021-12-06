using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace EDD
{
    public class MateriasPorAlumno
    {
        //Declaración de los atributos
        private string iDAsoc;
        private string iDAlumno;
        private string iDMateria;
        private double calificacion;

        string[] mPAArr;

        //Constructor para crear una MateriaPorAlumno
        public MateriasPorAlumno(string iDAsoc, string iDAlumno, string iDMateria, double calificacion)
        {
            this.iDAsoc = iDAsoc;
            this.iDAlumno = iDAlumno;
            this.iDMateria = iDMateria;
            this.calificacion = calificacion;
            mPAArr = new string[4]{iDAsoc,iDAlumno,iDMateria,calificacion.ToString()};
        }

        public string DatosMateriasPorAlumno()
        {
            return string.Format("\t{0,-20}{1,-20}{2,-20}{3,-20}",iDAsoc,iDAlumno,iDMateria,calificacion);
        }

        //propiedades
        public string IDAsoc { get => iDAsoc; set => iDAsoc = value; }      
        public string IDAlumno { get => iDAlumno; set => iDAlumno = value; }

        public string IDMateria {get => iDMateria; set => iDMateria = value;}    
        public double Calificacion { get => calificacion; set => calificacion = value; } 
        public string[] MPAArray { get=> mPAArr;} 
    }
}