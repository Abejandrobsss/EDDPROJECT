using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Collections;

namespace EDD
{
    public class Interfaz
    {
        ListasDeDatos Listas = new ListasDeDatos();
        public void menuPrincipal()
        {
            int opcion;

            //Menu interactivo
            opcion = MenuInteractivo.MenuInteractivoFlechas("MENU PRINCIPAL", "» Ingresar datos","» Busqueda","» Eliminacion (No implementado)","» Ordenamiento (No implementado)", "» Almacenamiento (No implementado)", "» Salir");

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    menuInsertar();
                    
                    break;

                case 2:
                    Console.Clear();
                    menuBusqueda();
                    
                    break;

                case 3:
                    
                    break;

                case 4:
                
                    break;
                
                case 5:
                    
                    break;
                
                case 6:
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

            //Parámetros para la clase Materias
            string idMaterias;
            string nombreMaterias;

            //Parámetros para la clase MateriasPorAlumno
            string idAsocMatPorAlumno;
            string idAlumnoMatPorAlumno;
            string idMateriaMatPorAlumno;
            double calificacionMatPorAlumno;

            //Menu interactivo
            opcion = MenuInteractivo.MenuInteractivoFlechas("INGRESAR", "» Alumnos","» Materias","» Materias por alumno","» Volver");
            
            switch (opcion)
            {
                case 1:
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

                    //Condicional que solo crea otro alumno si el iD proporcionado no existe ya en el sistema.
                    if(Listas.BuscarIDAlumno(idAlumno) != true)
                    {
                        Listas.AgregarAlumnos(new Alumno(idAlumno, nombreAlumno, apellidoPaternoAlumno, apellidoMaternoAlumno, fechaNacimientoAlumno));
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("\tAlumno creado satisfactoriamente.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("\tID de alumno ya existente.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write("\n\tPrecione cualquier tecla para continuar.");
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

                    if(Listas.BuscarIDMateria(idMaterias) != true)
                    {
                        Listas.AgregarMaterias(new Materias(idMaterias, nombreMaterias));
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("\tMateria creada satisfactoriamente.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("\tID de Materia ya existente.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                    Console.Write("\n\tPrecione cualquier tecla para continuar.");
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

                    if(Listas.BuscarIDAlumno(idAlumnoMatPorAlumno) == true && Listas.BuscarIDMateria(idMateriaMatPorAlumno) == true)
                    {
                        Listas.AgregarMateriasPorAlumno(new MateriasPorAlumno(idAsocMatPorAlumno, idAlumnoMatPorAlumno, idMateriaMatPorAlumno, calificacionMatPorAlumno));
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Materia por alumno agregada.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("\tID de alumno o de materia inexistentes.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write("\n\tPrecione cualquier tecla para continuar.");
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
            opcion = MenuInteractivo.MenuInteractivoFlechas("BUSCAR", "» Alumno","» Materia","» Materias por alumno","» Volver");

            switch (opcion)
            {
                case 1: // ALUMNO

                    //Menu interactivo
                    opcion = MenuInteractivo.MenuInteractivoFlechas("BUSCAR > ALUMNO", "» Por ID","» Por Nombre","» Todos los alumnos","» Volver");
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                        Console.WriteLine("\n\t═════ BUSCAR > ALUMNO > POR ID ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tID: ");
                            iDAlumno = Console.ReadLine();

                            if(Listas.BuscarIDAlumno(iDAlumno) == true)
                            {
                                System.Console.WriteLine("\n{0}",Listas.DatosDeAlumnoPorID(iDAlumno));
                            }

                            Console.Write("\n\tPrecione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break; 

                        case 2:
                            Console.WriteLine("\n\t═════ BUSCAR > ALUMNO > POR NOMBRE ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tNombre: ");
                            alumno = Console.ReadLine();

                            Listas.ImprimirAlumnosPorNombre(alumno);

                            Console.Write("\n\tPrecione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;
                        
                        case 3:
                            Console.WriteLine("\n\t═════ BUSCAR > ALUMNO > TODOS ════════════════════════════════════════════════════════════════\n");
                            Console.Clear();
                            Listas.ImprimirAlumnos();
                            Console.Write("\n\tPrecione cualquier tecla para continuar.");
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
                    opcion = MenuInteractivo.MenuInteractivoFlechas("BUSCAR > MATERIA", "» Por ID","» Por Nombre","» Todas las materias","» Volver");
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1: 
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA > POR ID ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tID: ");
                            iDMateria = Console.ReadLine();

                            if(Listas.BuscarIDMateria(iDMateria) == true)
                            {
                                System.Console.WriteLine("\n{0}",Listas.DatosDeMateriaPorID(iDMateria));
                            }

                            Console.Write("\n\tPrecione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break; 

                        case 2: 
                        Console.WriteLine("\n\t═════ BUSCAR > MATERIA > POR NOMBRE ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tNombre: ");
                            materia = Console.ReadLine();

                            Listas.ImprimirMateriasPorNombre(materia);

                            Console.Write("\n\tPrecione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;
                        
                        case 3: 
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA > TODOS ════════════════════════════════════════════════════════════════\n");
                            Listas.ImprimirMaterias();
                            Console.Write("\n\tPrecione cualquier tecla para continuar.");
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
                    opcion = MenuInteractivo.MenuInteractivoFlechas("BUSCAR > MATERIA POR ALUMNO", "» Por ID asociado","» Por ID del alumno","» Todas las materias por alumno","» Promedio por ID alumno","» Volver");
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA POR ALUMNO > POR ID ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tID: ");
                            iDAsoc = Console.ReadLine();

                            if(Listas.BuscarIDMateriaPorAlumno(iDAsoc) == true)
                            {
                                System.Console.WriteLine("\n{0}",Listas.DatosMateriasPorAlumno(iDAsoc));
                            }

                            Console.Write("\n\tPrecione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break; 

                        case 2:
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA POR ALUMNO > POR ID DEL ALUMNO ════════════════════════════════════════════════════════════════\n");
                            Console.Write("\tID del alumno: ");
                            iDAlumno = Console.ReadLine();

                            Listas.ImprimirMateriasPorAlumnoPorIDAlumno(iDAlumno);

                            Console.Write("\n\tPrecione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;
                        
                        case 3:
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA > TODOS ════════════════════════════════════════════════════════════════\n");
                            Listas.ImprimirMateriasPorAlumno();
                            Console.Write("\n\tPrecione cualquier tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                            menuBusqueda();
                            break;

                        case 4:
                            Console.WriteLine("\n\t═════ BUSCAR > MATERIA POR ALUMNO > PROMEDIO POR ID DEL ALUMNO ════════════════════════════════════════════════\n");
                            Console.Write("\tID del alumno: ");
                            iDAlumno = Console.ReadLine();

                            System.Console.WriteLine("\tPromedio: {0}",Listas.Promedio(iDAlumno));

                            Console.Write("\n\tPrecione cualquier tecla para continuar.");
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

    }
}
