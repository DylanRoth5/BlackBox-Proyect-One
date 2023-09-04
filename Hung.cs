namespace BlackBox_Proyect_One
{
    internal class Hung
    {
        public static void Start()
        {
            // lista de palabras
            List<string> listaDePalabras = new List<string>
            {
                "banana",
                "elemento",
                "murcielago",
                "hospital",
                "computadora",
                "emoji",
                "pastor",
                "dios",
                "mochila",
                "auto",
                "gorila",
                "argentina",
                "atmosfera",
            };

            //le asignamos a la palabra secreta la palabra random que obtuvo el metodo ChooseWord
            string secretWord = ChooseWord(listaDePalabras);
            string hiddenWord = new string('_', secretWord.Length);

            //variables para saber si estamos jugando y "cuantas vidas tenemos" 
            bool gameGoing = true;
            int wrongAttempts = 0;

            while(gameGoing)
            {
                 int x=0,y=0;

                //dibujo de la horca
                Tls.colorFlip(ConsoleColor.Black,ConsoleColor.DarkRed);
                Console.SetCursorPosition(x, y);
                Draw.down(7,'█',null,null);
                Draw.right(5,'█',null,null);
                Console.SetCursorPosition(x, y);
                Draw.right(8,'█',null,null);
                Draw.down(2,'│','█',null);

                //palabra oculta que vamos a adivinar y los intentos que nos quedan
                Tls.ParalelOut(x+15,y+8,$"Guess the Word: {hiddenWord}");
                Tls.ParalelOut(x+15,y+10,$"Attempts Left: {6 - wrongAttempts}");

                // leer la letra ingresada por el jugador
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
                    }  
                }

                else
                {
                    //incrementa los wrongAttempts hasta 6 (la cantidad de figuras que entran en el ahorcado)
                    wrongAttempts++;
                    bool rightFeet = false, leftFeet = false, torso = false, righHand = false, leftHand = false, head= false;

                    Console.SetCursorPosition(x, y);

                    //cada vez que haces un intento erroneo dibuja una parte del cuerpo
                    if (wrongAttempts==1){rightFeet=true;}
                    if (wrongAttempts==2){leftFeet=true;}
                    if (wrongAttempts==3){torso=true;}
                    if (wrongAttempts==4){righHand=true;}
                    if (wrongAttempts==5){leftHand=true;}
                    if (wrongAttempts==6){head=true;}

                    Tls.colorFlip(ConsoleColor.Black,ConsoleColor.Red);
                    
                    //dibujo del hombre
                    if (rightFeet == true){Draw.point(x+9,y+4,'\\');}
                    if (leftFeet){Draw.point(x+7,y+4,'/');}
                    if (torso){Draw.point(x+8,y+3,'|');}
                    if (righHand){Draw.point(x+9,y+3,'\\');}
                    if (leftHand){Draw.point(x+7,y+3,'/');}
                    if (head)
                    {
                        Draw.point(x+8,y+2,'0');
                        gameGoing = false;
                        Console.Clear();
                        Tls.ParalelOut(y+12,x+5,"You Lost");
                        Tls.ParalelOut(y+12,x+7,"Word: " + secretWord);
                    }
                }
            }
        }// end GuessingWord 

        //metodo para elegir alguna palabra de la lista
        static string ChooseWord(List<string> listaDePalabras)
        {
            Random random = new Random();
            int indiceAleatorio = random.Next(0, listaDePalabras.Count);
            return listaDePalabras[indiceAleatorio];
        }
    }//end hung   
}//end workspace