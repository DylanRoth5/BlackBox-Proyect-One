namespace BlackBox_Proyect_One
{
    public class Py
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

        public static string read(string? word = "")
        {
            if (word.Length > 0) { printLine(word); }
            return Console.ReadLine();
        }

        public static void enterClear()
        {
            read();
            Console.Clear();
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

        public static int menu(string title, string[] options)
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
            int animating=0;
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

                printAt(X=(menuWidth/2)-(word.Length/2), Y+4+options.Length, word);

                X=(menuWidth/2)-(title.Length/2); 
                Y++;
                Console.SetCursorPosition(X, Y);
                for (int i = 0; i < title.Length; i++){print(""+title[i]);X++; Console.CursorLeft = X;}
                Y++;
                Console.SetCursorPosition(X, Y);
                for (int i = 0;i < options.Length; i++){
                    Y++; 
                    X = (menuWidth / 2) - (options[i].Length / 2); 
                    Console.SetCursorPosition(X, Y);
                    if (result == i+1) { 
                        colorFlip(foreground, background); 
                        for (int j = 0; j < options[i].Length; j++){
                            print("" + options[i][j]); X++; Console.CursorLeft = X;
                        }
                        colorFlip(background, foreground);
                    } else{
                        for (int j = 0; j < options[i].Length; j++){
                            print("" + options[i][j]); X++; Console.CursorLeft = X;
                        }
                    }
                }

                if (result==1){
                    if (animating >= 60 && animating < 70){colorFlip(ConsoleColor.Black,ConsoleColor.DarkRed);}
                    if (animating >= 0 && animating < 10){
                        printAt(X+menuWidth-12,Y-5,"                                       ");
                        printAt(X+menuWidth-12,Y-4,"                                       ");
                        printAt(X+menuWidth-12,Y-3,"                                       ");
                        printAt(X+menuWidth-12,Y-2,"                                       ");
                        printAt(X+menuWidth-12,Y-1,"                                       ");
                        printAt(X+menuWidth-12,Y,"                                       ");
                        printAt(X+menuWidth-12,Y+1,"                                       ");
                        printAt(X+menuWidth-12,Y+2,"                                       ");
                        printAt(X+menuWidth-12,Y+3,"                                       ");
                    }
                    if (animating >= 0){
                        Console.SetCursorPosition(X+menuWidth, Y-5);
                        Draw.down(7,'█',null,null);
                        Draw.right(5,'█',null,null);
                        Console.SetCursorPosition(X+menuWidth, Y-5);
                        Draw.right(8,'█',null,null);
                        Draw.down(2,'│','█',null);
                     }
                    if (animating >= 10 && animating < 20){Draw.point(X+menuWidth+9,Y-5+4,'\\');}
                    if (animating >= 20 && animating < 30){
                        Draw.point(X+menuWidth+9,Y-5+4,'\\');
                        Draw.point(X+menuWidth+7,Y-5+4,'/');}
                    if (animating >= 30 && animating < 40){
                        Draw.point(X+menuWidth+9,Y-5+4,'\\');
                        Draw.point(X+menuWidth+7,Y-5+4,'/');
                        Draw.point(X+menuWidth+8,Y-5+3,'|');}
                    if (animating >= 40 && animating < 50){
                        Draw.point(X+menuWidth+9,Y-5+4,'\\');
                        Draw.point(X+menuWidth+7,Y-5+4,'/');
                        Draw.point(X+menuWidth+8,Y-5+3,'|');
                        Draw.point(X+menuWidth+9,Y-5+3,'\\');}
                    if (animating >= 50 && animating < 60){
                        Draw.point(X+menuWidth+9,Y-5+4,'\\');
                        Draw.point(X+menuWidth+7,Y-5+4,'/');
                        Draw.point(X+menuWidth+8,Y-5+3,'|');
                        Draw.point(X+menuWidth+9,Y-5+3,'\\');
                        Draw.point(X+menuWidth+7,Y-5+3,'/');}
                    if (animating >= 60 && animating < 70){
                        Draw.point(X+menuWidth+9,Y-5+4,'\\');
                        Draw.point(X+menuWidth+7,Y-5+4,'/');
                        Draw.point(X+menuWidth+8,Y-5+3,'|');
                        Draw.point(X+menuWidth+9,Y-5+3,'\\');
                        Draw.point(X+menuWidth+7,Y-5+3,'/');
                        Draw.point(X+menuWidth+8,Y-5+2,'0');}
                    if (animating >= 70){animating=0;}
                    animating+=2;
                }
                if (result == 2){
                    if (animating >= 0 && animating < 10){
                        printAt(X+menuWidth-12,Y-5,"                                       ");
                        printAt(X+menuWidth-12,Y-4,"                                       ");
                        printAt(X+menuWidth-12,Y-3,"                                       ");
                        printAt(X+menuWidth-12,Y-2,"                                       ");
                        printAt(X+menuWidth-12,Y-1,"                                       ");
                        printAt(X+menuWidth-12,Y,"                                       ");
                        printAt(X+menuWidth-12,Y+1,"                                       ");
                        printAt(X+menuWidth-12,Y+2,"                                       ");
                        printAt(X+menuWidth-12,Y+3,"                                       ");
                    }
                    if (animating >= 10 && animating < 20){Draw.rect(X+menuWidth-8, Y-5, 8, 2,'─', '│', "┌┐└┘");}
                    if (animating >= 20 && animating < 30){
                        Draw.rect(X+menuWidth-8, Y-5, 8, 2,  '─', '│', "┌┬├┼");
                        Draw.rect(X+menuWidth, Y-5, 8, 2,    '─', '│', "┬┐┼┤");
                        Draw.rect(X+menuWidth-8, Y+2-5, 8, 2,'─', '│', "├┼└┴");
                        Draw.rect(X+menuWidth, Y+2-5, 8, 2,  '─', '│', "┼┤┴┘");
                        }
                    if (animating >= 30){
                        Draw.rect(X+menuWidth-8, Y-5, 8, 2,  '─', '│', "┌┬├┼");
                        Draw.rect(X+menuWidth, Y-5, 8, 2,    '─', '│', "┬┬┼┼");
                        Draw.rect(X+menuWidth+8, Y-5, 8, 2,  '─', '│', "┬┐┼┤");
                        Draw.rect(X+menuWidth-8, Y+2-5, 8, 2,'─', '│', "├┼├┼");
                        Draw.rect(X+menuWidth, Y+2-5, 8, 2,  '─', '│', "┼┼┼┼");
                        Draw.rect(X+menuWidth+8, Y+2-5, 8, 2,'─', '│', "┼┤┼┤");
                        Draw.rect(X+menuWidth-8, Y+4-5, 8, 2,'─', '│', "├┼└┴");
                        Draw.rect(X+menuWidth, Y+4-5, 8, 2,  '─', '│', "┼┤┴┴");
                        Draw.rect(X+menuWidth+8, Y+4-5, 8, 2,'─', '│', "┼┤┴┘");
                    }
                    if (animating >= 40){animating=0;}
                    animating+=2;
                }
                if (result != 1 && result != 2){
                    printAt(X+menuWidth-12,Y-5,"                                       ");
                    printAt(X+menuWidth-12,Y-4,"                                       ");
                    printAt(X+menuWidth-12,Y-3,"                                       ");
                    printAt(X+menuWidth-12,Y-2,"                                       ");
                    printAt(X+menuWidth-12,Y-1,"                                       ");
                    printAt(X+menuWidth-12,Y,"                                       ");
                    printAt(X+menuWidth-12,Y+1,"                                       ");
                    printAt(X+menuWidth-12,Y+2,"                                       ");
                    printAt(X+menuWidth-12,Y+3,"                                       ");
                }
                
                Console.SetCursorPosition(0, 0);
                if (Console.KeyAvailable){
                    ConsoleKeyInfo k = Console.ReadKey();
                    if (k.Key == ConsoleKey.DownArrow) { result++;animating=0; }
                    if (k.Key == ConsoleKey.UpArrow) { result--;animating=0; }
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

    }
}