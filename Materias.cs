using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace EDD
{
    class Materias
    {
        //Declaración de los ArrayList
        private string iDMateria;
        private string nombreMateria;

        //Constructor para crear un Alumno
        public Materias(string iDMateria, string nombreMateria)
        {
            this.iDMateria = iDMateria;
            this.nombreMateria = nombreMateria;
        }
        public string DatosMaterias()
        {
            return string.Format("\t{0}\t{1}",iDMateria,NombreMateria);
        }

        public string IDMateria { get=> iDMateria;}
        public string NombreMateria { get=> nombreMateria;}

 
    }
}