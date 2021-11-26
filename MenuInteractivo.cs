using System;

namespace EDD
{
    class MenuInteractivo
    {
        //sobrecarga del metodo para ahorrar codigo y hacerlo dinamico no importa cuantas opciones debamos implementar de 1 - 6.
        // Nombre del Menu (etiqueta), Opciones (op1-6).
        public static int MenuInteractivoFlechas(string etiqueta, string op1)
        {
            int y = 0;
            int options = 0;
            string[] menu = { op1 };

            y = FlechasConOpciones(menu, options, y, etiqueta);

            Console.Clear();
            return y+1;
        }
        public static int MenuInteractivoFlechas(string etiqueta, string op1,string op2)
        {
            int y = 0;
            int options = 1;
            string[] menu = { op1, op2 };

            y = FlechasConOpciones(menu, options, y, etiqueta);

            Console.Clear();
            return y+1;
        }
        public static int MenuInteractivoFlechas(string etiqueta, string op1, string op2,string op3)
        {
            int y = 0;
            int options = 2;
            string[] menu = { op1, op2, op3 };

            y = FlechasConOpciones(menu, options, y, etiqueta);

            Console.Clear();
            return y+1;
        }
        public static int MenuInteractivoFlechas(string etiqueta, string op1, string op2, string op3, string op4)
        {
            int y = 0;
            int options = 3;
            string[] menu = { op1, op2, op3, op4 };

            y = FlechasConOpciones(menu, options, y, etiqueta);

            Console.Clear();
            return y+1;
        }
        public static int MenuInteractivoFlechas(string etiqueta, string op1, string op2, string op3, string op4, string op5)
        {
            int y = 0;
            int options = 4;
            string[] menu = { op1, op2, op3, op4, op5 };

            y = FlechasConOpciones(menu, options, y, etiqueta);

            Console.Clear();
            return y+1;
        }
        public static int MenuInteractivoFlechas(string etiqueta, string op1, string op2, string op3, string op4, string op5,string op6)
        {
            int y = 0;
            int options = 5;
            string[] menu = { op1, op2, op3, op4, op5, op6 };

            y = FlechasConOpciones(menu, options, y, etiqueta);

            Console.Clear();
            return y+1;
        }

        //----------------------------------------------------------------------
        private static int FlechasConOpciones(string[] menu,int options, int y, string etiqueta)
        {
            ConsoleKey cKey;
            do
            {
                Console.WriteLine("\n\t═════ {0} ════════════════════════════════════════════════════════════════\n",etiqueta);
                for (int i = 0; i < options + 1; i++)
                {
                    if (menu[i] == menu[y])
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t"+menu[i] + "              ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.WriteLine("\t" + menu[i] + "              ");
                }

                //-------------------------------------------------------------
                cKey = Console.ReadKey(true).Key;

                if (cKey == ConsoleKey.UpArrow)
                {
                    y--;
                    if (y < 0) y = options;
                }
                else if (cKey == ConsoleKey.DownArrow)
                {
                    y++;
                    if (y > options) y = 0;
                }

                Console.Clear();
            } while (cKey != ConsoleKey.Enter);
            return y;
        }
    }

    
}