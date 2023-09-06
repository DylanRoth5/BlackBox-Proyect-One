namespace BlackBox_Proyect_One
{
    internal class Hung
    {
        public static void Start()
        {
            // Lista de palabras para adivinar
            List<string> listaDePalabras = new()
            {
                "banana", "elemento", "murcielago", "hospital", "computadora",
                "emoji", "pastor", "dios", "mochila", "auto", "gorila",
                "argentina", "atmosfera"
            };

            // Seleccionamos una palabra secreta al azar
            string secretWord = ChooseWord(listaDePalabras);
            string hiddenWord = new('_', secretWord.Length);

            // Variables para controlar el juego y los intentos fallidos
            bool gameGoing = true;
            int wrongAttempts = 0;

            while (gameGoing)
            {
                // Dibujo de la horca
                Gallow(0, 0);

                // Mostramos la palabra oculta y los intentos restantes
                Py.printAt(15, 8, $"Guess the Word: {hiddenWord}");
                Py.printAt(15, 10, $"Attempts Left: {6 - wrongAttempts}");

                // Leer la letra ingresada por el jugador
                char letra = Console.ReadKey().KeyChar;

                if (secretWord.Contains(letra))
                {
                    // Si la letra está en la palabra, la insertamos en la palabra oculta
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (secretWord[i] == letra)
                        {
                            hiddenWord = hiddenWord.Remove(i, 1).Insert(i, letra.ToString());
                        }
                    }

                    // Verificar si adivinó la palabra
                    if (hiddenWord == secretWord)
                    {
                        gameGoing = false;
                        Console.Clear();
                        Console.WriteLine("¡YOU WON!");
                    }
                }
                else
                {
                    // Incrementamos los intentos fallidos hasta 6 (la cantidad de figuras que entran en el ahorcado)
                    wrongAttempts++;
                    bool rightFeet = false, leftFeet = false, torso = false, rightHand = false, leftHand = false, head = false;

                    Console.SetCursorPosition(0, 0);

                    // Dibujamos una parte del cuerpo cada vez que se comete un error
                    if (wrongAttempts == 1) { rightFeet = true; }
                    if (wrongAttempts == 2) { leftFeet = true; }
                    if (wrongAttempts == 3) { torso = true; }
                    if (wrongAttempts == 4) { rightHand = true; }
                    if (wrongAttempts == 5) { leftHand = true; }
                    if (wrongAttempts == 6) { head = true; }

                    Py.colorFlip(ConsoleColor.Black, ConsoleColor.Red);

                    // Dibujamos el cuerpo del ahorcado
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

        // Método para elegir una palabra al azar de la lista
        static string ChooseWord(List<string> listaDePalabras)
        {
            Random random = new();
            int indiceAleatorio = random.Next(0, listaDePalabras.Count);
            return listaDePalabras[indiceAleatorio];
        }

        // Función para dibujar la horca
        static void Gallow(int x, int y)
        {
            Py.colorFlip(ConsoleColor.Black, ConsoleColor.DarkRed);

            Console.SetCursorPosition(x, y);
            Draw.down(7, '█', null, null);
            Draw.right(5, '█', null, null);

            //Ponemos otra vez SetCursorPosition para reiniciar la x e y a 0
            Console.SetCursorPosition(x, y);
            Draw.right(8, '█', null, null);
            Draw.down(2, '│', '█', null);
        }
    }
}