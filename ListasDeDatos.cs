using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Collections;

namespace EDD
{
    class ListasDeDatos
    {
        //Creacion de los ArrayLists para almacenar Objetos.
        private ArrayList alumnos = new ArrayList();
        private ArrayList materias= new ArrayList();
        private ArrayList materiasPorAlumno = new ArrayList();

        //funciones para agregar datos a las listas.
        public void AgregarAlumnos(Alumno alumno) => alumnos.Add(alumno);
        public void AgregarMaterias(Materias materia) => materias.Add(materia);
        public void AgregarMateriasPorAlumno(MateriasPorAlumno materiaPorAlumno) => materiasPorAlumno.Add(materiaPorAlumno);

        //Funcion para Verificar si existe un IDAlumno
        public bool BuscarIDAlumno(string iD)
        {
            int count=alumnos.Count;
            bool existe= false;
            for (int i = 0; i < count; i++)
            {
                if(((Alumno)alumnos[i]).IDAlumno == iD)
                {
                    existe = true;
                }
            }
            return existe;
        }
        //Funcion para Verificar si existe un IDMateria
        public bool BuscarIDMateria(string iD)
        {
            int count=materias.Count;
            bool existe= false;
            for (int i = 0; i < count; i++)
            {
                if(((Materias)materias[i]).IDMateria == iD)
                {
                    existe = true;
                }
            }
            return existe;
        }
        //Funcion para Verificar si existe un IDMateriaPorAlumno
        public bool BuscarIDMateriaPorAlumno(string iD)
        {
            int count=materiasPorAlumno.Count;
            bool existe= false;
            for (int i = 0; i < count; i++)
            {
                if(((MateriasPorAlumno)materias[i]).IDAsoc == iD)
                {
                    existe = true;
                }
            }
            return existe;
        }

        
        //Funcion para Buscar e imprimir los datos de un alumno mediante su ID.
        public string DatosDeAlumnoPorID(string iD)
        {
            int count=alumnos.Count;
            string datos = "";
            for (int i = 0; i < count; i++)
            {
                if(((Alumno)alumnos[i]).IDAlumno == iD)
                {
                    datos = ((Alumno)alumnos[i]).DatosAlumno();
                }
            }
            return datos;
        }
        //Funcion para Buscar e imprimir los datos de una Materia mediante su ID.
        public string DatosDeMateriaPorID(string iD)
        {
            int count=materias.Count;
            string datos = "";
            for (int i = 0; i < count; i++)
            {
                if(((Materias)materias[i]).IDMateria == iD)
                {
                    datos = ((Materias)materias[i]).DatosMaterias();
                }
            }
            return datos;
        }
        //Funcion para Buscar e imprimir los datos de una MateriasPorAlumno mediante su ID.
        public string DatosMateriasPorAlumno(string iD)
        {
            int count=materiasPorAlumno.Count;
            string datos = "";
            for (int i = 0; i < count; i++)
            {
                if(((MateriasPorAlumno)materiasPorAlumno[i]).IDAsoc == iD)
                {
                    datos = ((MateriasPorAlumno)materiasPorAlumno[i]).DatosMateriasPorAlumno();
                }
            }
            return datos;
        }
        //funcion para imprimir todos los alumnos.
        public void ImprimirAlumnos()
        {
            int count=alumnos.Count;
            for (int i = 0; i < count; i++)
            {
                System.Console.WriteLine(((Alumno)alumnos[i]).DatosAlumno());
            }
        }
        //funcion para imprimir todas las materias.
        public void ImprimirMaterias()
        {
            int count=materias.Count;
            for (int i = 0; i < count; i++)
            {
                System.Console.WriteLine(((Materias)materias[i]).DatosMaterias());
            }
        }
        //funcion para imprimir todas las materias por alumno.
        public void ImprimirMateriasPorAlumno()
        {
            int count=materiasPorAlumno.Count;
            for (int i = 0; i < count; i++)
            {
                System.Console.WriteLine(((MateriasPorAlumno)materiasPorAlumno[i]).DatosMateriasPorAlumno());
            }
        }
        //Funcion que imprime todos los alumnos que tienen el mismo nombre.
        public void ImprimirAlumnosPorNombre(string nombre)
        {
            ArrayList alumnosTemp = this.alumnos;
            int count=alumnosTemp.Count;
            
            for (int i = 0; i < count; i++)
            {
                if(((Alumno)alumnosTemp[i]).NombreAlumno == nombre)
                {
                    System.Console.WriteLine(((Alumno)alumnosTemp[i]).DatosAlumno());
                    alumnosTemp[i]="";
                }
            }
        }
        //Funcion que imprime todas las materias que tienen el mismo nombre.
        public void ImprimirMateriasPorNombre(string nombre)
        {
            ArrayList materiasTemp = this.materias;
            int count=materiasTemp.Count;
            
            for (int i = 0; i < count; i++)
            {
                if(((Materias)materiasTemp[i]).NombreMateria == nombre)
                {
                    System.Console.WriteLine(((Materias)materiasTemp[i]).DatosMaterias());
                    materiasTemp[i]="";
                }
            }
        }
        //Funcion que imprime todas las materias por alumno de un Alumno mediante su ID.
        public void ImprimirMateriasPorAlumnoPorIDAlumno(string iD)
        {
            ArrayList materiasPorAlumnoTemp = this.materiasPorAlumno;
            int count=materiasPorAlumnoTemp.Count;
            
            for (int i = 0; i < count; i++)
            {
                if(((MateriasPorAlumno)materiasPorAlumnoTemp[i]).IDAlumno == iD)
                {
                    System.Console.WriteLine(((MateriasPorAlumno)materiasPorAlumnoTemp[i]).DatosMateriasPorAlumno());
                    materiasPorAlumnoTemp[i]="";
                }
            }
        }
        public double Promedio(string iD)
        {
            ArrayList materiasPorAlumnoTemp = this.materiasPorAlumno;
            int count=materiasPorAlumnoTemp.Count;
            double promedio=0;
            int contador=0;
            
            for (int i = 0; i < count; i++)
            {
                if(((MateriasPorAlumno)materiasPorAlumnoTemp[i]).IDAlumno == iD)
                {
                    promedio += ((MateriasPorAlumno)materiasPorAlumno[i]).Calificacion;
                    contador++;
                }
            }
            promedio /= contador;
            return promedio;
        }
    }

    
}
