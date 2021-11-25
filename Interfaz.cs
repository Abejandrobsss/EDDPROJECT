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

            Console.WriteLine("\n\t═════ Menu Principal ════════════════════════════════════════════════════════════════");
            Console.Write("\n\t» 1 Ingresar datos\n\t» 2 Busqueda\n\t» 3 Eliminacion(no implementado)\n\t» 4 Ordenamiento(no implementado)\n\t» 5 Almacenamiento(no implementado)\n\t» 6 Salir\n\n\t  > ");
            opcion = Convert.ToInt16(Console.ReadLine());

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


            Console.WriteLine("\n\t═════ INSERTAR ════════════════════════════════════════════════════════════════");
            Console.Write("\n\t» 1 Alumnos\n\t» 2 Materias\n\t» 3 Materias por alumno\n\t» 4 Volver\n\n\t  > ");
            opcion = Convert.ToInt16(Console.ReadLine());
            Console.Clear();
            

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("\n\t═════ INSERTAR > ALUMNOS ════════════════════════════════════════════════════════════════");
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
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("\tAlumno creado satisfactoriamente.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("\tID de alumno ya existente.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    
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
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("\tMateria creada satisfactoriamente.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("\tID de Materia ya existente.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
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
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Materia por alumno agregada.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("iD de alumno o de materia inexistentes.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

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

            Console.WriteLine("\n\t═════ BUSCAR ════════════════════════════════════════════════════════════════");
            Console.Write("\n\t» 1 Alumno\n\t» 2 Materia\n\t» 3 Materias por alumno\n\t» 4 Volver\n\n\t  > ");
            opcion = Convert.ToInt16(Console.ReadLine());
            Console.Clear();

            switch (opcion)
            {
                case 1: // ALUMNO
                    Console.WriteLine("\n\t═════ BUSCAR > ALUMNO ════════════════════════════════════════════════════════════════");
                    Console.Write("\n\t» 1 Por ID\n\t» 2 Por nombre\n\t» 3 Todos\n\t» 4 Volver\n\n\t  > ");
                    opcion = Convert.ToInt16(Console.ReadLine());
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
                    Console.WriteLine("\n\t═════ BUSCAR > MATERIA ════════════════════════════════════════════════════════════════");
                    Console.Write("\n\t» 1 Por ID\n\t» 2 Por nombre\n\t» 3 Todos\n\t» 4 Volver\n\n\t  > ");
                    opcion = Convert.ToInt16(Console.ReadLine());
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
                    Console.WriteLine("\n\t═════ BUSCAR > MATERIA POR ALUMNO ════════════════════════════════════════════════════════════════");
                    Console.Write("\n\t» 1 Por ID\n\t» 2 Por ID del Alumno\n\t» 3 Todos\n\t» 4 Promedio por ID\n\t» 5 Volver\n\n\t  > ");
                    opcion = Convert.ToInt16(Console.ReadLine());
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
