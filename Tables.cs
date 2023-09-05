namespace BlackBox_Proyect_One
{
    public class Tables
    {
        public static void Start(){


            int X=0;
            int Y=0;
            bool running=true;
            int columns = 1;
            int rows = 1;
            int width=8;
            int height=2;
            while (running){
                Draw.cell(X,Y,width,height,rows,columns);
                if (Console.KeyAvailable){
                    ConsoleKeyInfo k = Console.ReadKey();
                    if (k.Key == ConsoleKey.DownArrow) { rows++;Console.Clear(); }
                    if (k.Key == ConsoleKey.UpArrow) { rows--;Console.Clear(); }
                    if (k.Key == ConsoleKey.RightArrow) { columns++;Console.Clear(); }
                    if (k.Key == ConsoleKey.LeftArrow) { columns--;Console.Clear(); }
                    if (k.Key == ConsoleKey.Enter) { running = false; }
                }
                if (rows < 1) { rows = 1; }
                if (columns < 1) { columns = 1; }
            }
        }
    }
}