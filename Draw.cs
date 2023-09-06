namespace BlackBox_Proyect_One
{
    public class Draw
    {

        public static void point(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Py.print("" + symbol); 
        }
        public static void line(int x, int y, int lenght, bool horizontal, char symbol)
        {
            Console.SetCursorPosition(x,y);
            if (horizontal) { 
                for (int i = 0; i < lenght; i++)
                {
                    Py.print("" + symbol); 
                }
            }
            if (!horizontal) {
                for (int i = 0; i < lenght; i++)
                {
                    Py.print("" + symbol);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                }
            }
        }
        public static void rect(int x, int y, int width, int height, char horizontal, char vertical, string corners)
        {
            line(x+1, y, width-1, true, horizontal);
            line(x+1, y+height, width-1, true, horizontal);
            line(x, y+1, height-1, false, vertical);
            line(x+width, y+1, height-1, false, vertical);
            point(x, y, corners[0]);
            point(x+width, y, corners[1]);
            point(x, y+height, corners[2]);
            point(x+width, y + height, corners[3]);
        }
        public static void cell(int x, int y,int width, int height, int rows,int columns){
            for (int i = 0;i<columns;i++){
                for (int j = 0;j<rows;j++){
                    rect(x+(i*width), y+(j*height), width, height,'█', '█', "████");
                }
            }
        }

        public static void up(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue)
            {
                Py.print(""+start);
                steps--;
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 1);
            }
            if (end.HasValue) { steps--; }
            for (int i = 0; i < steps; i++)
            {
                Py.print("" + type);
                Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop-1);
            }
            if (end.HasValue) { Py.print(""+end); }
        }
        public static void down(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue)
            {
                Py.print("" + start);
                steps--;
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
            }
            if (end.HasValue) { steps--; }
            for (int i = 0; i < steps; i++)
            {
                Py.print("" + type);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
            }
            if (end.HasValue) { Py.print("" + end); }
        }
        public static void right(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue) { Py.print("" + start); steps--; }
            if (end.HasValue) { steps--; }
            for (int i = 0; i < steps; i++) { Py.print("" + type); }
            if (end.HasValue) { Py.print("" + end); }
        }
        public static void left(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue) { Console.CursorLeft -= 2; Py.print("" + start); steps--; }
            if (end.HasValue) { steps--; }
            for (int i = 0; i < steps; i++) { Console.CursorLeft -= 2; Py.print("" + type); }
            if (end.HasValue) { Py.print("" + end); }
        }
    }
}