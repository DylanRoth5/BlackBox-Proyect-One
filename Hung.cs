namespace BlackBox_Proyect_One
{
    internal class Hung{
        public static void Start(){
            bool rightFeet= false, leftFeet= false, torso= false, righHand= false, leftHand= false, head = false;
            int x=0,y=0;
            Guy(x,y,rightFeet, leftFeet, torso, righHand, leftHand, head);
        }
        public static void Guy(int x, int y, bool rightFeet, bool leftFeet, bool torso, bool righHand, bool leftHand, bool head){
            int wrong=0;
            bool running=true;
            while (running){
                Tls.colorFlip(ConsoleColor.Black,ConsoleColor.DarkRed);
                Console.SetCursorPosition(x, y);
                Draw.down(7,'█',null,null);
                Draw.right(5,'█',null,null);
                Console.SetCursorPosition(x, y);
                Draw.right(8,'█',null,null);
                Draw.down(2,'│','█',null);
                
                Console.SetCursorPosition(x, y);
                if (Console.KeyAvailable){
                        ConsoleKeyInfo k = Console.ReadKey();
                        if (k.Key == ConsoleKey.Enter) { wrong++; }
                }
                if (wrong==1){rightFeet=true;}
                if (wrong==2){leftFeet=true;}
                if (wrong==3){torso=true;}
                if (wrong==4){righHand=true;}
                if (wrong==5){leftHand=true;}
                if (wrong==6){head=true;running=false;}

                Tls.colorFlip(ConsoleColor.Black,ConsoleColor.Red);
                
                if (rightFeet){Draw.point(x+9,y+4,'\\');}
                if (leftFeet){Draw.point(x+7,y+4,'/');}
                if (torso){Draw.point(x+8,y+3,'|');}
                if (righHand){Draw.point(x+9,y+3,'\\');}
                if (leftHand){Draw.point(x+7,y+3,'/');}
                if (head){Draw.point(x+8,y+2,'0'); Tls.ParalelOut(x+12,y+5,"You Lost");}
            }
        }
    }
}