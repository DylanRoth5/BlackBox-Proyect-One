using System.Linq.Expressions;

namespace BlackBox_Proyect_One
{
    public class Tables
    {
        public static void Start(){
            int X;
            int Y;
            int lines=1;
            int posX=0;
            int posY=1;
            int columns = Py.readInt("How many columns do you want? ");
            int rows = Py.readInt("How many rows do you want? ");
            if (columns==0){
                columns++;
            }
            string[,] matriz = new string[columns,rows+1];
            Random r = new Random();
            int columnLength=10;
            bool running=true;
            for (int i=0;i<rows;i++){
                for (int j=0;j<columns;j++){
                    if(j==0){
                        matriz[i,j]="title";
                    }else{
                        matriz[i,j] = ""+r.Next(1600);
                    }
                }
            }
            while (running){
                Py.clean();
                X=0;
                Y=2;
                for (int i=0;i<rows;i++){
                    for (int j=0;j<columns;j++){
                        if(posY==j && posX==i){
                            Py.colorFlip(ConsoleColor.White,ConsoleColor.Black);
                        }else{
                            Py.colorFlip(ConsoleColor.Black,ConsoleColor.White);
                        }
                        if(matriz[i,j].Length<8){
                            Draw.cell(X,Y+j,columnLength,lines,$"{matriz[i,j]}");
                        }else{
                            string entrada = matriz[i,j];
                            string salida="";
                            for(int l=0; l<8;l++){
                                 salida += entrada[l];
                            }
                            Draw.cell(X,Y+j,columnLength,lines,$"{salida}");
                        }
                        Y++;
                    }
                    X+=columnLength+1;
                    Y=2;
                }
                Draw.cell(0,0,((columnLength+1)*columns)-1,lines,$"Write: {matriz[posX,posY]}");
                Py.printAt(0,columns*2+3,"Press TAB to go back to main menu"); 

                ConsoleKeyInfo k = Console.ReadKey();
                if (k.Key == ConsoleKey.Tab) { running = false; }
                if (k.Key == ConsoleKey.Enter) { 
                    string space=" ";
                    for(int i =0;i<matriz[posX,posY].Length;i++){
                        space+=" ";
                    }
                    Py.printAt(7,1,space); 
                    matriz[posX,posY] = Py.readAt(7,1); }
                if (k.Key == ConsoleKey.DownArrow) { posY++; }
                if (k.Key == ConsoleKey.UpArrow) { posY--; }
                if (k.Key == ConsoleKey.RightArrow) { posX++; }
                if (k.Key == ConsoleKey.LeftArrow) { posX--; }

                if(posX<0){posX=0;}
                if(posY<=0){posY=1;}
                if(posX>=columns){posX=columns-1;}
                if(posY>=rows){posY=rows-1;}
            }
        }
    }
}