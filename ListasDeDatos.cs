using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Collections;

namespace EDD
{
    public class ListasDeDatos
    {
        //Creacion de los ArrayLists para almacenar Objetos.
        private ArrayList alumnos = BaseDeDatosLocal.recuperarLista("Alumnos.txt");
        private ArrayList materias = BaseDeDatosLocal.recuperarLista("Materias.txt");
        private ArrayList materiasPorAlumno = BaseDeDatosLocal.recuperarLista("MPA.txt");

        //funciones para agregar datos a las listas.
        public void AgregarAlumnos(Alumno alumno) => alumnos.Add(alumno);
        public void AgregarMaterias(Materias materia) => materias.Add(materia);
        public void AgregarMateriasPorAlumno(MateriasPorAlumno materiaPorAlumno) => materiasPorAlumno.Add(materiaPorAlumno);

        public ArrayList GetListaAlumnos { get => alumnos; }
        public ArrayList GetListaMaterias { get => materias; }
        public ArrayList GetListaMateriasPorAlumno { get => materiasPorAlumno; }

        public static string[,] GetArrAlumnos(ArrayList alumno)
        {
            string[,] arreglo = new string[alumno.Count, 6];

            for (int i = 0; i < alumno.Count; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    arreglo[i, j] = j == 0 ? string.Format("\t{0,-20}", ((Alumno)alumno[i]).AlumnoArr[j]) : string.Format("{0,-20}", ((Alumno)alumno[i]).AlumnoArr[j]);
                }
            }
            return arreglo;
        }
        public static string[,] GetArrMaterias(ArrayList materia)
        {
            string[,] arreglo = new string[materia.Count, 2];

            for (int i = 0; i < materia.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    arreglo[i, j] = j == 0 ? string.Format("\t{0,-20}", ((Materias)materia[i]).MateriaArr[j]) : string.Format("{0,-20}", ((Materias)materia[i]).MateriaArr[j]);
                }
            }
            return arreglo;
        }
        public static string[,] GetArrMPA(ArrayList mPA)
        {
            string[,] arreglo = new string[mPA.Count, 4];

            for (int i = 0; i < mPA.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arreglo[i, j] = j == 0 ? string.Format("\t{0,-20}", ((MateriasPorAlumno)mPA[i]).MPAArray[j]) : string.Format("{0,-20}", ((MateriasPorAlumno)mPA[i]).MPAArray[j]);
                }
            }
            return arreglo;
        }

        //Funcion para Verificar si existe un IDAlumno
        public bool BuscarIDAlumno(string iD)
        {
            alumnos = BaseDeDatosLocal.recuperarLista("Alumnos.txt");
            int count = alumnos.Count;
            bool existe = false;
            for (int i = 0; i < count; i++)
            {
                if (((Alumno)alumnos[i]).IDAlumno == iD)
                {
                    existe = true;
                }
            }
            return existe;
        }
        //Funcion para Verificar si existe un IDMateria
        public bool BuscarIDMateria(string iD)
        {
            materias = BaseDeDatosLocal.recuperarLista("Materias.txt");
            int count = materias.Count;
            bool existe = false;
            for (int i = 0; i < count; i++)
            {
                if (((Materias)materias[i]).IDMateria == iD)
                {
                    existe = true;
                }
            }
            return existe;
        }
        //Funcion para Verificar si existe un IDMateriaPorAlumno
        public bool BuscarIDMateriaPorAlumno(string iD)
        {
            materiasPorAlumno = BaseDeDatosLocal.recuperarLista("MPA.txt");
            int count = materiasPorAlumno.Count;
            bool existe = false;
            for (int i = 0; i < count; i++)
            {
                if (((MateriasPorAlumno)materiasPorAlumno[i]).IDAsoc == iD)
                {
                    existe = true;
                }
            }
            return existe;
        }
        //Funcion para Buscar e imprimir los datos de un alumno mediante su ID.
        public string DatosDeAlumnoPorID(string iD)
        {
            alumnos = BaseDeDatosLocal.recuperarLista("Alumnos.txt");
            int count = alumnos.Count;
            string datos = "";
            for (int i = 0; i < count; i++)
            {
                if (((Alumno)alumnos[i]).IDAlumno == iD)
                {
                    datos = ((Alumno)alumnos[i]).DatosAlumno();
                }
            }
            return datos;
        }
        //Funcion para Buscar e imprimir los datos de una Materia mediante su ID.
        public string DatosDeMateriaPorID(string iD)
        {
            materias = BaseDeDatosLocal.recuperarLista("Materias.txt");
            int count = materias.Count;
            string datos = "";
            for (int i = 0; i < count; i++)
            {
                if (((Materias)materias[i]).IDMateria == iD)
                {
                    datos = ((Materias)materias[i]).DatosMaterias();
                }
            }
            return datos;
        }
        //Funcion para Buscar e imprimir los datos de una MateriasPorAlumno mediante su ID.
        public string DatosMateriasPorAlumno(string iD)
        {
            materiasPorAlumno = BaseDeDatosLocal.recuperarLista("MPA.txt");
            int count = materiasPorAlumno.Count;
            string datos = "";
            for (int i = 0; i < count; i++)
            {
                if (((MateriasPorAlumno)materiasPorAlumno[i]).IDAsoc == iD)
                {
                    datos = ((MateriasPorAlumno)materiasPorAlumno[i]).DatosMateriasPorAlumno();
                }
            }
            return datos;
        }
        //funcion para imprimir todos los alumnos.
        public void ImprimirAlumnos()
        {
            alumnos = BaseDeDatosLocal.recuperarLista("Alumnos.txt");
            int count = alumnos.Count;
            for (int i = 0; i < count; i++)
            {
                System.Console.WriteLine(((Alumno)alumnos[i]).DatosAlumno());
            }
        }

        public void ImprimirAlumnos(int cantidad)
        {
            alumnos = BaseDeDatosLocal.recuperarLista("Alumnos.txt");
            int count = cantidad;
            for (int i = 0; i < count; i++)
            {
                if(count > alumnos.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("\tNo hay tantas lineas");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                System.Console.WriteLine(((Alumno)alumnos[i]).DatosAlumno());
            }
        }
        //funcion para imprimir todas las materias.
        public void ImprimirMaterias()
        {
            materias = BaseDeDatosLocal.recuperarLista("Materias.txt");
            int count = materias.Count;
            for (int i = 0; i < count; i++)
            {
                System.Console.WriteLine(((Materias)materias[i]).DatosMaterias());
            }
        }

        public void ImprimirMaterias(int cantidad)
        {
            materias = BaseDeDatosLocal.recuperarLista("Materias.txt");
            int count = cantidad;
            for (int i = 0; i < count; i++)
            {
                if(count > materias.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("\tNo hay tantas lineas");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                System.Console.WriteLine(((Materias)materias[i]).DatosMaterias());
            }
        }
        //funcion para imprimir todas las materias por alumno.
        public void ImprimirMateriasPorAlumno()
        {
            materiasPorAlumno = BaseDeDatosLocal.recuperarLista("MPA.txt");
            int count = materiasPorAlumno.Count;
            for (int i = 0; i < count; i++)
            {
                System.Console.WriteLine(((MateriasPorAlumno)materiasPorAlumno[i]).DatosMateriasPorAlumno());
            }
        }
        public void ImprimirMateriasPorAlumno(int cantidad)
        {
            materiasPorAlumno = BaseDeDatosLocal.recuperarLista("MPA.txt");
            int count = cantidad;
            for (int i = 0; i < count; i++)
            {
                if(count > materiasPorAlumno.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("\tNo hay tantas lineas");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                System.Console.WriteLine(((MateriasPorAlumno)materiasPorAlumno[i]).DatosMateriasPorAlumno());
            }
        }
        //Funcion que imprime todos los alumnos que tienen el mismo nombre.
        public void ImprimirAlumnosPorNombre(string nombre)
        {
            alumnos = BaseDeDatosLocal.recuperarLista("Alumnos.txt");
            int count = alumnos.Count;
            for (int i = 0; i < count; i++)
            {
                if (((Alumno)alumnos[i]).NombreAlumno == nombre)
                {
                    System.Console.WriteLine(((Alumno)alumnos[i]).DatosAlumno());
                }
            }
        }
        //Funcion que imprime todas las materias que tienen el mismo nombre.
        public void ImprimirMateriasPorNombre(string nombre)
        {
            materias = BaseDeDatosLocal.recuperarLista("Materias.txt");
            int count = materias.Count;
            for (int i = 0; i < count; i++)
            {
                if (((Materias)materias[i]).NombreMateria == nombre)
                {
                    System.Console.WriteLine(((Materias)materias[i]).DatosMaterias());
                }
            }
        }
        //Funcion que imprime todas las materias por alumno de un Alumno mediante su ID.
        public void ImprimirMateriasPorAlumnoPorIDAlumno(string iD)
        {
            materiasPorAlumno = BaseDeDatosLocal.recuperarLista("MPA.txt");
            int count = materiasPorAlumno.Count;
            for (int i = 0; i < count; i++)
            {
                if (((MateriasPorAlumno)materiasPorAlumno[i]).IDAlumno == iD)
                {
                    System.Console.WriteLine(((MateriasPorAlumno)materiasPorAlumno[i]).DatosMateriasPorAlumno());
                }
            }
        }
        //Funcion para calcular y devolver el promedio de un alumno, buscandolo mediante su IDAlumno
        public double Promedio(string iD)
        {
            materiasPorAlumno = BaseDeDatosLocal.recuperarLista("MPA.txt");
            int count = materiasPorAlumno.Count;
            double promedio = 0;
            int contador = 0;

            for (int i = 0; i < count; i++)
            {
                if (((MateriasPorAlumno)materiasPorAlumno[i]).IDAlumno == iD)
                {
                    promedio += ((MateriasPorAlumno)materiasPorAlumno[i]).Calificacion;
                    contador++;
                }
            }
            promedio /= contador;
            return promedio;
        }

        //Función para obtener posición de un Alumno según su ID
        public int PosAlumno(string iD)
        {
            alumnos = BaseDeDatosLocal.recuperarLista("Alumnos.txt");
            int count = alumnos.Count;
            //bool existe= false;
            int posicion = 0;

            for (int i = 0; i < count; i++)
            {
                if (((Alumno)alumnos[i]).IDAlumno == iD)
                {
                    posicion = i;
                }
            }
            return posicion;
        }

        //Función para obtener posición de una Materia según su ID
        public int PosMateria(string iD)
        {
            materias = BaseDeDatosLocal.recuperarLista("Materias.txt");
            int count = materias.Count;
            //bool existe= false;
            int posicion = 0;

            for (int i = 0; i < count; i++)
            {
                if (((Materias)materias[i]).IDMateria == iD)
                {
                    posicion = i;
                }
            }
            return posicion;
        }

        //Función para obtener posición de una MateriaPorAlumno según su ID
        public int PosMateriaPorAlumno(string iD)
        {
            materiasPorAlumno = BaseDeDatosLocal.recuperarLista("MPA.txt");
            int count = materiasPorAlumno.Count;
            //bool existe= false;
            int posicion = 0;

            for (int i = 0; i < count; i++)
            {
                if (((MateriasPorAlumno)materiasPorAlumno[i]).IDAsoc == iD)
                {
                    posicion = i;
                }
            }
            return posicion;
        }


        string txtMPA = "MPA.txt";

        //Funciones para eliminar datos de las listas
        public void EliminarAlumnos(int iDalumnoE, string STRINGiDalumnoE)
        {
            string idAsocMatPorAlumno;
            string idAlumnoMatPorAlumno;
            string idMateriaMatPorAlumno;
            double calificacionMatPorAlumno;

            alumnos.RemoveAt(iDalumnoE);

            //Eliminación cruzada

            materiasPorAlumno = BaseDeDatosLocal.recuperarLista("MPA.txt");

            int count = materiasPorAlumno.Count;
            for (int i = 0; i < count; i++)
            {

                if (((MateriasPorAlumno)materiasPorAlumno[i]).IDAlumno != STRINGiDalumnoE)
                {
                    idAsocMatPorAlumno = ((MateriasPorAlumno)materiasPorAlumno[i]).IDAsoc;
                    idAlumnoMatPorAlumno = ((MateriasPorAlumno)materiasPorAlumno[i]).IDAlumno;
                    idMateriaMatPorAlumno = ((MateriasPorAlumno)materiasPorAlumno[i]).IDMateria;
                    calificacionMatPorAlumno = ((MateriasPorAlumno)materiasPorAlumno[i]).Calificacion;

                    AgregarMateriasPorAlumno(new MateriasPorAlumno(idAsocMatPorAlumno, idAlumnoMatPorAlumno, idMateriaMatPorAlumno, calificacionMatPorAlumno));
                    BaseDeDatosLocal.guardarLista(GetListaMateriasPorAlumno, txtMPA);
                }
            }

            materiasPorAlumno.RemoveRange(0, count);
            BaseDeDatosLocal.guardarLista(GetListaMateriasPorAlumno, txtMPA);
        }
        public void EliminarMaterias(int iDmateriaE, string STRINGiDmateriaE)
        {
            string idAsocMatPorAlumno;
            string idAlumnoMatPorAlumno;
            string idMateriaMatPorAlumno;
            double calificacionMatPorAlumno;

            materias.RemoveAt(iDmateriaE);

            //Eliminación cruzada

            materiasPorAlumno = BaseDeDatosLocal.recuperarLista("MPA.txt");

            int count = materiasPorAlumno.Count;
            for (int i = 0; i < count; i++)
            {

                if (((MateriasPorAlumno)materiasPorAlumno[i]).IDMateria != STRINGiDmateriaE)
                {
                    idAsocMatPorAlumno = ((MateriasPorAlumno)materiasPorAlumno[i]).IDAsoc;
                    idAlumnoMatPorAlumno = ((MateriasPorAlumno)materiasPorAlumno[i]).IDAlumno;
                    idMateriaMatPorAlumno = ((MateriasPorAlumno)materiasPorAlumno[i]).IDMateria;
                    calificacionMatPorAlumno = ((MateriasPorAlumno)materiasPorAlumno[i]).Calificacion;

                    AgregarMateriasPorAlumno(new MateriasPorAlumno(idAsocMatPorAlumno, idAlumnoMatPorAlumno, idMateriaMatPorAlumno, calificacionMatPorAlumno));
                    BaseDeDatosLocal.guardarLista(GetListaMateriasPorAlumno, txtMPA);
                }
            }

            materiasPorAlumno.RemoveRange(0, count);
            BaseDeDatosLocal.guardarLista(GetListaMateriasPorAlumno, txtMPA);
        }
        public void EliminarMateriasPorAlumno(int MPAE) => materiasPorAlumno.RemoveAt(MPAE);


        //Ordenamiento Ascendente - Descendente
        public static void Ordenamiento(string[,] list, int index, bool ascendente)
        {
            int counter = 0;
            string[,] ArrOrdenado = new string[list.GetLength(0), list.GetLength(1)];
            string[] tempList = new string[list.GetLength(0)];

            for (int j = 0; j < list.GetLength(0); j++)
            {
                tempList[j] = list[j, index];
            }
            Array.Sort(tempList);
            if (ascendente == false) Array.Reverse(tempList);

            for (int i = 1; i < list.GetLength(0)+1; i++)
            {
                for (int j = 0; j < list.GetLength(0); j++)
                {
                    if (tempList[counter] == list[j, index] && ArrOrdenado[list.GetLength(0) - 1, list.GetLength(1) - 1] == null)
                    {
                        for (int l = 0; l < list.GetLength(1); l++)
                        {
                            ArrOrdenado[counter, l] = list[j, l];
                        }
                        counter = counter < list.GetLength(0) - 1 ? ++counter : counter;
                    }
                }
            }
            for (int i = 0; i < ArrOrdenado.GetLength(0); i++)
            {
                for (int k = 0; k < ArrOrdenado.GetLength(1); k++)
                {
                    Console.Write(ArrOrdenado[i, k]);
                }
                Console.WriteLine();
            }
        }
    }
}
