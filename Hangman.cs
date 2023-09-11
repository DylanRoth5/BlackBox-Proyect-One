namespace BlackBox_Proyect_One
{
    internal class Hangman
    {
        public static void Start()
        {
            // List of words
            List<string> listaDePalabras = new(){
                "banana", "elemento", "murcielago", "hospital", "computadora", "emoji",
                "pastor", "dios", "mochila", "auto", "gorila", "argentina", "atmosfera"
            };
            // Select one word at random
            string secretWord = ChooseWord(listaDePalabras);
            string hiddenWord = new('_', secretWord.Length);
            // Variables to control play and failed attempts
            bool gameGoing = true;
            int wrongAttempts = 0;
            while (gameGoing){
                // Gallows drawing
                Gallow(0, 0);
                // Show the hiddden word and the remaining guesses
                Cs.printAt(15, 8, $"Guess the Word: {hiddenWord}");
                //The hidden word that we are going to guess and the attempts we have left are passed through the console
                Cs.printAt(15, 10, $"Attempts Left: {6 - wrongAttempts}");
                // The letter entered by the player is read
                char letter = Console.ReadKey().KeyChar;
                if (secretWord.Contains(letter)){
                    // If the letter entered is found in the word, it is printed
                    for (int i = 0; i < secretWord.Length; i++){
                        if (secretWord[i] == letter){
                            hiddenWord = hiddenWord.Remove(i, 1).Insert(i, letter.ToString());
                        }
                    }
                    // Check if the word was guessed
                    if (hiddenWord == secretWord){
                        gameGoing = false;
                        Cs.clear();
                        Cs.printLine("¡YOU WON!");
                    }
                }
                else {
                    // Increased failed attempts to six, which is the number of limbs the Hangman has
                    wrongAttempts++;
                    bool rightFeet = false, leftFeet = false, torso = false, rightHand = false, leftHand = false, head = false;
                    Cs.position(0, 0);
                    //A body part is drawn every time a mistake is made
                    if (wrongAttempts == 1) { rightFeet = true; }
                    if (wrongAttempts == 2) { leftFeet = true; }
                    if (wrongAttempts == 3) { torso = true; }
                    if (wrongAttempts == 4) { rightHand = true; }
                    if (wrongAttempts == 5) { leftHand = true; }
                    if (wrongAttempts == 6) { head = true; }
                    Cs.colorFlip(ConsoleColor.Black, ConsoleColor.Red);
                    // Parts of the body to draw
                    if (rightFeet) { Gr.point(9, 4, '\\'); }
                    if (leftFeet) { Gr.point(7, 4, '/'); }
                    if (torso) { Gr.point(8, 3, '|'); }
                    if (rightHand) { Gr.point(9, 3, '\\'); }
                    if (leftHand) { Gr.point(7, 3, '/'); }
                    if (head){
                        Gr.point(8, 2, '0');
                        gameGoing = false;
                        Cs.clear();
                        Cs.printAt(12, 5, "You Lost");
                        Cs.printAt(12, 7, "Word: " + secretWord);
                    }
                }
            }
        }
        // The fuction receives a list of words as a parameter and randomly chooses the index of one of them
        static string ChooseWord(List<string> wordsList){
            Random random = new();
            int randomIndex = random.Next(0, wordsList.Count);
            return wordsList[randomIndex];
        }
        // The function receives parameters in x and y to position the pointer and draw the gallow
        static void Gallow(int x, int y){
            Cs.colorFlip(ConsoleColor.Black, ConsoleColor.DarkRed);
            Cs.position(x, y);
            Gr.down(7, '█', null, null);
            Gr.right(5, '█', null, null);
            //Resets the position of x and y to the first position
            Cs.position(x, y);
            Gr.right(8, '█', null, null);
            Gr.down(2, '│', '█', null);
        }
    }
}