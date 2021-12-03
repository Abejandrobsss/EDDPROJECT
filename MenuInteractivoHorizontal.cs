using System;

namespace EDD
{
    class MenuInteractivoHorizontal
    {
        // Sobrecarga de metodos para ahorrar codigo y hacerlo dinamico no importa cuantas opciones debamos implementar de 1 - 3.
        // Opciones (op1-6).
        public static int MenuInteractivoFlechasH(string op1)
        {
            int y = 0;
            int options = 0;
            string[] menu = { op1 };

            y = FlechasConOpcionesH(menu, options, y);

            Console.Clear();
            return y+1;
        }
        public static int MenuInteractivoFlechasH(string op1,string op2)
        {
            int y = 0;
            int options = 1;
            string[] menu = { op1, op2 };

            y = FlechasConOpcionesH(menu, options, y);

            Console.Clear();
            return y+1;
        }
        public static int MenuInteractivoFlechasH(string op1, string op2,string op3)
        {
            int y = 0;
            int options = 2;
            string[] menu = { op1, op2, op3 };

            y = FlechasConOpcionesH(menu, options, y);

            Console.Clear();
            return y+1;
        }

        //----------------------------------------------------------------------
        private static int FlechasConOpcionesH(string[] menu,int options, int y)
        {
            ConsoleKey cKey;
            Console.WriteLine();
            do
            {
                for (int i = 0; i < options + 1; i++)
                {
                    if (menu[i] == menu[y])
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\t " + menu[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.Write("\t" + menu[i]);
                }

                //-------------------------------------------------------------
                cKey = Console.ReadKey(true).Key;

                if (cKey == ConsoleKey.LeftArrow)
                {
                    y--;
                    if (y < 0) y = options;
                }
                else if (cKey == ConsoleKey.RightArrow)
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