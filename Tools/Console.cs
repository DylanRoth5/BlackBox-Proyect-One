namespace BlackBox_Proyect_One
{
    public class Cs
    {
        public static void printLine(string? word="")
        {
            Console.WriteLine("" + word);
        }
        public static void print(string? word = "")
        {
            Console.Write("" + word);
        }
        public static void printAt(int x,int y, string? word)
        {
            int nx = Console.CursorLeft;
            int ny = Console.CursorTop;
            Console.SetCursorPosition(x, y);
            print(word);
            Console.SetCursorPosition(nx, ny);
        }
        public static string read()
        {
            return Console.ReadLine();
        }
        public static string read(string? word = "")
        {
            if (word.Length > 0) { printLine(word); }
            return Console.ReadLine();
        }
        public static void clear(){
            Console.Clear();
        }
        public static void enterClear()
        {
            printLine("Press enter.");
            read();
            Console.Clear();
        }
        public static void colorFlip(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }
        public static void position(int x, int y){
            Console.SetCursorPosition(x,y);
        }
        public static ConsoleColor[] colors = { //this is the color pattern for the menu 
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
        public static int menu(string title, string[] options)
        {
            // settings for the menu
            options = options.Append("Exit").ToArray(); 
            ConsoleColor background = ConsoleColor.Black;
            ConsoleColor foreground = ConsoleColor.White;
            Console.CursorVisible = false;
            bool running = true;
            int menuWidth = 0;
            int result = 1;
            int color=0;
            int apearence=0;
            string word = "(a) Appearence";
            colorFlip(background, foreground);
            // we have to assign the menu a width of at least the width of the lasgest word in the options
            for (int i = 0; i < options.Length; i++){ if (options[i].Length >= menuWidth) { menuWidth = options[i].Length; } }
            if (menuWidth%2 != 0) { menuWidth++; } // The width of the menu must be a pair number for it to be centered correctly
            menuWidth += 20; // this is some x axis padding
            while (running){
                foreground = colors[color]; // this will change the color of the menu with each iteration 
                int X = 0; // reseting position x
                int Y = 0; // reseting position y
                // choosing apearence
                if (apearence==0){
                    Gr.rect(X, Y, menuWidth, 2,                  '═', '║', "╔╗╠╣");
                    Gr.rect(X, Y+2, menuWidth, options.Length+1, '═', '║', "╠╣╠╣");
                    Gr.rect(X, Y+3+options.Length, menuWidth, 2, '═', '║', "╠╣╚╝");
                }else if (apearence==1){
                    Gr.rect(X, Y, menuWidth, 2,                  '─', '│', "┌┐├┤");
                    Gr.rect(X, Y+2, menuWidth, options.Length+1, '─', '│', "├┤├┤");
                    Gr.rect(X, Y+3+options.Length, menuWidth, 2, '─', '│', "├┤└┘");
                }else if (apearence==2){
                    Gr.rect(X, Y, menuWidth, 2,                  '█', '█', "████");
                    Gr.rect(X, Y+2, menuWidth, options.Length+1, '█', '█', "████");
                    Gr.rect(X, Y+3+options.Length, menuWidth, 2, '█', '█', "████");
                }
                printAt(X=(menuWidth/2)-(word.Length/2), Y+4+options.Length, word); // printing menu's help
                X=(menuWidth/2)-(title.Length/2); 
                Y++;
                Console.SetCursorPosition(X, Y);
                for (int i = 0; i < title.Length; i++){ print(""+title[i]); X++; Console.CursorLeft = X; } // printing title
                Y++;
                Console.SetCursorPosition(X, Y);
                // printing options
                for (int i = 0;i < options.Length; i++){
                    Y++; 
                    X = (menuWidth / 2) - (options[i].Length / 2); 
                    Console.SetCursorPosition(X, Y);
                    if (result == i+1) {  // if option is selected it must be noticeable
                        colorFlip(foreground, background); 
                        for (int j = 0; j < options[i].Length; j++){
                            print("" + options[i][j]); 
                            X++; 
                            Console.CursorLeft = X;
                        }
                        colorFlip(background, foreground);
                    } else{
                        for (int j = 0; j < options[i].Length; j++){
                            print("" + options[i][j]); 
                            X++; 
                            Console.CursorLeft = X;
                        }
                    }
                }
                Console.SetCursorPosition(0, 0);
                if (Console.KeyAvailable){ // if a kay has been presed do this ...
                    ConsoleKeyInfo k = Console.ReadKey(); // read it and check the following ...
                    if (k.Key == ConsoleKey.DownArrow) { result++; }
                    if (k.Key == ConsoleKey.UpArrow) { result--; }
                    if (k.Key == ConsoleKey.Enter) { running = false; }
                    if (k.Key == ConsoleKey.A) { apearence++; }
                }else{
                    Thread.Sleep(100); //this is the fps for che color change
                    color++;
                }
                // security check
                if (result < 1) { result = 1; }
                if (result > options.Length) { result = options.Length; }
                if (color >= colors.Length) { color=0; }
                if (apearence >= 3) { apearence = 0; }
            }
            if (result == options.Length) { result = 0; } // if you selected the last one throw a 0
            colorFlip(ConsoleColor.Black, ConsoleColor.White); // reset console colors
            return result; 
        }
    }
}