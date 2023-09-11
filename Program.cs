namespace BlackBox_Proyect_One
{
    internal class Program
    {
        //This is the main menu
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            // Statements
            string title = "Proyect One";
            string[] options = { "Ahorcado", "Tablas" };
            bool running = true;
            // Menu Program
            while (running){
                //The menu function is called by passing it the title and an array of options
                int result = Cs.Menu(title, options);
                Cs.Clear();
                switch (result){
                    case 1: 
                        // HangMan game
                        Hangman.Start();
                        break;
                    case 2: 
                        //Table of Contents
                        nTable.Start();
                        break;
                    case 0:
                        //Option to exit the menu
                        running = false; 
                        break;
                    default: 
                        //In case an error occurs, the default is executed
                        Cs.PrintLine("Algun error sucedio."); 
                        break;
                }
                Cs.EnterClear(); // this is so the menu doesn't start right away
            }
        }
    }
}