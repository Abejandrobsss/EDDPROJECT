using System;
using System.Collections;

namespace EDD
{
    class MenuInteractivoOrdenamiento
    {
        public static void MenuInteractivoOrd(string op1,string op2)
        {
            int x = 0;
            int options = 1;
            string[] menu = { op1, op2 ,"»Salir"};

            FlechasConOpcionesH(menu, options, x);

            Console.Clear();
        }

        public static void MenuInteractivoOrd(string op1, string op2,string op3, string op4)
        {
            int x = 0;
            int options = 3;
            string[] menu = { op1, op2, op3, op4 ,"»Salir"};

            FlechasConOpcionesH(menu, options, x);

            Console.Clear();
        }

        public static void MenuInteractivoOrd(string op1, string op2,string op3, string op4, string op5, string op6)
        {
            int x = 0;
            int options = 5;
            string[] menu = { op1, op2, op3, op4, op5, op6,"»Salir"};

            FlechasConOpcionesH(menu, options, x);

            Console.Clear();
        }

        //----------------------------------------------------------------------
        private static void FlechasConOpcionesH(string[] menu,int options, int x)
        {
            ConsoleKey cKey;
            int lista = options;
            options+=1;
            int counter=0;
            int counter2=2;
            do
            {
                Console.WriteLine();
                System.Console.Write("\t"); 
                for (int i = 0; i < options + 1; i++)
                {
                    
                    if(menu[i] == menu[counter])
                    {
                        if(counter2 == 0)
                        {
                            Console.ForegroundColor = menu[i] == menu[x]?ConsoleColor.Yellow: ConsoleColor.White;
                            Console.Write("{0,-20}", menu[i]+"↑");
                            Console.ForegroundColor = ConsoleColor.White;
                        }else if(counter2 == 1)
                        {
                            Console.ForegroundColor = menu[i] == menu[x]?ConsoleColor.Yellow: ConsoleColor.White;
                            Console.Write("{0,-20}", menu[i]+"↓");
                            Console.ForegroundColor = ConsoleColor.White;
                        }else
                        {   
                            Console.ForegroundColor = menu[i] == menu[x]?ConsoleColor.Yellow: ConsoleColor.White;
                            Console.Write("{0,-20}", menu[i]+"-");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        
                    }
                    else if (menu[i] == menu[x])
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0,-20}", menu[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.Write("{0,-20}", menu[i]);
                }

                //-------------------------------------------------------------
                for (int i = 0; i < options+1; i++)
                {
                    if(menu[i] == menu[counter])
                    {
                        switch (lista)
                        {
                            case 1:
                                if(counter2 == 0)
                                {   
                                    System.Console.WriteLine();
                                    ListasDeDatos.Ordenamiento(ListasDeDatos.GetArrMaterias(Interfaz.Listas.GetListaMaterias),i,true);
                                }else if(counter2 == 1)
                                {
                                    System.Console.WriteLine();
                                    ListasDeDatos.Ordenamiento(ListasDeDatos.GetArrMaterias(Interfaz.Listas.GetListaMaterias),i,false);
                                }else
                                {
                                    System.Console.WriteLine();
                                    Interfaz.Listas.ImprimirMaterias();   
                                }       
                                break;

                            case 3:
                                if(counter2 == 0)
                                {   
                                    System.Console.WriteLine();
                                    ListasDeDatos.Ordenamiento(ListasDeDatos.GetArrMPA(Interfaz.Listas.GetListaMateriasPorAlumno),i,true);
                                }else if(counter2 == 1)
                                {
                                    System.Console.WriteLine();
                                    ListasDeDatos.Ordenamiento(ListasDeDatos.GetArrMPA(Interfaz.Listas.GetListaMateriasPorAlumno),i,false);
                                }else
                                {
                                    System.Console.WriteLine();
                                    Interfaz.Listas.ImprimirMateriasPorAlumno();   
                                }       
                                break;
                            case 5:
                                if(counter2 == 0)
                                {   
                                    System.Console.WriteLine();
                                    ListasDeDatos.Ordenamiento(ListasDeDatos.GetArrAlumnos(Interfaz.Listas.GetListaAlumnos),i,true);
                                }else if(counter2 == 1)
                                {
                                    System.Console.WriteLine();
                                    ListasDeDatos.Ordenamiento(ListasDeDatos.GetArrAlumnos(Interfaz.Listas.GetListaAlumnos),i,false);
                                }else
                                {
                                    System.Console.WriteLine();
                                    Interfaz.Listas.ImprimirAlumnos();   
                                }       
                                break;  
                        }
                    }
                }
                cKey = Console.ReadKey(true).Key;

                if (cKey == ConsoleKey.LeftArrow)
                {
                    x--;
                    if (x < 0) x = options;
                }
                else if (cKey == ConsoleKey.RightArrow)
                {
                    x++;
                    if (x > options) x = 0;
                }else if(cKey == ConsoleKey.Enter)
                {
                    if(counter == x)
                    {
                        counter2 = counter2 == 2? counter2=0:++counter2;
                    }
                    else
                    {
                        counter2 = 2;
                        counter = x;
                    } 
                }
                Console.Clear();
            } while (counter != lista+1);
        }
    }

    
}