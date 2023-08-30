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

        public static ConsoleColor[] colors = { 
                                                ConsoleColor.Blue,	
                                                ConsoleColor.Blue,	
                                                ConsoleColor.Blue,	
                                                ConsoleColor.Blue,	
                                                ConsoleColor.Blue,	
                                                ConsoleColor.Blue,	
                                                ConsoleColor.Blue,	
                                                ConsoleColor.DarkCyan,
                                                ConsoleColor.DarkCyan,
                                                ConsoleColor.DarkCyan,
                                                ConsoleColor.DarkCyan,		
                                                ConsoleColor.Cyan,
                                                ConsoleColor.Cyan,
                                                ConsoleColor.Cyan,
                                                ConsoleColor.Cyan,		
                                                ConsoleColor.Cyan,	
                                                ConsoleColor.DarkCyan,	
                                                ConsoleColor.DarkCyan,		
                                                ConsoleColor.DarkCyan,
                                                ConsoleColor.DarkCyan,
                                                };

        public static int WriteMenu(string title, string[] options)
        {
            options = options.Append("Exit").ToArray(); 
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
            ConsoleColor background = ConsoleColor.Black;
            ConsoleColor foreground = ConsoleColor.White;
            string word = "(a) Appearence";
            int color=0;
            int apearence=0;
            while (running){
                foreground = colors[color];
                colorFlip(background, foreground);
                int X = 0;
                int Y = 0;
                if (apearence==0){
                    Draw.rect(X, Y, menuWidth, 2,                  '═', '║', "╔╗╠╣");
                    Draw.rect(X, Y+2, menuWidth, options.Length+1, '═', '║', "╠╣╠╣");
                    Draw.rect(X, Y+3+options.Length, menuWidth, 2, '═', '║', "╠╣╚╝");
                }else if (apearence==1){
                    Draw.rect(X, Y, menuWidth, 2,                  '─', '│', "┌┐├┤");
                    Draw.rect(X, Y+2, menuWidth, options.Length+1, '─', '│', "├┤├┤");
                    Draw.rect(X, Y+3+options.Length, menuWidth, 2, '─', '│', "├┤└┘");
                }else if (apearence==2){
                    Draw.rect(X, Y, menuWidth, 2,                  '█', '█', "████");
                    Draw.rect(X, Y+2, menuWidth, options.Length+1, '█', '█', "████");
                    Draw.rect(X, Y+3+options.Length, menuWidth, 2, '█', '█', "████");
                }

                ParalelOut(X=(menuWidth/2)-(word.Length/2), Y+4+options.Length, word);

                X=(menuWidth/2)-(title.Length/2); 
                Y++;
                Console.SetCursorPosition(X, Y);
                for (int i = 0; i < title.Length; i++){Out(""+title[i]);X++; Console.CursorLeft = X;}
                Y++;
                Console.SetCursorPosition(X, Y);
                for (int i = 0;i < options.Length; i++){
                    Y++; 
                    X = (menuWidth / 2) - (options[i].Length / 2); 
                    Console.SetCursorPosition(X, Y);
                    if (result == i+1) { 
                        colorFlip(foreground, background); 
                        for (int j = 0; j < options[i].Length; j++){
                            Out("" + options[i][j]); X++; Console.CursorLeft = X;
                        }
                        colorFlip(background, foreground);
                    } else{
                        for (int j = 0; j < options[i].Length; j++){
                            Out("" + options[i][j]); X++; Console.CursorLeft = X;
                        }
                    }
                }
                
                Console.SetCursorPosition(0, 0);
                if (Console.KeyAvailable){
                    ConsoleKeyInfo k = Console.ReadKey();
                    if (k.Key == ConsoleKey.DownArrow) { result++; }
                    if (k.Key == ConsoleKey.UpArrow) { result--; }
                    if (k.Key == ConsoleKey.Enter) { running = false; }
                    if (k.Key == ConsoleKey.A) { apearence++; }
                }else{
                    Thread.Sleep(100);
                    color++;
                }
                if (result < 1) { result = 1; }
                if (result > options.Length) { result = options.Length; }
                if (color >= colors.Length) { color=0; }
                if (apearence >= 3) { apearence = 0; }
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