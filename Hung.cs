namespace BlackBox_Proyect_One
{
    internal class Hung
    {
        public static void Start()
        {
            // List of words
            List<string> wordsList = new List<string>
            {
                "BANANA",
                "ELEMENTO",
                "MURCIELAGO",
                "HOSPITAL",
                "COMPUTADORA",
                "EMOJI",
                "PASTOR",
                "DIOS",
                "MOCHILA",
                "AUTO",
                "GORILA",
                "ARGENTINA",
                "ATMOSFERA",
                "GEOMETRIA",
                "ANALISIS",
                "JIRAFA",
            };

            // Select one word at random
            string secretWord = ChooseWord(wordsList);
            string hiddenWord = new('_', secretWord.Length);


            // Variables to control play and failed attempts
            bool gameGoing = true;
            int wrongAttempts = 0;

            while (gameGoing)
            {
                // Gallows drawing
                Gallow(0, 0);

                // Show the hiddden word and the remaining guesses
                Py.printAt(15, 8, $"Guess the Word: {hiddenWord}");
                Py.printAt(15, 10, $"Attempts Left: {6 - wrongAttempts}");

                //The hidden word that we are going to guess and the attempts we have left are passed through the console
                Py.printAt(15,8,$"Guess the Word: {hiddenWord}");
                Py.printAt(15,10,$"Attempts Left: {6 - wrongAttempts}");

                // The letter entered by the player is read
                char letter = Py.validateLetter();

                if (secretWord.Contains(letter))
                {
                    // If the letter entered is found in the word, it is printed
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (secretWord[i] == letter)
                        {
                            hiddenWord = hiddenWord.Remove(i, 1).Insert(i, letter.ToString());
                        }
                    }

                    // Check if the word was guessed
                    if (hiddenWord == secretWord)
                    {
                        gameGoing = false;
                        Console.Clear();
                        Console.WriteLine("¡YOU WON!");
                    }
                }
                else
                {
                    // Increased failed attempts to six, which is the number of limbs the Hangman has
                    wrongAttempts++;
                    bool rightFeet = false, leftFeet = false, torso = false, rightHand = false, leftHand = false, head = false;

                    Console.SetCursorPosition(0, 0);

                    //A body part is drawn every time a mistake is made
                    if (wrongAttempts == 1) { rightFeet = true; }
                    if (wrongAttempts == 2) { leftFeet = true; }
                    if (wrongAttempts == 3) { torso = true; }
                    if (wrongAttempts == 4) { rightHand = true; }
                    if (wrongAttempts == 5) { leftHand = true; }
                    if (wrongAttempts == 6) { head = true; }

                    Py.colorFlip(ConsoleColor.Black, ConsoleColor.Red);

                    // Parts of the body to draw
                    if (rightFeet) { Draw.point(9, 4, '\\'); }
                    if (leftFeet) { Draw.point(7, 4, '/'); }
                    if (torso) { Draw.point(8, 3, '|'); }
                    if (rightHand) { Draw.point(9, 3, '\\'); }
                    if (leftHand) { Draw.point(7, 3, '/'); }
                    if (head)
                    {
                        Draw.point(8, 2, '0');
                        gameGoing = false;
                        Console.Clear();
                        Py.printAt(12, 5, "You Lost");
                        Py.printAt(12, 7, "Word: " + secretWord);
                    }
                }
            }
        }

        // The fuction receives a list of words as a parameter and randomly chooses the index of one of them
        static string ChooseWord(List<string> wordsList)
        {
            Random random = new();
            int randomIndex = random.Next(0, wordsList.Count);
            return wordsList[randomIndex];
        }

        // The function receives parameters in x and y to position the pointer and draw the gallow
        static void Gallow(int x, int y)
        {
            Py.colorFlip(ConsoleColor.Black, ConsoleColor.DarkRed);

            Console.SetCursorPosition(x, y);
            Draw.down(7, '█', null, null);
            Draw.right(5, '█', null, null);

            //Resets the position of x and y to the first position
            Console.SetCursorPosition(x, y);
            Draw.right(8, '█', null, null);
            Draw.down(2, '│', '█', null);
        }
    }
}