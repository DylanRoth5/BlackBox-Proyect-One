namespace BlackBox_Proyect_One
{
    internal class Hung
    {
        public static void Start()
        {
            GuessingWord();
        }
        public static void Guy(int x, int y, bool rightFeet, bool leftFeet, bool torso, bool righHand, bool leftHand, bool head, int wrong)
        {
            //int wrong=0;
            // bool running=true;
            // while (running)
            // {
                Tls.colorFlip(ConsoleColor.Black,ConsoleColor.DarkRed);
                Console.SetCursorPosition(x, y);
                Draw.down(7,'█',null,null);
                Draw.right(5,'█',null,null);
                Console.SetCursorPosition(x, y);
                Draw.right(8,'█',null,null);
                Draw.down(2,'│','█',null);
                
            Console.SetCursorPosition(x, y);

                if (wrong==1){rightFeet=true;}
                if (wrong==2){leftFeet=true;}
                if (wrong==3){torso=true;}
                if (wrong==4){righHand=true;}
                if (wrong==5){leftHand=true;}
                if (wrong==6){head=true;}//running=false;}

                Tls.colorFlip(ConsoleColor.Black,ConsoleColor.Red);
                
                if (rightFeet){Draw.point(x+9,y+4,'\\');}
                if (leftFeet){Draw.point(x+7,y+4,'/');}
                if (torso){Draw.point(x+8,y+3,'|');}
                if (righHand){Draw.point(x+9,y+3,'\\');}
                if (leftHand){Draw.point(x+7,y+3,'/');}
                if (head){Draw.point(x+8,y+2,'0'); Tls.ParalelOut(x+12,y+5,"You Lost");}
        //}
            
        } // end Guy method

        public static void GuessingWord()
        {

            // lista de palabras
            List<string> listaDePalabras = new List<string>
            {
                "banana",
                "elemento",
                "murcielago",
                "hospital",
                "computadora"
            };

            int x1=20, y1=5;
            //le asignamos a la palabra secreta la palabra random que obtuvo el metodo ChooseWord
            string secretWord = ChooseWord(listaDePalabras);
            string hiddenWord = new string('_', secretWord.Length);
            Tls.ParalelOut(x1,y1,hiddenWord);

            //variables para saber si estamos jugando y "cuantas vidas tenemos" 
            bool gameGoing = true;
            int wrongAttempts = 0;
            bool rightFeet= false, leftFeet= false, torso= false, righHand= false, leftHand= false, head = false;
            while(gameGoing)
            {
                int x=0,y=0;
                Guy(x,y,rightFeet, leftFeet, torso, righHand, leftHand, head, wrongAttempts);

                Console.Clear();
                Console.SetCursorPosition(20, 10);
                Console.WriteLine("guess the word: " + hiddenWord);
                Console.WriteLine($"Wrong Attemps: {wrongAttempts}");

                // Leer la letra ingresada por el jugador
                Console.Write("Write a Letter: ");
                char letra = Console.ReadKey().KeyChar;

                if (secretWord.Contains(letra))
                {
                    // si la letra esta en la palabra se inserta
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (secretWord[i] == letra)
                        {
                            hiddenWord = hiddenWord.Remove(i, 1).Insert(i, letra.ToString());
                        }
                    }

                    // verificar si adivinó la palabra
                    if (hiddenWord == secretWord)
                    {
                        gameGoing = false;
                        Console.Clear();
                        Console.WriteLine("¡YOU WON!");
                        Console.WriteLine("Word: " + secretWord);
                    }

                    else
                    {
                        wrongAttempts++;
                        if(wrongAttempts == 6)
                        {
                            //Console.WriteLine("¡YOU LOST!");
                            Console.WriteLine("The Word Is: " + secretWord);
                            gameGoing = false;
                        }
                    }
                }
            }

        }// end GuessingWord method

        static string ChooseWord(List<string> listaDePalabras)
        {
            Random random = new Random();
            int indiceAleatorio = random.Next(0, listaDePalabras.Count);
            return listaDePalabras[indiceAleatorio];
        }

    }//end hung
//fukfjgv
}//end workspace