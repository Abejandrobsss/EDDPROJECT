using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace EDD
{
    class MateriasPorAlumno
    {
        //Declaración de los ArrayList
        ArrayList IDAsoc = new ArrayList();
        ArrayList IDAlumno = new ArrayList();
        ArrayList IDMateria = new ArrayList();
        ArrayList calificacion = new ArrayList();

        //Constructor para crear una MateriaPorAlumno
        public MateriasPorAlumno(int idasoc, int idalumno, int idmateria, double calificacionn)
        {
            IDAsoc.Add(idasoc);
            IDAlumno.Add(idalumno);
            IDMateria.Add(idmateria);
            calificacion.Add(calificacionn);
        }


    }
}