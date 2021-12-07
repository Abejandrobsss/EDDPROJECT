using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Collections;

namespace EDD
{
    public class Interfaz
    {
        string txtAlumnos = "Alumnos.txt";
        string txtMaterias = "Materias.txt";
        string txtMPA = "MPA.txt";

        public static ListasDeDatos Listas = new ListasDeDatos();
        public void menuPrincipal()
        {
            int opcion;

            //Menu interactivo
            opcion = MenuInteractivo.MenuInteractivoFlechas("MENÚ PRINCIPAL", "» Ingresar datos", "» Búsqueda", "» Eliminación", "» Ordenamiento", "» Salir");
            Console.Clear();
            switch (opcion)
            {
                case 1:
                    menuInsertar();
                    break;

                case 2:
                    menuBusqueda();
                    break;

                case 3:
                    menuEliminar();
                    break;

                case 4:
                    menuOrdenamiento();
                    break;

                case 5:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
        }
        public void menuInsertar()
        {
            int opcion;

            //Parametros para la clase Alumno
            string idAlumno;
            string nombreAlumno;
            string apellidoPaternoAlumno;
            string apellidoMaternoAlumno;
            string fechaNacimientoAlumno;
            string semestre;

            //Parámetros para la clase Materias
            string idMaterias;
            string nombreMaterias;

            //Parámetros para la clase MateriasPorAlumno
            string idAsocMatPorAlumno;
            string idAlumnoMatPorAlumno;
            string idMateriaMatPorAlumno;
            double calificacionMatPorAlumno;

            //Menu interactivo
            opcion = MenuInteractivo.MenuInteractivoFlechas("INGRESAR", "» Alumnos", "» Materias", "» Materias por alumno", "» Volver");

            switch (opcion)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("\n\t═════ INGRESAR > ALUMNOS ════════════════════════════════════════════════════════════════");
                        Console.Write("\n\tID: ");
                        idAlumno = Console.ReadLine();
                        Console.Write("\tNombre: ");
                        nombreAlumno = Console.ReadLine();
                        Console.Write("\tApellido paterno: ");
                        apellidoPaternoAlumno = Console.ReadLine();
                        Console.Write("\tApellido materno: ");
                        apellidoMaternoAlumno = Console.ReadLine();
                        Console.Write("\tFecha de nacimiento: ");
                        fechaNacimientoAlumno = Console.ReadLine();
                        Console.Write("\tSemestre: ");
                        semestre = Console.ReadLine();

                        //Condicional que solo crea otro alumno si el iD proporcionado no existe ya en el sistema.
                        if (Listas.BuscarIDAlumno(idAlumno) != true)
                        {
                            Listas.AgregarAlumnos(new Alumno(idAlumno, nombreAlumno, apellidoPaternoAlumno, apellidoMaternoAlumno, fechaNacimientoAlumno, semestre));
                            Console.ForegroundColor = ConsoleColor.Green;
                            System.Console.WriteLine("\n\tAlumno creado satisfactoriamente.");
                            Console.ForegroundColor = ConsoleColor.White;
                            BaseDeDatosLocal.guardarLista(Listas.GetListaAlumnos, txtAlumnos);

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("\n\tID de alumno ya existente.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    catch (System.Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("\n\tOcurrio un error, intentelo de nuevo.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write("\tPresione cualquier tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    menuInsertar();
                    break;

                case 2:
                    Console.WriteLine("\n\t═════ INSERTAR > MATERIAS ════════════════════════════════════════════════════════════════");
                    Console.Write("\n\tID: ");
                    idMaterias = Console.ReadLine();
                    Console.Write("\tNombre: ");
                    nombreMaterias = Console.ReadLine();

                    if (Listas.BuscarIDMateria(idMaterias) != true)
                    {
                        Listas.AgregarMaterias(new Materias(idMaterias, nombreMaterias));
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("\n\tMateria creada satisfactoriamente.");
                        Console.ForegroundColor = ConsoleColor.White;
                        BaseDeDatosLocal.guardarLista(Listas.GetListaMaterias, txtMaterias);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("\n\tID de Materia ya existente.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write("\tPresione cualquier tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    menuInsertar();
                    break;

                case 3:
                    Console.WriteLine("\n\t═════ INSERTAR > MATERIAS POR ALUMNO ════════════════════════════════════════════════════════");
                    Console.Write("\n\tID asociado: ");
                    idAsocMatPorAlumno = Console.ReadLine();
                    Console.Write("\tID alumno: ");
                    idAlumnoMatPorAlumno = Console.ReadLine();
                    Console.Write("\tID materia: ");
                    idMateriaMatPorAlumno = Console.ReadLine();
                    Console.Write("\tCalificación: ");
                    calificacionMatPorAlumno = Convert.ToDouble(Console.ReadLine());

                    if (Listas.BuscarIDAlumno(idAlumnoMatPorAlumno) == true && Listas.BuscarIDMateria(idMateriaMatPorAlumno) == true)
                    {
                        Listas.AgregarMateriasPorAlumno(new MateriasPorAlumno(idAsocMatPorAlumno, idAlumnoMatPorAlumno, idMateriaMatPorAlumno, calificacionMatPorAlumno));
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("\n\tMateria por alumno agregada.");
                        Console.ForegroundColor = ConsoleColor.White;
                        BaseDeDatosLocal.guardarLista(Listas.GetListaMateriasPorAlumno, txtMPA);

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("\n\tID de alumno o de materia inexistentes.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write("\tPresione cualquier tecla para continuar.");
                    Console.ReadKey();
                    Console.Clear();
                    menuInsertar();
                    break;

                case 4:
                    Console.Clear();
                    menuPrincipal();
                    break;
            }
        }
        public void menuBusqueda()
        {

            int opcion;
            //Parameros para la clase Alumno
            string iDAlumno;
            string alumno;
            //Parameros para la clase Materias
            string iDMateria;
            string materia;
            //Parametros para la clase MateriasPorAlumno
            string iDAsoc;

            //Menu interactivo
            opcion = MenuInteractivo.MenuInteractivoFlechas("BUSCAR", "» Alumno", "» Materia", "» Materias por alumno", "» Volver");

            switch (opcion)
            {
                case 1: // Alumno

                    //Menu interactivo
                    opcion = MenuInteractivo.MenuInteractivoFlechas("BUSCAR > ALUMNO", "» Por ID", "» Por Nombre", "» Todos los alumnos", "» Volver");
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("\n\t═════ BUSCAR > ALUMNO > POR ID ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tID: ");
                            iDAlumno = Console.ReadLine();
                            System.Console.WriteLine("\t{0,-20}{1,-20}{2,-20}{3,-20}{4,20}{5,20}", "ID", "Nombre", "Apellido Paterno", "Apellido Materno", "Dia de nacimiento", "Semestre");
                            if (Listas.BuscarIDAlumno(iDAlumno) == true)
                            {

                                System.Console.WriteLine("{0}", Listas.DatosDeAlumnoPorID(iDAlumno));
                            }

                            Console.Write("\n\tPresione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;

                        case 2:
                            Console.WriteLine("\n\t═════ BUSCAR > ALUMNO > POR NOMBRE ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tNombre: ");
                            alumno = Console.ReadLine();
                            System.Console.WriteLine("\t{0,-20}{1,-20}{2,-20}{3,-20}{4,20}{5,20}", "ID", "Nombre", "Apellido Paterno", "Apellido Materno", "Dia de nacimiento", "Semestre");
                            Listas.ImprimirAlumnosPorNombre(alumno);

                            Console.Write("\n\tPresione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;

                        case 3:
                            Console.WriteLine("\n\t═════ BUSCAR > ALUMNO > TODOS ════════════════════════════════════════════════════════════════\n");
                            System.Console.WriteLine("\t{0,-20}{1,-20}{2,-20}{3,-20}{4,20}{5,20}", "ID", "Nombre", "Apellido Paterno", "Apellido Materno", "Dia de nacimiento", "Semestre");

                            Listas.ImprimirAlumnos();

                            Console.Write("\n\tPresione cualquier tecla para continuar.");
                            Console.ReadKey();

                            Console.Clear();
                            menuBusqueda();
                            break;

                        case 4:
                            Console.Clear();
                            menuBusqueda();
                            break;
                    }
                    break;

                case 2:// MATERIA

                    //Menu interactivo
                    opcion = MenuInteractivo.MenuInteractivoFlechas("BUSCAR > MATERIA", "» Por ID", "» Por Nombre", "» Todas las materias", "» Volver");
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA > POR ID ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tID: ");
                            iDMateria = Console.ReadLine();
                            System.Console.WriteLine("\t{0,-20}{1,-20}", "ID", "Materia");
                            if (Listas.BuscarIDMateria(iDMateria) == true)
                            {
                                System.Console.WriteLine("\n{0}", Listas.DatosDeMateriaPorID(iDMateria));
                            }

                            Console.Write("\n\tPresione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;

                        case 2:
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA > POR NOMBRE ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tNombre: ");
                            materia = Console.ReadLine();
                            System.Console.WriteLine("\t{0,-20}{1,-20}", "ID", "Materia");
                            Listas.ImprimirMateriasPorNombre(materia);

                            Console.Write("\n\tPresione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;

                        case 3:
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA > TODOS ════════════════════════════════════════════════════════════════\n");
                            System.Console.WriteLine("\t{0,-20}{1,-20}", "ID", "Materia");
                            Listas.ImprimirMaterias();
                            Console.Write("\n\tPresione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;

                        case 4:
                            Console.Clear();
                            menuBusqueda();
                            break;
                    }
                    break;

                case 3: // MATERIA POR ALUMNO

                    //Menu interactivo
                    opcion = MenuInteractivo.MenuInteractivoFlechas("BUSCAR > MATERIA POR ALUMNO", "» Por ID asociado", "» Por ID del alumno", "» Todas las materias por alumno", "» Promedio por ID alumno", "» Volver");
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA POR ALUMNO > POR ID ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tID: ");
                            iDAsoc = Console.ReadLine();
                            System.Console.WriteLine("\t{0,-20}{1,-20}{2,-20}{3,-20}", "ID Asociado", "ID del Alumno", "ID de la materia", "Calificacion");
                            if (Listas.BuscarIDMateriaPorAlumno(iDAsoc) == true)
                            {
                                System.Console.WriteLine("{0}", Listas.DatosMateriasPorAlumno(iDAsoc));
                            }

                            Console.Write("\n\tPresione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;

                        case 2:
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA POR ALUMNO > POR ID DEL ALUMNO ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tID del alumno: ");
                            iDAlumno = Console.ReadLine();
                            System.Console.WriteLine("\t{0,-20}{1,-20}{2,-20}{3,-20}", "ID Asociado", "ID del Alumno", "ID de la materia", "Calificacion");
                            Listas.ImprimirMateriasPorAlumnoPorIDAlumno(iDAlumno);
                            Console.Write("\n\tPresione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;

                        case 3:
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA > TODOS ════════════════════════════════════════════════════════════════\n");
                            System.Console.WriteLine("\t{0,-20}{1,-20}{2,-20}{3,-20}", "ID Asociado", "ID del Alumno", "ID de la materia", "Calificacion");
                            Listas.ImprimirMateriasPorAlumno();
                            Console.Write("\n\tPresione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;

                        case 4:
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA POR ALUMNO > PROMEDIO POR ID DEL ALUMNO ════════════════════════════════════════════════\n");
                            Console.Write("\tID del alumno: ");
                            iDAlumno = Console.ReadLine();

                            System.Console.WriteLine("\tPromedio: {0}", Listas.Promedio(iDAlumno));

                            Console.Write("\n\tPresione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;

                        case 5:
                            Console.Clear();
                            menuBusqueda();
                            break;
                    }
                    break;

                case 4:
                    menuPrincipal();
                    break;
            }
        }

        public void menuEliminar()
        {

            int opcion;
            int opcionH;
            //Parametros para la clase Alumno
            string idAlumno;
            //Parametros para la clase Materias
            string idMateria;
            //Parametros para la clase MateriasPorAlumno
            string idAsoc;

            //Menu interactivo
            opcion = MenuInteractivo.MenuInteractivoFlechas("ELIMINAR", "» Alumno", "» Materia", "» Materias por alumno", "» Volver");


            switch (opcion)
            {
                case 1: // Alumno

                    //Menu interactivo
                    opcion = MenuInteractivo.MenuInteractivoFlechas("ELIMINAR > ALUMNO", "» Por ID", "» Volver");
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("\n\t═════ ELIMINAR > ALUMNO > POR ID ════════════════════════════════════════════════════════════════\n");

                            System.Console.WriteLine("\n\t{0,-20}{1,-20}{2,-20}{3,-20}{4,20}{5,20}", "ID", "Nombre", "Apellido Paterno", "Apellido Materno", "Dia de nacimiento", "Semestre");
                            Listas.ImprimirAlumnos();

                            Console.Write("\n\t» ID: ");
                            idAlumno = Console.ReadLine();

                            System.Console.WriteLine("\n\t{0,-20}{1,-20}{2,-20}{3,-20}{4,20}{5,20}", "ID", "Nombre", "Apellido Paterno", "Apellido Materno", "Dia de nacimiento", "Semestre");
                            if (Listas.BuscarIDAlumno(idAlumno) == true)
                            {
                                System.Console.WriteLine("{0}", Listas.DatosDeAlumnoPorID(idAlumno));
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                System.Console.WriteLine("\n\tAlumno inexistente.");
                                Console.ReadKey();
                                Console.Clear();
                                menuEliminar();
                            }

                            //Menu interactivo
                            opcionH = MenuInteractivoHorizontal.MenuInteractivoFlechasH("» Confirmar acción", "» Volver");

                            switch (opcionH)
                            {
                                case 1:
                                    Listas.EliminarAlumnos(Listas.PosAlumno(idAlumno), idAlumno);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    System.Console.WriteLine("\n\tAlumno eliminado.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    BaseDeDatosLocal.guardarLista(Listas.GetListaAlumnos, txtAlumnos);
                                    BaseDeDatosLocal.guardarLista(Listas.GetListaMateriasPorAlumno, txtMPA);

                                    Console.Write("\tPresione cualquier tecla para continuar.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    menuEliminar();

                                    break;

                                case 2:
                                    menuEliminar();
                                    break;
                            }

                            break;


                        case 2:
                            Console.Clear();
                            menuEliminar();
                            break;
                    }
                    break;

                case 2: // Materia

                    //Menu interactivo
                    opcion = MenuInteractivo.MenuInteractivoFlechas("ELIMINAR > MATERIA", "» Por ID", "» Volver");
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("\n\t═════ ELIMINAR > MATERIA > POR ID ════════════════════════════════════════════════════════════════\n");

                            System.Console.WriteLine("\t{0,-20}{1,-20}", "ID", "Materia");
                            Listas.ImprimirMaterias();

                            Console.Write("\n\t» ID: ");
                            idMateria = Console.ReadLine();
                            Console.WriteLine();

                            System.Console.WriteLine("\t{0,-20}{1,-20}", "ID", "Materia");
                            if (Listas.BuscarIDMateria(idMateria) == true)
                            {

                                System.Console.WriteLine("{0}", Listas.DatosDeMateriaPorID(idMateria));
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                System.Console.WriteLine("\n\tMateria inexistente.");
                                Console.ReadKey();
                                Console.Clear();
                                menuEliminar();
                            }

                            //Menu interactivo
                            opcionH = MenuInteractivoHorizontal.MenuInteractivoFlechasH("» Confirmar acción", "» Volver");

                            switch (opcionH)
                            {
                                case 1:
                                    Listas.EliminarMaterias(Listas.PosMateria(idMateria), idMateria);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    System.Console.WriteLine("\n\tMateria eliminada.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    BaseDeDatosLocal.guardarLista(Listas.GetListaMaterias, txtMaterias);
                                    BaseDeDatosLocal.guardarLista(Listas.GetListaMateriasPorAlumno, txtMPA);

                                    Console.Write("\tPresione cualquier tecla para continuar.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    menuEliminar();

                                    break;

                                case 2:
                                    menuEliminar();
                                    break;
                            }

                            break;


                        case 2:
                            Console.Clear();
                            menuEliminar();
                            break;
                    }
                    break;

                case 3: // Materia por alumno

                    //Menu interactivo
                    opcion = MenuInteractivo.MenuInteractivoFlechas("ELIMINAR > MATERIA POR ALUMNO", "» Por ID", "» Volver");
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("\n\t═════ ELIMINAR > MATERIAS POR ALUMNO > POR ID ════════════════════════════════════════════════════════════════\n");

                            Listas.ImprimirMateriasPorAlumno();

                            Console.Write("\n\t» ID Asociado: ");
                            idAsoc = Console.ReadLine();

                            System.Console.WriteLine("\n\t{0,-20}{1,-20}{2,-20}{3,-20}", "ID Asociado", "ID del Alumno", "ID de la materia", "Calificación");
                            if (Listas.BuscarIDMateriaPorAlumno(idAsoc) == true)
                            {
                                System.Console.WriteLine("{0}", Listas.DatosMateriasPorAlumno(idAsoc));
                            }

                            //Menu interactivo
                            opcionH = MenuInteractivoHorizontal.MenuInteractivoFlechasH("» Confirmar acción", "» Volver");

                            switch (opcionH)
                            {
                                case 1:
                                    Listas.EliminarMateriasPorAlumno(Listas.PosMateriaPorAlumno(idAsoc));
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    System.Console.WriteLine("\n\tMateria Por Alumno eliminada.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    BaseDeDatosLocal.guardarLista(Listas.GetListaMateriasPorAlumno, txtMPA);

                                    Console.Write("\tPresione cualquier tecla para continuar.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    menuEliminar();

                                    break;

                                case 2:
                                    menuEliminar();
                                    break;
                            }

                            break;


                        case 2:
                            Console.Clear();
                            menuEliminar();
                            break;
                    }
                    break;

                case 4:
                    menuPrincipal();
                    break;
            }
        }

        public void menuOrdenamiento()
        {
            int opcion;

            //Menu interactivo
            opcion = MenuInteractivo.MenuInteractivoFlechas("ORDENAR", "» Alumno", "» Materia", "» Materias por alumno", "» Volver");

            switch (opcion)
            {
                case 1: //Ordenar alumnos
                    MenuInteractivoOrdenamiento.MenuInteractivoOrd("ID", "NOMBRE", "APELLIDO PATERNO", "APELLIDO MATERNO", "DIA DE NACIMIENTO", "SEMESTRE");
                    menuOrdenamiento();
                    break;

                case 2: //Ordenar materias
                    MenuInteractivoOrdenamiento.MenuInteractivoOrd("ID", "MATERIA");
                    menuOrdenamiento();
                    break;

                case 3: //Ordenar materias por alumno
                    MenuInteractivoOrdenamiento.MenuInteractivoOrd("ID Asociado", "ID Alumno", "ID MATERIA", "CALIFICACION");
                    menuOrdenamiento();
                    break;

                case 4: //Volver
                    Console.Clear();
                    menuPrincipal();
                    break;

            }
        }
    }
}