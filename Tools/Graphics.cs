namespace BlackBox_Proyect_One
{
    public class Gr
    {
        public static void point(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Cs.print("" + symbol); 
        }

        //This function draws a line, receives the x and y parameters for the position. Also the parameters of length, orientation and symbol to print
        public static void line(int x, int y, int lenght, bool horizontal, char symbol)
        {
            Console.SetCursorPosition(x,y);
            //If the orientation is horizontal, the "horizontal" parameter will be true and the line will be drawn
            if (horizontal) { 
                for (int i = 0; i < lenght; i++)
                {
                    Cs.print("" + symbol); 
                }
            }
            //If the orientation is vertical, said parameter would be false, therefore the following code would be executed
            if (!horizontal) {
                for (int i = 0; i < lenght; i++)
                {
                    Cs.print("" + symbol);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                }
            }
        }
        //This function draws a rectangle, for this it receives the position in x and y as a parameter. In addition, it also receives the height, width, and characters that will be printed on the horizontal, vertical, and corner sides
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
        //This method draws a grid of cells at a specific location in x and y
        public static void cell(int x, int y,int width, int height, int rows,int columns){
            for (int i = 0;i<columns;i++){
                for (int j = 0;j<rows;j++){
                    rect(x+(i*width), y+(j*height), width, height,'█', '█', "████");
                }
            }
        }

        //The following methods allow us to move on the console in four directions: up, down, right and left
        public static void up(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue)
            {
                Cs.print(""+start);
                steps--;
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 1);
            }
            if (end.HasValue) { steps--; }
            // Loop to print the specified character (type) and adjust the console position up
            for (int i = 0; i < steps; i++)
            {
                Cs.print("" + type);
                Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop-1);
            }
            if (end.HasValue) { Cs.print(""+end); }
        }
        public static void down(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue)
            {
                Cs.print("" + start);
                steps--;
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
            }
            if (end.HasValue) { steps--; }
             // Loop to print the specified character (type) and adjust the console position down
            for (int i = 0; i < steps; i++)
            {
                Cs.print("" + type);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
            }
            if (end.HasValue) { Cs.print("" + end); }
        }
        public static void right(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue) { Cs.print("" + start); steps--; }
            if (end.HasValue) { steps--; }
            for (int i = 0; i < steps; i++) { Cs.print("" + type); }
            if (end.HasValue) { Cs.print("" + end); }
        }
        public static void left(int steps, char? type, char? start, char? end)
        {
            if (start.HasValue) { Console.CursorLeft -= 2; Cs.print("" + start); steps--; }
            if (end.HasValue) { steps--; }
            for (int i = 0; i < steps; i++) { Console.CursorLeft -= 2; Cs.print("" + type); }
            if (end.HasValue) { Cs.print("" + end); }
        }
    }
}