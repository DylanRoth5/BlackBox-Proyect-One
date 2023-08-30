namespace BlackBox_Proyect_One
{
    public class Draw
    {

        public static void point(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Tls.Out("" + symbol); 
        }

        public static void line(int x, int y, int lenght, bool horizontal, char symbol)
        {
            Console.SetCursorPosition(x,y);
            if (horizontal) { 
                for (int i = 0; i < lenght; i++)
                {
                    Tls.Out("" + symbol); 
                }
            }
            if (!horizontal) {
                for (int i = 0; i < lenght; i++)
                {
                    Tls.Out("" + symbol);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                }
            }
        }

        public static void rect(int x, int y, int width, int height, char horizontal, char vertical, string corners)
        {
            line(x, y, width, true, horizontal);
            line(x, y+height, width, true, horizontal);
            line(x, y, height, false, vertical);
            line(x+width, y, height, false, vertical);
            point(x, y, corners[0]);
            point(x+width, y, corners[1]);
            point(x, y+height, corners[2]);
            point(x+width, y + height, corners[3]);
        }

        public static void up(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue)
            {
                Tls.Out(""+start);
                steps--;
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 1);
            }
            if (end.HasValue) { steps--; }
            for (int i = 0; i < steps; i++)
            {
                Tls.Out("" + type);
                Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop-1);
            }
            if (end.HasValue) { Tls.Out(""+end); }
        }

        public static void down(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue)
            {
                Tls.Out("" + start);
                steps--;
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
            }
            if (end.HasValue) { steps--; }
            for (int i = 0; i < steps; i++)
            {
                Tls.Out("" + type);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
            }
            if (end.HasValue) { Tls.Out("" + end); }
        }
        
        public static void right(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue) { Tls.Out("" + start); steps--; }
            if (end.HasValue) { steps--; }
            for (int i = 0; i < steps; i++) { Tls.Out("" + type); }
            if (end.HasValue) { Tls.Out("" + end); }
        }
        public static void left(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue) { Console.CursorLeft -= 2; Tls.Out("" + start); steps--; }
            if (end.HasValue) { steps--; }
            for (int i = 0; i < steps; i++) { Console.CursorLeft -= 2; Tls.Out("" + type); }
            if (end.HasValue) { Tls.Out("" + end); }
        }
    }
}