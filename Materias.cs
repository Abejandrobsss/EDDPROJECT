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
        public Materias()
        {

        }
        public Materias(string iDMateria, string nombreMateria)
        {
            this.iDMateria = iDMateria;
            this.nombreMateria = nombreMateria;
        }
        public string DatosMaterias()
        {
            return string.Format("\t{0,-20}{1,-20}",iDMateria,NombreMateria);
        }

        public string IDMateria { get=> iDMateria; set => iDMateria = value;}
        public string NombreMateria { get=> nombreMateria; set => nombreMateria = value; }
    }
}