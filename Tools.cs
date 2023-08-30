namespace BlackBox_Proyect_One
{
    public class Tls
    {

        public static void OutLine(string? word="")
        {
            Console.WriteLine("" + word);
        }
        public static void Out(string? word = "")
        {
            Console.Write("" + word);
        }

        public static string readLine(string? word = "")
        {
            if (word.Length > 0) { OutLine(word); }
            return Console.ReadLine();
        }

        public static void clear() { Console.Clear(); }

        public static void enterClear()
        {
            readLine();
            clear();
        }

        public static void colorFlip(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }

        public static int WriteMenu(string title, string[] options)
        {
            options = options.Append("Exit.").ToArray(); 
            Console.CursorVisible = false;
            bool running = true;
            int menuWidth = 0;
            int result = 1;
            for (int i = 0; i < options.Length; i++){ 
                if (options[i].Length >= menuWidth){
                    menuWidth = options[i].Length;
                }
            }
            if (menuWidth%2 != 0) { menuWidth++; }
            menuWidth += 20;
            while (running){
                ConsoleColor background = ConsoleColor.Black;
                ConsoleColor foreground = ConsoleColor.Red;
                colorFlip(background, foreground);
                int X = 0;
                int Y = 0;
                Console.SetCursorPosition(X, Y);

                Out("╔"); Y++; Console.SetCursorPosition(X, Y);
                Out("║"); Y++; Console.SetCursorPosition(X, Y);
                Out("╠"); Y++; Console.SetCursorPosition(X, Y);
                for (int i = 0; i < options.Length; i++) { Out("║"); Y++; Console.SetCursorPosition(X, Y); }
                Out("╚"); Y++; Console.SetCursorPosition(X, Y);
                Y = 0; X++; Console.SetCursorPosition(X, Y);
                for (int i = 0; i < menuWidth; i++){Out("═"); X++; Console.CursorLeft = X;}
                Y++; Console.CursorTop = Y;
                X=(X/2)-(title.Length/2); Console.CursorLeft = X;
                
                for (int i = 0; i < title.Length; i++){Out(""+title[i]);X++; Console.CursorLeft = X;}
                Y++; X = 1; Console.SetCursorPosition(X, Y);
                for (int i = 0; i < menuWidth; i++){Out("═"); X++; Console.CursorLeft = X;}
                Y++; Console.CursorTop = Y;
                
                for (int i = 0;i < options.Length; i++){
                    X = menuWidth;
                    X = (X / 2) - (options[i].Length / 2); Console.CursorLeft = X;
                    if (result == i+1) { colorFlip(foreground, background); }
                    for (int j = 0; j < options[i].Length; j++){
                        Out("" + options[i][j]); X++; Console.CursorLeft = X;
                    }
                    colorFlip(background, foreground);
                    Y++; Console.CursorTop = Y;
                }
                Console.CursorTop = Y; X = 1; Console.CursorLeft = X;
                for (int i = 0; i < menuWidth; i++){Out("═"); X++; Console.CursorLeft = X;}
                X = menuWidth+2;
                Y = 0; Console.CursorTop = Y; X--;
                Out("╗"); Y++; Console.SetCursorPosition(X, Y);
                Out("║"); Y++; Console.SetCursorPosition(X, Y);
                Out("╣"); Y++; Console.SetCursorPosition(X, Y);
                for (int i = 0; i < options.Length; i++) { Out("║"); Y++; Console.SetCursorPosition(X, Y); }
                Out("╝"); Y++; Console.SetCursorPosition(X, Y);

                ConsoleKeyInfo k = Console.ReadKey();
                if (k.Key == ConsoleKey.DownArrow) { result++; }
                if (k.Key == ConsoleKey.UpArrow) { result--; }
                if (k.Key == ConsoleKey.Enter) { running = false; }

                if (result < 1) { result = 1; }
                if (result > options.Length) { result = options.Length; }
            }
            if (result == options.Length) { result = 0; }
            colorFlip(ConsoleColor.Black, ConsoleColor.White);
            return result;
        }

        public static void ParalelOut(int x,int y, string? word)
        {
            int nx = Console.CursorLeft;
            int ny = Console.CursorTop;
            Console.SetCursorPosition(x, y);
            Out(word);
            Console.SetCursorPosition(nx, ny);
        }

    }
}