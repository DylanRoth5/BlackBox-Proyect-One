namespace BlackBox_Proyect_One
{
    internal class Hangman
    {
        public static void Start()
        {
            // Lista de palabras para adivinar
            List<string> listaDePalabras = new(){
                "banana", "elemento", "murcielago", "hospital", "computadora", "emoji",
                "pastor", "dios", "mochila", "auto", "gorila", "argentina", "atmosfera"
            };
            // Seleccionamos una palabra secreta al azar
            string secretWord = ChooseWord(listaDePalabras);
            string hiddenWord = new('_', secretWord.Length);
            // Variables para controlar el juego y los intentos fallidos
            bool gameGoing = true;
            int wrongAttempts = 0;
            while (gameGoing){
                // Dibujo de la horca
                Gallow(0, 0);
                // Mostramos la palabra oculta y los intentos restantes
                Cs.printAt(15, 8, $"Guess the Word: {hiddenWord}");
                Cs.printAt(15, 10, $"Attempts Left: {6 - wrongAttempts}");
                // Leer la letra ingresada por el jugador
                char letra = Console.ReadKey().KeyChar;
                if (secretWord.Contains(letra)){
                    // Si la letra está en la palabra, la insertamos en la palabra oculta
                    for (int i = 0; i < secretWord.Length; i++){
                        if (secretWord[i] == letra){
                            hiddenWord = hiddenWord.Remove(i, 1).Insert(i, letra.ToString());
                        }
                    }
                    // Verificar si adivinó la palabra
                    if (hiddenWord == secretWord){
                        gameGoing = false;
                        Cs.clear();
                        Cs.printLine("¡YOU WON!");
                    }
                }
                else {
                    // Incrementamos los intentos fallidos hasta 6 (la cantidad de figuras que entran en el ahorcado)
                    wrongAttempts++;
                    bool rightFeet = false, leftFeet = false, torso = false, rightHand = false, leftHand = false, head = false;
                    Cs.position(0, 0);
                    // Dibujamos una parte del cuerpo cada vez que se comete un error
                    if (wrongAttempts == 1) { rightFeet = true; }
                    if (wrongAttempts == 2) { leftFeet = true; }
                    if (wrongAttempts == 3) { torso = true; }
                    if (wrongAttempts == 4) { rightHand = true; }
                    if (wrongAttempts == 5) { leftHand = true; }
                    if (wrongAttempts == 6) { head = true; }
                    Cs.colorFlip(ConsoleColor.Black, ConsoleColor.Red);
                    // Dibujamos el cuerpo del ahorcado
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
        // Método para elegir una palabra al azar de la lista
        static string ChooseWord(List<string> listaDePalabras){
            Random random = new();
            int indiceAleatorio = random.Next(0, listaDePalabras.Count);
            return listaDePalabras[indiceAleatorio];
        }
        // Función para dibujar la horca
        static void Gallow(int x, int y){
            Cs.colorFlip(ConsoleColor.Black, ConsoleColor.DarkRed);
            Cs.position(x, y);
            Gr.down(7, '█', null, null);
            Gr.right(5, '█', null, null);
            // Ponemos otra vez SetCursorPosition para reiniciar la x e y a 0
            Cs.position(x, y);
            Gr.right(8, '█', null, null);
            Gr.down(2, '│', '█', null);
        }
    }
}