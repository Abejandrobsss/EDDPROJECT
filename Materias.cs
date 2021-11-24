using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace EDD
{
    class Materias
    {
        //Declaración de los ArrayList
        ArrayList IDMateria = new ArrayList();
        ArrayList nombreMateria = new ArrayList();

        //Constructor para crear un Alumno
        public Materias(int idmateria, string nombremat)
        {
            IDMateria.Add(idmateria);
            nombreMateria.Add(nombremat);
        }

 
    }
}